using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using INTECH_STOCK_EXCHANGE;

namespace INTECH_STOCK_EXCHANGE
{
    [TestFixture]
    public class CompanyTests
    {

        [Test]
        public void CheckingCompanies()
        {
            Market market = new Market();

            Assert.That( market.companyList != null );
            Assert.That( market.companyList.Count > 0 );
        
        }

        [Test]
        public void PlacingOrders()
        {
            
        }

        [Test]
        public void PreparingOrders()
        {
            
        }
    }
}
