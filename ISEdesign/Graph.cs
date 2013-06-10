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
    public partial class Graph : UserControl
    {
        public Graph()
        {
            InitializeComponent();
        }

        public System.Windows.Forms.DataVisualization.Charting.Chart GraphCompany
        {
            get { return _chartCompany; }
            set { _chartCompany = value; }
        }
    }
}
