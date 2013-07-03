using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INTECH_STOCK_EXCHANGE;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.Serialization;

namespace ISEdesign
{
    public partial class MarketView : UserControl
    {
        Market _market;
        private int sortColumn = -1;

        public MarketView()
        {
            InitializeComponent();
        }
        
        public int listViewHeight { get { return _listView.Height; } }
        public Chart GraphCompany;
        public Chart GraphMarket;

        internal void SetMarket (Market m)
        {
            if (_market != null)
            {
                _market.CompanyListChanged -= _market_CompanyListChanged;
                _market.CompanyChanged -= _market_CompanyChanged;
                _market = null;
            }

            if (m != null)
            {
                _market = m;
                FillCompanyList();
                _market.CompanyListChanged += _market_CompanyListChanged;
                _market.CompanyChanged += _market_CompanyChanged;
            }            
        }

        void _market_CompanyChanged( object sender, CompanyChangedArgs e )
        {
            ListViewItem item = _listView.Items.Cast<ListViewItem>().First( i => i.Text == e.Company.Name );
            item.SubItems[1].Text = e.Company.SharePrice.ToString();
        }

        void _market_CompanyListChanged( object sender, EventArgs e )
        {
            FillCompanyList();
        }

        private void FillCompanyList()
        {
            _listView.Items.Clear();
            foreach (var c in _market.companyList)
            {
                ListViewItem i = new ListViewItem( c.Name );
                i.UseItemStyleForSubItems = false;
                i.SubItems.Add( c.SharePrice.ToString( "N2" ) );
                i.SubItems.Add( c.ShareVolume.ToString() );
                i.SubItems.Add( c.ShareVariation.ToString( "N2" ));

                if (c.ShareVariation < 0)
                {
                    i.SubItems[3].ForeColor = System.Drawing.Color.Red;
                }
                else if ( c.ShareVariation == 0 )
                {
                    i.SubItems[3].ForeColor = System.Drawing.Color.Black;
                }
                else i.SubItems[3].ForeColor = System.Drawing.Color.Green;

                _listView.Items.Add( i );
            }
        }

        private void _listView_DoubleClick( object sender, EventArgs e )
        {
            using (var t = new ChangeCompany())
            {
                DialogResult r = t.ShowDialog();

                if (r == DialogResult.OK)
                {
                    _listView.SelectedItems[0].Text.Trim();
                    ListViewItem i = _listView.SelectedItems[0];
                    decimal price;
                    if (_market.CheckNameCompany( t.CompanyName ))
                    {
                        MessageBox.Show( "The name of the company already exists." );
                    }
                    else if (t.IsShareValueDecimal(out price))
                    {
                        _market.UpdateCompanyPrice( i.Text, t.ShareValue );
                    }

                    if (!_market.CheckNameCompany( t.CompanyName ) && t.CompanyName != "")
                    {
                        _market.ChangeCompanyName( i.Text, t.CompanyName );
                    }
                }
            }
        }

        public void FillGraphCompany(Company company)
        {
            GraphCompany.Series.Clear();
            GraphCompany.Titles.Clear();
                        
            GraphCompany.Palette = ChartColorPalette.Fire;
            GraphCompany.Titles.Add( company.Name );
            Series series = GraphCompany.Series.Add( "Number of transactions" );
            Series series2 = GraphCompany.Series.Add( "Stock Price" );

            GraphCompany.Series[0].ChartType = SeriesChartType.FastLine;
            GraphCompany.Series[0].BorderWidth = 2;
            GraphCompany.Series[0].YAxisType = AxisType.Primary;

            GraphCompany.Series[1].ChartType = SeriesChartType.Line;
            GraphCompany.Series[1].BorderWidth = 2;
            GraphCompany.Series[1].YAxisType = AxisType.Secondary;

            List<int> history = company.HistoryNbTransactions;
            for (int j = 0; j < history.Count; j++)
            {
                series.Points.Add( history[j] );
            }

            foreach (var d in company.HistoryLastPrice)
            {
                series2.Points.Add( d );
            }
        }

        public void FillGraphMarket()
        {
            GraphMarket.Series.Clear();
            GraphMarket.Titles.Clear();

            GraphMarket.Palette = ChartColorPalette.Fire;
            GraphMarket.Titles.Add( "Market" );
            Series series = GraphMarket.Series.Add( "Variation" );

            GraphMarket.Series[0].ChartType = SeriesChartType.Line;
            GraphMarket.Series[0].BorderWidth = 2;
            
            //for (int x = 0; x < ; x++)
            {
                decimal i = _market.TotalMarketValue();
                List<decimal> MarketDataPoints = new List<decimal>();
                MarketDataPoints.Add(i);
                
                for (int j = 0; j < MarketDataPoints.Count; j++)
                {
                    series.Points.Add( (double)MarketDataPoints[j] );
                }
            }
            

            
        }

        private void _listView_Click( object sender, EventArgs e )
        {
            if (_listView.SelectedItems.Count > 0)
            {
                ListViewItem i = _listView.SelectedItems[0];
                Company company = null;
                foreach (var c in _market.Companies)
                {
                    if (c.Name == i.Text) company = c;
                }
                _market.SuperCompany = company;
                FillGraphCompany( company );
            }
        }

        private void _listView_ColumnClick( object sender, ColumnClickEventArgs e )
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default
                _listView.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it
                if (_listView.Sorting == SortOrder.Ascending)
                    _listView.Sorting = SortOrder.Descending;
                else
                    _listView.Sorting = SortOrder.Ascending;
            }          
            // Call the sort method to manually sort
                 _listView.ListViewItemSorter = new _listViewItemComparer( e.Column, _listView.Sorting );
                 _listView.Sort();      
        }  
    }
}
