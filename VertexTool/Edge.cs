using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTool;
using SortTool;

namespace EdgeTool
{

    public class Edge
    {
        public static short InnereColor = 4;
        public static short OutherColor = 2;
        public static string InnerVertexSt = "Innere Kanten";
        public static string OutherVertexSt = "Aussere Kanten";
  

        /// <summary>
        /// Method  creates the list of inner entities
        /// </summary>
        /// <param name="polylines">All drown entities in AutoCAD</param>
        /// <returns>List with Inner entities.</returns>
        public static List<Entity> InnerEntities(List<Entity> polylines)
        {
            if (polylines == null)
            {
                throw new NullReferenceException("The polylines is null");
            }
            List<Entity> innerEntities = new List<Entity>();
            foreach (Entity e in polylines)
            {
                if (e.Layer.Equals(Edge.InnerVertexSt))
                {
                    innerEntities.Add(e);
                }
            }

            return innerEntities;
        }
        /// <summary>
        /// Checks if the Entity outher is
        /// </summary>
        /// <param name="e">entity e</param>
        /// <returns>True if entity is outher</returns>
        public static bool IsOuter(Entity e)
        {
            if (e == null)
            {
                throw new NullReferenceException("The entity is null");
            }
            return e.Layer == OutherVertexSt;
        }

        /// <summary>
        /// Checks if the Entity inner is
        /// </summary>
        /// <param name="e">entity e</param>
        /// <returns>True if entity is inner</returns>
        public static bool IsInner(Entity e)
        {
            if (e == null)
            {
                throw new NullReferenceException("The entity is null");
            }
            return e.Layer == InnerVertexSt;
        }


        /// <summary>
        /// Method  creates the list of outher entities
        /// </summary>
        /// <param name="polylines">All drown entities in AutoCAD</param>
        /// <returns>List with outher entities.</returns>
        public static List<Entity> OuterEntyties(List<Entity> polylines)
        {

            if (polylines == null)
            {
                throw new NullReferenceException("The polylines is null");
            }

  
            List<Entity> outerEntities = new List<Entity>();
            foreach (Entity e in polylines)
            {
                if (e.Layer.Equals(Edge.OutherVertexSt))
                {
                    outerEntities.Add(e);
                }
            }

            return outerEntities;
        }

    }
}
