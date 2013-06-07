using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public class SmartStrategy : IStrategy
    {
        private Order Buy( Market market, Shareholder shareholder )
        {
            return null;
        }
        private Order Sell( Market market, Shareholder shareholder )
        {
            return null;
        }
        public Order MakeDecision( Market market, Shareholder shareholder )
        {
            return null;
            //return order;
        }
    }
}
