using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
   public class GCodeBase
    {

        private StringBuilder GCode { get; }

        public GCodeBase()
        {
            GCode = new StringBuilder();
        }
        public void Up()
        {
            //Problem
            GCode.AppendLine("G1 Z10");
        }

        public void Down()
        {
            //Problem
            GCode.AppendLine("G1 Z-10");
        }


        public void Move(double x, double y)
        {
            GCode.AppendLine("G1 X" + x + "Y" + y);

        }

        public void Move(Point2d p)
        {
            Move(p.X, p.Y);
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
            GCode.AppendLine(s);
            CoolingOff();
            Up();
            RotationOff();
        }

        public void MoveArc(Point2d endPoint, double radius, CommandOption option = CommandOption.ClockWise)
        {
            //Position(new Point2d(center.X + radius, center.Y));
            RotationOn();
            Down();
            CoolingOn();
            string s = "";
            if ( option == CommandOption.ClockWise)
            {
                s = String.Format("G02 X{0} Y{1} I{2} J{3}", endPoint.X, endPoint.Y, -radius, 0);

            }
            else
            {
               s = String.Format("G03 X{0} Y{1} I{2} J{3}", endPoint.X, endPoint.Y, -radius, 0);

            }
            GCode.AppendLine(s);
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
                GCode.AppendLine("M3 S" + speed);
            }
            else
            {
                if (option == CommandOption.AntiClockWise)
                {
                    GCode.AppendLine("M4 S" + speed);
                }
                else
                {
                    throw new ArgumentException("Wrong option");
                }
            }

        }

        public void RotationOff()
        {

            GCode.AppendLine("M5");
        }

        public void CoolingOn()
        {
            GCode.AppendLine("M8");

        }

        public void CoolingOff()
        {
            GCode.AppendLine("M9");
        }
        public override string ToString()
        {
            return GCode.ToString();
        }

    }
}
