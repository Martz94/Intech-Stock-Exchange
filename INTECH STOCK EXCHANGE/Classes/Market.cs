using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Company SuperCompany;
        public Shareholder SuperShareholder;
        Shareholder.pItem share;
        int _transactionCount = 0;
        readonly Random _random;

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

        public event EventHandler<EventArgs> CompanyListChanged;

        public event EventHandler<EventArgs> ShareholdersListChanged;

        public event EventHandler<CompanyChangedArgs> CompanyChanged;

        public IReadOnlyList<Company> Companies { get { return _companies; } }

        public Random Random { get { return _random; } }

        public void AlterPortfolio( Market.ActionType actionType, int shareCount, Company firm, Shareholder sh )
        //Called when:
        //- The market opens for the 1st time,
        //- Transactions need to be made,

        // (!) automatically creates a new struct in the portfolio if the s/h does not already hold at least 1 action of the firm
        // (!) automatically removes a struct if the s/h holds 0 action of the firm
        {
            Debug.Assert( firm != null );

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
 
        public void Clear()
        //(!) Keeping track on how many rounds each order undergo before being cleared from the orderbook
        //Clearing: 
        //- The outdated orders (by checking their expiration dates)
        //- The orders that found a match
        //- And prolly more...
        {
            List<Order> tmp = new List<Order>();

            foreach ( Order o in _globalOrderbook )
            {
                if ( o.OrderStatus != Order.orderStatus.Dispatched && o.TimedOut == false)
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

                        MakeTransaction( oBuy, oSell, exchangeCount, exchangePrice );
                    }
                }
            }
            var h = CompanyListChanged;
            if (h != null) h( this, EventArgs.Empty );
        }
  
        private void MakeTransaction( Order oBuy, Order oSell, int quantity, decimal price )
        {
            Debug.Assert( oBuy.Company == oSell.Company );
            Debug.Assert( oBuy.OrderMaker != oSell.OrderMaker );

            Shareholder buyer =  oBuy.OrderMaker;
            Shareholder seller = oSell.OrderMaker;
            Company company = oSell.Company;

            // Updating buyer info
            buyer.Capital = buyer.Capital - price * quantity;
            this.AlterPortfolio(Market.ActionType.Fill, quantity, company, buyer);

            // Updating seller info
            seller.Capital = seller.Capital + price * quantity;
            this.AlterPortfolio(Market.ActionType.Empty, quantity, company, seller);

            // Updating market data
            UpdateMarketData( company, price );
            _transactionCount++;

            oBuy.DecreaseOrderShareQuantity( quantity );
            oSell.DecreaseOrderShareQuantity( quantity );
            if ( oBuy.OrderShareQuantity == 0 ) oBuy.OrderStatus = Order.orderStatus.Dispatched;
            if ( oSell.OrderShareQuantity == 0 ) oSell.OrderStatus = Order.orderStatus.Dispatched;

            System.Diagnostics.Debug.WriteLine( "[TRANSACTION] : " + buyer.Name + " bought to " + seller.Name + " " + quantity + " shares of " + company.Name + " at " + price);
            System.Diagnostics.Debug.WriteLine("Transaction number : " + _transactionCount);
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
                foreach ( Shareholder.pItem share in shareholder._portfolio )
                {
                    sb.Append("\t").Append( share.company.Name ).Append( " : " ).Append( share.shareCount ).AppendLine();
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
                var h = CompanyListChanged;
                if (h != null) h( this, EventArgs.Empty );
            }
            else if (c.SharePrice != shareValue)
            {
                c.SharePrice = shareValue;
                var h = CompanyChanged;
                if (h != null)
                {
                    CompanyChangedArgs e = new CompanyChangedArgs( c );
                    h( this, e );
                }
            }
        }

        public void AddShareholders(List<Shareholder> shareholdersListToAdd)
        {

            _shareholders.AddRange(shareholdersListToAdd);
            var h = ShareholdersListChanged;
            if (h != null) h( this, EventArgs.Empty );
        }

        public void ChangeCompanyName(string oldName, string newName)
        {
            foreach (var c in _companies)
            {
                if (c.Name == oldName) c.Name = newName;
            }
            var h = CompanyListChanged;
            if (h != null) h( this, EventArgs.Empty );
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
                if (c.Name == name) c.SharePrice = newPrice;
            }
            var h = CompanyListChanged;
            if (h != null) h( this, EventArgs.Empty );
        }

        public void AddOrUpdateShareholders( string name, decimal money )
        {
            Shareholder c = _shareholders.FirstOrDefault( company => company.Name == name );
            if (c == null)
            {
                c = new Shareholder( this, name, money );
                _shareholders.Add( c );
                var h = ShareholdersListChanged;
                if (h != null) h( this, EventArgs.Empty );
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

        public IList<string> companyNames = new List<string>
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
            "Starbucks"
        };
        public IList<string> GetNameList { get { return shareholderNames; } }

        public IList<string> shareholderNames = new List<string>
       {
           "Martin Finkel",
           "Vincent Dufrasnes",
           "Johan Rain",
           "Martin Lavie",
           "Corentin Broux",
           "Nicolas Beuzart",
           "Camille Colin",
           "Brice Hoffmann",
           "Christie Bunlon",
           "Eric Lalitte",
           "Olivier Spinelli",
           "Damien Goldenberg",
           "Catherine Dorignac",
           "Corinne Thomas",
           "Alexis Boulanger",
           "Christophe Mortelette",
           "Julien Bernard",
           "Valentin Beuzart",
           "Franck Bontemps",
           "Jules Bourreau",
           "Benjamin Gratade",
           "Vincent Ricard",
           "Etienne Rocipon",
           "Ludovic Tresson",
           "Salman Alamdar",
           "Alexandre Arnal",
           "Nicolas Chatelain",
           "Stéphane Gereme",
           "Michel Gille",
           "Alban Inquel",
           "Silvja Jung",
           "Maxime Pavaut",
           "Thomas Rempenault",
           "Guillaume Roux",
           "Florian Thorreau",
           "Sabrina Mustafic",
           "Stéphane Mougel",
           "Adeline Martin",
           "Lucas Souppe",
           "Patrice Thiré",
           "Valéry Farcy",
           "Joel Goy",
           "Thomas Barach",
           "Antoine Bibes",
           "Riwan Bodereau",
           "Julien Cartier",
           "Anthony Chami",
           "Alain Cheung",
           "David Cingala",
           "Margot Filleton",
           "Kevin Guyoton",
           "Simon Hallay",
           "Charles Jarre",
           "Guillaume Noel",
           "Stéphane Pourrier",
           "François Proust",
           "Thomas Bouzou",
           "Yoel Marciano",
           "Nathan Gatti",
           "Antoine Chwalek",
           "Arthur Caron",
           "Kévin Defarge",
           "Bruno Paty",
           "Bessalel Cohen",
           "Adrien Dumont",
           "Christophe Hermer",
           "Raphael Costet",
           "Joshua Molinier",
           "Rami Morri",
           "Clément Rousseau",
           "Tristan Letrou",
           "Christine Brouste",
           "Mazen Dekhil",
           "Clémence Enault",
           "Clément Gaillardot",
           "Pierre Houdyer",
           "Stéphane Miginiac",
           "Jessica Ndjiki",
           "Timothée Pillard",
           "Axel Riffard",
           "Cédric Sika",
           "Xavier Diaz",
           "Etienne Got",
           "Brice Guégan",
           "Adrien Kasse",
           "Thomas Michau",
           "Mathieu Quioc",
           "Aurélien Roose",
           "Antoine Meunier",
           "Benoit Sturzer",
           "Guillaume Tawil",
           "Tomasz Urbanski"
       };
    }
}