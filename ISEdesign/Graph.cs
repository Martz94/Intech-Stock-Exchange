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

namespace ISEdesign
{
    public partial class Graph : UserControl
    {
        public Graph()
        {
            InitializeComponent();
        }

        public Chart GraphCompany
        {
            get { return _chartCompany; }
            set { _chartCompany = value; }
        }

        public Chart GraphMarket
        {
            get { return _chartMarket; }
            set { _chartMarket = value; }
        }
    }
}
