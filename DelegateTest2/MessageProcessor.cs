using System;
using System.Collections.Generic;
using System.Threading;

namespace DelegateTest2
{
    internal class MessageProcessor<T> where T:AMessage
    {
        // Action<AMessage> 尖括号中的AMessage表示被委托的方法的参数，比如SendSMS方法的参数。
        // 它不需要有返回类型
        static Action<AMessage> actions = MessageUtility<AMessage>.SendEmail;

        // Func<AMessage, bool> 尖括号中的AMessage表示被委托的方法的参数，比如LogDebug方法的参数。
        // 尖括号中的最后一个参数bool表示被委托的方法的返回类型，比如 LogDebug的返回类型为 bool.
        // Func必须存在有效的返回类型，并且返回类型不能是void
        // 多个Func最好不要使用多播，否则 func.invoke()只返回最后一个委托方法的返回值。所以应该使用数组传递，依次执行。
        static Func<AMessage, bool>[] funcs =
        {
            MessageUtility<AMessage>.LogDebug,
            MessageUtility<AMessage>.LogInfo
        };
        public MessageProcessor()
        {
            actions += MessageUtility<AMessage>.SendSMS;
        }

        internal void ProcessNewMessage(object sender, MessageInfoEventArgs<T> e)
        {
            Console.WriteLine($"new message received. I am processing {e.Msg.ToString()}");
            // 收到订阅到的消息后，开始处理消息，做两件事：发送邮件，发送短消息
            SendMessageWithActionDelegate(e.Msg);
            LogMessageWithFuncDelegate(e.Msg);
            Console.WriteLine();
        }

        private static void SendMessageWithActionDelegate(T msg)
        {
            // 现在要发送消息
            actions.Invoke(msg);
            Thread.Sleep(100);
        }
        private static void LogMessageWithFuncDelegate(T msg)
        {
            // 为消息记录日志 (debug 和 info)
            for (int j = 0; j < funcs.Length; j++)
            {
                bool b = funcs[j].Invoke(msg);
            }
        }

    }
}