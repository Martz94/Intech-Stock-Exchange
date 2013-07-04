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

        public EventHandler<EventArgs> MarketLoad;
        public MarketView MarketView { get; set; }
        public ShareholderView ShareholderView { get; set; }
        public TabShareholder TabShareholder { get; set; }
        public Market Market { get { return _market; } }
        public Timer GoTimer;
        int numberRound;
                
        private void _goButtonClick( object sender, EventArgs e )
        {
            numberRound = Convert.ToInt32(this._roundNumber.Text);
            if ( numberRound > 0 && numberRound < 1000 )

            {
            if (_autoRefresh.Checked)
            {
                for (int i = 0; i < numberRound; i++)
                {
                    _market.RoundCount++;
                    foreach (Shareholder sh in _market.shareholderList)
                    {
                        sh.HistoryCapital.Add( sh.Cash );
                        sh.HistoryPortfolioValue.Add( sh.PortfolioValue );
                        Order newOrder = sh.MakeDecision( _market, sh );
                        if (newOrder != null) _market.GlobalOrderbook.Add( newOrder );
                    }
                    _market.MatchOrders();
                    _market.ClearOrderbook();
                    ShareholderView.FillShareholdersList();

                    foreach (var c in _market.Companies)
                    {
                        c.VariationHistory.Add( c.ShareVariation );
                        c.HistoryLastPrice.Add( (double)c.SharePrice );
                        c.HistoryNbTransactions.Add( c.NbTransaction );
                        c.VolumexVar.Add( c.VolxPrice );
                        c.NbTransaction = 0;
                    }
                    MarketView.FillGraphMarket();
                    ShareholderView.FillGraphStrat();
                    if (_market.SuperShareholder != null)
                    {
                        ShareholderView.FillShareholderPortfolio( _market.SuperShareholder );
                        ShareholderView.FillGraphShareholder( _market.SuperShareholder );
                    }

                    if (_market.SuperCompany != null) MarketView.FillGraphCompany( _market.SuperCompany );
                }
            }
            else
            {
                int intervalTime = 500;
                GoTimer = new Timer();

                GoTimer.Interval = intervalTime;
                GoTimer.Tick += new EventHandler( _stepByStep_Click );
                GoTimer.Start();
            }
            }
        }

        private void _stepByStep_Click( object sender, EventArgs e )
        {            
            if (GoTimer != null)
            {
                numberRound--;
                if (numberRound == 0) GoTimer.Stop();
            }
            _market.RoundCount++;
            foreach (Shareholder sh in _market.shareholderList)
            {
                sh.HistoryCapital.Add( sh.Cash );
                sh.HistoryPortfolioValue.Add(sh.PortfolioValue);
                Order newOrder = sh.MakeDecision( _market, sh );
                if (newOrder != null) _market.GlobalOrderbook.Add( newOrder );
            }
            _market.MatchOrders();
            _market.ClearOrderbook();
            ShareholderView.FillShareholdersList();

            foreach (var c in _market.Companies)
            {
                if (c.HistoryLastPrice.Count > 0)
                {
                    c.ShareVariation = ((c.SharePrice - (decimal)c.HistoryLastPrice[c.HistoryLastPrice.Count - 1]) / (decimal)c.HistoryLastPrice[c.HistoryLastPrice.Count - 1]) * 100;
                }
                c.VariationHistory.Add( c.ShareVariation );
                c.HistoryLastPrice.Add( (double)c.SharePrice );
                c.HistoryNbTransactions.Add( c.NbTransaction );
                c.VolumexVar.Add( c.VolxPrice );
                c.NbTransaction = 0;
            }
            MarketView.FillGraphMarket();
            ShareholderView.FillGraphStrat();
            if (_market.SuperShareholder != null)
            {
                ShareholderView.FillShareholderPortfolio( _market.SuperShareholder );
                ShareholderView.FillGraphShareholder( _market.SuperShareholder );
            }
                
            if (_market.SuperCompany != null) MarketView.FillGraphCompany( _market.SuperCompany );           
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if (GoTimer != null) GoTimer.Stop();
        }

        private void _buttonInitialize_Click( object sender, EventArgs e )
        {
            using (var d = new CreateNewWorld())
            {
                DialogResult r = d.ShowDialog();

                if (r == DialogResult.OK)
                {
                    if (d.CompanyNumber > 0 && d.CompanyNumber <= 50 && d.ShareholderNumber > 0)
                    {
                        _market.companyList.Clear();
                        _market.shareholderList.Clear();
                        _market.ClearOrderbook();
                        _market.RoundCount = 0;
                        _market.HistoryMarketValue.Clear();
                        //Builder.CreateAll( _market, d.CompanyNumber, d.ShareholderNumber );
                        Builder.CreateAll( _market, d.CompanyNumber, d.ShareOfRandoms, d.ShareOfStupids, d.ShareOfSmarts );

                    }
                    else
                    {
                        MessageBox.Show( "Wrong company or shareholder number input data" );
                        _buttonInitialize_Click( sender, e );
                    }
                }
            }
        }

        private void saveMarket_Click( object sender, EventArgs e )
        {
            SaveFileDialog saveMarket = new SaveFileDialog();
            saveMarket.Filter = "Fichier market(*.market)|*.market";

            if (saveMarket.ShowDialog() == DialogResult.OK)
            {
                _market.Save( saveMarket.FileName );
            }
        }

        private void openMarket_Click( object sender, EventArgs e )
        {
            OpenFileDialog loadMarket = new OpenFileDialog();
            loadMarket.Filter = "Fichier market(*.market)|*.market";

            if (loadMarket.ShowDialog() == DialogResult.OK)
            {
                _market = _market.Load( loadMarket.FileName );
                var h = MarketLoad;
                if (h != null) h( this, new EventArgs() );
            }
        }   
    }
}
