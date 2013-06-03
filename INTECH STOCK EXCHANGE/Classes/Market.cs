using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace INTECH_STOCK_EXCHANGE
{
    public class Market
    {
        bool _orderCount = false;
        List<Shareholder> _shareholders;
        List<Company> _companies;
        List<Order> _globalOrderbook;
        Order order;
        Company company;
        Timer round;
        //List<MatchOrders> _matchOrders;
        //public Dictionary<Guid, List<Order>> _sellOrders;
        //public Dictionary<Guid, List<Order>> _buyOrders;
        Shareholder.pItem share;

        public enum ActionType
        {
            Fill,
            Empty,
        }
      
        public Market()
        {
            _globalOrderbook = new List<Order>();
            _shareholders = new List<Shareholder>();
            _companies = new List<Company>();
            //_matchOrders = new List<MatchOrders>();     
        }
        public void AlterPortfolio( Market.ActionType actionType, int shareCount, Company firm, Shareholder sh )
        //Called when:
        //- The market opens for the 1st time,
        //- Transactions need to be made,

        // (!) automatically creates a new struct in the portfolio if the s/h does not already hold at least 1 action of the firm
        // (!) automatically removes a struct if the s/h holds 0 action of the firm
        {
            if(actionType == Market.ActionType.Fill)
            {
                int i;
                int f = -1;
                for(i = 0; i < sh._portfolio.Count; i++)
                {
                    if(sh._portfolio[i].company == firm)
                    {
                        f = i;
                    }
                }
                if(f != -1)
                {
                    Shareholder.pItem p = sh._portfolio[f];
                    p.shareCount = p.shareCount + shareCount;
                    share.shareLastPurchaseValue = firm.SharePrice;// last purchase price kept
                    share.lastBuyDate = new DateTime();     // last purchase date
                    sh._portfolio[f] = p;
                }
                else                 
                {                   
                    share = new Shareholder.pItem();
                    share.shareCount = shareCount;
                    share.shareLastPurchaseValue = firm.SharePrice;
                    share.company = firm;
                    share.lastBuyDate = new DateTime(); 
                    sh._portfolio.Add( share );                
                }                
            }

            else if(actionType == Market.ActionType.Empty)
            {
                int i;
                int f = -1;
                for(i = 0; i < sh._portfolio.Count; i++)
                {
                    if(sh._portfolio[i].company == firm)
                    {
                        f = i;
                    }
                    else throw new ArgumentException("The s/h is trying to sell a sharecount he does not possess");
                }
                if(f != -1)
                {
                    Shareholder.pItem p = sh._portfolio[f];
                    p.shareCount = p.shareCount - shareCount;
                    if(p.shareCount == 0)
                    {
                        sh._portfolio.RemoveAt(f);
                    }
                    else if(p.shareCount > 0)
                    {   
                        sh._portfolio[f] = p;
                    }
                }
                else           
                {                   
                    share = new Shareholder.pItem();
                    share.shareLastPurchaseValue = firm.SharePrice;
                    share.company = firm;
                    share.shareCount = shareCount;
                    share.lastBuyDate = new DateTime(); 
                    sh._portfolio.Add( share );                
                }                
            }
            else
            {
                throw new ArgumentException("ActionType to portfolio invalid");
            }           
        }
        //public List<MatchOrders> MatchOrders
        //{
        //    get
        //    {
        //        return _matchOrders;
        //    }
        //}
        public bool minimumOrderCount()
        {
            //Checking in the order book whether there is enough potential orders to open the market
            //If so, then _orderCount goes "true"
            if ( _globalOrderbook.Count > 20 )
            {
                return _orderCount = true;
            }
            else
            {
                return _orderCount;
            }
        }

        public List<Company> companyList
        {
            get { return _companies; }
        }
        public List<Shareholder> shareholderList
        {
            get { return _shareholders; }
        }
        public List<Order> globalOrderbook
        {
            get { return _globalOrderbook; }
            set { _globalOrderbook = value; }
        }

        public void start()
        {
            round.Enabled = true;
            round.Start();
            round.Interval = 2500; //0.5 times the order timout
        }

        //public void SellBuy()
        //{
        //    int nbtransactions;
        //    int nbselltransaction;
        //    int nbbuytransaction;

        //    foreach (Company c in _companies)
        //    {
        //        nbtransactions = 0;
        //        nbselltransaction = 0;

        //        foreach (Order o in _sellOrders[c.GetID])
        //        {
        //            if (o.GetOrderSharePriceProposal <= c.GetSharePrice)
        //            {
        //                nbselltransaction += o.GetOrderShareQuantity;
        //            }
        //        }

        //        nbbuytransaction = 0;
        //        foreach (Order o in _buyOrders[c.GetID])
        //        {
        //            if (o.GetOrderSharePriceProposal >= c.GetSharePrice)
        //            {
        //                nbbuytransaction += o.GetOrderShareQuantity;
        //            }
        //        }

        //        if (nbbuytransaction > nbselltransaction)
        //        {
        //            nbtransactions = nbselltransaction;
        //        }
        //        else
        //        {
        //            nbtransactions = nbbuytransaction;
        //        }

        //        int tmp = nbtransactions;
        //        foreach (Order o in _sellOrders[c.GetID])
        //        {
        //            if (o.GetOrderSharePriceProposal <= c.GetSharePrice)
        //            {
        //                for (int i = 0; i < _shareholders.Count ;i++)
        //                {
        //                    if (_shareholders[i].GetID == o.OrderReceiverID)
        //                    {
        //                        if (tmp > o.GetOrderShareQuantity)
        //                        {
        //                            _shareholders[i].Capital += c.GetSharePrice * o.GetOrderShareQuantity;
        //                            tmp -= o.GetOrderShareQuantity;
        //                            // retirer actions dans portfolio
        //                        }
        //                        else
        //                        {
        //                            _shareholders[i].Capital += c.GetSharePrice * tmp;
        //                            tmp = 0;
        //                            // retirer actions dans portfolio
        //                        }
        //                    }
        //                }
        //            }
        //        }

                //tmp = nbtransactions;
            //    foreach (Order o in _buyOrders[c.GetID])
            //    {
            //        if (o.GetOrderSharePriceProposal >= c.GetSharePrice)
            //        {
            //            for (int i = 0; i < _shareholders.Count; i++)
            //            {
            //                if (_shareholders[i].GetID == o.OrderBuyerID)
            //                {
            ////                    if (tmp > o.GetOrderShareQuantity)
            //                    {
            //                        _shareholders[i].Capital -= c.GetSharePrice * o.GetOrderShareQuantity;
            //                        tmp -= o.GetOrderShareQuantity;
            //                        _shareholders[i].FillPortfolio( o.GetOrderShareQuantity, c );
            //                    }
            //                    else
            //                    {
            //                        _shareholders[i].Capital -= c.GetSharePrice * tmp;
            //                        tmp = 0;
            //                        _shareholders[i].FillPortfolio( tmp, c );
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        

        //public void SortOrders()
        //{
        //    _sellOrders = new Dictionary<Guid,List<Order>>();
        //    _buyOrders = new Dictionary<Guid, List<Order>>();

        //    foreach (Company c in _companies)
        //    {
        //        _sellOrders.Add( c.GetID, new List<Order>() );
        //        _buyOrders.Add( c.GetID, new List<Order>() );
        //    }

        //    foreach (Order o in _globalOrderbook)
        //    {
        //        if (o._orderType == Order.orderType.Buy)
        //        {
        //            _buyOrders[o.GetSharesCompanyID].Add( o );
        //        }
        //        else
        //        {
        //            _sellOrders[o.GetSharesCompanyID].Add( o );
        //        }
        //    }
        //}

        //public void DefineNewPrice()
        //{
        //    Dictionary<decimal, int> nbtransactions = new Dictionary<decimal,int>();
        //    int nbselltransaction;
        //    int nbbuytransaction = 0;
        //    decimal priceTransaction = 0;
        //    int nbtransaction = 0;

        //    SortOrdersByPrice();

        //    foreach (Company c in companyList)
        //    {
        //        for (int i = 0; i < _buyOrders[c.GetID].Count ;i++)
        //        {
        //            nbbuytransaction += _buyOrders[c.GetID][i].GetOrderShareQuantity;
        //            nbselltransaction = 0;

        //            for (int j = 0; j < _sellOrders[c.GetID].Count && _sellOrders[c.GetID][j].GetOrderSharePriceProposal >= _buyOrders[c.GetID][i].GetOrderSharePriceProposal ;j++)
        //            {
        //                nbselltransaction += _sellOrders[c.GetID][j].GetOrderShareQuantity;
        //            }

        //            if (nbselltransaction < nbbuytransaction)
        //            {
        //                nbtransactions.Add( _buyOrders[c.GetID][i].GetOrderSharePriceProposal, nbselltransaction );
        //            }
        //            else
        //            {
        //                nbtransactions.Add( _buyOrders[c.GetID][i].GetOrderSharePriceProposal, nbbuytransaction );
        //            }
        //        }

        //        foreach (var p in nbtransactions)
        //        {
        //            if (p.Value > nbtransaction)
        //            {
        //                nbtransaction = p.Value;
        //                priceTransaction = p.Key;
        //            }
        //            c.GetSharePrice = priceTransaction;
        //        }
        //    }
        //}

        //public void SortOrdersByPrice()
        //{
        //    Order tmp;
        //    foreach (var keyvalue in _buyOrders)
        //    {
        //        for (int i = 0; i < keyvalue.Value.Count; i++)
        //        {
        //            for (int j = i + 1; j < keyvalue.Value.Count; j++)
        //            {
        //                if (keyvalue.Value[i].GetOrderSharePriceProposal > keyvalue.Value[j].GetOrderSharePriceProposal)
        //                {
        //                    tmp = keyvalue.Value[i];
        //                    keyvalue.Value[i] = keyvalue.Value[j];
        //                    keyvalue.Value[j] = tmp;
        //                }
        //            }
        //        }
        //    }
        //    foreach (var keyvalue in _sellOrders)
        //    {
        //        for (int i = 0; i < keyvalue.Value.Count; i++)
        //        {
        //            for (int j = i + 1; j < keyvalue.Value.Count; j++)
        //            {
        //                if (keyvalue.Value[i].GetOrderSharePriceProposal > keyvalue.Value[j].GetOrderSharePriceProposal)
        //                {
        //                    tmp = keyvalue.Value[i];
        //                    keyvalue.Value[i] = keyvalue.Value[j];
        //                    keyvalue.Value[j] = tmp;
        //                }
        //            }
        //        }
        //    }
        //}

        public void Clear()
        //(!) Keeping track on how many rounds each order undergo before being cleared from the orderbook
        //Clearing: 
        //- The outdated orders (by checking their internal timer)
        //- The orders that found a match
        //- And prolly more...
        {
            List<Order> tmp = new List<Order>();

            foreach ( Order o in _globalOrderbook )
            {
                if ( o.OrderStatus != Order.orderStatus.Dispatched || o.TimedOut != false)
                {             
                    tmp.Add( o );                  
                }
            }
            _globalOrderbook.Clear();
            _globalOrderbook = tmp;
            tmp.Clear();
        }
        public void MatchOrders()
        //Matching orders algorithm maximalizing transactions:
        //- Set the buyer/seller IDs to both orders properties when a deal's been made,
        //- Mark up the orders that found a match for further removal (Order.orderAvailability.Matched;)
        {
            foreach ( Order o1 in _globalOrderbook )
            {
                if ( o1._orderType != Order.orderType.Buy ) continue;

                foreach ( Order o2 in _globalOrderbook )
                {
                    //Checking it is not the same person who made the 2 orders
                    if ( o1.GetOrderMakerID == o2.GetOrderMakerID ) continue;

                    if ( o2._orderType != Order.orderType.Sell ) continue;

                    // Checking if the orders are about the same company
                    if ( o1.Company == o2.Company 
                        && o1.GetOrderSharePriceProposal >= o2.GetOrderSharePriceProposal
                        && o1.GetOrderShareQuantity <= o2.GetOrderShareQuantity)
                    {
                        decimal price = o1.GetOrderSharePriceProposal;    // our decision!
                        MakeTransaction( o1.GetOrderMakerID, o2.GetOrderMakerID, o1.Company, o1.GetOrderShareQuantity, price );
                        o1.OrderStatus = Order.orderStatus.Dispatched;

                       //TODO o2.decreaseOrderQuantity(o1.GetOrderShareQuantity);
                        if (o2.GetOrderShareQuantity == 0) o2.OrderStatus = Order.orderStatus.Dispatched;
                    }
                }
            }
        }

        private Shareholder getShareholderById( Guid id )
        {
            foreach ( Shareholder s in _shareholders )
            {
                if ( id == s.GetID ) return s;
            }
            throw new ArgumentException();
        }

      
        private void MakeTransaction( Guid buyerId, Guid sellerId, Company company, int quantity, decimal price )
        {
            Shareholder buyer = getShareholderById(buyerId);
            Shareholder seller = getShareholderById(sellerId);

            // Updating buyer info
            buyer.Capital = buyer.Capital - price * quantity;
            this.AlterPortfolio(Market.ActionType.Fill, quantity, company, buyer);

            // Updating seller info
            seller.Capital = seller.Capital + price * quantity;
            this.AlterPortfolio(Market.ActionType.Empty, quantity, company, seller);

            // Updating market data
            UpdateMarketData( company, price );

            System.Diagnostics.Debug.WriteLine( "TRANSACTION : " + company.Name + " " + quantity + " shares sold at " + price);
        }

        //Currently: Defining the new company share price based upon the latest exchange in the market
        private void UpdateMarketData( Company company, decimal price )
        {
            //Share variation definition needs re-coding taking into account the cash difference between current price and price proposal
            if ( price > company.SharePrice )
            {
                company.ShareVariation = 1.0M;
            }
            else
            {
                company.ShareVariation = -1.0M;
            }
            company.SharePrice = price; 
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach ( Shareholder shareholder in _shareholders )
            {
                sb.Append( shareholder.Name ).AppendLine();
                foreach ( Shareholder.pItem share in shareholder._portfolio )
                {
                    sb.Append("\t").Append( share.company.Name ).Append( " : " ).Append( share.shareCount ).AppendLine();
                }
            }
            return sb.ToString();
        }
    }
}