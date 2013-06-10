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
            get { return Convert.ToInt32( _nbShareholderTextBox.Text ); }
        }

        private void _okButton_Click( object sender, EventArgs e )
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void _cancelButton_Click( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //private void textBox1_KeyPress( object sender, KeyPressEventArgs e )
        //{
        //    if (!char.IsControl( e.KeyChar ) && !char.IsDigit( e.KeyChar ))
        //    {
        //        e.Handled = true;
        //    }
        //    else
        //    {
        //        e.Handled = false;
        //    }
        //}
    }
}
