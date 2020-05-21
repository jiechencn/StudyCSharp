using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockTest
{
    public class SaleService
    {
        private readonly IShop m_shop;

        public SaleService(IShop shop)
        {
            m_shop = shop;
        }

        // return orderID
        public string PlaceOrder(string customerPhoneNumber, List<Product> products)
        {
            if (products == null || products.Count < 1)
                throw new NoNullAllowedException("BLANK_PRODUCT");
            if (string.IsNullOrEmpty(customerPhoneNumber))
                throw new NoNullAllowedException("BLANK_CUSTOMERPHONENUMBER");

            var orderID = customerPhoneNumber + "_" +DateTime.Now.Date.ToString("yyyyMMddHHMMSI");

            Product freeCard = PromoteHelper.GetPromotions(products, true);
            freeCard.SerialID = 99;
            freeCard.Name = "card 99 yuan";

            products.Add(freeCard);

            Order order = new Order()
            {
                CustomerPhoneNumber = customerPhoneNumber,
                OrderID = orderID,
                Products = products

            };
            if (m_shop.Save(order))
                return orderID;
            else
                throw new Exception("ERROR_TO_SAVE_ORDER");
        }

        internal Order SearchByOrder(string orderID)
        {
            return m_shop.GetOrder(orderID);
        }

        internal List<Order> SearchByCustomer(string customerPhoneNumber)
        {
            return m_shop.GetOrders(customerPhoneNumber);
        }
    }

    public class PromoteHelper
    {
        public static Product GetPromotions(List<Product> products, bool expensePromote=false)
        {
            Product card = new Postcard();
            card.SerialID = 5;
            card.Name = "card 5yuan";
            
            if (expensePromote)
            {
                card.SerialID = 10;
                card.Name = "card 10yuan";
            }

            return card;
        }
    }

    public interface IPromotion
    {
        Product GetPromotions(List<Product> products, bool expensePromote = false);
    }
    
}
