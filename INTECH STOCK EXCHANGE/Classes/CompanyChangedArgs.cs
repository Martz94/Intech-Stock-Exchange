using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace INTECH_STOCK_EXCHANGE
{
    [Serializable()]
    public class CompanyChangedArgs : EventArgs
    {
        public readonly Company Company;

        internal CompanyChangedArgs( Company c )
        {
            Company = c;
        }
    }
}
