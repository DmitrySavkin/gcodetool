using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmierprojekt
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> l = new List<string>();
            l.Add("First");
            l.Add("Second");
            l.Add("Sec");
            l.Insert(2,".");
            foreach (string s in l)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
