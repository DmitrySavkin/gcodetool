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
        private Polyline polylines;
        private bool direction;
        private bool isOuther;
        private double diameter;

        public Polyline getBias(Polyline polyline, bool isOuter, double diameter)
        {
            this.diameter = diameter;
            var polylineCpy = new Polyline();
            for (int i = 0; i < polyline.NumberOfVertices - 1; i++)
            {
                polylineCpy.AddVertexAt(i, polyline.GetPoint2dAt(i), 0, 0, 0);
            }
            this.polylines = polylineCpy;
            this.isOuther = isOuter;
            this.direction = TraversalPolylineClockWise();
            List<Point2d> AModifiedList = GetModifiedPoints();
            var res = GetIntersections(AModifiedList);
            var p = new Polyline();
            for (int i = 0; i <= res.Count; i++) { 
                p.AddVertexAt(i, res[(i + 1) % res.Count],0,0,0);
            }
            return p;
        }

        private bool TraversalPolylineClockWise()
        {
            int a = TheMostLeftPointIndex();
            int aNext = (a + 1) % polylines.NumberOfVertices;
            int aPrev = (a - 1 + polylines.NumberOfVertices) % polylines.NumberOfVertices;
            Vector2d v1 = new Vector2d();
            Vector2d v2 = new Vector2d();

            return v1.X * v2.Y - v1.Y * v2.X > 0;
        }

        private int TheMostLeftPointIndex()
        {
            int ind = 0;
            for (int i = 0; i < polylines.NumberOfVertices; i++)
            {
                if (polylines.GetPoint2dAt(ind).X < polylines.GetPoint2dAt(ind).X)
                {
                    ind = i;
                }
            }
            return ind;
        }

        private List<Point2d> GetModifiedPoints()
        {
            var res = new List<Point2d>();
            for (int i = 0; i < polylines.NumberOfVertices; i++)
            {
                Point2d curPoint = polylines.GetPoint2dAt(i);
                Point2d nextPoint = polylines.GetPoint2dAt(((i + 1) % polylines.NumberOfVertices));
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
                bool dirRes = v2.X * v1.Y - v2.Y * v2.X > 0;
                if (dirRes != this.direction)
                {
                    v2 = new Point2d(-v2.X, -v2.Y);
                }


                if (!isOuther)
                {
                    v2 = new Point2d(-v2.X, -v2.Y);
                }
                double k = diameter / Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y);
                v2 = new Point2d(v2.X * k, v2.Y * k);
                res.Add(new Point2d(curPoint.X + v2.X, curPoint.Y + v2.Y));
            }
            return res;
        }

        private List<Point2d> GetIntersections(List<Point2d> modifierList)
        {
            var res = new List<Point2d>();
            for (int i = 0; i < polylines.NumberOfVertices; i++)
            {

                Point2d A = polylines.GetPoint2dAt(i);
                Point2d B = polylines.GetPoint2dAt((i + 1) % polylines.NumberOfVertices);
                Point2d vAB = getVector(A, B);

                Point2d A1 = modifierList[i];
                Point2d B1 = new Point2d(A1.X + vAB.X, A1.Y + vAB.Y);

                Point2d C = polylines.GetPoint2dAt(((i + 1) % polylines.NumberOfVertices));
                Point2d D = polylines.GetPoint2dAt(((i + 2) % polylines.NumberOfVertices));
                Point2d vCD = getVector(C, D);
                Point2d C1 = modifierList[(i + 1) % polylines.NumberOfVertices];
                Point2d D1 = new Point2d(C1.X + vCD.X, C1.Y + vCD.Y);
                Point2d tmp;
                if (A1.X > B1.X)
                {
                    tmp = A1;
                    A1 = B1;
                    B1 = tmp;
                }
                if (C1.X > D1.X)
                {
                    tmp = C1;
                    C1 = D1;
                    D1 = tmp;
                }

                double k1 = 0;
                double k2 = 0;
                bool parallelToY1 = false;
                bool parallelToY2 = false;
                if (A1.Y != B1.Y)
                {
                    if (Math.Abs(B1.X - A1.X) < 0.00001)
                    {
                        parallelToY1 = true;
                    }
                    else
                    {
                        k1 = (B1.Y - A1.Y) / (B1.X - A1.X);
                    }
                }

                if (C1.Y != D1.Y)
                {
                    if (Math.Abs(D1.X - C1.X) < 0.00001)
                    {
                        parallelToY2 = true;
                    }
                    else
                    {
                        k2 = (D1.Y - C1.Y) / (D1.X - C1.X);
                    }
                }

                double b1 = A1.Y - k1 * A1.X;
                double b2 = C1.Y - k2 * C1.X;
                if (parallelToY1 || parallelToY2)
                {
                    if (parallelToY1 == parallelToY2)
                    {
                        continue;
                    }
                    if (parallelToY1)
                    {
                        res.Add(new Point2d(A1.X, k2 * A1.X + b2));
                    }
                    else
                    {
                        res.Add(new Point2d(C1.X, k1 * C1.X + b1));
                    }
                    continue;
                }
                if (Math.Abs(k1 - k2) < 0.00001)
                {
                    continue;
                }
                double x = (b2 - b1) / (k1 - k2);
                double y = k1 * x + b1;
                res.Add(new Point2d(x, y));
            }

            return res;
        }

        private Point2d getVector(Point2d c, Point2d d)
        {
            return new Point2d(d.X - c.X, d.Y - c.Y);
        }
    }
}
