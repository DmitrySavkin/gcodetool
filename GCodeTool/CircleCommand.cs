﻿using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using SortTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    /// <summary>
    /// Provides methods to generate gcode of circle
    /// </summary>
    public class CircleCommand :  Command
    {
        /// <summary>
        /// Circle which in task now
        /// </summary>
        public Circle Circle { get; }

        /// <summary>
        /// Creates new object to generate gcode of polkyline relative of base point of coordinates system
        /// </summary>
        /// <param name="basePoint">Base point of coordinates system</param>
        /// <param name="e">Curve information </param>
        /// <param name="diam">Diameter of wimble</param>
        /// <param name="option">Metric or inch system</param>
        public CircleCommand(Point2d basePoint, CurveInfo e,double diam, CommandMetricOption option = CommandMetricOption.IncSystem) : base(basePoint,e, diam ) 
        {


            Circle c = e.Entity as Circle;
            if (c == null)
            {
                throw new NullReferenceException("The circle is null");
            }
            this.Circle = c;
            
        }


        private double ModifyRadius(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("The radius is less  than 0");
            }

            double d = DiameterOffset;
            if (!EdgeTool.Edge.IsOuter(Circle))
            {
                d = -d;
            }
            return radius + d;
        }
        
        public override GCode Run()
        {
            GCode2d c = new GCode2d(coordinateSystem);
            Point2d center = new Point2d(Circle.Center.X, Circle.Center.Y);
            c.MoveCircle(GetRealPoint(center), ModifyRadius(Circle.Radius));
            return c;
        }

    }
}
