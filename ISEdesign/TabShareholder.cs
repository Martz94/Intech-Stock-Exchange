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
        public TabShareholder()
        {
            InitializeComponent();
        }
    }
}
