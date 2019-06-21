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
        public ArcCommand(Point2d basePoint, CurveInfo e, double diam) : base(basePoint, e, diam)
        {
            Arc a = e.Entity as Arc;
            if (a == null)
            {
                throw new NullReferenceException("The arc is null");
            }
            this.arc = a;
        }

        public ArcCommand(Point2d basePoint, Entity e, bool isOuther, double diam) : base(basePoint, isOuther, diam)
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
            Point2d end = new Point2d(arc.EndPoint.X, arc.EndPoint.Y);
            Point2d start = new Point2d(arc.StartPoint.X, arc.StartPoint.Y);
            Point2d center = new Point2d(arc.EndPoint.X, arc.StartPoint.Y);
            double dist = Math.Sqrt(Math.Pow(center.X - end.X, 2) + Math.Pow(center.Y - end.Y, 2));
            c.MoveArc(start,end, dist);
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
