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

        private void _nbCompanyTextBox_Validating( object sender, CancelEventArgs e )
        {
            //if (Char.IsControl( e.KeyChar ) || !Char.IsNumber( e.KeyChar ))
            //{
            //    e.Handled = true; // Set l'evenement comme etant completement fini
            //    return;
            //}
        }
    }
}
