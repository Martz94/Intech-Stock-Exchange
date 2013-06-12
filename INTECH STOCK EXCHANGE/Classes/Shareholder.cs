﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization;

namespace INTECH_STOCK_EXCHANGE
{
    [Serializable()]
    public class Shareholder //: IShareholder, IEnumerable
    {
        //Profil
        private string _displayName;
        private Guid shareholderID; //unique identifier
        List<Shareholder> _shareholders;
        public List<Order> _globalOrderbook;//Orderbook of the market
        public List<PortfolioItem> _portfolio;//company, sharevalue, buydate, sharecount - using a list of structs
        public PortfolioItem share; //Share (struct type)
        Order.orderType _orderType;
        private readonly Market market;
        Company firm;
        decimal _cash;
        decimal _priceProp;
        int shareCount;//nb of shares the guy wants to buy/sell
        private IStrategy _strategy;
        Order order;
        RiskTaker _riskTaker;
        TimeVision _timeVision;
        decimal shareVariation;

        public Shareholder(Market marketPlace, string Name, decimal Money)
        {
            if ( Money < 0 ) throw new ArgumentException( "An investor must have some money at one point!" );

            market = marketPlace;

            foreach ( Shareholder x in market.shareholderList )
            {
                if ( x.Name == Name ) throw new ArgumentException( "A shareholder already exists with that name!" );
            }
            //Assign a strategy
            //Randomly defines riskTaker and timeVision values

            Array values = Enum.GetValues( typeof( RiskTaker ) );
            Random random = market.Random;
            RiskTaker _riskTaker = (RiskTaker)values.GetValue( random.Next( values.Length ) );

            Array values2 = Enum.GetValues( typeof( TimeVision ) );
            TimeVision _timeVision = (TimeVision)values2.GetValue( random.Next( values2.Length ) );

            _portfolio = new List<PortfolioItem>();
            _displayName = Name;

            //Random r = market.Random;
            //int i = r.Next( 100 );
            //if ( i > 50 ) _strategy = new RandomStrategy();
            if ( market.Random.Next( 2 ) == 1 ) _strategy = new StupidStrategy();
            else _strategy = new RandomStrategy();

            _cash = Money;
           
            shareholderID = Guid.NewGuid();
        }
        public Order MakeDecision( Market market, Shareholder shareholder )
        {
            //Call an algorithm here taking into account history, industry and strategy to determine:
            //- Whether to buy, to sell or to wait next round, 
            //- Which actions to buy or sell and how many (including the company's own shares),
            //- A price proposal taking into account the current share price, the cash, the strategy

            //Decide whether to buy, sell or do nothing
            //Make an algorithm that takes into account the market, the evolution of prices, the capital of the guy, w/e
            return  _strategy.MakeDecision(market, this);
        }
        
        public string Name
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public decimal Capital
        {
            get { return _cash; }
            set { _cash = value; }
        }

        [Serializable]
        public class PortfolioItem
        {
            public Company Company { get; set; }
            public decimal ShareLastPurchaseValue { get; set; }
            public DateTime LastBuyDate { get; set; }
            public int ShareCount { get; set; }
        }

        public IStrategy Strategy 
        {
            get { return _strategy; }
            set { _strategy = value; } 
        }
        
        public RiskTaker GetRiskIndex
        {
            get { return _riskTaker; }
        }
        TimeVision GetTimeVision
        {
            get { return _timeVision; }
        }
        public enum RiskTaker
        {
            Bold,
            Cautious,
            Crazy,
        }

        enum TimeVision
        {
            shortTerm,
            middleTerm,
            longTerm,
        }

        public Guid GetID
        {
            get { return shareholderID; }
        }
        public void AlterPortfolio( Market.ActionType actionType, int shareCount, Company firm, Shareholder sh )
        //Called when:
        //- The market opens for the 1st time,
        //- Transactions need to be made,

        // (!) automatically creates a new struct in the portfolio if the s/h does not already hold at least 1 action of the firm
        // (!) automatically removes a struct if the s/h holds 0 action of the firm
        {
            //Debug.Assert( firm != null );

            if ( actionType == Market.ActionType.Fill )
            {
                int i;
                int f = -1;
                for ( i = 0; i < sh._portfolio.Count; i++ )
                {
                    if ( sh._portfolio[i].Company == firm )
                    {
                        f = i;
                    }
                }
                if ( f != -1 )
                {
                    Shareholder.PortfolioItem p = sh._portfolio[f];
                    p.ShareCount = p.ShareCount + shareCount;
                    p.ShareLastPurchaseValue = firm.SharePrice;// last purchase price kept
                    p.LastBuyDate = new DateTime();     // last purchase date
                    sh._portfolio[f] = p;
                }
                else
                {
                    Shareholder.PortfolioItem x = new Shareholder.PortfolioItem();
                    x.ShareCount = shareCount;
                    x.ShareLastPurchaseValue = firm.SharePrice;
                    x.Company = firm;
                    x.LastBuyDate = new DateTime();
                    sh._portfolio.Add( x );
                }
            }

            else if ( actionType == Market.ActionType.Empty )
            {
                int i;
                int f = -1;
                for ( i = 0; i < sh._portfolio.Count; i++ )
                {
                    if ( sh._portfolio[i].Company == firm )
                    {
                        f = i;
                    }
                }
                if ( f != -1 )
                {
                    Shareholder.PortfolioItem p = sh._portfolio[f];
                    p.ShareCount = p.ShareCount - shareCount;
                    if ( p.ShareCount == 0 )
                    {
                        sh._portfolio.RemoveAt( f );
                    }
                    else if ( p.ShareCount > 0 )
                    {
                        sh._portfolio[f] = p;
                    }
                }
                else
                {
                    Shareholder.PortfolioItem share = new Shareholder.PortfolioItem();
                    share.ShareLastPurchaseValue = firm.SharePrice;
                    share.Company = firm;
                    share.ShareCount = shareCount;
                    share.LastBuyDate = new DateTime();
                    sh._portfolio.Add( share );
                }
            }
            else
            {
                throw new ArgumentException( "ActionType to portfolio invalid" );
            }
        }
    }
}
