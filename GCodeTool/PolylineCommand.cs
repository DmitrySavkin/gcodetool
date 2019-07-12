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



        public PolylineCommand(Point2d basePoint, CurveInfo e, double diam) : base(basePoint, e, diam)
        {
            Polyline p = e.Entity as Polyline;
            if (p != null)
            {
                var o = new Offset();
                this.Polyline = o.getBias(p, base.IsOuter, DiameterOffset);
            }
        }

        public PolylineCommand(Point2d basePoint, Entity e, bool isOuther, double diam) : base(basePoint, isOuther, diam)
        {
            Polyline p = e as Polyline;
            if (p != null)
            {
                var o = new Offset();
                this.Polyline = o.getBias(p, base.IsOuter, DiameterOffset);
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
                Point2d nextPoint = GetRealPoint(Polyline.GetPoint2dAt(i));
                if (Polyline.GetSegmentType(i - 1) == SegmentType.Arc)
                {
                    var seg = Polyline.GetArcSegment2dAt(i - 1);
                    var bulge = Polyline.GetBulgeAt(i - 1) > 0;
                    c.MoveArcTo(nextPoint, seg.Radius, bulge
                        ? CommandOption.CounterClockWise
                        : CommandOption.ClockWise);
                }
                else
                {
                    c.Move(nextPoint);
                }
            }
            c.Up();
            c.RotationOff();
            c.CoolingOff();

            return c;
        }

    }

}