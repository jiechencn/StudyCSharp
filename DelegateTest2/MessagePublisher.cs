using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateTest2
{
    internal class MessagePublisher<T> where T: AMessage
    {
        public event EventHandler<MessageInfoEventArgs<T>> NewMessageInfoHandler;

        private IList<T> messages = new List<T>();

        public MessagePublisher(IList<T> messages)
        {
            this.messages = messages;
        }
        public MessagePublisher()
        {
        }


        internal void AddMessage(T msg)
        {
            messages.Add(msg);
            NewMessageInfoHandler?.Invoke(this, new MessageInfoEventArgs<T>(msg));
        }

        internal void AddMessage(T[] msgs)
        {
            foreach(T m in msgs)
            {
                AddMessage(m);
            }
        }
        internal void AddMessage(IList<T> msgs)
        {
            AddMessage(msgs.ToArray());
        }
    }
}