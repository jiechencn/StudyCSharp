using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTest2
{
    class Score
    {
        private int no;
        private string subject;
        private double point;
        

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

        internal double Point
        {
            get
            {
                return point;
            }
            set
            {
                point = value;
            }
        }

        internal string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }
        public override string ToString()
        {
            return String.Format("{0,2}\t{1,-18}\t{2,2}", no, subject, point);
        }
    }
}
