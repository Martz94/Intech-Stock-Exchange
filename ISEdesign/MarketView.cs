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
    public partial class MarketView : UserControl
    {

        public System.Windows.Forms.ListView ListView
        {
            get { return _listView; }
            set { _listView = value; }
        }

        public MarketView()
        {
            InitializeComponent();
        }
    }
}
