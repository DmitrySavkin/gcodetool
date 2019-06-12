﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace SortTool
{
    public class CircleSort : SortEntity
    {
        public CircleSort(Entity e1, Entity e2) : base(e1, e2)
        {
        }

        public override bool HasInside()
        {

            if (E2.GetType().Name == "Polyline")
            {
                return CircleInPolyline();
            }
            if (E2.GetType().Name == "Circle")
            {
                return CircleInCircle();
            }

            throw new TypeAccessException("The Geometrie is not defined");
        }

        private bool CircleInCircle()
        {
            Circle c1 = (Circle)E1;
            Circle c2 = (Circle)E2;
            return isPointInCircle(PointOfCircle(c1), c2);
        }

        private bool CircleInPolyline()
        {
            Circle c = (Circle)E1;
            Polyline p = (Polyline)E2; 
            return isPointInPolyline(PointOfCircle(c), p);
        }


        private Point3d PointOfCircle(Circle c)
        {
            return new Point3d(c.Center.X + c.Radius, c.Center.Y, 0);
        }


    }
}
