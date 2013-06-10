using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISEdesign
{
    public partial class TabShareholder : UserControl
    {
        public ListView TabPortfolio
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        public ListView TabOrderBook
        {
            get { return listView2; }
            set { listView2 = value; }
        }
        
        public Label Cash
        {
            get { return _cash; }
            set { _cash = value; }
        }

        public Label TotalShareValue
        {
            get { return _totalShareValue; }
            set { _totalShareValue = value; }
        }

        public Label NbBuyOrders
        {
            get { return _nbBuyOrders; }
            set { _nbBuyOrders = value; }
        }

        public Label NbSellOrders
        {
            get { return _nbSellOrders; }
            set { _nbSellOrders = value; }
        }

        public TabShareholder()
        {
            InitializeComponent();
        }

    }
}
