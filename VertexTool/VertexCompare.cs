using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexTool
{
    public class VertexCompare : IComparer<Polyline>
    {
        public int Compare(Polyline p1, Polyline p2)
        {
            if (p1.Area > p2.Area)
                return 1;
            else
            { 
                if (p1.Area < p2.Area)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
