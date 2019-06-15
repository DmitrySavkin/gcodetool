using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
   public class CommandManager
    {
        private static Point2d getBasePoint(List<Entity> entities)
        {
            double minX = Double.MaxValue, minY = Double.MaxValue;
            foreach (Entity e in entities)
            {
                Polyline p = e as Polyline;
                if (p != null)
                {
                    for (int i = 0; i < p.NumberOfVertices; i++)
                    {
                        Point2d point = p.GetPoint2dAt(i);
                        if (point.X < minX)
                        {
                            minX = point.X;
                        }
                        if (point.Y < minY)
                        {
                            minY = point.Y;
                        }
                    }
                }

                Circle c = e as Circle;
                if (c != null)
                {
                    if (c.Center.X - c.Radius < minX)
                    {
                        minX = c.Center.X - c.Radius;
                    }
                    if (c.Center.Y - c.Radius < minY)
                    {
                        minY = c.Center.Y - c.Radius;
                    }
                }
            }
            if (minX == Double.MaxValue)
            {
                return new Point2d();
            }
            return new Point2d(minX, minY);
        }

        public static  string Gcode(List<Entity> entities)
        {
            string s = "";
            ITask t = null;
            Point2d basePoint = getBasePoint(entities);
            foreach(Entity e in entities)
            {
                Polyline p = e as Polyline;
                if (p!= null)
                {
                    t = new PolylineCommand(basePoint, p);
                }

                Circle c = e as Circle;
                if (c != null)
                {
                    t = new CircleCommand(basePoint, c);   
                }
                if (t != null)
                {
                    s += t.Run().ToString();
                }
            }
            return s;
        }
    }
}
