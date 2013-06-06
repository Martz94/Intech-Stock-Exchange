using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace INTECH_STOCK_EXCHANGE
{
    public class Order : IOrder
    {
        public orderType _orderType;
        DateTime _expirationDate;
        int shareCount; //Total count of actions in this order
        decimal _sharePriceProposal; //Price proposal for 1 action
        decimal _totalOrderPriceProposal;//Total price of 1 order = _sharePriceProposal * _shareQuantity
        Guid _orderID;
        Shareholder _shareholder;//Need to check whether the shareholder is of type "shareholder" or "company"
        Company _company;
        Order.orderStatus _orderStatus;
        Guid _orderBuyerID;
        Timer _timer;
        Guid _orderReceiverID;

        public Order(orderType orderType, decimal PriceProp, int ShareCount, Company firm, Shareholder Shareholder )
        {
            if ( PriceProp < 0 ) throw new ArgumentException("Price proposition error");
            if ( ShareCount < 0 ) throw new ArgumentException( "share count error" );

            _orderType = orderType;
            _shareholder = Shareholder;
            _company = firm;//Company's share
            shareCount = ShareCount;
            _orderStatus = Order.orderStatus.ReadyForDispatch;
            _sharePriceProposal = PriceProp;//Unit price proposal
            _totalOrderPriceProposal = PriceProp * ShareCount;//Order's total price proposal
            _orderID = Guid.NewGuid(); //ID of the order
            _orderReceiverID = Guid.Empty;//ID of the shareholder that got the deal, to be modified when the deal is done (sold/bought)

            _expirationDate = DateTime.Now.AddMilliseconds( 30 ); //Expiration date set to 30ms  after order's built

            //(!) (!) (!)
            //Scenario: 1 guy with 100€ cash
            //1st round passes, he wants to buy a couple actions for 70€, makes a buy order
            //2nd round, no takers for his previous order. he makes another one for 50 € (he has the same cash since his order remained)
            //3rd round, his two orders find takers yet he only has 100€ <- (system is f*cked)

            //Some more checking needed... (timer etc)
        }

        
        public Guid GetOrderId
        {
            get { return _orderID; }
        }
        public bool TimedOut
        {
            get { return (DateTime.Now < _expirationDate); }
        }
        public orderType GetOrderType
        {
            get { return _orderType; }
        }
        public int GetOrderShareQuantity
        {
            get { return shareCount; }
        }
        public Guid GetSharesCompanyID
        {
            get { return _company.GetID; }
        }
        public Guid GetOrderMakerID
        {
            get { return _shareholder.GetID; }
        }
        public decimal GetOrderSharePriceProposal
        {
            get { return _sharePriceProposal; }
        }
        public decimal GetOrderTotalPriceProposal
        {
            get { return _totalOrderPriceProposal; }
        }
       
        public Order.orderStatus OrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }
        public Guid OrderReceiverID
        {
            get { return _orderReceiverID; }
        }
        public Company Company
        {
            get { return _company; }
        }
        public enum orderType
        {
            Buy,
            Sell,
        }
       
        public enum orderStatus
        {
            Dispatched,
            ReadyForDispatch,
        }
    }
}
