using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTool
{
    public class EntityOrder
    {


        public static bool isInside(Entity e1, Entity e2)
        {
            return VerifierFabric.SortEntity(e1, e2).HasInside();

        }


        public static List<Entity> GetOrderedEntities(List<EntityInfo> allEntities)
        {
            List<Entity> resEntities = new List<Entity>();
            bool wasProcessed;
            do
            {

                wasProcessed = false;
                for (int i = 0; i < allEntities.Count; i++)
                {
                    EntityInfo curEntity = allEntities[i];
                    if (curEntity.Done) continue;
                    bool hasInternals = false;
                    for (int j = 0; j < allEntities.Count; j++)
                    {
                        EntityInfo compEntity = allEntities[j];
                        if (curEntity == compEntity || compEntity.Done) continue;
                        if (EntityOrder.isInside(compEntity.Entity, curEntity.Entity))
                        {
                            hasInternals = true;
                        }
                    }
                    if (!hasInternals)
                    {
                        resEntities.Add(curEntity.Entity);
                        wasProcessed = true;
                        curEntity.Done = true;
                    }
                }
            } while (wasProcessed);
         /*   for (int i = 0; i < resEntities.Count; i++)
            {
                Entity curEntity = resEntities[i].Entity;
                Polyline p = curEntity as Polyline;
                if (p == null) continue;
                if (p.StartPoint != p.EndPoint)
                {
                    Console.WriteLine("Bad figure here");

                }

            }*/
            return resEntities;
        }


    }
}
