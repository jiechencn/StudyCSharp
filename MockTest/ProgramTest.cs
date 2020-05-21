using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using Moq.Protected;


namespace MockTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void SalesService_Test_PlaceOrder_Normal()
        {
            var mockShop = new Mock<IShop>();

            var mockProd1 = new Mock<Product>();
            mockProd1.SetupProperty(p => p.SerialID, 111);
            mockProd1.SetupProperty(p => p.Name, "samsumg 1x");
            
            var mockProd2 = new Mock<Product>();
            mockProd2.SetupProperty(p => p.SerialID, 222);
            mockProd2.SetupProperty(p => p.Name, "samsumg 2x");

            var mockProd3 = new Mock<Product>();
            mockProd3.SetupProperty(p => p.SerialID, 333);
            mockProd3.SetupProperty(p => p.Name, "samsumg 3x");

            SaleService ss = new SaleService(mockShop.Object);

            List<Product> products = new List<Product>()
            {
                mockProd1.Object,
                mockProd2.Object,
                mockProd3.Object
            };

            string customer1 = "13812345678";
            Order beforeOrder = new Order();
            Order afterOrder = new Order() ;
            mockShop
                .Setup(s => s.Save(It.IsAny<Order>()))
                .Returns(true)
                .Callback((Order o)=> 
                {
                    afterOrder = o;
                });

            string actualOrderID = ss.PlaceOrder(customer1, products);
            
            Assert.IsNotNull(actualOrderID);
            Assert.AreEqual(actualOrderID, afterOrder.OrderID);
            Assert.AreEqual(9, afterOrder.Products.Count);



        }

        [TestMethod]
        public void SalesService_Test_PlaceOrder_EmptyProduct()
        {
            var mockShop = new Mock<IShop>();

            var mockProd1 = new Mock<Product>();
            mockProd1.SetupProperty(p => p.SerialID, 111);
            mockProd1.SetupProperty(p => p.Name, "samsumg 1x");

            var mockProd2 = new Mock<Product>();
            mockProd2.SetupProperty(p => p.SerialID, 222);
            mockProd2.SetupProperty(p => p.Name, "samsumg 2x");

            var mockProd3 = new Mock<Product>();
            mockProd3.SetupProperty(p => p.SerialID, 333);
            mockProd3.SetupProperty(p => p.Name, "samsumg 3x");

            SaleService ss = new SaleService(mockShop.Object);

            List<Product> products = new List<Product>();

            string customer1 = "13812345678";
            Order beforeOrder = new Order();
            Order afterOrder = new Order();
            mockShop
                .Setup(s => s.Save(It.IsAny<Order>()))
                .Callback((Order o) =>
                {
                    afterOrder = o;
                })
                .Returns(true)
                .Callback((Order o) =>
                {
                    afterOrder = o;
                });

            try
            {
                string actualOrderID = ss.PlaceOrder(customer1, products);
            }catch(NoNullAllowedException ne)
            {
                Assert.AreEqual("BLANK_PRODUCT", ne.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NoNullAllowedException))]
        public void SalesService_Test_PlaceOrder_EmptyCustomerPhone()
        {
            var mockShop = new Mock<IShop>();

            var mockProd1 = new Mock<Product>();
            mockProd1.SetupProperty(p => p.SerialID, 111);
            mockProd1.SetupProperty(p => p.Name, "samsumg 1x");

            var mockProd2 = new Mock<Product>();
            mockProd2.SetupProperty(p => p.SerialID, 222);
            mockProd2.SetupProperty(p => p.Name, "samsumg 2x");

            var mockProd3 = new Mock<Product>();
            mockProd3.SetupProperty(p => p.SerialID, 333);
            mockProd3.SetupProperty(p => p.Name, "samsumg 3x");

            SaleService ss = new SaleService(mockShop.Object);


            List<Product> products = new List<Product>()
            {
                mockProd1.Object,
                mockProd2.Object,
                mockProd3.Object
            };

            string customer1 = "";
            Order beforeOrder = new Order();
            Order afterOrder = new Order();
            mockShop
                .Setup(s => s.Save(It.IsAny<Order>()))
                .Callback((Order o) =>
                {
                    afterOrder = o;
                })
                .Returns(true)
                .Callback((Order o) =>
                {
                    afterOrder = o;
                });

            string actualOrderID = ss.PlaceOrder(customer1, products);
   

        }

        [TestMethod]
        public void IShop_Test_Save()
        {
            var mockShop = new Mock<IShop>();
            mockShop.Setup(s => s.Save(It.IsAny<Order>()))
                .Returns(false);
            bool actualResult = mockShop.Object.Save(new Order());

        }

        [TestMethod]
        public void Product_Test_ReadOnlyString()
        {
            var mockProd = new Mock<Product>();
            mockProd.SetupGet(p => p.ReadOnlyString).Returns("hello readonly string");

            String realString = mockProd.Object.ReadOnlyString;



        }

    }
}
