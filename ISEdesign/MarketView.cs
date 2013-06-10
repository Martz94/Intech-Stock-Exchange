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
using System.Windows.Forms.DataVisualization.Charting;

namespace ISEdesign
{
	public partial class MarketView : UserControl
	{
		Market _market;

		public MarketView()
		{
			InitializeComponent();
		}
		
		public int listViewHeight { get { return _listView.Height; } }
		public System.Windows.Forms.DataVisualization.Charting.Chart GraphCompany;

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
				i.UseItemStyleForSubItems = false;
				i.SubItems.Add( c.SharePrice.ToString( "#.###" ) );
				i.SubItems.Add( c.ShareVolume.ToString() );
				i.SubItems.Add( c.ShareVariation.ToString( "N2" ) +" %");

				if (c.ShareVariation < 0)
				{
					i.SubItems[3].ForeColor = System.Drawing.Color.Red;
				}
				else i.SubItems[3].ForeColor = System.Drawing.Color.Green;

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
					_listView.SelectedItems[0].Text.Trim();
					ListViewItem i = _listView.SelectedItems[0];
					decimal price;
					if (_market.CheckNameCompany( t.CompanyName ))
					{
						MessageBox.Show( "The name of the company already exists." );
					}
					else if (t.IsShareValueDecimal(out price))
					{
						_market.UpdateCompanyPrice( i.Text, t.ShareValue );
					}

					if (!_market.CheckNameCompany( t.CompanyName ) && t.CompanyName != "")
					{
						_market.ChangeCompanyName( i.Text, t.CompanyName );
					}
				}
			}
		}


		public void FillGraphCompany(Company company)
		{
			GraphCompany.Series.Clear();
			GraphCompany.Titles.Clear();
			List<double> history = company.HistoryPrice;
			GraphCompany.Palette = ChartColorPalette.SeaGreen;
			GraphCompany.Titles.Add( company.Name );
			Series series = GraphCompany.Series.Add( "" );

			for (int j = 0; j < history.Count; j++)
			{
				series.Points.Add( history[j] );
			}

			series.Points.Add( (double)company.SharePrice );
		}

		private void _listView_Click( object sender, EventArgs e )
		{
			
			int[] pointsArray = { 1, 2 };



			ListViewItem i = _listView.SelectedItems[0];
			Company company = null;
			foreach (var c in _market.Companies)
			{
				if (c.Name == i.Text) company = c;
			}

			_market.SuperCompany = company;
			FillGraphCompany( company );
			
		}

		private void _listView_ColumnClick( object sender, ColumnClickEventArgs e )
		{
			
		}
	}
}
