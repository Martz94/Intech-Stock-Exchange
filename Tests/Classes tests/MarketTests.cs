using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using INTECH_STOCK_EXCHANGE;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tests.Classes_tests
{
    [TestFixture]
    public class MarketTests
    {
        [Test]
        public void TestingMarket()
        {
            Market Pouet = new Market();
            int maxRound = 5;

            //Builder.CreateAll(Pouet);

            Play( Pouet, maxRound );

            // Serialization
            Stream stream = File.Open( "data.xml", FileMode.Create );
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize( stream, Pouet );
            stream.Close();

            // Deserialization
            stream = File.Open( "data.xml", FileMode.Open );
            formatter = new BinaryFormatter();
            Pouet = (Market)formatter.Deserialize( stream );
            stream.Close();
        }

        static void Play( Market market, int maxRound )
        {
            int i;
            for (i = 0; i < maxRound; i++)
            {
                foreach (Shareholder sh in market.shareholderList)
                {
                    Order newOrder = sh.MakeDecision( market, sh );
                    if (newOrder != null) market.globalOrderbook.Add( newOrder );
                }
                market.MatchOrders();
                market.Clear();
            }
        }
    }
}