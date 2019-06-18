using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTool
{
    public class EntityInfo
    {
        private Entity entity;
        private bool isOuter;
        private bool done;

        public EntityInfo(Entity entity, bool isOuter)
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

        public Entity Entity
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
