using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTool
{
    public abstract class EntityVerifier
    {
        public Entity E1 { get; }
        public Entity E2 { get; }

        public EntityVerifier(Entity e1, Entity e2)
        {
            if (e1 == null)
            {
                throw new NullReferenceException("The entity e1 is null");

            }

            if (e2 == null)
            {
                throw new NullReferenceException("The entity e2 is null");
            }

            this.E1 = e1;
            this.E2 = e2;
        }

        /// <summary>
        /// Checks if current goemetry contains any other one.
        /// </summary>
        /// <returns>Return true, if the geometry contains any other one.</returns>
        public abstract bool HasInside();

        protected bool isPointInCircle(Point3d p, Circle c)
        {
            return (p.X - c.Center.X) * (p.X - c.Center.X) + (p.Y - c.Center.Y) * (p.Y - c.Center.Y)
                <= (c.Radius * c.Radius);
        }

        protected bool isPointInPolyline(Point3d pt, Polyline Ligne)
        {
            if (Ligne == null)
            {
                throw new NullReferenceException("The Polyline is null");
            }
            if (pt == null)
            {
                throw new NullReferenceException("The Point3d is null");
            }

            if (Ligne.StartPoint != Ligne.EndPoint)
            {
                return false;
            }
            //if (Ligne == null/* || !Ligne.Closed*/)
            //{
            //return false;
            //}
            int vn = Ligne.NumberOfVertices;
            Point3d[] colpt = new Point3d[vn + 1];
            for (int i = 0; i < vn; i++)
            {
                colpt[i] = Ligne.GetPoint3dAt(i);
                Curve3d seg = null;
                SegmentType segType = Ligne.GetSegmentType(i);
                if (segType == SegmentType.Arc)
                {
                    seg = Ligne.GetArcSegmentAt(i);
                }
                else if (segType == SegmentType.Line)
                {
                    seg = Ligne.GetLineSegmentAt(i);
                }
                if (seg != null)
                {
                    if (seg.IsOn(pt))
                    {
                        return true;
                    }
                }
            }
            colpt[vn] = Ligne.GetPoint3dAt(0);
            return wn_PnPoly(pt, colpt, vn) != 0;
        }

        private double isLeft(Point3d P0, Point3d P1, Point3d P2)
        {
            return ((P1.X - P0.X) * (P2.Y - P0.Y) - (P2.X - P0.X) * (P1.Y - P0.Y));
        }

        private double wn_PnPoly(Point3d P, Point3d[] V, double n)
        {
            double wn = 0;
            for (int i = 0; i < n; i++)
            {
                if (V[i].Y <= P.Y)
                {
                    if (V[i + 1].Y > P.Y)
                    {
                        if (isLeft(V[i], V[i + 1], P) > 0)
                        {
                            wn = wn + 1;
                        }
                    }
                }
                else
                {
                    if (V[i + 1].Y <= P.Y)
                    {
                        if (isLeft(V[i], V[i + 1], P) < 0)
                        {
                            wn = wn - 1;
                        }
                    }
                }
            }
            return wn;
        }

    }
}
