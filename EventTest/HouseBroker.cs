using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    
    class HouseBroker:Broker
    {
        public override void Publish(string name, double price)
        {
            price = price * 1.85;
            base.Publish(name, price);
        }

    }
}
