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
        public Timer GoTimer;
        int numberRound;

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

        private void _goButtonClick( object sender, EventArgs e )
        {
            numberRound = Convert.ToInt32(this._roundNumber.Text);
            int intervalTime = 500;
            GoTimer = new System.Windows.Forms.Timer();

            GoTimer.Interval = intervalTime;
            GoTimer.Tick += new EventHandler( _stepByStep_Click );
            GoTimer.Start();
        }

        private void _stepByStep_Click( object sender, EventArgs e )
        {
            if (GoTimer != null)
            {
                numberRound--;
                if (numberRound == 0) GoTimer.Stop();
            }

            foreach (Shareholder sh in _market.shareholderList)
            {
                Order newOrder = sh.MakeDecision( _market, sh );
                if (newOrder != null) _market.globalOrderbook.Add( newOrder );
            }
            _market.MatchOrders();
            _market.Clear();
            FillShareholdersList();
            
            if (_market.SuperShareholder != null) fillShareholderPortfolio( _market.SuperShareholder );
            if (_market.SuperCompany != null) MarketView.FillGraphCompany( _market.SuperCompany );

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

        private void fillShareholderPortfolio(Shareholder s)
        {

            TabShareholder.TabPortfolio.Items.Clear();
            TabShareholder.TabOrderBook.Items.Clear();
            decimal shareValue = 0;
            int nbSell = 0;
            int nbBuy = 0;

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

                    if (o.GetOrderType == Order.orderType.Buy) nbBuy++;
                    else nbSell++;
                }
            }

            TabShareholder.Cash.Text = s.Capital.ToString( "C" );
            TabShareholder.TotalShareValue.Text = shareValue.ToString( "C" );
            TabShareholder.NbBuyOrders.Text = nbBuy.ToString();
            TabShareholder.NbSellOrders.Text = nbSell.ToString();
        }

        private void _listShareholder_SelectedIndexChanged( object sender, EventArgs e )
        {


            foreach (var c in _market.shareholderList)
            {

                if (c.Name == _listShareholder.Items[_listShareholder.SelectedIndex].ToString())
                {
                    _market.SuperShareholder = c;
                    fillShareholderPortfolio( c );
                }
            }
        }
    }
}
