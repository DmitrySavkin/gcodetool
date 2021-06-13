using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTool;

namespace SortTool
{
    /// <summary>
    /// Provides the methods to order parts of sketch. 
    /// </summary>
    public class EntityOrder
    {


        /// <summary>
        /// Checks is entity e2  in inner entity e1
        /// </summary>
        /// <param name="e1">Outher entity</param>
        /// <param name="e2">Inner entity</param>
        /// <returns>True, when e1 contains e2</returns>
        public static bool isInside(Entity e1, Entity e2)
        {
          EntityVerifier ef =  VerifierFabric.SortEntity(e1, e2);
          if (ef != null) 
            return ef.HasInside();
          return false;
        }

        /// <summary>
        /// Returns sorted list of entities from center to outer bounder of  component
        /// </summary>
        /// <param name="allEntities">List of sketchs from autocad</param>
        /// <returns>Sorted list of sketch</returns>
        public static List<CurveInfo> GetOrderedEntities(List<CurveInfo> allEntities)
        {
            if (allEntities == null)
                throw new NullReferenceException("The list of entities  is null");
            if (allEntities.Count == 0)
                return null;

           // Dublicate.RemoveDublicateCircle(allEntities);
         //   Dublicate.RemoveDublicatePolyline(allEntities);
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
          
            return resEntities;
        }



    }
}
