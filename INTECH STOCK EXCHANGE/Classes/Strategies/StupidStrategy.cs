using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public class StupidStrategy : IStrategy
    {
        //The stupid strategy consists of buying 1 share of a company that has its share variation superior to 1.0M
        //Checking the cash of the s/h as well
        //Define price proposition according to share variation (buy/sell)

        private Order checkInvest(Market market, Shareholder shareholder)
        {      
            //BUYING
            int i;
            List<Company> targetList = new List<Company>();
            foreach ( Company c in market.companyList )
            {
                if ( c.ShareVariation >= 1.0M ) targetList.Add( c );
            }
            Random index = new Random();
            i = index.Next( targetList.Count );
            Company target = targetList[ i ];

            decimal priceProp = target.SharePrice * ((target.ShareVariation/100) + 1);
            
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
            int max = (int) (mentalState * shareholder.Capital);
            int quantity = (int) (max/priceProp);
            return new Order( Order.orderType.Buy, priceProp, quantity, target, shareholder );
        }
        private Order checkSelling( Market market, Shareholder shareholder )
        {
            //SELLING
            List<Shareholder.pItem> targetList = new List<Shareholder.pItem>();
            decimal mentalState;

            foreach ( Shareholder.pItem share in shareholder._portfolio )
            {
                if ( share.company.ShareVariation < -1.0M ) targetList.Add( share );
            }
            Random y = new Random();
            int index = y.Next(targetList.Count);
            if ( index > 0 )
            {
                Shareholder.pItem target = targetList.ElementAt( index );

                decimal priceProp = target.company.SharePrice * ((target.company.ShareVariation / 100) + 1);
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

                int quantity = (int)(mentalState * (target.shareCount));
                return new Order( Order.orderType.Sell, priceProp, quantity, target.company, shareholder );
            }
            else return null;
       }
       public Order MakeDecision( Market market, Shareholder shareholder )
       {
            if ( market.globalOrderbook.Count > 2 )
            {
                Order.orderType checkingOrderTypes = market.EstimateOrderbookBalance( market );
                if ( checkingOrderTypes == Order.orderType.Buy )
                {
                    return checkInvest( market, shareholder );
                }
                else
                {
                    return checkSelling( market, shareholder );
                }
            }
            else
            {
               return checkInvest( market, shareholder );
            }        
        }
    }
}
