using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTool
{
    public class VerifierFabric
    {
        public static EntityVerifier SortEntity(Entity e1, Entity e2)
        {

            var p = e1 as Polyline;
            if (p != null)
            {
                return new PolylineVerifier(p, e2);
            }                  
            var c = e1 as Circle;
            if (c != null)
            {
                return new CircleVerifier(c, e2);
            }
            
                        var l = e1 as Line;
                        if (l != null)
                        {
                            return new LineVerifier(l, e2);
                        }
                     
            //    throw new NullReferenceException("The sort is null");
            return null;
        }
    }
}
