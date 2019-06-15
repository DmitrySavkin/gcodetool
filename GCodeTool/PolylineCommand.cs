using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    public class PolylineCommand : ITask
    {
        public Polyline Polyline { get; }

        public PolylineCommand(Polyline p)
        {
            this.Polyline = p;
        }
        public Command Run()
        {
            Command c = new Command();
            c.Position(Polyline.GetPoint2dAt(0));

            c.RotationOn();
            c.Down();
            c.CoolingOn();
            for (int i = 1; i < Polyline.NumberOfVertices; i++)
            {
                c.Move(Polyline.GetPoint2dAt(i));
            }
            c.Up();
            c.RotationOff();
            c.CoolingOff();

            return c;
        }
    }
}
