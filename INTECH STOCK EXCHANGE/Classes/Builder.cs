using System;
using System.IO;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public class Builder
    {
        public static void CreateAll(Market market, int maxCompanies, int nbOfRandoms, int nbOfStupids, int nbOfSmarts )
        {
            int maxShareholders = nbOfRandoms +  nbOfStupids + nbOfSmarts;
            List<string> tmp = new List<string>();

            foreach (string name in market.companyNames)
            {
                tmp.Add( name );
            }

            // Create companies with companies' numbers defined by user
            for (int i = 0; i < maxCompanies; i++)
            {
                Random r = market.Random;
                int tmprdm = r.Next( 100 );
                double price;
                if (tmprdm > 95) price = 700 + r.NextDouble() * 300;
                else if (tmprdm > 55) price = 300 + r.NextDouble() * 400;
                else price = 5 + r.NextDouble() * 295;

                decimal sharePrice = (decimal)price;

                //Random r2 = market.Random;
                int shareVolume = r.Next( 5000 );

                Array values = Enum.GetValues( typeof( Company.Industry ) );
                //Random random = market.Random;
                Company.Industry randomInd = (Company.Industry)values.GetValue( r.Next( values.Length ) );

                //Random rdm = market.Random;
                int k = r.Next( tmp.Count );
                string name = tmp[k];
                
                tmp.RemoveAt( k );

                market.AddOrUpdateCompany( name, randomInd, sharePrice, shareVolume );
            }

            for ( int t = 0; t < maxShareholders; t++ )
            {
                string name;
                name = "Shareholder n°" + t;
                //market.shareholderList.Add( new Shareholder( market, name, 20000.0M ) );
                market.shareholderList.Add( new Shareholder( market, name, 20000.0M ) );
            }

            //Assigning user-defined strategies to s/h

            for( int i = 0; i < nbOfRandoms; i++ )
            {
                if ( market.shareholderList[i].Strategy == null ) market.shareholderList[i].Strategy = new RandomStrategy();  
            }
            for ( int y = nbOfRandoms; y < nbOfStupids + nbOfRandoms; y++)
            {
                if ( market.shareholderList[y].Strategy == null ) market.shareholderList[y].Strategy = new StupidStrategy();
            }
            for( int z = nbOfRandoms + nbOfStupids; z < market.shareholderList.Count; z++)
            {
                if ( market.shareholderList[z].Strategy == null ) market.shareholderList[z].Strategy = new SmartStrategy();
            }

            market.AddShareholders( market.shareholderList );

            // Filling the shareholders portfolios           
            foreach(Shareholder s in market.shareholderList)
            {
                    Random r = market.Random;
                int maxPortfolioValue = r.Next(5000, 15000);
                while(s.PortfolioValue < maxPortfolioValue)
                {

                    int shareCount = r.Next(1, company.ConvertValueToShareCount(1000));
                    s.Cash = s.Cash - company.ConvertShareCountToValue(shareCount);
                        s.AlterPortfolio( Market.ActionType.Fill, shareCount, company, s );

                }               
            }
            market.AddShareholders( market.shareholderList );
                    //foreach (Company c in market.companyList)
                //{
                //    Random random = market.Random;
                //    int sharePrice = 0;
                //    int rand = random.Next( 6 );

                //    if (rand == 1)
                //    {
                //        sharePrice = random.Next(c.GetTotalShareCount / market.shareholderList.Count * 4 / 4); if
                //   
                //    }
                //    else if (rand == 2)
                //    {
                //        sharePrice = random.Next(c.GetTotalShareCount / market.shareholderList.Count * 4);
                //    }
                //    else if (rand == 3)
                //    {
                //        sharePrice = random.Next(c.GetTotalShareCount / market.shareholderList.Count * 16);
                //    }
                //    if (sharePrice != 0 ) s.AlterPortfolio( Market.ActionType.Fill, sharePrice, c, s );
                //}
            
        }
    }
}
