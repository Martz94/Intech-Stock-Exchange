using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INTECH_STOCK_EXCHANGE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new WinForms() );
            Market market;
            DateTime time;

            market = new Market();
            Builder builder = new Builder(market);
            

        }
    }
}
