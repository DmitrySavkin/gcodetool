using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using SortTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
    public class PolylineCommand : Command
    {
        public Polyline Polyline { get; }



        public PolylineCommand(Point2d basePoint, EntityInfo e): base(basePoint, e)
        {
            Polyline p = e.Entity as Polyline;
            if (p != null)
            {
                this.Polyline = new Offset().getBias(p, base.IsOuter);
            }
        }

   

        public override GCodeBase Run()
        {
            GCodeBase c = new GCodeBase();
            c.Position(GetRealPoint(Polyline.GetPoint2dAt(0)));

            c.RotationOn();
            c.Down();
            c.CoolingOn();
            for (int i = 1; i < Polyline.NumberOfVertices; i++)
            {
                c.Move(GetRealPoint(Polyline.GetPoint2dAt(i)));
            }
            c.Up();
            c.RotationOff();
            c.CoolingOff();

            return c;
        }

    }

}