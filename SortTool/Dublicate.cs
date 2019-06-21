using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTool
{
    public class Dublicate
    {

        internal static void Filter(List<CurveInfo> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                for (int j = 0; j < entities.Count; j++)
                {
                    if (entities[i].Entity.StartPoint == entities[j].Entity.StartPoint &&
                       entities[i].Entity != entities[j].Entity)
                    {
                        Line l = entities[i].Entity as Line;
                        Arc a = entities[j].Entity as Arc;
                        if (l != null && a != null)
                        {
                            entities.RemoveAt(i);
                            continue;
                        }
                        l = entities[j].Entity as Line;
                        a = entities[i].Entity as Arc;
                        if (l != null & a != null)
                        {
                            entities.RemoveAt(j);
                            continue;
                        }
                    }
                }

            }
        }

        internal static  void RemoveDublicateCircle(List<CurveInfo> entities)
        {


            for (int i = 0; i < entities.Count; i++)
            {
                for (int j = 0; j < entities.Count; j++)
                {

                    Circle c1 = entities[i].Entity as Circle;
                    Circle c2 = entities[j].Entity as Circle;
                    if (c1 != null && c2 != null)
                    {
                        if (c1.Center.X == c2.Center.X && c1.Center.Y == c2.Center.Y
                            && c1.Radius == c2.Radius)
                        {
                            entities.RemoveAt(j);
                            continue;
                        }
                    }
                }

            }
        }

    }
}
