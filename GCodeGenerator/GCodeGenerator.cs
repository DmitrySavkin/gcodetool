using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeGenerator
{

    public class GCodeGenerator
    {

        public static GCode GetGCode()
        {
            GCode g = new GCode();
            g.G00(0, 0, 0);
            g.G01(0, 1, 1);
            return g;
        }
    }

}
