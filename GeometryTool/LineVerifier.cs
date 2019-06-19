using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;

namespace GeometryTool
{
    public class LineVerifier : EntityVerifier
    {
        private Line line;

        public Line Line
        {
            get
            {
                return this.line;
            }
        }
        public LineVerifier(Line l, Entity e2) : base(e2)
        {
            if (l == null)
            {
                throw new NullReferenceException("The polyline is null");
            }
            this.line = l;
        }

        private bool LineInCircle()
        {
            
            Circle c = E2 as Circle;
            if ( c != null)
            {
            }

            return false;

        }

        public static  Polyline ConvertToPolyline(Line l)
        {
            Polyline p = new Polyline();
            p.AddVertexAt(0, new Point2d(l.StartPoint.X, l.StartPoint.Y), 0, 0, 0);
            p.AddVertexAt(1, new Point2d(l.EndPoint.X, l.EndPoint.Y), 0, 0, 0);
            return p;
        }

        public static Line ConvertToLine(Line2d l2d)
        {
            Line l = new Line(new Point3d(l2d.StartPoint.X, l2d.StartPoint.Y, 0), new Point3d(l2d.EndPoint.X, l2d.EndPoint.Y, 0));
            return l;
        }



        private bool LineInLine()
        {
            return false;

        }
        public override bool HasInside()
        {
            return LineInCircle() || LineInLine();
        }
    }
}