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
        private double diamOffset;
        internal CommandMetricOption coordinateSystem;

        public Command(Point2d basePoint, CurveInfo e, double diamOffset, CommandMetricOption coordinate = CommandMetricOption.MetricSystem)
        {

            this.isOuter = e.IsOuter;
            this.basePoint = basePoint;
            //this.Polyline = p;
            this.diamOffset = diamOffset;
            this.coordinateSystem = coordinate;
            //    this.Polyline = new Offset().getBias(p, EdgeTool.Edge.IsOuter(p));
        }

        protected Command(Point2d basePoint, bool isOuter, double diamOffset)
        {
            this.basePoint = basePoint;
            this.isOuter = isOuter;
            this.diamOffset = diamOffset;

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
        public abstract GCode Run();


        public double DiameterOffset
        {
            get
            {
                return diamOffset;
            }
        }
    }
    public enum CommandDirectionOption
    {
        ClockWise = 0,
        CounterClockWise = 1

    }

    public enum CommandMetricOption
    {
        MetricSystem = 0,
        IncSystem = 1,
    }

}
