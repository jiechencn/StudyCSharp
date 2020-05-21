using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockTest
{
    public interface IShop
    {
        Order GetOrder(string orderID);
        List<Order> GetOrders(string customerPhone);
        bool Save(Order order);
    }

    public class ABigShop : IShop
    {
        List<Order> orders = new List<Order>();
        public Order GetOrder(string orderID)
        {
            foreach(Order o in orders)
            {
                if (o.OrderID.Equals(orderID))
                {
                    return o;
                }
            }
            throw new ArgumentOutOfRangeException("No_Such_OrderID");
        }

        public List<Order> GetOrders(string customerPhoneNumber)
        {
            List<Order> foundOrders = new List<Order>();
            foreach (Order o in orders)
            {
                if (o.CustomerPhoneNumber.Equals(customerPhoneNumber))
                {
                    foundOrders.Add(o);
                }
            }

            if (foundOrders.Count() > 0)
                return foundOrders;
            
            throw new ArgumentOutOfRangeException("No_Such_Customer");
        }

        public bool Save(Order order)
        {
            orders.Add(order);
            return true;
        }
    }

    public class ASmallShop : IShop
    {
        List<Order> orders = new List<Order>();
        public Order GetOrder(string orderID)
        {
            foreach (Order o in orders)
            {
                if (o.OrderID.Equals(orderID))
                {
                    return o;
                }
            }
            throw new ArgumentOutOfRangeException("No_Such_OrderID");
        }

        public List<Order> GetOrders(string customerPhoneNumber)
        {
            List<Order> foundOrders = new List<Order>();
            foreach (Order o in orders)
            {
                if (o.CustomerPhoneNumber.Equals(customerPhoneNumber))
                {
                    foundOrders.Add(o);
                }
            }

            if (foundOrders.Count() > 0)
                return foundOrders;

            throw new ArgumentOutOfRangeException("No_Such_Customer");
        }

        public bool Save(Order order)
        {
            if (
                order==null || string.IsNullOrEmpty(order.OrderID)
                || order.Products==null
                || order.Products.Count==0
                )
            {
                return false;
            }
            orders.Add(order);
            return true;
        }
    }

}
