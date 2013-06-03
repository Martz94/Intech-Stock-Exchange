using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public class Execution : IExecution
    {
        Repository _repository;
        Action _action;
        Company _company;
        Order _order;
        Shareholder _shareholder;

    }
}
