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

        private int speed = 2000;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value >= 500 && value <= 2000)
                {
                    speed = value;
                }
            }
        }

        public GCode()
        {
            GCodeText = new StringBuilder();
           
        }

        public GCode(GCode gcode)
        {
            GCodeText = new StringBuilder();
            GCodeText.AppendLine(gcode.GCodeText.ToString());
        }

        public void SetMetricSystem()
        {
            GCodeText.AppendLine("G90 G21");
        }
        public void SetInchSystem()
        {
            GCodeText.AppendLine("G90 G20");
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
            RotationOn(speed);
        }

        public void CoolingOn()
        {
            GCodeText.AppendLine("M8");
        }

        public void CoolingOff()
        {
            GCodeText.AppendLine("M9");
        }

        public void RotationOn(int speed, CommandDirectionOption option = CommandDirectionOption.ClockWise)
        {
            switch (option)
            {
                case CommandDirectionOption.ClockWise:

                    GCodeText.AppendLine("M3 S" + speed);
                    break;
                case CommandDirectionOption.CounterClockWise:
                    GCodeText.AppendLine("M4 S" + speed);
                    break;
            }
          
        }

        public void RotationOff()
        {
            GCodeText.AppendLine("M5");
        }

    }
}
