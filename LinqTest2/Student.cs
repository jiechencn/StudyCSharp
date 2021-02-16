using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTest2
{
    class Student
    {
        private int no;
        private char sex;
        private string fullname;

        internal int No
        {
            get
            {
                return no;
            }
            set
            {
                no = value;
            }
        }

        internal char Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        internal string Fullname
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0,2}\t{1,-18}\t{2}", no, sex, fullname);
        }

    }
}
