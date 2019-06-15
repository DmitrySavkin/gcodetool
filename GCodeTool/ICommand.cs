using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeTool
{
   public interface ICommand
   {
        void Internal();

        void Outher();
   }
}
