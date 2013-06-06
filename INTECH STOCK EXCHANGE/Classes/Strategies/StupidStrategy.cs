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

        private Order checkInvest(Market market, Shareholder shareholder)
        {      
            //BUYING
            int i;
            decimal price;
            int f = -1;
            for ( i = 0; i < market.companyList.Count; i++ )
            {
                if ( market.companyList[i].ShareVariation >= 1.0M )
                {
                    f = i;                   
                }
            }
            if ( f != -1 )
            {
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
                price = market.companyList[f].SharePrice - 5.0M;
                int quantity = (int) (max/price);
                return new Order( Order.orderType.Buy, price, quantity, market.companyList[f], shareholder );
            }
            return null; //No order for this round!
         }
        private Order checkSelling( Market market, Shareholder shareholder )
        {
            //SELLING
            foreach ( Shareholder.pItem x in shareholder._portfolio )
            {
                Company company = x.company;
                decimal lastPrice = company.SharePrice;

                if ( company.ShareVariation <= -1.0M )
                {
                    decimal price = x.shareLastPurchaseValue + 5.0M;
                    int quantity = (int)(0.5 * (x.shareCount));
                    return new Order( Order.orderType.Sell, price, quantity, company, shareholder );
                }
            }
            return null;         
        }

        public Order MakeDecision( Market market, Shareholder shareholder )
        {
            if ( market.globalOrderbook.Count > 2 )
            {
                Order.orderType checkingOrderTypes = market.EstimateOrderbookBalance( market );
                if ( checkingOrderTypes == Order.orderType.Buy )
                {
                    Order order = checkInvest( market, shareholder );
                    return order;
                }
                else
                {
                    Order order = checkSelling( market, shareholder );
                    return order;
                }
            }
            else
            {
                Order order = checkInvest( market, shareholder );
                return order;
            }        
        }
    }
}
