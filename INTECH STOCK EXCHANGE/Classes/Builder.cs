using System;
using System.IO;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPoco;
using AutoPoco.Engine;
using AutoPoco.DataSources;

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

            List<Shareholder> shareholdersList = new List<Shareholder>();
            // Create shareholders with shareholders' numbers defined by user
            IGenerationSessionFactory mFactory = AutoPocoContainer.Configure( x =>
            {
                x.Conventions( c =>
                {
                    c.UseDefaultConventions();
                });
                    x.AddFromAssemblyContainingType<SimpleUser>();
                    x.Include<SimpleUser>()
                        .Setup( c => c.FirstName ).Use<FirstNameSource>()
                        .Setup( c => c.LastName ).Use<LastNameSource>();
            });

            IGenerationSession session = mFactory.CreateSession();

            //SimpleUser userName = session.Single<SimpleUser>().Get();
            IList<SimpleUser> users = session.List<SimpleUser>( maxShareholders ).Get();
                
            for (int t = 0; t < maxShareholders; t++)
            {
                string name;
                //Random rdm = market.Random;
                //name = Path.GetRandomFileName();
                //name = name.Replace(".", ""); // For Removing the dots and spaces
                //}
                //shareholdersList.Add( new Shareholder( market, name, 20000.0M ) );
                SimpleUser user = users.FirstOrDefault();
                shareholdersList.Add( new Shareholder( market, user.FirstName + " " + user.LastName, 20000.0M ) );
                users.Remove( user );
            }

            market.AddShareholders( shareholdersList );

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
