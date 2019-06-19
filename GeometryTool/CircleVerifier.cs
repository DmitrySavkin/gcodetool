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
        private Circle circle;

        public Circle Circle
        {
            get
            {
                return circle;
            }
        }
        public CircleVerifier(Circle c, Entity e2) : base( e2)
        {
            if (c == null)
            {
                throw new NullReferenceException("The circle is null");
            }
            this.circle = c;

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
            
            Circle c2 = (Circle)E2;
            return IsPointInCircle(PointOfCircle(circle), c2);
        }

        private bool CircleInPolyline()
        {
            Polyline p = (Polyline)E2; 
            return IsPointInPolyline(PointOfCircle(circle), p);
        }


        private Point3d PointOfCircle(Circle c)
        {
            return new Point3d(c.Center.X + c.Radius, c.Center.Y, 0);
        }


    }
}
