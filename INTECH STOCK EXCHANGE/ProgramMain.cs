using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace INTECH_STOCK_EXCHANGE
{
    static class ProgramMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Market market;
            DateTime time;
            int maxRound = 1;//Set from the GUI sometime
            //int nbShareholders = 100; Set from the GUI sometime
            //int nbCompanies; Possibly set from the GUI (or just nbShareholders/4)

            //Market Initialization

            market = new Market(); //Creating an empty market with empty lists of s/h, firms and orders (The orderbook)
            
            //Market Building
            //Instancing companies and s/h objects. Filling portfolios and capitals to get the game going

            //Builder builder = new Builder();
            //builder.CreateAll( market); 
            //System.Diagnostics.Debug.WriteLine( market.ToString() );

            Play( market, maxRound ); //Called again and again by UI
        }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault( false );
            //Application.Run( new WinForms() );

        //STATIC METHOD HERE (?)
        static void Play(Market market, int maxRound)
        {
            int i;
            for ( i = 0; i < maxRound; i++ )
            {
                foreach ( Shareholder sh in market.shareholderList )
                {
                    Order newOrder = sh.MakeDecision( market, sh );
                    if ( newOrder != null ) market.globalOrderbook.Add( newOrder );
                }
                System.Diagnostics.Debug.WriteLine( market.OrderBookToString() );
                market.MatchOrders();
                market.Clear();

                //System.Diagnostics.Debug.WriteLine( "after round #" + (i + 1) );
                //System.Diagnostics.Debug.WriteLine( market.ToString() );
            }           
        }
    }
}