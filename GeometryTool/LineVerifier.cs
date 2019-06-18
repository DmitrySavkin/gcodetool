using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace GeometryTool
{
    public class LineVerifier : EntityVerifier
    {

        public LineVerifier(Entity e1, Entity e2) : base(e1, e2)
        {
        }

        private bool LineInCircle()
        {
            Line l = E1 as Line;
            Circle c = E2 as Circle;
            if (l !=null && c != null)
            {
                Polyline p = new Polyline();
                p.AddVertexAt(0, new Point2d(l.StartPoint.X, l.StartPoint.Y), 0, 0, 0);
                p.AddVertexAt(1, new Point2d(l.EndPoint.X, l.EndPoint.Y), 0, 0, 0);
                return new PolylineVerifier(p, c).HasInside();
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
            Line l1 = E1 as Line;
            Line l2 = E2 as Line;
            if (l1 != null && l2 != null)
            {
                Polyline p1 = ConvertToPolyline(l1);
                Polyline p2 = ConvertToPolyline(l2);
                return new PolylineVerifier(p1, p2).HasInside();
            }

            return false;

        }
        public override bool HasInside()
        {
            return LineInCircle() || LineInLine();
        }
    }
}