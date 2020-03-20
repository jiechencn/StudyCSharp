using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    
    class Consumer
    {
        private string _name;
        public Consumer(string name)
        {
            _name = name;
        }
        public void SubscriberBroker(object broker, BrokerEventArgs brokerEvnt)
        {
            Console.WriteLine($"{_name} is looking at house {brokerEvnt.Brand} with price {brokerEvnt.Price}");
        }
    }
}
