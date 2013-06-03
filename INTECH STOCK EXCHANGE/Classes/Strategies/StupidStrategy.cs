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
                //check cash
                decimal price = market.companyList[f].SharePrice - 5.0M;
                int quantity = 10;
                return new Order( Order.orderType.Buy, price, quantity, market.companyList[f], shareholder );
            }
 
            return null; //No order for this round!
         }

        //(1 ORDER/SHAREHOLDER/ROUND FOR STARTERS)

        private Order checkSelling( Market market, Shareholder shareholder )
        {
            //SELLING
            foreach ( Shareholder.pItem x in shareholder._portfolio )
            {
                Company company = x.company;
                decimal lastPrice = company.SharePrice;
                decimal shareVariation = company.ShareVariation;

                if ( shareVariation <= -1.0M )
                {
                    decimal price = x.shareLastPurchaseValue + 5.0M;
                    int quantity = (int)(0.5 * (x.shareCount));
                    return new Order( Order.orderType.Sell, price, quantity, x.company, shareholder );
                }
            }
            return null;
           
        }

        public Order MakeDecision( Market market, Shareholder shareholder )
        {
            Order order = checkInvest( market, shareholder );
            if ( order == null ) order = checkSelling( market, shareholder );
            return null;    // no order required
        }
    }
}
