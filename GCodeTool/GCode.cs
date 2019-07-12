using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    /// <summary>
    /// Contains generating gcode methods 
    /// </summary>
    public abstract class GCode
   {
        protected bool up = true;

        protected StringBuilder GCodeText { get; }

        private static int speed = 2000;

        private CommandMetricOption coordinates;

        /// <summary>
        /// Set Coordinate system for machine
        /// </summary>
        public CommandMetricOption Coordinates
        {
            get
            {
                return coordinates;
            }
        }
        /// <summary>
        /// Speed of  wimble rotation
        /// </summary>
        public static int Speed
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

        /// <summary>
        /// Creates a new object and sets metric  or inch system
        /// </summary>
        /// <param name="option">Metric or inch system</param>
        public GCode(CommandMetricOption option)
        {
            GCodeText = new StringBuilder();
            switch (option)
            {
                case CommandMetricOption.MetricSystem :
                    SetMetricSystem();
                    break;
                case CommandMetricOption.IncSystem:
                    SetInchSystem();
                    break;

            }
            this.coordinates = option;
           
        }

        /// <summary>
        /// Creates a new object and attaches external existing gcode.
        /// </summary>
        /// <param name="gcode">Existing gcode</param>
        public GCode(GCode gcode):this(gcode.Coordinates)
        {
            
            GCodeText.AppendLine(gcode.GCodeText.ToString());
        }

        /// <summary>
        /// Attaches external existing gcode.
        /// </summary>
        /// <param name="gcode">Existing gcode</param>
        public void AddCode(GCode gcode)
        {
            GCodeText.AppendLine(gcode.ToString());
        
        }
        /// <summary>
        /// Sets XYcoordinate system
        /// </summary>
        public void SetXYCoordinates()
        {
            GCodeText.AppendLine("G17");
        }
        /// <summary>
        /// Sets metric system
        /// </summary>
        public void SetMetricSystem()
        {
            GCodeText.AppendLine("G90 G21");
        }

        /// <summary>
        /// Sets inch system
        /// </summary>
        public void SetInchSystem()
        {
            GCodeText.AppendLine("G90 G20");
        }
        /// <summary>
        /// Elevates the wimble
        /// </summary>
        public abstract void Up();

        /// <summary>
        ///  Drops the wimble
        /// </summary>
        public abstract void Down();


        /// <summary>
        /// Drives the wimble alongside  the line
        /// </summary>
        /// <param name="x">final value x-coordinate</param>
        /// <param name="y">final value y-coordinate</param>
        public abstract void Move(double x, double y);

        /// <summary>
        /// Confines the wimble on a particular place
        /// </summary>
        /// <param name="x">final value x-coordinate</param>
        /// <param name="y">final value y-coordinate</param>
        public abstract void Position(double x, double y);

        public override string ToString()
        {
            return GCodeText.ToString();
        }

        /// <summary>
        /// Turns on the wimble with rotation default speed 
        /// /// </summary>
        public void RotationOn()
        {
            RotationOn(speed);
        }

        

        /// <summary>
        /// Turns the wimble with setted speed on 
        /// </summary>
        /// <param name="speed">speed of rotation</param>
        /// <param name="option">sets clockwise or anticlockwise direction of the wimble</param>
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
        /// <summary>
        /// Turns the wimble off
        /// </summary>
        public void RotationOff()
        {
            GCodeText.AppendLine("M5");
        }

        /// <summary>
        /// Turns the cooling system on
        /// </summary>
        public void CoolingOn()
        {
            GCodeText.AppendLine("M8");
        }

        /// <summary>
        /// Turns the cooling system off
        /// </summary>
        public void CoolingOff()
        {
            GCodeText.AppendLine("M9");
        }

    }
}
