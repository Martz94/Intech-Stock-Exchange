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
            //- Pick a priceProp according to the state of mind of the s/h,
            //- Pick a quantity according to the priceProp and initial firm share price.

            Random properties = new Random();
            decimal mentalState;

            if ( shareholder.GetRiskIndex == Shareholder.RiskTaker.Crazy )
            {
                mentalState = 0.75M;
            }
            else if( shareholder.GetRiskIndex == Shareholder.RiskTaker.Cautious )
            {
                mentalState = 0.15M;
            }
            else
            {
                mentalState = 0.50M;
            }

            int i = properties.Next( 1, market.companyList.Count );
            Company firm = market.companyList[i];

            int max = (int)(mentalState * shareholder.Capital);
            int quantity = (int)(max / firm.SharePrice);
            decimal priceProp = max / quantity;

            if(priceProp * quantity < shareholder.Capital) return new Order(Order.orderType.Buy, priceProp, quantity, firm, shareholder); 
            else return null;
        }

        private Order RandomSell( Market market, Shareholder shareholder )
        {
            //RandomSell Strategy
            //- Pick a company in the portfolio,
            //- Pick a random number of share count to sell,
            //- Pick a random price.

            int i;
            decimal priceProp;
            decimal mentalState;
            int quantity;
            Company firm;
            Shareholder.pItem share = new Shareholder.pItem();
            Random r = new Random();
            int k = r.Next( shareholder._portfolio.Count ); 

            if(k > -1)
            {
                share = shareholder._portfolio.ElementAt(k);
            }
            if ( shareholder.GetRiskIndex == Shareholder.RiskTaker.Cautious ) mentalState = 1.15M;
            else if ( shareholder.GetRiskIndex == Shareholder.RiskTaker.Bold ) mentalState = 1.50M;
            else mentalState = 1.7M;

            priceProp = mentalState * share.company.SharePrice;
            quantity = (int)(0.5 * share.shareCount);
            firm = share.company;

            return new Order( Order.orderType.Sell, priceProp, quantity, firm, shareholder );
        }
        public Order MakeDecision(Market market, Shareholder shareholder)
        {
            //return RandomBuy( market, shareholder );
            Random random = new Random();
            int i = random.Next( 0, 10 );
            if ( i > 5 ) return RandomBuy( market, shareholder );
            else return RandomSell( market, shareholder );            
        }
    }
}
