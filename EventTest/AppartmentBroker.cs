using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    class AppartmentBroker:Broker
    {
        public void Publish(string brand, double price)
        {
            price *= 0.85;
            base.Publish(brand, price);
        }
    }
}
