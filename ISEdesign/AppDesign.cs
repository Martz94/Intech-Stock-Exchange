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
            this._actionBar.TabShareholder = this.tabShareholder1;
        }

        protected override void OnLoad( EventArgs e )
        {
            _market = new Market();
            
            _actionBar.SetMarket (_market);
            _marketView.SetMarket( _market );

            base.OnLoad( e );
        }
    }
}
