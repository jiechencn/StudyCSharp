using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTest
{
    public enum StudentComparerType
    {
        ByNo,
        ByName,
        ByAge
    }
    class StudentComparer : IComparer<Student>
    {
        private StudentComparerType _type;
        public StudentComparer(StudentComparerType type)
        {
            _type = type;
        }
        public int Compare(Student x, Student y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            switch (_type)
            {
                case StudentComparerType.ByAge:
                    if (x.Age >= y.Age) return 1;
                    return -1;
                case StudentComparerType.ByNo:
                    if (x.No >= y.No) return 1;
                    return -1;
                case StudentComparerType.ByName:
                    return String.Compare(x.Name, y.Name);
                default:
                    throw new ArgumentException("invalid comparer type");
            }
        }
    }
}
