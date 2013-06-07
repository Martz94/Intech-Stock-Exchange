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
        public void CreateAll(Market market)
        {
            int _maxCompanies = 20;
            int _maxShareholders = 1000;

            // Create companies with companies' numbers defined by user
            for (int i = 0; i < _maxCompanies; i++)
            {
                Random r = market.Random;
                double price = 5 + r.NextDouble() * 995;
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

                Company newCompany = new Company( market, name, randomInd, sharePrice, shareVolume );
            }

            // Create shareholders with shareholders' numbers defined by user
            for (int t = 0; t < _maxShareholders; t++)
            {
                string name;
                Random rdm = market.Random;
                //if ( market.GetNameList.Count > 1 )
                //{
                //    int k = rdm.Next( market.shareholderNames.Count );
                //    name = market.shareholderNames[k];
                //    market.shareholderNames.RemoveAt( k );
                //}
                //else
                //{
                    name = Path.GetRandomFileName();
                    name = name.Replace(".", ""); // For Removing the dots and spaces
                //}
                Shareholder newshareholder = new Shareholder( market, name, 20000.0M );
            }

            // Filling the shareholders portfolios
            foreach (Shareholder s in market.shareholderList)
            {
                foreach (Company c in market.companyList)
                {
                    Random random = market.Random;
                    int shareCount = random.Next(c.GetTotalShareCount);

                    market.AlterPortfolio( Market.ActionType.Fill, shareCount, c, s );
                }
                
            }

            // Filling the shareholders portfolios
            //foreach ( Shareholder s in market.shareholderList )
            //{
            //    market.AlterPortfolio( Market.ActionType.Fill, 20, Google, s ); //Google gives 100 shares, keeps 200
            //    market.AlterPortfolio( Market.ActionType.Fill, 20, Facebook, s ); //Facebook gives 100 shares, keeps 205
            //    market.AlterPortfolio( Market.ActionType.Fill, 15, Twitter, s ); //Twitter gives 75 shares, keeps 25
            //    market.AlterPortfolio( Market.ActionType.Fill, 20, Axa, s ); //Axa gives 100 shares, keeps 10
            //    market.AlterPortfolio( Market.ActionType.Fill, 10, Alliance, s ); //Alliance gives 50 shares, keeps 10
            //    market.AlterPortfolio( Market.ActionType.Fill, 15, Yoyo, s ); //Yoyo gives 75 shares, keeps 14
            //    market.AlterPortfolio( Market.ActionType.Fill, 20, Monsanto, s ); //Monsanto gives 100 shares, keeps 10
            //    market.AlterPortfolio( Market.ActionType.Fill, 15, Boiron, s ); //Boiron gives 75 shares, keeps 25
            //    market.AlterPortfolio( Market.ActionType.Fill, 15, Pfizer, s ); //Pfizer gives 75 shares, keeps 3
            //    market.AlterPortfolio( Market.ActionType.Fill, 20, Sanofi, s ); //Sanofi gives 100 shares, keeps 10
            //}           
        }
    }
}
