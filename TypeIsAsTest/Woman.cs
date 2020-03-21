using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeIsAsTest
{
    class Woman : Human
    {
        public override void Walk()
        {
            Console.WriteLine("woman walks slow");
        }
    }
}
