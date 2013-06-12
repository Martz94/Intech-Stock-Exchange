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
    public partial class ChangeCompany : Form
    {
        public ChangeCompany()
        {
            InitializeComponent();
            this._companyNameTextBox.Focus();
        }

        public string CompanyName
        {
            get { return _companyNameTextBox.Text; }
        }

        public decimal ShareValue
        {
            get { return Convert.ToDecimal(_shareValueTextBox.Text); }
        }

        public bool IsShareValueDecimal(out decimal d)
        {
            return (decimal.TryParse( _shareValueTextBox.Text, out d ));
        }

        private void _buttonOk_Click( object sender, EventArgs e )
        {
            //Need to :
            //- Check input numbers,           
            DialogResult = DialogResult.OK;
            Close();
        }

        private void _buttonCancel_Click( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void _okButton_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ChangeCompany_Enter( object sender, EventArgs e )
        {
            _companyNameTextBox.Focus();
        }
    }
}
