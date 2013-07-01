using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class SmartStrategy : IStrategy
    {
        private Order Buy( Market market, Shareholder shareholder )
        {
            //BUYING
            int i;
            List<Company> targetList = new List<Company>();
            foreach ( Company c in market.companyList )
            {
                if ( c.ShareVariation >= 5.0M ) targetList.Add( c );
            }
            Random index = market.Random;
            if ( targetList.Count > 0 )
            {
                i = index.Next( targetList.Count );
                Company target = targetList[i];

                decimal priceProp = target.SharePrice * ((target.ShareVariation / 100) + 1);

                decimal mentalState;

                if ( shareholder.GetRiskIndex == Shareholder.RiskTaker.Crazy )
                {
                    mentalState = 0.75M;
                }
                else if ( shareholder.GetRiskIndex == Shareholder.RiskTaker.Cautious )
                {
                    mentalState = 0.15M;
                }
                else
                {
                    mentalState = 0.50M;
                }
                int max = (int)(mentalState * shareholder.Capital);
                int quantity = (int)(max / priceProp);
                return new Order( Order.orderType.Buy, priceProp, quantity, target, shareholder );
            }
            else return null;
        }
        private Order Sell( Market market, Shareholder shareholder )
        {
            //SELLING
            List<Shareholder.PortfolioItem> targetList = new List<Shareholder.PortfolioItem>();
            decimal mentalState;

            foreach ( Shareholder.PortfolioItem share in shareholder.Portfolio )
            {
                if ( share.Company.ShareVariation < -4.0M ) targetList.Add( share );
            }
            Random y = market.Random;
            if ( targetList.Count > 0 )
            {
                int index = y.Next( targetList.Count );
                Shareholder.PortfolioItem target = targetList[index];

                decimal priceProp = target.Company.SharePrice * ((target.Company.ShareVariation / 100) + 1);
                if ( shareholder.GetRiskIndex == Shareholder.RiskTaker.Crazy )
                {
                    mentalState = 0.75M;
                }
                else if ( shareholder.GetRiskIndex == Shareholder.RiskTaker.Cautious )
                {
                    mentalState = 0.15M;
                }
                else
                {
                    mentalState = 0.50M;
                }
                int quantity = (int)(mentalState * (target.ShareCount));
                return new Order( Order.orderType.Sell, priceProp, quantity, target.Company, shareholder );
            }
            else return null;
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
