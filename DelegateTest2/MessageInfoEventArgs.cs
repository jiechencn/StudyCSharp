using System;

namespace DelegateTest2
{
    class MessageInfoEventArgs<T> : EventArgs
        where T : AMessage
    {
        public T Msg { get; }
        public MessageInfoEventArgs(T msg)
        {
            Msg = msg;
        }
    }
}