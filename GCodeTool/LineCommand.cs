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
    public class LineCommand : Command
    {
        private Line line;
        private static List<Line> lines = new List<Line>();
        public LineCommand(Point2d basePoint, CurveInfo e) : base(basePoint, e)
        {
            Line l = e.Entity as Line;
            if (l != null)
            {
                this.line = l;
                lines.Add(line);
            }

        }

        public  static List<Line> Line
        {
            get
            {
                return lines;
            }
        }

        public override GCodeBase Run()
        {
            Polyline p1 = ConvertToPolyline();
            return new PolylineCommand(this.basePoint, p1, IsOuter).Run();
        }

        
        public static Polyline ConvertToPolyline()
        {
            Polyline p = new Polyline();

            for (int i = 0; i < lines.Count; i++)
            {
                Line l = lines[i];
                p.AddVertexAt(i, new Point2d(l.StartPoint.X, l.StartPoint.Y), 0, 0, 0);
            }
            p.AddVertexAt(lines.Count, new Point2d(lines[lines.Count - 1].EndPoint.X, lines[lines.Count - 1].EndPoint.Y), 0, 0, 0);
            return p;
        }
    }
}
