using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public interface IStrategy
    {
        // return null when no investment is required
        Order MakeDecision( Market market, Shareholder shareholder );      
    }
}
