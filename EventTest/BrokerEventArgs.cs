using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    public class BrokerEventArgs:EventArgs
    {
        // 定义事件属性：楼盘名称，楼盘价格
        public BrokerEventArgs(string brand, double price)
        {
            Brand = brand;
            Price = price;

        }
        public string Brand { get; }
        public double Price { get; }

    }
}
