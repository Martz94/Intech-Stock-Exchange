using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    /// <summary>
    /// Goal: Get more cash and a more valuable portfolio than the other strategies
    /// s/h with SmartStrategy must rank 1st when sorting the s/h list by cash or portfolio value. (2nd stupids, 3rd randoms)
    /// </summary>
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
            if ( market.Random.Next( 2 ) == 1 ) return Buy( market, shareholder );
            else return Sell( market, shareholder );     
        }

        public override string ToString()
        {
            string strat = "Smart Strategy";
            return strat.ToString();
        }
    }
}
