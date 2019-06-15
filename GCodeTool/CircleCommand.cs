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

            if (basePoint == null)
            {
                throw new NullReferenceException("The basePoint is null");
            }

            if (c == null)
            {
                throw new NullReferenceException("The circle is null");
            }
            this.BasePoint = basePoint;
            this.Circle = c;
        }

        private Point2d getRealPoint(Point2d p)
        {
            if (p == null)
            {
                throw new NullReferenceException("The point is null");
            }

            return new Point2d(p.X - BasePoint.X, p.Y - BasePoint.Y);
        }

        private double modifyRadius(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("The radius is less  than 0");
            }

            double d = CommandManager.diam;
            if (!VertexTool.Vertex.IsOuter(Circle))
            {
                d = -d;
            }
            return radius + d;
        }
        
        public Command Run()
        {
            Command c = new Command();
       
            Point2d center = new Point2d(Circle.Center.X, Circle.Center.Y);
            c.MoveCircle(getRealPoint(center), modifyRadius(Circle.Radius));
            return c;
        }

   
    }
}
