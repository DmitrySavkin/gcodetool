using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeGenerator
{
    public class GCode
    {

        private StringBuilder Code { get; }

        public GCode()
        {
            Code = new StringBuilder();
        }

        public void G00(int x, int y, int z)
        {
            Code.Append($"G0 X{x} Y{y} Z{z}");
            Code.Append(Environment.NewLine);
        }


        public void G01(int x, int y, int z)
        {
            Code.Append($"G01 X{x} Y{y} Z{z}");
            Code.Append(Environment.NewLine);
        }
        //............usw...
        public String ToString()
        {
            return Code.ToString();
        }
    }
}
