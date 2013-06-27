using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace INTECH_STOCK_EXCHANGE
{
    [Serializable]
    public class Market
    {
        List<Shareholder> _shareholders;
        List<Company> _companies;
        List<Order> _globalOrderbook;
        public Company SuperCompany;
        public Shareholder SuperShareholder;
        int _transactionCount = 0;
        readonly Random _random;

        [NonSerialized]
        EventHandler<EventArgs> _companyListChanged;
        [NonSerialized]
        EventHandler<EventArgs> _shareholdersListChanged;
        [NonSerialized]
        EventHandler<CompanyChangedArgs> _companyChanged;

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
            _random = new Random();
        }

        public event EventHandler<EventArgs> CompanyListChanged
        {
            add { _companyListChanged = (EventHandler<EventArgs>)Delegate.Combine( (Delegate)_companyListChanged, (Delegate)value ); }
            remove { _companyListChanged = (EventHandler<EventArgs>)Delegate.Remove( (Delegate)_companyListChanged, (Delegate)value ); }
        }

        public event EventHandler<EventArgs> ShareholdersListChanged
        {
            add { _shareholdersListChanged = (EventHandler<EventArgs>)Delegate.Combine( (Delegate)_shareholdersListChanged, (Delegate)value ); }
            remove { _shareholdersListChanged = (EventHandler<EventArgs>)Delegate.Remove( (Delegate)_shareholdersListChanged, (Delegate)value ); }
        }

        public event EventHandler<CompanyChangedArgs> CompanyChanged
        {
            add { _companyChanged = (EventHandler<CompanyChangedArgs>)Delegate.Combine( (Delegate)_companyChanged, (Delegate)value ); }
            remove { _companyChanged = (EventHandler<CompanyChangedArgs>)Delegate.Remove( (Delegate)_companyChanged, (Delegate)value ); }
        }

        void RaiseCompanyChanged( Company c )
        {
            var h = _companyChanged;
            if (h != null) h( this, new CompanyChangedArgs( c ) );
        }

        void RaiseShareholdersListChanged()
        {
            var h = _shareholdersListChanged;
            if (h != null) h( this, EventArgs.Empty );
        }

        void RaiseCompanyListChanged()
        {
            var h = _companyListChanged;
            if (h != null) h( this, EventArgs.Empty );
        }

        public IReadOnlyList<Company> Companies { get { return _companies; } }

        public Random Random { get { return _random; } }

        public void Save (string filename)
        {
            using (FileStream file = File.Open( filename, FileMode.OpenOrCreate ))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize( file, this );
            }
        }

        public Market Load( string filename )
        {
            using (FileStream file = File.Open( filename, FileMode.Open ))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Market market = (Market)formatter.Deserialize( file );
                return market;
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

        public List<Order> GlobalOrderbook
        {
            get { return _globalOrderbook; }
            internal set { _globalOrderbook = value; }
        }
 
        public void ClearOrderbook()
        //Clearing: 
        //- The outdated orders (by checking their expiration dates)
        //- The orders that found a match
        //- And prolly more...
        {
            List<Order> tmp = new List<Order>();

            foreach ( Order o in _globalOrderbook )
            {
                if ( o.OrderStatus != Order.Status.Dispatched && o.TimedOut == false)
                {             
                    tmp.Add( o );                  
                }
            }
            _globalOrderbook.Clear();
            _globalOrderbook = tmp;
        }
        public void MatchOrders()
        //Matching orders algorithm maximalizing transactions:
        //- Set the buyer/seller IDs to both orders properties when a deal's been made,
        //- Mark up the orders that found a match for further removal (Order.orderAvailability.Matched;)
        {
            foreach ( Order oBuy in _globalOrderbook )
            {
                if ( oBuy._orderType != Order.orderType.Buy ) continue;

                foreach ( Order oSell in _globalOrderbook )
                {
                    //Checking it is not the same person who made the 2 orders
                    if ( oBuy.OrderMaker == oSell.OrderMaker ) continue;

                    if ( oSell._orderType != Order.orderType.Sell ) continue;

                    // Checking if the orders are about the same company
                    if ( oBuy.Company != oSell.Company) continue;

                    if (oBuy.OrderShareQuantity == 0 || oSell.OrderShareQuantity == 0) continue;

                    if(oBuy.OrderSharePriceProposal >= oSell.OrderSharePriceProposal )
                    {
                        decimal exchangePrice = oBuy.OrderSharePriceProposal;    // our call!
                        int exchangeCount = Math.Min( oBuy.OrderShareQuantity, oSell.OrderShareQuantity );
                        exchangeCount = Math.Min(exchangeCount, (int)(oBuy.OrderMaker.Capital / exchangePrice));
                        int nbSellerShares = 0;

                        foreach (var s in oSell.OrderMaker.Portfolio)
                        {
                            if (s.Company == oSell.Company) nbSellerShares = s.ShareCount;
                        }

                        exchangeCount = Math.Min( exchangeCount, nbSellerShares );

                        if(exchangeCount > 0) MakeTransaction( oBuy, oSell, exchangeCount, exchangePrice );
                    }
                }
            }
            RaiseCompanyListChanged();
        }
  
        private void MakeTransaction( Order oBuy, Order oSell, int quantity, decimal price )
        {
            Debug.Assert( oBuy.Company == oSell.Company );
            Debug.Assert( oBuy.OrderMaker != oSell.OrderMaker );
            Debug.Assert( quantity > 0 );

            Shareholder buyer =  oBuy.OrderMaker;
            Shareholder seller = oSell.OrderMaker;
            Company company = oSell.Company;

            // Updating buyer info
            buyer.Capital = buyer.Capital - price * quantity;
            buyer.AlterPortfolio(Market.ActionType.Fill, quantity, company, buyer);

            // Updating seller info
            seller.Capital = seller.Capital + price * quantity;
            seller.AlterPortfolio(Market.ActionType.Empty, quantity, company, seller);

            // Updating market data
            UpdateMarketData( company, price );
            _transactionCount++;

            System.Diagnostics.Debug.WriteLine( "[TRANSACTION] : " + buyer.Name + " bought to " + seller.Name + " " + quantity + " shares of " + company.Name + " at " + price);
            System.Diagnostics.Debug.WriteLine("Transaction number : " + _transactionCount);
            
            oBuy.DecreaseOrderShareQuantity( quantity );
            oSell.DecreaseOrderShareQuantity( quantity );
            if ( oBuy.OrderShareQuantity == 0 ) oBuy.OrderStatus = Order.Status.Dispatched;
            if ( oSell.OrderShareQuantity == 0 ) oSell.OrderStatus = Order.Status.Dispatched;
        }

        //Currently: Defining the new company share price based upon the latest exchange in the market
        private void UpdateMarketData( Company company, decimal price )
        {
            decimal newVariation = ((price - company.SharePrice) / company.SharePrice)*100;
            company.ShareVariation = newVariation;

            company.SharePrice = price; 
        }
        public String OrderBookToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach ( Order order in _globalOrderbook )
            {
                sb.Append(order._orderType ).AppendLine();
                sb.Append( "\t" ).Append( order.Company.Name ).AppendLine();
                sb.Append( "\t" ).Append( "SP : " ).Append( order.Company.SharePrice).AppendLine();
                sb.Append( "\t" ).Append( "Q : " ).Append( order.OrderShareQuantity ).AppendLine();
                sb.Append( "\t" ).Append( "Prop : " ).Append( order.OrderSharePriceProposal ).AppendLine();
            }
            return sb.ToString();
        }
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach ( Shareholder shareholder in _shareholders )
            {
                sb.Append( shareholder.Name ).AppendLine();
                foreach ( Shareholder.PortfolioItem share in shareholder.Portfolio )
                {
                    sb.Append("\t").Append( share.Company.Name ).Append( " : " ).Append( share.ShareCount ).AppendLine();
                }
            }
            return sb.ToString();
        }

        public Order.orderType EstimateOrderbookBalance(Market market)
        {
            int buy = 0;
            int sell = 0;

            foreach(Order o in _globalOrderbook)
            {
                if ( o.GetOrderType == Order.orderType.Buy ) buy++;
                else if ( o.GetOrderType == Order.orderType.Sell ) sell++;
            }
            if ( buy > sell ) return Order.orderType.Sell;
            else return Order.orderType.Buy;
        }

        public void AddOrUpdateCompany( string name, Company.Industry ind, decimal shareValue, int sharevolume )
        {
            Company c = _companies.FirstOrDefault( company => company.Name == name );
            if (c == null)
            {
                c = new Company( this, name, ind, shareValue, sharevolume );
                _companies.Add( c );
                RaiseCompanyListChanged();
            }
            else if (c.SharePrice != shareValue)
            {
                c.SharePrice = shareValue;
                RaiseCompanyChanged( c );
            }
        }

        public void AddShareholders(List<Shareholder> shareholdersListToAdd)
        {
            RaiseShareholdersListChanged();
        }

        public void ChangeCompanyName(string oldName, string newName)
        {
            foreach (var c in _companies)
            {
                if (c.Name == oldName)
                {
                    c.Name = newName;
                    RaiseCompanyListChanged();
                    return;
                }
            }
        }

        public bool CheckNameCompany (string Name)
        {
            foreach (var c in _companies)
            {
                if (c.Name == Name)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateCompanyPrice(string name, decimal newPrice)
        {
            foreach (var c in _companies)
            {
                if (c.Name == name)
                {
                    c.SharePrice = newPrice;
                    RaiseCompanyChanged( c );
                    return;
                }
            }
        }

        public void AddOrUpdateShareholders( string name, decimal money )
        {
            Shareholder c = _shareholders.FirstOrDefault( company => company.Name == name );
            if (c == null)
            {
                c = new Shareholder( this, name, money );
                _shareholders.Add( c );
                RaiseShareholdersListChanged();
            }
            //else if (c.SharePrice != shareValue)
            //{
            //    c.SharePrice = shareValue;
            //    var h = CompanyChanged;
            //    if (h != null)
            //    {
            //        CompanyChangedArgs e = new CompanyChangedArgs( c );
            //        h( this, e );
            //    }
            //}
        }

        public List<string> companyNames = new List<string>
        {
            "Lafarge",
            "Safran",
            "Publicis",
            "Alstom",
            "EDF",
            "Solvay",
            "Capgemini",
            "CréditAgricole",
            "Bouygues",
            "Accor",
            "Vallourec",
            "Veolia",
            "STMicroelectronics",
            "Gemalto",
            "Blizzard",
            "Akamai",
            "Amazon",
            "Amgen",
            "Apple",
            "Autodesk",
            "Broadcom",
            "Cephalon",
            "Cisco",
            "Comcast",
            "Dell",
            "eBay",
            "EA",
            "Garmin",
            "Google",
            "Intel",
            "Juniper",
            "Logitech",
            "Microsoft",
            "Monster",
            "NetApp",
            "Nvidia",
            "Oracle",
            "Ryanair",
            "SanDisk",
            "Starbucks",
            "LinkedIn",
            "Invenietis",
            "Sun",
            "Oaken",
            "Atos",
            "Neurones",
            "Steria",
            "TalentSoft",
            "Thales",
            "Total"
        };
    }
}