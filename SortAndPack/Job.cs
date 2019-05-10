using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Geometry;
namespace SortAndPack
{
    public class Job
    {
       
        public List<PolylineCurve2d> curve2Ds { get; set; }

        public int Size
        {

            get
            {
                return curve2Ds.Count;
            }
        }
        public double GetStartX(int i)
        {
            return curve2Ds[i].StartPoint.X;
        }

        public double GetStartY(int i)
        {
            return curve2Ds[i].StartPoint.Y;
        }

        public double GetEndX(int i)
        {
            return curve2Ds[i].EndPoint.X;
        }
        public double GetEndY(int i)
        {
            return curve2Ds[i].EndPoint.Y;
        }

        public void Methode() 
        {}
    }
}
