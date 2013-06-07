using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_STOCK_EXCHANGE
{
    public class Builder
    {
        public static void CreateAll(Market market, int maxCompanies, int maxShareholders)
        {

            // Create companies with companies' numbers defined by user
            market.companyList.Clear();
            market.shareholderList.Clear();

            for (int i = 0; i < maxCompanies; i++)
            {
                // max sharePrice = 1000
                Random r = new Random( (int)DateTime.Now.Ticks );
                double price = 5 + r.NextDouble() * 995;
                decimal sharePrice = (decimal)price;

                // max shareVolume = 500 000
                Random r2 = new Random();
                int shareVolume = r.Next( 500000 );

                Array values = Enum.GetValues( typeof( Company.Industry ) );
                Random random = new Random();
                Company.Industry randomInd = (Company.Industry)values.GetValue( random.Next( values.Length ) );

                Random rdm = new Random();
                int k = rdm.Next( market.companyNames.Count );
                string name = market.companyNames[k];
                market.companyNames.RemoveAt( k );

                Company newCompany = new Company( market, name, randomInd, sharePrice, shareVolume );
                market.AddOrUpdateCompany( name, randomInd, sharePrice, shareVolume );
            }

            // Create shareholders with shareholders' numbers defined by user
            for (int t = 0; t < maxShareholders; t++)
            {
                Random rdm = new Random();
                int k = rdm.Next( market.shareholderNames.Count );
                string name = market.shareholderNames[k];
                market.shareholderNames.RemoveAt( k );

                Shareholder newshareholder = new Shareholder( market, name, 20000.0M );
                market.AddOrUpdateShareholders( name, 20000.0M );
            }

            // Filling the shareholders portfolios
            Random rand3 = new Random( (int)DateTime.Now.Ticks );
            foreach (Company c in market.companyList)
            {
                
                foreach (Shareholder s in market.shareholderList)
                {
                    int shareCount = rand3.Next(c.GetTotalShareCount);
                    market.AlterPortfolio( Market.ActionType.Fill, shareCount, c, s );
                }
                
            }     
        }
    }
}
