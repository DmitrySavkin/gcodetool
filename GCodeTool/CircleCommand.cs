using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using SortTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    public class CircleCommand :  Command
    {
        public Circle Circle { get; }


        public CircleCommand(Point2d basePoint, CurveInfo e,double diam) : base(basePoint,e, diam ) 
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
        
        public override GCodeBase Run()
        {
            GCodeBase c = new GCodeBase();
            Point2d center = new Point2d(Circle.Center.X, Circle.Center.Y);
            c.MoveCircle(GetRealPoint(center), ModifyRadius(Circle.Radius));
            return c;
        }

   
    }
}
