using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public class Company : IHistory, IShareholder
    {
        string name;                    //Company name
        decimal sharePrice;             //starting price for 1 action
        decimal currentSharePrice;      //share price updated by event
        decimal _sharePriceVariation;    //action price's variations updated by event

        int shareCount;                 //Quantity of its own shares the company still detains updated by event
  
        Guid companyID;
        private readonly Market market;
        int TotalShareCount;
        
        Industry TheIndustry;
        //Typehere history;//To be defined.. used to determine whether buying actions from this company is a safe deal or not.
        //for example, could take into account net income and growth
        //Ranges from 1 to 10, could be randomly defined

        public Company( Market Marketplace, string name, Industry Industry, decimal SharePrice, int ShareCount )
        {
            market = Marketplace;
            foreach ( Company x in market.companyList )
            {
                if ( x.Name == name ) throw new ArgumentException("A company already exists under that name");  
            }

            if ( SharePrice < 0 ) throw new ArgumentException("The starting action price must be at least 1€");

            this.name = name;
            
            this.TheIndustry = Industry;
            sharePrice = SharePrice;
            shareCount = ShareCount;
            TotalShareCount = ShareCount;
            companyID = Guid.NewGuid();
            Random rate = new Random();
            _sharePriceVariation = rate.Next(-5, 10);
            market.companyList.Add( this );
        }

        public enum Industry
        {
            IT,
            Agriculture,
            Pharmaceuticals,
            Insurance,
            RealEstate,
        }

        public Guid GetID
        {
            get { return companyID; }
        }

        public decimal SharePrice
        {
            get { return sharePrice; }
            set { sharePrice = value; }
        }

        public int GetTotalShareCount
        {
            get { return TotalShareCount; }
        }

        public void RemoveShare(int Sharecount)
        {
            shareCount = shareCount - Sharecount;
        }

        public decimal ShareVariation
        {
            get { return _sharePriceVariation; }
            set { _sharePriceVariation = value; }
        }
        public string Name
        {
            get { return name; }
        }

    }
}
