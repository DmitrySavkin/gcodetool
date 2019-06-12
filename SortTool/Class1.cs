using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTool
{
    public class Class1
    {

        public void SetLines(Database db, Polyline p, Hatch h)
        {
            int  number = h.NumberOfHatchLines;
            int numberOfLoop =  h.NumberOfLoops;
            for (int i = 0; i < number; i++)
            {
                
            }
        }
    }
}
