﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    class StudentComparer : IComparer<Student>
    {
        // compare by Name
        public int Compare(Student x, Student y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return x.Name.CompareTo(y.Name);
        }
    }
}
