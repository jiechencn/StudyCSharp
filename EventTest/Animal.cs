using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    class Animal
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            this.Name = name;
        }
        public void Sleep()
        {
            Console.WriteLine(Name + " begins to sleep");
        }

        public void Eat()
        {
            Console.WriteLine(Name + " begins to eat");
        }
    }
}
