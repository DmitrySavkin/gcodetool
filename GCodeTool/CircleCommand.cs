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

        public CircleCommand(Circle c)
        {
            this.Circle = c;
        }

        public Command Run()
        {
            Command c = new Command();
       
            Point2d center = new Point2d(Circle.Center.X, Circle.Center.Y);
            c.MoveCircle(center, Circle.Radius);
            return c;
        }

   
    }
}
