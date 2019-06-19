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
        private Polyline polyline;

        public Polyline Polyline
        {
            get
            {
                return this.polyline;
            }
        }
        public PolylineVerifier(Polyline p, Entity e2) : base( e2)
        {
            if (p == null)
            {
                throw new NullReferenceException("The polyline is null");
            }

            this.polyline = p;
        }

      

        public override bool HasInside()
        {
            var p2 = E2 as Polyline;
            var c2 = E2 as Circle;
          
            if (p2 != null) {
                return PolylineInPolyline();
            }
            if (c2 != null) {
                return PolylineInCircle();
            }

            return false;
        }

        protected bool PolylineInPolyline()
        {
            Polyline p2 = (Polyline)E2;
            return IsPointInPolyline(this.polyline.GetPoint3dAt(0), p2);
        }

        protected bool PolylineInCircle()
        {
            Circle c = (Circle)E2;
            return IsPointInCircle(this.polyline.GetPoint3dAt(0), c);
        }

    }
}
