using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
   public abstract class GCode
   {
        protected bool up = true;

        protected StringBuilder GCodeText { get; }

        public GCode()
        {
            GCodeText = new StringBuilder();
        }

        public GCode(GCode gcode)
        {
            GCodeText = new StringBuilder();
            GCodeText.AppendLine(gcode.GCodeText.ToString());
        }

        public abstract void Up();
        public abstract void Down();

        public abstract void Move(double x, double y);

        public abstract void Position(double x, double y);

        public override string ToString()
        {
            return GCodeText.ToString();
        }

        public void RotationOn()
        {
            RotationOn(2000);
        }

        public void CoolingOn()
        {
            GCodeText.AppendLine("M8");
        }

        public void CoolingOff()
        {
            GCodeText.AppendLine("M9");
        }

        public void RotationOn(int speed, CommandOption option = CommandOption.ClockWise)
        {
            if (option == CommandOption.ClockWise)
            {
                GCodeText.AppendLine("M3 S" + speed);
            }
            else
            {
                if (option == CommandOption.CounterClockWise)
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

    }
}
