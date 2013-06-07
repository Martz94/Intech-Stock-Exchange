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
    public partial class Actionbar : UserControl
    {
        Market _market;

        public Actionbar()
        {
            InitializeComponent();
        }

        public MarketView MarketView { get; set; }
        public TabShareholder TabShareholder { get; set; }

        private void _initialize_Click( object sender, EventArgs e )
        {
            using (var d = new CreateNewWorld())
            {
                DialogResult r = d.ShowDialog();

                if (r == DialogResult.OK)
                {
                    Builder.CreateAll( _market, d.CompanyNumber, d.ShareholderNumber );
                }
            }

        }

        private void Play( object sender, EventArgs e )
        {
            //Function that's starting the market for x rounds

            //int roundMax = _roundNumber;
        }

        internal void SetMarket( Market market )
        {
            _market = market;
            _market.ShareholdersListChanged += _market_ShareholdersListChanged;
        }

        void _market_ShareholdersListChanged( object sender, EventArgs e )
        {
            FillShareholdersList();
        }

        private void FillShareholdersList()
        {
            _listShareholder.Items.Clear();
            foreach (var c in _market.shareholderList)
            {
                _listShareholder.Items.Add( c.Name );
            }

        }

        private void _listShareholder_SelectedIndexChanged( object sender, EventArgs e )
        {
            TabShareholder.TabPortfolio.Items.Clear();
            foreach (var c in _market.shareholderList)
            {
                if (c.Name == _listShareholder.Items[_listShareholder.SelectedIndex])
                {
                    foreach (var a in c._portfolio)
                    {
                        ListViewItem i = new ListViewItem( a.company.Name );
                        i.SubItems.Add( a.shareCount.ToString() );
                        i.SubItems.Add( a.company.SharePrice.ToString() );
                        TabShareholder.TabPortfolio.Items.Add( i );
                    }
                }
            }
        }
    }
}
