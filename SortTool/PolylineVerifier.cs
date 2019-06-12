using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;

namespace SortTool
{
    public class PolylineVerifier : EntityVerifier
    {
        public PolylineVerifier(Entity e1, Entity e2) : base(e1, e2)
        {
            
        }

        private bool PolylineInPolyline() {

            Polyline p1 = (Polyline)E1;
            Polyline p2 = (Polyline)E2;
            return isPointInPolyline(p1.GetPoint3dAt(0), p2);
        }

        private bool PolylineInCircle()
        {
            Polyline p = (Polyline)E1;
            Circle c = (Circle)E2;
            return isPointInCircle(p.GetPoint3dAt(0), c);
        }

        public override bool HasInside()
        {
            var p2 = E2 as Polyline;
            var c2 = E2 as Circle;
            if (p2 != null) {
            //if (E2.GetType().Name == "Polyline")
            //{
                return PolylineInPolyline();
            }
            if (c2 != null) {
            //if (E2.GetType().Name == "Circle")
            //{
                return PolylineInCircle();
            }

            throw new TypeAccessException("The Geometrie is not defined");
        }
    }
}
