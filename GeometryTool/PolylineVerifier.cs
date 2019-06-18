using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;

namespace GeometryTool
{
    public class PolylineVerifier : EntityVerifier
    {
        public PolylineVerifier(Entity e1, Entity e2) : base(e1, e2)
        {
            
        }

      

        public override bool HasInside()
        {
            var p2 = E2 as Polyline;
            var c2 = E2 as Circle;
            var l2 = E2 as Line;
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

            return false;
        }
    }
}
