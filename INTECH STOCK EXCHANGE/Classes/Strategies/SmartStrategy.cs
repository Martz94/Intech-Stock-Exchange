﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace INTECH_STOCK_EXCHANGE
{
    /// <summary>
    /// Goal: Get more cash and a more valuable portfolio than the other strategies, 
    /// s/h with SmartStrategy must rank 1st when sorting the s/h list by cash or portfolio value. (2nd stupids, 3rd randoms)
    /// Currently: Similar to the stupid strategy but invests in companies that experience higher growth (share variation++)
    /// Will take into account more data to invest more intelligently
    /// Problem: Most data is random at start (builder) and often continues to be (random components in most strategies) -> 
    /// Not easy to build something that is supposed to be "smarter" or at least "smart" when playing with randomly defined data!
    /// Implement history in Companies objects for tracking feature(!)
    /// </summary>
    [Serializable()]
    public class SmartStrategy : IStrategy
    {
        private Order Buy( Market market, Shareholder shareholder )
        {
            //Round count must be over 5
            //Roundcount == variationhistory.count
            int j = 0;                
            List<decimal> tmpData = new List<decimal>();

            for(int i = 0; i < market.companyList.Count; i++)
            {
                int f; 

                f = market.companyList[i].VariationHistory.Count;
                tmpData = market.companyList[i].VariationHistory.GetRange( f - 4, 4 );
                //Quick'N'Dirty - Needs refactoring
                for ( int d = 0; d < tmpData.Count; d++ )
                {
                    if ( tmpData[d] > 1 ) j++;
                }

                //For now, buying 10 shares for -5€ the current price, 
                //company chosen for its consistency during the last 4 rounds regarding its share variation (always > 1)
                if ( j == tmpData.Count )
                {
                    return new Order( Order.orderType.Buy, market.companyList[i].SharePrice - 5, 10, market.companyList[i], shareholder );
                }

                tmpData.Clear();
            }
            return null;
        }
        private Order Sell( Market market, Shareholder shareholder )
        {                
            List<decimal> tmpData = new List<decimal>();
            int j = 0;

            if ( market.RoundCount > 5 )
            {
                for ( int i = 0; i < shareholder.Portfolio.Count; i++ )
                {
                    int x = shareholder.Portfolio[i].Company.VariationHistory.Count;
                    tmpData = shareholder.Portfolio[i].Company.VariationHistory.GetRange( x - 5, 4 );

                    for ( int f = 0; f < tmpData.Count; f++ )
                    {
                        if ( tmpData[f] < -1 ) j++;
                    }

                    if ( j == tmpData.Count )
                    {
                        return new Order( Order.orderType.Sell, shareholder.Portfolio[i].ShareLastPurchaseValue + 5, 10%(shareholder.Portfolio[i].ShareCount), shareholder.Portfolio[i].Company, shareholder );
                    }
                }
            }
            else
            {
                for ( int u = 0; u < shareholder.Portfolio.Count; u++ )
                {
                    if ( shareholder.Portfolio[u].Company.ShareVariation < -1 )
                    {
                        return new Order( Order.orderType.Sell, shareholder.Portfolio[u].ShareLastPurchaseValue + 5, shareholder.Portfolio[u].ShareCount, shareholder.Portfolio[u].Company, shareholder );
                    }
                }
            }
            return null;
        }
        public Order MakeDecision( Market market, Shareholder shareholder )
        {
            if ( market.RoundCount > 5 )
            {
                if ( market.Random.Next( 2 ) == 1 ) return Buy( market, shareholder );
                else return Sell( market, shareholder );
            }
            else return Sell( market, shareholder );
        }

        public override string ToString()
        {
            string strat = "Smart Strategy";
            return strat;
        }
    }
}
