using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Collections;

namespace INTECH_STOCK_EXCHANGE
{
    public class Shareholder //: IShareholder, IEnumerable
    {
        //Profil
        private string _displayName;
        private Guid shareholderID; //unique identifier
        List<Shareholder> _shareholders;
        public List<Order> _globalOrderbook;//Orderbook of the market
        public List<pItem> _portfolio;//company, sharevalue, buydate, sharecount - using a list of structs
        public pItem share; //Share (struct type)
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

            _portfolio = new List<pItem>();
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

        public struct pItem         //Portfolio Item
        {
            public Company company { get; set; }
            public decimal shareLastPurchaseValue { get; set; }
            public DateTime lastBuyDate { get; set; }
            public int shareCount { get; set; }
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
    }
}
