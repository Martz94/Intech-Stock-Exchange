using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace INTECH_STOCK_EXCHANGE
{
    [Serializable()]
    public class RandomStrategy : IStrategy
    {
        private Order RandomBuy(Market market, Shareholder shareholder)
        {
            // RandomBuy Strategy:
            //- Pick the company randomly,
            //- Pick a quantity according to the priceProp and initial firm share price.

            Random properties = market.Random;
            double q = properties.NextDouble();
            q++;
            int i = properties.Next( 0, market.companyList.Count );
            Company firm = market.companyList[i];
            decimal priceProp = firm.SharePrice * (properties.Next( 201 ) + 899) / 1000;
            double max = (int)(q * (double)shareholder.Cash);
            int quantity = properties.Next( Math.Abs((int)((max / (double)priceProp))) );

            if(priceProp * quantity < shareholder.Cash) return new Order(Order.orderType.Buy, priceProp, quantity, firm, shareholder); 
            else return null;
        }
        public override string ToString()
        {
            string strat = "Random Strategy";
            return strat.ToString();
        }
        private Order RandomSell( Market market, Shareholder shareholder )
        {
            //RandomSell Strategy
            //- Pick a company in the portfolio,
            //- Pick a random number of share count to sell,

            decimal priceProp;
            int quantity;
            Company firm;
            Shareholder.PortfolioItem share = new Shareholder.PortfolioItem();
            Random r = market.Random;
            int k = r.Next( shareholder.Portfolio.Count );

            if ( k > -1 && shareholder.Portfolio.Count > 0)
            {
                share = shareholder.Portfolio[k];
                priceProp = share.Company.SharePrice * (r.Next( 201 ) + 899) / 1000;
                quantity = (int)(0.5 * share.ShareCount);
                firm = share.Company;

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
