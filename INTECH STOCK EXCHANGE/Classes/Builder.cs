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
        public static void CreateAll(Market market, int maxCompanies, int maxShareholders )
        {
            market.companyList.Clear();
            market.shareholderList.Clear();

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

                Random r2 = market.Random;
                int shareVolume = r2.Next( 500000 );

                Array values = Enum.GetValues( typeof( Company.Industry ) );
                Random random = market.Random;
                Company.Industry randomInd = (Company.Industry)values.GetValue( random.Next( values.Length ) );

                Random rdm = market.Random;
                int k = rdm.Next( market.companyNames.Count );
                string name = market.companyNames[k];
                market.companyNames.RemoveAt( k );

                market.AddOrUpdateCompany( name, randomInd, sharePrice, shareVolume );
            }
            for (int t = 0; t < maxShareholders; t++)
            {
                string name;
                name = "Shareholder n°" + t;
                //Random rdm = market.Random;
                //name = Path.GetRandomFileName();
                //name = name.Replace(".", ""); // For Removing the dots and spaces
                market.shareholderList.Add( new Shareholder( market, name, 20000.0M ) );
            }

            market.AddShareholders( market.shareholderList );

            // Filling the shareholders portfolios
            foreach (Shareholder s in market.shareholderList)
            {
                foreach (Company c in market.companyList)
                {
                    Random random = market.Random;
                    int shareCount = 0;
                    int rand = random.Next( 6 );

                    if (rand == 1)
                    {
                        shareCount = random.Next(c.GetTotalShareCount / market.shareholderList.Count * 4 / 4);
                    }
                    else if (rand == 2)
                    {
                        shareCount = random.Next(c.GetTotalShareCount / market.shareholderList.Count * 4);
                    }
                    else if (rand == 3)
                    {
                        shareCount = random.Next(c.GetTotalShareCount / market.shareholderList.Count * 16);
                    }
                    if (shareCount != 0 ) s.AlterPortfolio( Market.ActionType.Fill, shareCount, c, s );
                }
                
            }
       
        }
    }
}
