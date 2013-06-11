﻿using System;
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
    public partial class MenuFile : UserControl
    {
        Market _market;

        public MenuFile()
        {
            InitializeComponent();
        }

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
                    Builder.CreateAll( _market, d.CompanyNumber, d.ShareholderNumber );
                }
            }
        }

        private void _loadMenu_Click( object sender, EventArgs e )
        {
            OpenFileDialog loadMarket = new OpenFileDialog();
            loadMarket.Filter = "Fichier xml(*.xml)|*.xml";

            if (loadMarket.ShowDialog() == DialogResult.OK)
            {
                Market market = _market.Load( loadMarket.FileName );
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
