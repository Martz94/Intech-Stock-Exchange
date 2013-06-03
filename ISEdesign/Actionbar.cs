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
        public Actionbar()
        {
            InitializeComponent();
        }

        public MarketView MarketView { get; set; }
        public TabShareholder TabShareholder { get; set; }

        Market market;

        private void _initialize_Click( object sender, EventArgs e )
        {
            market = new Market();
            market.CreateNewCompany( "Google", 650.0M, 1000 );
            market.CreateNewCompany( "Loreal", 130.0M, 1000 );
            market.CreateNewCompany( "Apple", 450.0M, 1000 );
            market.CreateNewCompany( "EDF", 17.590M, 1000 );
            market.CreateNewCompany( "Sanofi", 82.51M, 1000 );
            market.CreateNewCompany( "France Telecom", 7.843M, 1000 );
            market.CreateNewCompany( "Total", 38.585M, 1000 );
            Shareholder Olivier = new Shareholder( market, "Olivier", 10000.0M );
            Olivier.FillPortfolio( 100, market.companyList[0] );
            market.shareholderList.Add( Olivier );
            market.shareholderList.Add( new Shareholder( market, "Vincent", 20000.0M ) );
            market.shareholderList.Add( new Shareholder( market, "Nicolas", 20000.0M ) );
            market.shareholderList.Add( new Shareholder( market, "Camille", 20000.0M ) );
            market.shareholderList.Add( new Shareholder( market, "Romain", 20000.0M ) );
            market.shareholderList.Add( new Shareholder( market, "Corentin", 20000.0M ) );
            market.shareholderList.Add( new Shareholder( market, "Martin", 20000.0M ) );

            MarketView.ListView.Items.Clear();

            foreach (var c in market.companyList)
            {
                ListViewItem i = new ListViewItem( c.Name );
                i.SubItems.Add( c.GetSharePrice.ToString() );
                MarketView.ListView.Items.Add(i);
            }

            foreach (var s in market.shareholderList)
            {
                if (!s.IsCompany) _listShareholder.Items.Add( s.Name );
            }
        }

        private void _listShareholder_SelectedIndexChanged( object sender, EventArgs e )
        {
            TabShareholder.TabPortfolio.Items.Clear();
            foreach (var c in market.shareholderList)
            {
                if (c.Name == _listShareholder.Items[_listShareholder.SelectedIndex])
                {
                    foreach (var a in c.Portfolio)
                    {
                        ListViewItem i = new ListViewItem( a.company.Name );
                        i.SubItems.Add( a.shareCount.ToString() );
                        i.SubItems.Add( a.shareValue.ToString() );
                        TabShareholder.TabPortfolio.Items.Add( i );
                    }
                }
            }
        }
    }
}
