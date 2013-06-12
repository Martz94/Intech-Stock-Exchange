using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace INTECH_STOCK_EXCHANGE
{
    [Serializable()]
    public class StupidStrategy : IStrategy
    {
        //The stupid strategy consists of buying 1 share of a company that has its share variation superior to 1.0M
        //Checking the cash of the s/h as well
        //Define price proposition according to share variation (buy/sell)

        private Order Buy( Market market, Shareholder shareholder )
        {
            //BUYING
            int i;
            List<Company> targetList = new List<Company>();
            foreach ( Company c in market.companyList )
            {
                if ( c.ShareVariation >= 3.0M ) targetList.Add( c );
            }
            Random index = market.Random;
            if (targetList.Count > 0)
            {
                i = index.Next( targetList.Count );
                Company target = targetList[i];

                decimal priceProp = target.SharePrice * ((target.ShareVariation / 100) + 1);

                decimal mentalState;

                if (shareholder.GetRiskIndex == Shareholder.RiskTaker.Crazy)
                {
                    mentalState = 0.75M;
                }
                else if (shareholder.GetRiskIndex == Shareholder.RiskTaker.Cautious)
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

            foreach ( Shareholder.PortfolioItem share in shareholder._portfolio )
            {
                if ( share.Company.ShareVariation < -1.0M ) targetList.Add( share );
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
        }
        public Order MakeDecision( Market market, Shareholder shareholder )
        {
            if ( market.Random.Next( 2 ) == 1 ) return Buy( market, shareholder );
            else return Sell( market, shareholder );
        }
    }
}
