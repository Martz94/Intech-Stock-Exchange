using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISEdesign
{
    public partial class CreateNewWorld : Form
    {
        public CreateNewWorld()
        {
            InitializeComponent();
        }

        public int CompanyNumber
        {
            get { return Convert.ToInt32( _nbCompanyTextBox.Text ); }
        }

        public int ShareholderNumber
        {
            get { return Convert.ToInt32( _labelNbSh.Text ); }
        }

        //Share of each strategy amongst shareholders (%)
        public int ShareOfRandoms { get { return RandomTrackBar.Value; } }
        public int ShareOfStupids { get { return StupidTrackBar.Value; } }
        public int ShareOfSmarts { get { return SmartTrackBar.Value; } }

        private void _okButton_Click( object sender, EventArgs e )
        {
            //Need to :
            //- Check input numbers
            DialogResult = DialogResult.OK;
            Close();
        }
        private void _cancelButton_Click( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void _Button_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if ( e.KeyCode == Keys.Escape )
            {
                Close();
            }
        }

        private void UpdateTotalShareholders()
        {
            int total = RandomTrackBar.Value + StupidTrackBar.Value + SmartTrackBar.Value;
            _labelNbSh.Text = total.ToString();
        }

        private void RandomTrackBar_ValueChanged( object sender, EventArgs e )
        {
            UpdateTotalShareholders();
            nbRandom.Text = RandomTrackBar.Value.ToString();
        }
        private void StupidTrackBar_ValueChanged( object sender, EventArgs e )
        {
            UpdateTotalShareholders();
            nbStupid.Text = StupidTrackBar.Value.ToString();
        }
        private void SmartTrackBar_ValueChanged( object sender, EventArgs e )
        {
            UpdateTotalShareholders();
            nbSmart.Text = SmartTrackBar.Value.ToString();
        }      
    }
}
