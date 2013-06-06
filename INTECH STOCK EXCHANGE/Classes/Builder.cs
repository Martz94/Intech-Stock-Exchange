using System;
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
            int _maxCompanies = 30;
            int _maxShareholders = 60;

            // Create companies with companies' numbers defined by user
            for (int i = 0; i < _maxCompanies; i++)
            {
                Random r = new Random();
                double price = 5 + r.NextDouble() * 995;
                decimal sharePrice = (decimal)price;

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
            }

            // Create shareholders with shareholders' numbers defined by user
            for (int t = 0; t < _maxShareholders; t++)
            {
                Random rdm = new Random();
                int k = rdm.Next( market.shareholderNames.Count );
                string name = market.shareholderNames[k];
                market.shareholderNames.RemoveAt( k );

                Shareholder newshareholder = new Shareholder( market, name, 20000.0M );
            }

            // Filling the shareholders portfolios
            foreach (Shareholder s in market.shareholderList)
            {
                foreach (Company c in market.companyList)
                {
                    Random random = new Random();
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
