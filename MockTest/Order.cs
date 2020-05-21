using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockTest
{
    public class Order
    {
        public List<Product> Products { get; set; }
        public string OrderID { get; set; }
        public string CustomerPhoneNumber { get; set; } 
    }
}
