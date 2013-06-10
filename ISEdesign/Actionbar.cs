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

        internal void SetMarket( Market market )
        {
            _market = market;
        }

        public Actionbar()
        {
            InitializeComponent();
        }

        public MarketView MarketView { get; set; }
        public ShareholderView ShareholderView { get; set; }
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
            ShareholderView.FillShareholdersList();

            foreach (var c in _market.Companies)
            {
                c.HistoryLastPrice.Add( (double)c.SharePrice );
                c.HistoryNbTransactions.Add( c.NbTransaction );
                c.NbTransaction = 0;
            }


            if (_market.SuperShareholder != null) ShareholderView.fillShareholderPortfolio( _market.SuperShareholder );
            if (_market.SuperCompany != null)
            {
                MarketView.FillGraphCompany( _market.SuperCompany );
                MarketView.FillGraphStockPrice( _market.SuperCompany );
            }

        }   
    }
}
