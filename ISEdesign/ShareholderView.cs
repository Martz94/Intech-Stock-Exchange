﻿using System;
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

        public ShareholderView()
        {
            InitializeComponent();
        }

        public TabShareholder TabShareholder { get; set; }
        public Chart GraphShareholder;

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
                i.SubItems.Add( s.Cash.ToString("N2") );
                i.SubItems.Add( s.PortfolioValue.ToString( "N2" ) );
                i.SubItems.Add( s.Strategy.ToString() );
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

            GraphShareholder.Palette = ChartColorPalette.Berry;
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
    }
}
