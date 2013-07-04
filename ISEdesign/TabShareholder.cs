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
        int sortColumn = -1;

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

        public Chart GraphStrat
        {
            get { return _chartStrat; }
            set { _chartStrat = value; }
        }
        
        public TabShareholder()
        {
            InitializeComponent();
        }

        private void listView1_ColumnClick( object sender, ColumnClickEventArgs e )
        {
           
            // Determine whether the column is the same as the last column clicked.
            if ( e.Column != sortColumn )
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default
                listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it
                if ( listView1.Sorting == SortOrder.Ascending )
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }
            // Call the sort method to manually sort
            listView1.ListViewItemSorter = new _listViewItemComparer( e.Column, listView1.Sorting );
            listView1.Sort();   
        }

    }
}
