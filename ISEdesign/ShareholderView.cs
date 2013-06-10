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

        internal void SetMarket( Market market )
        {
            _market = market;
            FillShareholdersList();
            _market.ShareholdersListChanged += _market_ShareholdersListChanged;
        }

        void _market_ShareholdersListChanged( object sender, EventArgs e )
        {
            FillShareholdersList();
        }

        public void FillShareholdersList()
        {
            _listViewSh.Items.Clear();
            foreach (var c in _market.shareholderList)
            {
                decimal shareValue = 0;

                ListViewItem i = new ListViewItem( c.Name );
                i.SubItems.Add( c.Capital.ToString("C") );

                foreach (var a in c._portfolio)
                {
                    shareValue += a.shareCount * a.company.SharePrice;
                }
                i.SubItems.Add( shareValue.ToString( "C" ) );

                i.SubItems.Add( c.Strategy.ToString() );
                _listViewSh.Items.Add( i );
            }
        }

        public void fillShareholderPortfolio( Shareholder s )
        {
            TabShareholder.TabPortfolio.Items.Clear();
            TabShareholder.TabOrderBook.Items.Clear();
            decimal shareValue = 0;

            foreach (var a in s._portfolio)
            {
                ListViewItem i = new ListViewItem( a.company.Name );
                i.UseItemStyleForSubItems = false;
                i.SubItems.Add( a.shareCount.ToString() );

                i.SubItems.Add( a.company.SharePrice.ToString( "#.###" ) );
                i.SubItems.Add( a.company.ShareVariation.ToString( "N2" ) + " %" );

                if (a.company.ShareVariation < 0)
                {
                    i.SubItems[3].ForeColor = System.Drawing.Color.Red;
                }
                else i.SubItems[3].ForeColor = System.Drawing.Color.Green;
                TabShareholder.TabPortfolio.Items.Add( i );

                shareValue += a.shareCount * a.company.SharePrice;
            }

            foreach (var o in _market.globalOrderbook)
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

        private void _listViewSh_Click( object sender, EventArgs e )
        {
            foreach (var c in _market.shareholderList)
            {
                ListViewItem i = _listViewSh.SelectedItems[0];
                if (c.Name == i.Text)
                {
                    _market.SuperShareholder = c;
                    fillShareholderPortfolio( c );
                }
            }
        }
    }
}
