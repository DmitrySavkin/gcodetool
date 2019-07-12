using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTool;

namespace SortTool
{
    public class EntityOrder
    {


        public static bool isInside(Entity e1, Entity e2)
        {
          EntityVerifier ef =  VerifierFabric.SortEntity(e1, e2);
          if (ef != null) 
            return ef.HasInside();
          return false;
        }


        public static List<CurveInfo> GetOrderedEntities(List<CurveInfo> allEntities)
        {
            if (allEntities == null)
                throw new NullReferenceException("The list of entities  is null");
            if (allEntities.Count == 0)
                return null;
            List<CurveInfo> resEntities = new List<CurveInfo>();
            bool wasProcessed;
            do
            {

                wasProcessed = false;
                for (int i = 0; i < allEntities.Count; i++)
                {
                    CurveInfo curEntity = allEntities[i];
                    if (curEntity.Done) continue;
                    bool hasInternals = false;
                    for (int j = 0; j < allEntities.Count; j++)
                    {
                        CurveInfo compEntity = allEntities[j];
                        if (curEntity == compEntity || compEntity.Done) continue;
                        if (EntityOrder.isInside(compEntity.Entity, curEntity.Entity))
                        {
                            hasInternals = true;
                        }
                    }
                    if (!hasInternals)
                    {
                        resEntities.Add(curEntity);
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
           // Dublicate.Filter(resEntities);
            //Dublicate.RemoveDublicateCircle(resEntities);
            if (resEntities.Count == 0)
            {
               
            }
            return resEntities;
        }



    }
}
