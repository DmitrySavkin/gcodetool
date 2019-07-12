using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    public class Offset
    {
        private Polyline polyline;
        private bool direction;
        private bool isOuter;
        private double diameter;
        private int count;

        public Polyline getBias(Polyline polyline, bool isOuter, double diameter)
        {
            this.diameter = diameter;
            this.polyline = polyline;
            this.isOuter = isOuter;
            this.count = polyline.NumberOfVertices - 1;
            this.direction = TraversalPolylineClockWise();
            List<Point2d> AModifiedList = GetModifiedPoints();
            var res = GetIntersections(AModifiedList);
            return res;
        }

        private bool TraversalPolylineClockWise()
        {
            int a = TheMostLeftPointIndex();
            int aNext = (a + 1) % count;
            int aPrev = (a - 1 + count) % count;
            Vector2d v1 = new Vector2d();
            Vector2d v2 = new Vector2d();

            return v1.X * v2.Y - v1.Y * v2.X > 0;
        }

        private int TheMostLeftPointIndex()
        {
            int ind = 0;
            for (int i = 0; i < count; i++)
            {
                if (polyline.GetPoint2dAt(ind).X < polyline.GetPoint2dAt(ind).X)
                {
                    ind = i;
                }
            }
            return ind;
        }

        private List<Point2d> GetModifiedPoints()
        {
            var res = new List<Point2d>();
            for (int i = 0; i < count; i++)
            {
                Point2d curPoint = polyline.GetPoint2dAt(i);
                Point2d nextPoint = polyline.GetPoint2dAt(((i + 1) % count));
                Point2d v1 = getVector(curPoint, nextPoint);
                Point2d v2;
                if (Math.Abs(v1.Y) < 0.00001)
                {
                    v2 = new Point2d(0f, 1f);
                }
                else
                {
                    v2 = new Point2d(1.0f, -v1.X / v1.Y);
                }
                bool dirRes = v2.X * v1.Y - v2.Y * v1.X > 0;
                if (dirRes != this.direction)
                {
                    v2 = new Point2d(-v2.X, -v2.Y);
                }


                if (!isOuter)
                {
                    v2 = new Point2d(-v2.X, -v2.Y);
                }
                double k = diameter / Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y);
                v2 = new Point2d(v2.X * k, v2.Y * k);
                res.Add(new Point2d(curPoint.X + v2.X, curPoint.Y + v2.Y));
            }
            return res;
        }

        private Point2d? GetLinesIntersection(Point2d A, Point2d B, Point2d C, Point2d D)
        {
            Point2d tmp;
            if (A.X > B.X)
            {
                tmp = A;
                A = B;
                B = tmp;
            }
            if (C.X > D.X)
            {
                tmp = C;
                C = D;
                D = tmp;
            }

            double k1 = 0;
            double k2 = 0;
            bool parallelToY1 = false;
            bool parallelToY2 = false;
            if (A.Y != B.Y)
            {
                if (Math.Abs(B.X - A.X) < 0.00001)
                {
                    parallelToY1 = true;
                }
                else
                {
                    k1 = (B.Y - A.Y) / (B.X - A.X);
                }
            }

            if (C.Y != D.Y)
            {
                if (Math.Abs(D.X - C.X) < 0.00001)
                {
                    parallelToY2 = true;
                }
                else
                {
                    k2 = (D.Y - C.Y) / (D.X - C.X);
                }
            }

            double b1 = A.Y - k1 * A.X;
            double b2 = C.Y - k2 * C.X;
            if (parallelToY1 || parallelToY2)
            {
                if (parallelToY1 == parallelToY2)
                {
                    return null;
                }
                if (parallelToY1)
                {
                    return new Point2d(A.X, k2 * A.X + b2);
                }
                else
                {
                    return new Point2d(C.X, k1 * C.X + b1);
                }
            }
            if (Math.Abs(k1 - k2) < 0.00001)
            {
                return null;
            }
            double x = (b2 - b1) / (k1 - k2);
            double y = k1 * x + b1;
            return new Point2d(x, y);
        }

        class ArcInfo
        {
            public Point2d Center;
            public double Radius;
        }

        private Polyline GetIntersections(List<Point2d> modifierList)
        {
            var arcsPost = new Dictionary<int, ArcInfo>();
            var res = new Polyline();
            var ind = 0;
            for (int i = 0; i < count; i++)
            {
                Point2d A = polyline.GetPoint2dAt(i);
                Point2d B = polyline.GetPoint2dAt((i + 1) % count);
                Point2d vAB = getVector(A, B);

                Point2d A1 = modifierList[i];
                Point2d B1 = new Point2d(A1.X + vAB.X, A1.Y + vAB.Y);

                Point2d C = polyline.GetPoint2dAt(((i + 1) % count));
                Point2d D = polyline.GetPoint2dAt(((i + 2) % count));
                Point2d vCD = getVector(C, D);
                Point2d C1 = modifierList[(i + 1) % count];
                Point2d D1 = new Point2d(C1.X + vCD.X, C1.Y + vCD.Y);

                var s1Type = polyline.GetSegmentType(i);
                var s2Type = polyline.GetSegmentType((i + 1) % count);
                if (s1Type == SegmentType.Line && s2Type == SegmentType.Line)
                {
                    Point2d? p = GetLinesIntersection(A1, B1, C1, D1);
                    if (p.HasValue)
                    {
                        res.AddVertexAt(ind++, p.Value, 0, 0, 0);
                    }
                }
                else
                {
                    if (s1Type == SegmentType.Line && s2Type == SegmentType.Arc)
                    {
                        var seg = polyline.GetArcSegment2dAt((i + 1) % count);
                        var buldge = polyline.GetBulgeAt((i + 1) % count);
                        var r = GetCorrectRadius(seg.Radius, buldge);
                        var points = GetCircleLineIntersection(A1, B1, seg.Center, r);
                        Point2d? theBest = getCloserPoint(B, points);
                        if (theBest.HasValue)
                        {
                            arcsPost.Add(ind, new ArcInfo { Center = seg.Center, Radius = r });
                            res.AddVertexAt(ind++, theBest.Value, buldge, 0, 0);
                        }
                    }
                    else if (s1Type == SegmentType.Arc && s2Type == SegmentType.Line)
                    {
                        var seg = polyline.GetArcSegment2dAt(i);
                        var r = GetCorrectRadius(seg.Radius, polyline.GetBulgeAt(i));
                        var points = GetCircleLineIntersection(C1, D1, seg.Center, r);
                        Point2d? theBest = getCloserPoint(C, points);
                        if (theBest.HasValue)
                        {
                            res.AddVertexAt(ind++, theBest.Value, 0, 0, 0);
                        }
                    }
                    else if (s1Type == SegmentType.Arc && s2Type == SegmentType.Arc)
                    {
                        var seg1 = polyline.GetArcSegment2dAt(i);
                        var seg2 = polyline.GetArcSegment2dAt((i + 1) % count);
                        var r1 = GetCorrectRadius(seg1.Radius, polyline.GetBulgeAt(i));
                        var r2 = GetCorrectRadius(seg2.Radius, polyline.GetBulgeAt((i + 1) % count));
                        /*
                        var points = GetCircleCircleIntersection(seg1.Center, r1, seg2.Center, r2);

                        */
                    }
                }
            }
            foreach (var pair in arcsPost)
            {
                int segInd = pair.Key;
                var p1 = res.GetPoint2dAt(segInd);
                var p2 = res.GetPoint2dAt((segInd + 1) % count);
                var center = pair.Value.Center;
                var cp1 = getVector(center, p1);
                var cp2 = getVector(center, p2);
                var costeta = (cp1.X * cp2.X + cp1.Y * cp2.Y) /
                    (Math.Sqrt(cp1.X * cp1.X + cp1.Y * cp1.Y) * Math.Sqrt(cp2.X * cp2.X + cp2.Y * cp2.Y));
                var teta = Math.Acos(costeta);
                var bulge = Math.Abs(Math.Tan(teta / 4));
                var p1c = getVector(p1, center);
                var p1p2 = getVector(p1, p2);
                if (p1c.X * p1p2.Y - p1c.Y * p1p2.X > 0)
                {
                    bulge = -bulge;
                }
                res.SetBulgeAt(segInd, bulge);
            }
            res.AddVertexAt(res.NumberOfVertices, res.GetPoint2dAt(0), 0, 0, 0);
            return res;
        }

        private Point2d? getCloserPoint(Point2d p, List<Point2d> choiceList)
        {
            Point2d? res = null;
            double minDist = 0;
            foreach (var choice in choiceList)
            {
                if (res == null)
                {
                    res = choice;
                    minDist = (choice.X - p.X) * (choice.X - p.X) + (choice.Y - p.Y) * (choice.Y - p.Y);
                    continue;
                }
                var dist = (choice.X - p.X) * (choice.X - p.X) + (choice.Y - p.Y) * (choice.Y - p.Y);
                if (dist < minDist)
                {
                    res = choice;
                    minDist = dist;
                }
            }
            return res;
        }

        private double GetCorrectRadius(double r, double buldge)
        {
            var clock = !direction;
            var buldgePositive = buldge > 0;
            var offset = diameter;
            if (!(!isOuter ^ !clock ^ !buldgePositive))
            {
                offset = -offset;
            }
            return r + offset;
        }

        private List<Point2d> GetCircleLineIntersection(Point2d p0, Point2d p1, Point2d center, double radius)
        {
            var res = new List<Point2d>();
            var r = radius;
            var a = (p1.X - p0.X) * (p1.X - p0.X) + (p1.Y - p0.Y) * (p1.Y - p0.Y);
            var k = (p1.X - p0.X) * (p0.X - center.X) + (p1.Y - p0.Y) * (p0.Y - center.Y);
            var c = (p0.X - center.X) * (p0.X - center.X) + (p0.Y - center.Y) * (p0.Y - center.Y) - r * r;
            var d = k * k - a * c;
            // var EPS = 1.0e-4;
            if (d > 0)
            {
                d = Math.Sqrt(d);
                var t1 = (-k + d) / a;
                var t2 = (-k - d) / a;
                res.Add(new Point2d(t1 * (p1.X - p0.X) + p0.X, t1 * (p1.Y - p0.Y) + p0.Y));
                res.Add(new Point2d(t2 * (p1.X - p0.X) + p0.X, t2 * (p1.Y - p0.Y) + p0.Y));
                return res;
            }
            d = 0;
            double t = -k / a;
            res.Add(new Point2d(t * (p1.X - p0.X) + p0.X, t * (p1.Y - p0.Y) + p0.Y));
            return res;
        }

        private Point2d getVector(Point2d c, Point2d d)
        {
            return new Point2d(d.X - c.X, d.Y - c.Y);
        }
    }
}
