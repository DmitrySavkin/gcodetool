using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAndPack
{
   public class JobContainer
    {
        public List<Job> Jobs { get; set; }

        public int Count
        {
            get
            {
                return Jobs.Count;
            }
        }

        public JobContainer()
        {

            Jobs = new List<Job>();
        }
        public Job GetNextJob()
        {
            if (Jobs.Count == 0)
            {
                throw new MemberAccessException("No Jobs currently");
            }
        
            return Jobs[Jobs.Count - 1];
        }

        public Job GetNextJobById(int id)
        {
            if (id < 0 || id > Jobs.Count - 1)
            {
                throw new MemberAccessException("No Jobs currently");
            }
            return Jobs[Jobs.Count - 1];
        }

        public void PushJob(Job j)
        {
            Jobs.Add(j);
            
        }

    }
}
