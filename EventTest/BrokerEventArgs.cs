using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    public class BrokerEventArgs:EventArgs
    {
        public BrokerEventArgs(string brand, double price)
        {
            Brand = brand;
            Price = price;

        }
        public string Brand { get; }
        public double Price { get; }

    }
}
