﻿using System;
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
        Shareholder.pItem share;
        int transactionCount = 0;

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
                if ( o.OrderStatus != Order.orderStatus.Dispatched || o.TimedOut == false)
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

                        o2.decreaseOrderShareQuantity( o1.GetOrderShareQuantity );
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
            transactionCount++;

            System.Diagnostics.Debug.WriteLine( "[TRANSACTION] : " + buyer.Name + " baught to " + seller.Name + " " + quantity + " shares of " + company.Name + " at " + price);
            System.Diagnostics.Debug.WriteLine(transactionCount);
        }

        //Currently: Defining the new company share price based upon the latest exchange in the market
        private void UpdateMarketData( Company company, decimal price )
        {
            decimal newVariation = ((price - company.SharePrice) / company.SharePrice)*100;
            company.ShareVariation = newVariation;
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