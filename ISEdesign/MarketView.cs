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
    public partial class MarketView : UserControl
    {
        Market _market;

        public MarketView()
        {
            InitializeComponent();
        }

        internal void SetMarket (Market market)
        {
            _market = market;
            FillCompanyList();
            _market.CompanyListChanged += _market_CompanyListChanged;
            _market.CompanyChanged += _market_CompanyChanged;
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
                i.SubItems.Add( c.SharePrice.ToString( "#.###" ) );
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
                    
                }
            }
        }
    }
}
