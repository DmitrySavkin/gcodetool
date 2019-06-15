using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    public class CircleCommand : ITask
    {
        public Circle Circle { get; }

        public Point2d BasePoint
        {
            get;
        }


        public CircleCommand(Point2d basePoint, Circle c)
        {
            this.BasePoint = basePoint;
            this.Circle = c;
        }

        private Point2d getRealPoint(Point2d p)
        {
            return new Point2d(p.X - BasePoint.X, p.Y - BasePoint.Y);
        }

        public Command Run()
        {
            Command c = new Command();
       
            Point2d center = new Point2d(Circle.Center.X, Circle.Center.Y);
            c.MoveCircle(getRealPoint(center), Circle.Radius);
            return c;
        }

   
    }
}
