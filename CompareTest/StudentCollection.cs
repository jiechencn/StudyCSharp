using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTest
{
    class StudentCollection
    {
        private Student[] _students;
        public StudentCollection(params Student[] students)
        {
            _students = students.ToArray();
        }


        public IEnumerable<Student> this[int age] => _students.Where(stu => stu.Age == age);
  
    }
}
