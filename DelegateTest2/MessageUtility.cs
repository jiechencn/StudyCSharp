using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateTest2
{
    class MessageUtility<T>
        where T : AMessage
    {
        public static void SendEmail(T msg)
        {
            Console.WriteLine($"Sending email: {msg.ToString()}");
        }

        public static void SendSMS(T msg)
        {
            Console.WriteLine($"Sending SMS: {msg.ToString()}");
        }

        public static bool LogDebug(T msg)
        {
            Console.WriteLine($"Log Debug message: {msg.ToString()}");
            return true;
        }

        public static bool LogInfo(T msg)
        {
            Console.WriteLine($"Log Info message: {msg.ToString()}");
            return true;
        }
    }
}
