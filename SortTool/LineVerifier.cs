﻿using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace SortTool
{
    internal class LineVerifier : EntityVerifier
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

        private  Polyline ConvertToPolyline(Line l)
        {
            Polyline p = new Polyline();
            p.AddVertexAt(0, new Point2d(l.StartPoint.X, l.StartPoint.Y), 0, 0, 0);
            p.AddVertexAt(1, new Point2d(l.EndPoint.X, l.EndPoint.Y), 0, 0, 0);
            return p;
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