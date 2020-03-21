using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    class Student : IComparable<Student>
    {
        public int ID { get; }
        public string Name { get; }
        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int CompareTo(Student other)
        {
            if (other == null)
                return -1;
            if (ID >= other.ID)
                return 1;
            else
                return -1;
        }

        public override string ToString()
        {
            return $"{ Name} ({ID})";
        }
    }
}
