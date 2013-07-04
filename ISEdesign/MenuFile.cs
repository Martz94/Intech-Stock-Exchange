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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ISEdesign
{
    public partial class MenuFile : UserControl
    {
        Market _market;


        public Market Market { get { return _market; } }
        public MenuFile()
        {
            InitializeComponent();
        }

        public EventHandler<EventArgs> MarketLoad;

        internal void SetMarket( Market m )
        {
            _market = m;
        }

        private void _initializeMenu_Click( object sender, EventArgs e )
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
                        _initializeMenu_Click (sender, e);
                    }
                }
            }
        }

        private void _loadMenu_Click( object sender, EventArgs e )
        {
            OpenFileDialog loadMarket = new OpenFileDialog();
            loadMarket.Filter = "Fichier xml(*.xml)|*.xml";

            if (loadMarket.ShowDialog() == DialogResult.OK)
            {
                _market = _market.Load( loadMarket.FileName );
                var h = MarketLoad;
                if (h != null) h( this, new EventArgs() );
            }
        }

        private void _saveMenu_Click( object sender, EventArgs e )
        {
            SaveFileDialog saveMarket = new SaveFileDialog();
            saveMarket.Filter = "Fichier xml(*.xml)|*.xml";

            if (saveMarket.ShowDialog() == DialogResult.OK)
            {
                _market.Save( saveMarket.FileName );
            }
        }
    }
}
