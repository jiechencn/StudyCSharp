using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    public abstract class Broker
    {
        public event EventHandler<BrokerEventArgs> BrokerEvent;
        public virtual void Publish(string brand, double price)
        {
            Console.WriteLine($"Come on, we have {brand}. come here to buy...");
            BrokerEvent?.Invoke(this, new BrokerEventArgs(brand, price));
            // or below is same
            // if (BrokerEvent!=null) BrokerEvent(this, new BrokerEventArgs(brand, price));
        }
    }
}
