using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    /// <summary>
    /// Contains generating gcode methods in 2D-space
    /// </summary>
    public class GCode2d : GCode
    {
        /// <summary>
        /// Creates new object and set metric or inch system
        /// </summary>
        /// <param name="option">metric or inch system</param>
        public GCode2d(CommandMetricOption option) : base(option)
        {
        }

        /// <summary>
        /// Creates a new object and attaches external existing gcode.
        /// </summary>
        /// <param name="gcode">Existing gcode</param>
        public GCode2d(GCode gcode) : base(gcode)
        {
        }

        public override void Up()
        {
            //Problem
            if (!up)
            {
                GCodeText.AppendLine("G1 Z10");
                up = true;
            }
        }

        public override void Down()
        {
            //Problem
            if (up)
            {
                GCodeText.AppendLine("G1 Z-10");
                up = false;
            }
        }


        public override  void Move(double x, double y)
        {
            GCodeText.AppendLine("G1 X" + x + "Y" + y);

        }

        public override void Position(double x, double y)
        {
            Up();
            Move(x, y);
        }

        /// <summary>
        /// Confines the wimble on a particular place
        /// </summary>
        /// <param name="p">final point</param>
        public void Move(Point2d p)
        {
            Move(p.X, p.Y);
        }
        /// <summary>
        /// Moves the wimble in end final pooint
        /// </summary>
        /// <param name="endPoint">final end point</param>
        /// <param name="radius">radius of arc</param>
        /// <param name="option">Sets clockwise or counter-clockwise movement</param>
        public void MoveArcTo(Point2d endPoint, double radius, CommandDirectionOption option = CommandDirectionOption.ClockWise)
        {
            string s;
            var b = option == CommandDirectionOption.ClockWise;
            s = String.Format("G0{0} X{1} Y{2} R{3} ", b ? 2 : 3, endPoint.X, endPoint.Y, radius);
            GCodeText.AppendLine(s);
        }


        /// <summary>
        /// Confines the wimble on a particular place
        /// </summary>
        /// <param name="p">final point</param>
        public void Position(Point2d p)
        {
            Position(p.X, p.Y);
        }

        /// <summary>
        /// Make circular movements
        /// </summary>
        /// <param name="center">center-point of circle</param>
        /// <param name="radius">radius of circle</param>
        public void MoveCircle(Point2d center, double radius)
        {//G02 X5. Y0. I-5. J0.
            Position(new Point2d(center.X + radius, center.Y));
            RotationOn();
            Down();
            CoolingOn();
            string s = String.Format("G02 X{0} Y{1} I{2} J{3}", center.X + radius, center.Y, -radius, 0);
            GCodeText.AppendLine(s);
            CoolingOff();
            Up();
            RotationOff();
        }

        /// <summary>
        /// Rounds up  parts of component 
        /// </summary>
        /// <param name="startPoint">start point</param>
        /// <param name="endPoint">end point</param>
        /// <param name="radius">radius of arc</param>
        /// <param name="option">sets clockwise or anticlockwise direction of the wimble</param>

        public void MoveArc(Point2d startPoint, Point2d endPoint, double radius, CommandDirectionOption option = CommandDirectionOption.ClockWise)
        {
            Position(new Point2d(startPoint.X, startPoint.Y));
            RotationOn();
            Down();
            CoolingOn();
            MoveArcTo(endPoint, radius, option);
            CoolingOff();
            Up();
            RotationOff();
        }
    }
}
