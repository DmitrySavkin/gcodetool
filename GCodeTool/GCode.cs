using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
   public class GCode
    {
        private static bool up = true;

        private StringBuilder GCodeText { get; }

        public GCode()
        {
            GCodeText = new StringBuilder();
        }
        public void Up()
        {
            //Problem
            if (!up)
            {
                GCodeText.AppendLine("G1 Z10");
                up = true;
            }
        }

        public void Down()
        {
            //Problem
            if (up)
            {
                GCodeText.AppendLine("G1 Z-10");
                up = false;
            }
        }


        public void Move(double x, double y)
        {
            GCodeText.AppendLine("G1 X" + x + "Y" + y);

        }

        public void Move(Point2d p)
        {
            Move(p.X, p.Y);
        }

        public void MoveArcTo(Point2d endPoint, double radius, CommandOption option = CommandOption.ClockWise)
        {
            string s;
            var b = option == CommandOption.ClockWise;
            s = String.Format("G0{0} X{1} Y{2} R{3} ", b ? 2 : 3, endPoint.X, endPoint.Y, radius);
            GCodeText.AppendLine(s);
        }

        public void Position(double x, double y)
        {
            Up();
            Move(x, y);
        }

        public void Position(Point2d p)
        {
            Position(p.X, p.Y);
        }
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

        public void MoveArc(Point2d startPoint, Point2d endPoint, double radius, CommandOption option = CommandOption.ClockWise)
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


        public void RotationOn()
        {
            RotationOn(2000);
        }

        public void RotationOn(int speed, CommandOption option = CommandOption.ClockWise)
        {
            if (option == CommandOption.ClockWise)
            {
                GCodeText.AppendLine("M3 S" + speed);
            }
            else
            {
                if (option == CommandOption.AntiClockWise)
                {
                    GCodeText.AppendLine("M4 S" + speed);
                }
                else
                {
                    throw new ArgumentException("Wrong option");
                }
            }
        }

        public void RotationOff()
        {
            GCodeText.AppendLine("M5");
        }

        public void CoolingOn()
        {
            GCodeText.AppendLine("M8");
        }

        public void CoolingOff()
        {
            GCodeText.AppendLine("M9");
        }
        public override string ToString()
        {
            return GCodeText.ToString();
        }

    }
}
