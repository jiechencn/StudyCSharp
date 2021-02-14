using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DelegateTest2
{
    class Message : AMessage
    {
        private string sender;
        private DateTime when;
        private string content;
        public string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }

        public DateTime When
        {
            get
            {
                return when;
            }
            set
            {
                when = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        public override string ToString()
        {
            return $"Sender={Sender};DateTime={When};Content={Content}";
        }
    }

    internal abstract class AMessage
    {
        // 添加 "new" 修饰符，覆盖 object.ToString()，让当前的方法称为一个新的方法，让子类实现override 
        public new abstract string ToString();
    }
}
