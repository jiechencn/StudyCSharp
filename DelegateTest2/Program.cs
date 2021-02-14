using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace DelegateTest2
{
    
    class Program
    {
        // 只供 SendMessageWithCommonDelegate 普通委托使用
        delegate void CommonDelegateRespondToNewMessage<T>(T x);

        static void Main(string[] args)
        {

            // 模拟数据库来了10个新消息
            int count = 10;
            IList<AMessage> messages = new List<AMessage>();
            for (int i= 0; i<count; i++)
            {
                messages.Add(new Message()
                {
                    Sender = "Sender-" + i,
                    When = DateTime.Now,
                    Content = "hello content: " + i
                });
            }

            // 演示使用普通委托，调用两个委托，发送邮件和SMS消息，此处不关心返回值
            Console.WriteLine("\n------- Common Delegate");
            SendMessageWithCommonDelegate(messages);

            // 演示使用Action委托(Action不需要返回类型)，对于多个委托，采用多播方式，调用两个委托，发送邮件和SMS消息
            Console.WriteLine("\n------- Action Delegate");
            SendMessageWithActionDelegate(messages);

            // 演示使用Func委托(Func要求有效的返回类型)，调用两个委托，记录debug和info日志
            Console.WriteLine("\n------- Func Delegate");
            LogMessageWithFuncDelegate(messages);

            // 演示使用一个普通delegate 发送邮件，一个action发送短消息和一个func记录debug，实现方法的回调
            Console.WriteLine("\n------- Callback with one delegate, one action and one fun");
            CommonDelegateRespondToNewMessage<AMessage> oneOp = MessageUtility<AMessage>.SendEmail;
            Action<AMessage> oneAction = MessageUtility<AMessage>.SendSMS;
            Func<AMessage, bool> oneFunc = MessageUtility<AMessage>.LogDebug;
            CallbackDelegate(messages, oneOp, oneAction, oneFunc);

            // 演示事件的发布/订阅，调用2个委托，实现发送邮件和SMS消息，调用另外2个委托，实现记录debug和info日志
            Console.WriteLine("\n------- Event publisher and subscriber");
            var msgPublisher = new MessagePublisher<AMessage>();
            var msgProcessor = new MessageProcessor<AMessage>();
            msgPublisher.NewMessageInfo += msgProcessor.ProcessNewMessage;
            AMessage msg1 = new Message()
            {
                Sender = "new sender 1",
                When = DateTime.Now,
                Content = "new content 1",
            };
            msgPublisher.AddMessage(msg1);

            msgPublisher.AddMessage(new Message()
            {
                Sender = "new sender 2",
                When = DateTime.Now,
                Content = "new content 2",
            });
            msgPublisher.AddMessage(messages);
        }

        private static void CallbackDelegate(IList<AMessage> messages, CommonDelegateRespondToNewMessage<AMessage> op, Action<AMessage> action, Func<AMessage, bool> func)
        {
            foreach(var msg in messages)
            {
                op.Invoke(msg);
                action.Invoke(msg);
                bool b = func.Invoke(msg);
                Console.WriteLine($"{func.Method} is {b}");
            }
        }

        private static void SendMessageWithCommonDelegate(IList<AMessage> messages)
        {

            // 定义两个delegation, 此处我们不需要返回类型
            CommonDelegateRespondToNewMessage<AMessage>[] ops =
            {
                MessageUtility<AMessage>.SendEmail,
                MessageUtility<AMessage>.SendSMS
            };
            // 现在要发送消息
            for (int i = 0; i < messages.Count; i++)
            {
                for (int j = 0; j < ops.Length; j++)
                {
                    ops[j].Invoke(messages[i]);
                    Thread.Sleep(100);
                }
            }
        }

        private static void SendMessageWithActionDelegate(IList<AMessage> messages)
        {
            // Action<AMessage> 尖括号中的AMessage表示被委托的方法的参数，比如SendSMS方法的参数。
            // 它不需要有返回类型
            Action<AMessage> action = MessageUtility<AMessage>.SendEmail;
            action += MessageUtility<AMessage>.SendSMS;

            // 现在要发送消息
            for (int i = 0; i < messages.Count; i++)
            {
                action.Invoke(messages[i]);
                Thread.Sleep(100);
            }
        }
        private static void LogMessageWithFuncDelegate(IList<AMessage> messages)
        {
            // Func<AMessage, bool> 尖括号中的AMessage表示被委托的方法的参数，比如LogDebug方法的参数。
            // 尖括号中的最后一个参数bool表示被委托的方法的返回类型，比如 LogDebug的返回类型为 bool.
            // Func必须存在有效的返回类型，并且返回类型不能是void
            // 多个Func最好不要使用多播，否则 func.invoke()只返回最后一个委托方法的返回值。所以应该使用数组传递，依次执行。
            Func<AMessage, bool>[] funcs =
            {
                MessageUtility<AMessage>.LogDebug,
                MessageUtility<AMessage>.LogInfo
            };
 
            // 现在要发送消息
            for (int i = 0; i < messages.Count; i++)
            {
                for (int j=0; j<funcs.Length; j++)
                {
                    bool b = funcs[j].Invoke(messages[i]);
                    Thread.Sleep(100);
                }
            }
        }
    }
}
