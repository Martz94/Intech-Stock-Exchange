using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using INTECH_STOCK_EXCHANGE;

namespace Tests.Classes_tests
{
    [TestFixture]
    class MarketTests
    {
        //SortOrders()
        //DefineNewPrice()
        //SellBuy()

        [Test]
        public void SortOrdersTest()
        {
            Market Pouet = new Market();
            Order order1 = new Order( Order.orderType.Buy, 10.0M, 50, Pouet.companyList[0], Pouet.shareholderList[0] );
            Order order2 = new Order( Order.orderType.Sell, 10.0M, 50, Pouet.companyList[0], Pouet.shareholderList[1] );
            Order order3 = new Order( Order.orderType.Sell, 9.0M, 50, Pouet.companyList[0], Pouet.shareholderList[2] );
            Order order4 = new Order( Order.orderType.Sell, 10.5M, 25, Pouet.companyList[0], Pouet.shareholderList[3] );
            Order order5 = new Order( Order.orderType.Buy, 9.0M, 30, Pouet.companyList[0], Pouet.shareholderList[4] );

            Pouet.globalOrderbook.Add( order1 );
            Pouet.globalOrderbook.Add( order2 );
            Pouet.globalOrderbook.Add( order3 );
            Pouet.globalOrderbook.Add( order4 );
            Pouet.globalOrderbook.Add( order5 );

            Pouet.SortOrders();


            foreach (var keyvalue in Pouet._sellOrders)
            {
                Assert.That( keyvalue.Value.Count, Is.EqualTo( 3 ) );
                Assert.That( keyvalue.Value[0], Is.EqualTo( order2 ) );
                Assert.That( keyvalue.Value[1], Is.EqualTo( order3 ) );
                Assert.That( keyvalue.Value[2], Is.EqualTo( order4 ) );
            }

            foreach (var keyvalue in Pouet._buyOrders)
            {
                Assert.That( keyvalue.Value.Count, Is.EqualTo( 2 ) );
                Assert.That( keyvalue.Value[0], Is.EqualTo( order1 ) );
                Assert.That( keyvalue.Value[1], Is.EqualTo( order5 ) );
            }
        }

        [Test]
        public void DefineNewPriceTest()
        {
            Market Pouet = new Market();
            Order order1 = new Order( Order.orderType.Buy, 10.0M, 50, Pouet.companyList[0], Pouet.shareholderList[0] );
            Order order2 = new Order( Order.orderType.Sell, 10.0M, 50, Pouet.companyList[0], Pouet.shareholderList[1] );
            Order order3 = new Order( Order.orderType.Sell, 11.0M, 50, Pouet.companyList[0], Pouet.shareholderList[2] );
            Order order4 = new Order( Order.orderType.Sell, 10.5M, 25, Pouet.companyList[0], Pouet.shareholderList[3] );
            Order order5 = new Order( Order.orderType.Buy, 9.0M, 30, Pouet.companyList[0], Pouet.shareholderList[4] );

            Pouet.globalOrderbook.Add( order1 );
            Pouet.globalOrderbook.Add( order2 );
            Pouet.globalOrderbook.Add( order3 );
            Pouet.globalOrderbook.Add( order4 );
            Pouet.globalOrderbook.Add( order5 );

            Pouet.SortOrders();
            Pouet.DefineNewPrice();

            Assert.That( Pouet.companyList[0].SharePrice, Is.EqualTo( 10.0M ) );
        }

        [Test]
        public void SellBuyTest()
        {
            Market Pouet = new Market();
            Order order1 = new Order( Order.orderType.Buy, 10.0M, 50, Pouet.companyList[0], Pouet.shareholderList[0] );
            Order order2 = new Order( Order.orderType.Sell, 10.0M, 50, Pouet.companyList[0], Pouet.shareholderList[1] );
            Order order3 = new Order( Order.orderType.Sell, 11.0M, 50, Pouet.companyList[0], Pouet.shareholderList[2] );
            Order order4 = new Order( Order.orderType.Sell, 10.5M, 25, Pouet.companyList[0], Pouet.shareholderList[3] );
            Order order5 = new Order( Order.orderType.Buy, 9.0M, 30, Pouet.companyList[0], Pouet.shareholderList[4] );

            Pouet.globalOrderbook.Add( order1 );
            Pouet.globalOrderbook.Add( order2 );
            Pouet.globalOrderbook.Add( order3 );
            Pouet.globalOrderbook.Add( order4 );
            Pouet.globalOrderbook.Add( order5 );

            Pouet.SortOrders();
            Pouet.DefineNewPrice();
            Pouet.SellBuy();

            Assert.That( Pouet.shareholderList[0].Capital, Is.EqualTo(500) );
            Assert.That( Pouet.shareholderList[1].Capital, Is.EqualTo( 1000 ) );
            Assert.That( Pouet.shareholderList[2].Capital, Is.EqualTo(1000) );
            Assert.That( Pouet.shareholderList[3].Capital, Is.EqualTo( 2000 ) );
            Assert.That( Pouet.shareholderList[4].Capital, Is.EqualTo( 20000 ) );
        }
    }
}
