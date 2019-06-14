using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    public class PolylineInterpretator : Interpretator
    {
        public PolylineInterpretator(Entity e): base(e)
        {

        }
      
        public override StringBuilder GCode { get; }

        private void Interperator()
        {
            List<GTask> tasks = new List<GTask>();
            Polyline p = E as Polyline;
            if (p == null)
                throw new NullReferenceException("The polyline is null. Not possible to convert");
            for (int i = 0; i < p.NumberOfVertices - 1; i++)
            {
                GTask task = new GLinealTask(p.GetPoint2dAt(i), GTaskModul.On);
            }
        }
    }
}
