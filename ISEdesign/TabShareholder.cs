using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using INTECH_STOCK_EXCHANGE;

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

        public Chart GraphShareholder
        {
            get { return _chartShareholder; }
            set { _chartShareholder = value; }
        }
        
        public TabShareholder()
        {
            InitializeComponent();
        }

    }
}
