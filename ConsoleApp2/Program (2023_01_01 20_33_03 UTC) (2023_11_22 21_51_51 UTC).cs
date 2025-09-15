using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            using(DevEntities de = new DevEntities())
            {

                var carriers = de.Carriers;

            }
        }
    }
}
