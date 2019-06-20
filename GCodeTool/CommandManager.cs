﻿using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using SortTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
   public class CommandManager
    {
        public static double diam = 20.0;

        private static Point2d getBasePoint(List<EntityInfo> entities)
        {
            double minX = Double.MaxValue, minY = Double.MaxValue;
            foreach (EntityInfo e in entities)
            {
                Polyline p = e.Entity as Polyline;
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

                Circle c = e.Entity as Circle;
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

        public static  string Gcode(List<EntityInfo> entities)
        {
            string s = "";
            Command gcode = null;
            Point2d basePoint = getBasePoint(entities);
            foreach(EntityInfo e in entities)
            {
                gcode = null;
                Polyline p = e.Entity as Polyline;
                if (p!= null)
                {
                    gcode = new PolylineCommand(basePoint, e);
                }

                Circle c = e.Entity as Circle;
                if (c != null)
                {
                    gcode = new CircleCommand(basePoint, e);   
                }

                Arc a = e.Entity as Arc;
                if (a != null)
                {
                    gcode = new ArcCommand(basePoint, e);
                }
                Line l = e.Entity as Line;
                if (l != null)
                {
                    gcode = new LineCommand(basePoint, e);
                }
                if (gcode != null && LineCommand.Line.Count > 2)
                {
                    s += gcode.Run().ToString();
                    gcode = null;
                }


            }
            return s;
        }
    
    }
}