using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
   public class CommandManager
    {
        
        public static  string Gcode(List<Entity> entities)
        {
            string s = "";
            ITask t = null;
            foreach(Entity e in entities)
            {
                Polyline p = e as Polyline;
                if (p!= null)
                {
                    t = new PolylineCommand(p);
                }

                Circle c = e as Circle;
                if (c != null)
                {
                    t = new CircleCommand(c);   
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
