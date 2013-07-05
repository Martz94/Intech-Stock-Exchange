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
    public partial class ShareholderView : UserControl
    {
        Market _market;
        int sortColumn = -1;

        public ShareholderView()
        {
            InitializeComponent();
        }

        public TabShareholder TabShareholder { get; set; }
        public Chart GraphShareholder;
        public Chart GraphStrat;

        internal void SetMarket( Market m )
        {
            if (_market != null)
            {
                _market.ShareholdersListChanged -= _market_ShareholdersListChanged;
                _market = null;
            }
            if (m != null)
            {
                _market = m;
                FillShareholdersList();
                FillGraphStrat();
                _market.ShareholdersListChanged += _market_ShareholdersListChanged;
            }
        }

        void _market_ShareholdersListChanged( object sender, EventArgs e )
        {
            FillShareholdersList();
        }

        public void FillShareholdersList()
        {
            _listViewSh.Items.Clear();
            foreach (var s in _market.shareholderList)
            {
                ListViewItem i = new ListViewItem( s.Name );
                i.UseItemStyleForSubItems = false;
                i.SubItems.Add( s.Cash.ToString("N2") );
                i.SubItems.Add( s.PortfolioValue.ToString("N2") );
                i.SubItems.Add( s.Capital.ToString( "N2" ) );
                i.SubItems.Add( s.Strategy.ToString() );
                
                //Coloring strats
                if ( s.Strategy.ToString() == "Random Strategy" )      i.SubItems[4].ForeColor = System.Drawing.Color.DarkMagenta;
                else if ( s.Strategy.ToString() == "Stupid Strategy" ) i.SubItems[4].ForeColor = System.Drawing.Color.DarkRed;
                else if (s.Strategy.ToString() == "Smart Strategy" )   i.SubItems[4].ForeColor = System.Drawing.Color.DeepSkyBlue;

                _listViewSh.Items.Add( i );
            }
        }

        public void FillShareholderPortfolio( Shareholder s )
        {
            TabShareholder.TabPortfolio.Items.Clear();
            TabShareholder.TabOrderBook.Items.Clear();

            foreach (var a in s.Portfolio)
            {
                ListViewItem i = new ListViewItem( a.Company.Name );
                i.UseItemStyleForSubItems = false;
                i.SubItems.Add( a.ShareCount.ToString() );

                i.SubItems.Add( a.Company.SharePrice.ToString( "#.###" ) );
                i.SubItems.Add( a.Company.ShareVariation.ToString( "N2" ));

                if (a.Company.ShareVariation < 0)
                {
                    i.SubItems[3].ForeColor = System.Drawing.Color.Red;
                }
                else i.SubItems[3].ForeColor = System.Drawing.Color.Green;
                TabShareholder.TabPortfolio.Items.Add( i );
            }

            foreach (var o in _market.GlobalOrderbook)
            {
                if (o.OrderMaker.Name == s.Name)
                {
                    ListViewItem i = new ListViewItem( o.GetOrderType.ToString() );
                    i.SubItems.Add( o.Company.Name );
                    i.SubItems.Add( o.OrderShareQuantity.ToString() );
                    i.SubItems.Add( o.OrderSharePriceProposal.ToString( "#.###" ) );
                    TabShareholder.TabOrderBook.Items.Add( i );
                }
            }
        }

        public void FillGraphShareholder (Shareholder shareholder)
        {
            GraphShareholder.Series.Clear();
            GraphShareholder.Titles.Clear();

            GraphShareholder.Palette = ChartColorPalette.Bright;
            GraphShareholder.Titles.Add( shareholder.Name );
            Series serie = GraphShareholder.Series.Add( "Portfolio value" );
            Series serie2 = GraphShareholder.Series.Add( "Cash" );

            GraphShareholder.Series[0].ChartType = SeriesChartType.FastLine;
            GraphShareholder.Series[0].BorderWidth = 2;
            GraphShareholder.Series[0].YAxisType = AxisType.Primary;

            GraphShareholder.Series[1].ChartType = SeriesChartType.FastLine;
            GraphShareholder.Series[1].BorderWidth = 2;
            GraphShareholder.Series[1].YAxisType = AxisType.Secondary;

            foreach (var a in shareholder.HistoryPortfolioValue)
            {
                serie.Points.Add( (double)a );            
            }

            foreach (var s in shareholder.HistoryCapital)
            {
                serie2.Points.Add( (double)s );
            }
        }

        public void FillGraphStrat ()
        {
            GraphStrat.Series.Clear();
            GraphStrat.Titles.Clear();

            GraphStrat.Palette = ChartColorPalette.Bright;
            GraphStrat.Titles.Add( "Strategies repartition" );
            Series serie1 = GraphStrat.Series.Add( "Random Strategy" );
            //Series serie2 = GraphStrat.Series.Add( "Stupid Strategy" );
            //Series serie3 = GraphStrat.Series.Add( "Smart Strategy" );
            
            decimal randomStrategyCapital = 0;
            decimal stupidStrategyCapital = 0;
            decimal smartStrategyCapital = 0;

            foreach (var s in _market.shareholderList)
            {
                if (s.Strategy.ToString() == "Random Strategy")
                {
                    randomStrategyCapital += s.Capital;
                }
                else if (s.Strategy.ToString() == "Stupid Strategy")
                {
                    stupidStrategyCapital += s.Capital;
                }
                else
                {
                    smartStrategyCapital += s.Capital;
                }
            }
            
            decimal third;
            decimal second;
            decimal first;

            if ( randomStrategyCapital > stupidStrategyCapital && randomStrategyCapital > smartStrategyCapital )
            {
                if ( stupidStrategyCapital > smartStrategyCapital )
                //1 = Random
                //2 = Stupid
                //3 = Smart
                {
                    third = smartStrategyCapital;
                    second = stupidStrategyCapital;
                    first = randomStrategyCapital;

                    smartStrategyCapital = first;
                    stupidStrategyCapital = second;
                    randomStrategyCapital = third;

                }
                else
                //1 = Random
                //2 = Smart
                //3 = Stupid
                {
                    first = randomStrategyCapital;
                    second = smartStrategyCapital;
                    third = stupidStrategyCapital;

                    smartStrategyCapital = first;
                    stupidStrategyCapital = second;
                    randomStrategyCapital = third;
                }    
            }
            else if ( stupidStrategyCapital > randomStrategyCapital && stupidStrategyCapital > smartStrategyCapital )
            {
                if ( randomStrategyCapital > smartStrategyCapital )
                //1 = Stupid
                //2 = Random
                //3 = Smart
                {
                    first = stupidStrategyCapital;
                    second = randomStrategyCapital;
                    third = smartStrategyCapital;

                    smartStrategyCapital = first;
                    stupidStrategyCapital = second;
                    randomStrategyCapital = third;
                }
                else
                //1 = Stupid
                //2 = Smart
                //3 = Random
                {
                    first = stupidStrategyCapital;
                    second = smartStrategyCapital;
                    third = randomStrategyCapital;

                    smartStrategyCapital = first;
                    stupidStrategyCapital = second;
                    randomStrategyCapital = third;
                }
            }
            else if ( smartStrategyCapital > randomStrategyCapital && smartStrategyCapital > stupidStrategyCapital )
            {
                if ( randomStrategyCapital > stupidStrategyCapital )
                //1 = Smart
                //2 = Random
                //3 = Stupid
                {
                    first = smartStrategyCapital;
                    second = randomStrategyCapital;
                    third = stupidStrategyCapital;

                    smartStrategyCapital = first;
                    stupidStrategyCapital = second;
                    randomStrategyCapital = third;
                }
                else
                //1 = Smart
                //2 = Stupid
                //3 = Random
                {
                }
            }
            string[] xValues = { "Random Strategy", "Stupid Strategy", "Smart Strategy" };
            double[] yValues = { (double)randomStrategyCapital, (double)stupidStrategyCapital, (double)smartStrategyCapital };
            serie1.Points.DataBindXY( xValues, yValues );

            serie1.Points[0].Color = Color.DarkMagenta;
            serie1.Points[1].Color = Color.DarkRed;
            serie1.Points[2].Color = Color.DeepSkyBlue;

            serie1.ChartType = SeriesChartType.Pie;

            serie1["PieLabelStyle"] = "Disabled";

            GraphStrat.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            GraphStrat.Legends[0].Enabled = true;

            //serie1.Points.Add( (double)randomStrategyCapital );
            //serie2.Points.Add( (double)stupidStrategyCapital );
            //serie3.Points.Add( (double)smartStrategyCapital );

        }

        private void _listViewSh_Click( object sender, EventArgs e )
        {
            foreach (var c in _market.shareholderList)
            {
                ListViewItem i = _listViewSh.SelectedItems[0];
                if (c.Name == i.Text)
                {
                    _market.SuperShareholder = c;
                    FillShareholderPortfolio( c );
                    FillGraphShareholder( c );
                }
            }
        }

        private void _listViewSh_ColumnClick( object sender, ColumnClickEventArgs e )
        {
            // Determine whether the column is the same as the last column clicked.
            if ( e.Column != sortColumn )
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default
                _listViewSh.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it
                if ( _listViewSh.Sorting == SortOrder.Ascending )
                    _listViewSh.Sorting = SortOrder.Descending;
                else
                    _listViewSh.Sorting = SortOrder.Ascending;
            }
            // Call the sort method to manually sort
            _listViewSh.ListViewItemSorter = new _listViewItemComparer( e.Column, _listViewSh.Sorting );
            _listViewSh.Sort();   
        }       
    }
}
