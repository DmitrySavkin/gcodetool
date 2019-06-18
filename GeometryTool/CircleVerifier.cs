using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace GeometryTool
{
    public class CircleVerifier : EntityVerifier
    {
        public CircleVerifier(Entity e1, Entity e2) : base(e1, e2)
        {
        }

        public override bool HasInside()
        {

            var p = E2 as Polyline;
            if (p != null)
            {
                return CircleInPolyline();
            }
            var c = E2 as Circle;
            if (c != null)
            {
                return CircleInCircle();
            }

            throw new TypeAccessException("The Geometrie is not defined");
        }

        private bool CircleInCircle()
        {
            Circle c1 = (Circle)E1;
            Circle c2 = (Circle)E2;
            return IsPointInCircle(PointOfCircle(c1), c2);
        }

        private bool CircleInPolyline()
        {
            Circle c = (Circle)E1;
            Polyline p = (Polyline)E2; 
            return IsPointInPolyline(PointOfCircle(c), p);
        }


        private Point3d PointOfCircle(Circle c)
        {
            return new Point3d(c.Center.X + c.Radius, c.Center.Y, 0);
        }


    }
}
