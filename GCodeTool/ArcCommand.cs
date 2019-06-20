using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using SortTool;

namespace GCodeTool
{
    public class ArcCommand : Command
    {
        private Arc arc;
        public ArcCommand(Point2d basePoint, EntityInfo e) : base(basePoint, e)
        {
            Arc a = e.Entity as Arc;
            if (a == null)
            {
                throw new NullReferenceException("The arc is null");
            }
            this.arc = a;
        }

        public ArcCommand(Point2d basePoint, Entity e, bool isOuther) : base(basePoint, isOuther)
        {
            Arc a = e as Arc;
            if (a == null)
            {
                throw new NullReferenceException("The arc is null");
            }
            this.arc = a;
        }
        public override GCodeBase Run()
        {
            /*  Polyline p1 = ConvertToPolyline();
              return new PolylineCommand(this.basePoint, p1, IsOuter).Run();
              */

            GCodeBase c = new GCodeBase();
            c.RotationOn();
            c.Down();
            c.CoolingOn();
            Point2d p = new Point2d(arc.EndPoint.X, arc.EndPoint.Y);
            c.MoveArc(p, arc.Radius);
            c.Up();
            c.RotationOff();
            c.CoolingOff();
            return c;
        }

        public  Polyline ConvertToPolyline()
        {
            Polyline p = new Polyline();
            p.AddVertexAt(0, new Point2d(arc.StartPoint.X, arc.StartPoint.Y), GetArcBulge(arc), 0, 0);
            p.AddVertexAt(1, new Point2d(arc.EndPoint.X, arc.EndPoint.Y), 0, 0, 0);
            p.LayerId = arc.LayerId;
            return p;
        }

        private double GetArcBulge(Arc a)
        {
            double deltaAng =  (a.EndAngle - a.StartAngle);
            if (deltaAng < 0)
            {
                deltaAng += 2 * Math.PI;
            }
            return Math.Tan(deltaAng * 0.25);
        }
    }
}
