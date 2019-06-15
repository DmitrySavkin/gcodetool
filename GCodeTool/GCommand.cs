using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    public class GCommand
    {

        private StringBuilder GCode { get; }

        public GCommand()
        {
            GCode = new StringBuilder();
        }

        public void G00() { }
        public void G01(double  x, double y)
        {
            GCode.AppendLine("G1 X" + x + "Y" + y);
        }

        public void G02(double x,double y, double r)
        {
            GCode.AppendLine("G2 X" + x + "Y" + y + "R" + r);
        }

        public void G03(double x, double y, double r)
        {
            GCode.AppendLine("G3 X" + x + "Y" + y + "R" + r);
        }

        public void G04(double  sec, CommandOption option)
        {
            if (option == CommandOption.DelayP)
            {
                GCode.AppendLine("G04 P" + sec);
            }
            else
            {
                if (option == CommandOption.AntiClockWise)
                {
                    GCode.AppendLine("G04 X" + sec);
                }
                else
                {
                    throw new ArgumentException("Wrong option");
                }
            }
        }



        public void G10(double x, double y, double z)
        {
            GCode.AppendLine("G10 X" + x + "Y" + y + "Y" + 0);
        }
        
        public void G15(double x, double y)
        {
            GCode.Append("G15 X" + 15 + "Y" + y);
        }
        public void G16() { }
        public void G17() { }
        public void G18() { }
        public void G19() { }
        public void G20() { }
        public void G21() { }
        public void G22() { }
     
        public void G23() { }
        public void G24() { }
        public void G25() { }
        public void G26() { }
        public void G27() { }
        public void G28() { }
        public void G29() { }
        public void G30() { }

        public void G31() { }
        public void G32() { }
        public void G33() { }
        public void G34() { }
        public void G35() { }
        public void G36() { }
        public void G37() { }
        public void G38() { }
        public void G39() { }
        public void G40() { }
        public void G41() { }
        public void G42() { }
        public void G43() { }
        public void G44() { }
        public void G45() { }
        public void G46() { }
        public void G47() { }
        public void G48() { }
        public void G49() { }
        public void G50() { }
        public void G51() { }
        public void G52() { }
        public void G53() { }
        public void G54() { }
        public void G55() { }
        public void G56() { }
        public void G57() { }
        public void G58() { }
        public void G59() { }
        public void G60() { }
        public void G61() { }
        public void G62() { }
        public void G63() { }
        public void G64() { }
        public void G65() { }
        public void G66() { }
        
        public void G67() { }
        public void G68() { }
        public void G69() { }
        public void G70() { }
        public void G71() { }
        public void G72() { }
        public void G73() { }
        public void G74() { }
        public void G75() { }
        public void G76() { }
        public void G77() { }
        public void G78() { }
        public void G79() { }
        public void G80() { }
        public void G81() { }
        public void G82() { }
        public void G83() { }
        public void G84() { }
        public void G85() { }
        public void G86() { }
        public void G87() { }
        public void G88() { }
        public void G89() { }
        public void G90() { }


        private string FormatCoordinats(double x, double y, double z)
        {
            String s = String.Format("{0} {1} {2}", FormatCoordinatsX(x), FormatCoordinatsY(y), FormatCoordinatsZ(z));
            return s;
        }

        private string FormatCoordinatsXY(double x, double y)
        {
            String s = String.Format("{0} {1}", FormatCoordinatsX(x), FormatCoordinatsY(y));
            return s;
        }
        private string FormatCoordinatsYZ(double y, double z)
        {
            String s = String.Format("{0} {1}", FormatCoordinatsX(y), FormatCoordinatsY(z));
            return s;
        }
        private string FormatCoordinatsX(double x)
        {
            String s = String.Format("X{0}", x);
            return s;
        }

        private string FormatCoordinatsY(double y)
        {
            String s = String.Format("Y{0}", y);
            return s;
        }


        private string FormatCoordinatsZ(double z)
        {
            String s = String.Format("Z{0}", z);
            return s;
        }
        public enum CommandOption
        {
            ClockWise = 0,
            AntiClockWise = 1,
            DelayP = 2,
            DelayX = 3,

        }
    }
}
