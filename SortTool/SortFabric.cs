using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTool
{
    public class SortFabric
    {
        public static SortEntity SortEntity(Entity e1, Entity e2)
        {

            switch (e1.GetType().Name)
            {
                case "Polyline":
                    return new PolylineSort(e1, e2);
                case "Circle":
                    return new CircleSort(e1,e2);
                default:
                    throw new NullReferenceException("The sort is null");

            }

        }
    }
}
