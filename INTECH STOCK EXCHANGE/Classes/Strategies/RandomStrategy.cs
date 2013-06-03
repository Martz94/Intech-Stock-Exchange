using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public class RandomStrategy : IStrategy
    {
        public Order MakeDecision(Market market, Shareholder shareholder)
        {
            Random random = new Random();
            decimal priceProp;
            
            return null;
        }
    }
}
