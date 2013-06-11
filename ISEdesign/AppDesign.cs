using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INTECH_STOCK_EXCHANGE;

namespace ISEdesign
{
    public partial class AppDesign : Form
    {
        Market _market;

        public AppDesign()
        {
            InitializeComponent();
            _actionBar.TabShareholder = tabShareholder1;
            _actionBar.ShareholderView = shareholderView1;
            _actionBar.MarketView = _marketView;
            _marketView.GraphCompany = graph1.GraphCompany;
            shareholderView1.TabShareholder = tabShareholder1;
            shareholderView1.GraphShareholder = tabShareholder1.GraphShareholder;
        }

        protected override void OnLoad( EventArgs e )
        {
            BindToMarket( new Market() );
            base.OnLoad( e );
        }

        public void BindToMarket( Market m )
        {
            _market = m;
            _actionBar.SetMarket( _market );
            shareholderView1.SetMarket( _market );
            _marketView.SetMarket( _market );
            _menuFile.SetMarket( _market );
        }
    }
}
