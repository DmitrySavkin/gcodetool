using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTool
{
    public class CurveInfo
    {
        private Curve entity;
        private bool isOuter;
        private bool done;

        public CurveInfo(Curve entity, bool isOuter)
        {
            if (entity == null)
            {
                throw new NullReferenceException("The entity is null");
            }

            this.entity = entity;
            this.done = false;
            this.isOuter = isOuter;
        }

        public bool Done
        {
            set
            {
                this.done = value;
            }
            get
            {
                return this.done;
            }
        }

        public Curve Entity
        {
            set
            {
                this.entity = value;
            }
            get
            {
                return this.entity;
            }
        }

        public bool IsOuter
        {
            get
            {
                return this.isOuter;
            }
        }
    }

}
