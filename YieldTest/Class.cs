using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldTest
{
    class Class: IEnumerable<Student>
    {
        private LinkedList<Student> students = new LinkedList<Student>();
        public Class()
        {

        }
        public void Add(Student s)
        {
            students.AddLast(s);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            foreach(Student s in students)
            {
                if (s.ID %2==0)
                    yield return s;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
