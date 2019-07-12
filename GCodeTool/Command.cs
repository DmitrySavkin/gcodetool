using Autodesk.AutoCAD.Geometry;
using System.Text;
using System;
using SortTool;
using Autodesk.AutoCAD.DatabaseServices;

namespace GCodeTool
{
    /// <summary>
    /// Provides methods to generate gcode
    /// </summary>
    public abstract class Command
    {


        private bool isOuter;
        internal Point2d basePoint;
        private double diamOffset;
        internal CommandMetricOption coordinateSystem;


        /// <summary>
        /// Creates new object to generate gcode of polkyline relative of base point of coordinates system
        /// </summary>
        /// <param name="basePoint">base point of coordinates system</param>
        /// <param name="e">Curve information </param>
        /// <param name="diam">Diameter of wimble</param>
        /// <param name="option">Metric or inch system</param>
        public Command(Point2d basePoint, CurveInfo e, double diamOffset, CommandMetricOption coordinate = CommandMetricOption.MetricSystem)
        {

            this.isOuter = e.IsOuter;
            this.basePoint = basePoint;
            //this.Polyline = p;
            this.diamOffset = diamOffset;
            this.coordinateSystem = coordinate;
            //    this.Polyline = new Offset().getBias(p, EdgeTool.Edge.IsOuter(p));
        }

        /// <summary>
        /// Creates new object to generate gcode of polkyline relative of base point of coordinates system
        /// </summary>
        /// <param name="basePoint">base point of coordinates system</param>
        /// <param name="e">Curve  </param>
        /// <param name="isOuther">True, if polyline must be outer. </param>
        /// <param name="diam">Diameter of wimble</param>
        protected Command(Point2d basePoint, bool isOuter, double diamOffset)
        {
            this.basePoint = basePoint;
            this.isOuter = isOuter;
            this.diamOffset = diamOffset;

        }

        /// <summary>
        ///Offset the given point  about coordinate system
        /// </summary>
        /// <param name="p">Present point</param>
        /// <returns>Point with offset</returns>
        public Point2d GetRealPoint(Point2d p)
        {
            if (p == null)
            {
                throw new NullReferenceException("The point is null");
            }
            return new Point2d(p.X - BasePoint.X, p.Y - BasePoint.Y);
        }

        /// <summary>
        /// True,  when polyline is other bound
        /// </summary>
        public bool IsOuter
        {
            get
            {
                return isOuter;
            }
        }

        /// <summary>
        /// Offset the given point  about coordinate system
        /// </summary>
        public Point2d BasePoint
        {
            get
            {
                return basePoint;
            }
        }

        /// <summary>
        /// Converts autocad sketch to gcode 
        /// </summary>
        /// <returns>GCode</returns>
        public abstract GCode Run();


        /// <summary>
        /// Offeset wimble around the sketch
        /// </summary>
        public double DiameterOffset
        {
            get
            {
                return diamOffset;
            }
        }
    }

    /// <summary>
    /// Enums of cirlce direction the wimble
    /// </summary>
    public enum CommandDirectionOption
    {
        ClockWise = 0,
        CounterClockWise = 1

    }

    /// <summary>
    /// Enum of metric coordinate system
    /// </summary>
    public enum CommandMetricOption
    {
        MetricSystem = 0,
        IncSystem = 1,
    }

}
