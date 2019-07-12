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



        public PolylineCommand(Point2d basePoint, CurveInfo e, double diam): base(basePoint, e,diam)
        {
            Polyline p = e.Entity as Polyline;
            if (p != null)
            {
                this.Polyline = new Offset().getBias(p, base.IsOuter, DiameterOffset);
            }
        }

        public PolylineCommand(Point2d basePoint, Entity e, bool isOuther, double diam): base(basePoint, isOuther, diam)
        {
            Polyline p = e as Polyline;
            if (p != null)
            {
                this.Polyline = new Offset().getBias(p, base.IsOuter, DiameterOffset);
            }
        }
   

        public override GCode Run()
        {
            GCode2d c = new GCode2d();
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