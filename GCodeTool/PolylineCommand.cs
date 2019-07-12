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
    /// <summary>
    /// Provides methods to generate gcode of polyline
    /// </summary>
    public class PolylineCommand : Command
    {
        /// <summary>
        /// Polyline which in task now
        /// </summary>
        public Polyline Polyline { get; }



        /// <summary>
        /// Creates new object to generate gcode of polkyline relative of base point of coordinates system
        /// </summary>
        /// <param name="basePoint">base point of coordinates system</param>
        /// <param name="e">Curve information </param>
        /// <param name="diam">Diameter of wimble</param>
        /// <param name="option">Metric or inch system</param>
        public PolylineCommand(Point2d basePoint, CurveInfo e, double diam, CommandMetricOption option = CommandMetricOption.MetricSystem) : base(basePoint, e, diam, option)
        {
            Polyline p = e.Entity as Polyline;
            if (p != null)
            {
                var o = new Offset();
                this.Polyline = o.getBias(p, base.IsOuter, DiameterOffset);
            }
        }

        /// <summary>
        /// Creates new object to generate gcode of polkyline relative of base point of coordinates system
        /// </summary>
        /// <param name="basePoint">base point of coordinates system</param>
        /// <param name="e">Curve  </param>
        /// <param name="isOuther">True, if polyline must be outer. </param>
        /// <param name="diam">Diameter of wimble</param>
        public PolylineCommand(Point2d basePoint, Curve e, bool isOuther, double diam) : base(basePoint, isOuther, diam)
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
            GCode2d c = new GCode2d(coordinateSystem);
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
                        ? CommandDirectionOption.CounterClockWise
                        : CommandDirectionOption.ClockWise);
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