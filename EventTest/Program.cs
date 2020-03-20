using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Broker houseSeller = new HouseBroker();
            Broker appartSeller = new AppartmentBroker();

            var jie1 = new Consumer("jie1 chen2");
            var jie2 = new Consumer("jie2 chen2");

            houseSeller.BrokerEvent += jie1.SubscriberBroker;
            houseSeller.BrokerEvent += jie2.SubscriberBroker;
            appartSeller.BrokerEvent += jie2.SubscriberBroker;

            houseSeller.Publish("mingmen 1 hao", 23560);
            appartSeller.Publish("8 hao", 12300);

        }
    }
}
