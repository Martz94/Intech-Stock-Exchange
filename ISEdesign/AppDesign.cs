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
        public AppDesign()
        {
            InitializeComponent();
            this.actionbar1.MarketView = this.marketView1;
            this.actionbar1.TabShareholder = this.tabShareholder1;
        }
        
    }
}
