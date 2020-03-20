using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTest
{
    class Student : IComparable<Student>
    {
        public int No { get; }
        public string Name { get; }
        public int Age { get; }
        public Student(int no, string name, int age)
        {
            No = no;
            Name = name;
            Age = age;
        }
        // by default, order by No.
        public int CompareTo(Student other)
        {
            if (other == null || No > other.No)
                return 1;
            else 
                return -1;
        }

        public override string ToString()
        {
            return $"{No}. {Name} is {Age} years old";
        }

    }
}
