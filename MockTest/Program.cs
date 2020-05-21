using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockTest
{
    class Program
    {
        public static void Main(string[] args)
        {

            string customer1 = "138123456789";
            IShop phoneShop = new ASmallShop();
            
            SaleService ss = new SaleService(phoneShop);
            Product p101 = new Computer()
            {
                SerialID = 101,
                Name = "imac 1"
            };

            Product p102 = new Computer()
            {
                SerialID = 102,
                Name = "imac 2"
            };
            List<Product> products1 = new List<Product>()
            {
                p101, 
                p102
            };

            
            string orderID1 = ss.PlaceOrder(customer1, products1);
            Console.WriteLine($"customer {customer1} buys {products1.Count} computers");

            Console.WriteLine("one day after");

            Product p201 = new Phone()
            {
                SerialID = 201,
                Name = "Samsumg 1x"
            };

            Product p202 = new Phone()
            {
                SerialID = 202,
                Name = "Samsumg 2x"
            };
            Product p203 = new Phone()
            {
                SerialID = 203,
                Name = "Samsumg 3x"
            };
            List<Product> products2 = new List<Product>()
            {
                p201,
                p202,
                p203
            };

            string orderID2 = ss.PlaceOrder(customer1, products2);
            Console.WriteLine($"customer {customer1} buys {products2.Count} phones");

            Order o1 = ss.SearchByOrder(orderID1);
            Console.WriteLine($"oderID1={o1.OrderID}");
            List<Order> o2s = ss.SearchByCustomer(customer1);
            Console.WriteLine($"{customer1} places {o2s.Count} orders");

        }



    }
}
