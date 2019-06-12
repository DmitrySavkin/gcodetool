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
        private bool done;

        public EntityInfo(Entity entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException("The entity is null");
            }

            this.entity = entity;
            this.done = false;
        }

        public bool Done
        {
            set
            {
                Hatch h;
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
    }

}
