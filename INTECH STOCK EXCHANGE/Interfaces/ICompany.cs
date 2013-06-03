using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public interface ICompany
    {

        decimal GetSharePrice();
        int GetTotalShareCount();
        void RemoveShare( int Sharecount );
        decimal ShareVariation();

        //int shareCount;
        //decimal sharePrice;
        //decimal currentSharePrice;
        //string Name;
        //Market market;

    }
}
