using Autodesk.AutoCAD.Geometry;
using System.Text;
using System;
using SortTool;
using Autodesk.AutoCAD.DatabaseServices;

namespace GCodeTool
{
    public abstract class Command 
    {

        
        private bool isOuter;
        internal Point2d basePoint;


        public Command(Point2d basePoint, EntityInfo e)
        {
           
            this.isOuter = e.IsOuter;
            this.basePoint = basePoint;
            //this.Polyline = p;
        //    this.Polyline = new Offset().getBias(p, EdgeTool.Edge.IsOuter(p));
        }

        protected Command(Point2d basePoint, bool isOuter)
        {
            this.basePoint = basePoint; 
            this.isOuter = isOuter;
        }

        public Point2d GetRealPoint(Point2d p)
        {
            if (p == null)
            {
                throw new NullReferenceException("The point is null");
            }
            return new Point2d(p.X - BasePoint.X, p.Y - BasePoint.Y);
        }

        public bool IsOuter
        {
            get
            {
                return isOuter;
            }
        }

        public Point2d BasePoint
        {
            get
            {
                return basePoint;
            }
        }
        public abstract GCodeBase Run();
    }

    public enum CommandOption
    {
         ClockWise = 0,
         AntiClockWise = 1
    }

}
