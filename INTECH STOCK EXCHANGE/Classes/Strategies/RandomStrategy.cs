using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public class RandomStrategy : IStrategy
    {
        private Order RandomBuy(Market market, Shareholder shareholder)
        {
            // RandomBuy Strategy:
            //- Pick the company randomly,
            //- Pick a quantity according to the priceProp and initial firm share price.
            //- Pick the company price - 5

            Random properties = market.Random;
            double q = properties.NextDouble();
            q++;
            int i = properties.Next( 0, market.companyList.Count );
            Company firm = market.companyList[i];

            double max = (int)(q * (double)shareholder.Capital);
            int quantity = (int)(max / (double)firm.SharePrice);
            decimal priceProp = (decimal)(max / (double)quantity);

            if(priceProp * quantity < shareholder.Capital) return new Order(Order.orderType.Buy, priceProp - 5, quantity, firm, shareholder); 
            else return null;
        }

        private Order RandomSell( Market market, Shareholder shareholder )
        {
            //RandomSell Strategy
            //- Pick a company in the portfolio,
            //- Pick a random number of share count to sell,
            //- Pick the company share price + 5.

            decimal priceProp;
            int quantity;
            Company firm;
            Shareholder.pItem share = new Shareholder.pItem();
            Random r = market.Random;
            int k = r.Next( shareholder._portfolio.Count );

            if ( k > -1 )
            {
                share = shareholder._portfolio[k];
                priceProp = share.company.SharePrice + 5;
                quantity = (int)(0.5 * share.shareCount);
                firm = share.company;
                return new Order( Order.orderType.Sell, priceProp, quantity, firm, shareholder );
            }
            else return null;            
        }
        public Order MakeDecision(Market market, Shareholder shareholder)
        {
            if ( market.Random.Next( 2 ) == 1 ) return RandomBuy( market, shareholder );
            else return RandomSell( market, shareholder );            
        }
    }
}
