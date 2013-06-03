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
            // 10 Companies
            Company Google = new Company( market, "Google", Company.Industry.IT, 100.0M, 300 );
            Company Facebook = new Company(market, "Facebook", Company.Industry.IT, 120.0M, 305);
            Company Twitter = new Company(market, "Twitter", Company.Industry.IT, 78.0M, 100 );
            Company Axa = new Company( market, "Axa", Company.Industry.Insurance, 90.0M, 110 );
            Company Alliance = new Company(market, "Alliance", Company.Industry.Insurance, 110.0M, 60);
            Company Yoyo = new Company(market, "Yoyo", Company.Industry.Agriculture, 67.0M, 89);
            Company Monsanto = new Company(market, "Monsanto", Company.Industry.Agriculture, 57.0M, 110);
            Company Boiron = new Company(market, "Boiron", Company.Industry.Pharmaceuticals, 60.0M, 100);
            Company Pfizer = new Company(market, "Pfizer", Company.Industry.Pharmaceuticals, 100.0M, 78);
            Company Sanofi = new Company(market, "Sanofi", Company.Industry.Pharmaceuticals, 97.0M, 110);

            // 5 Shareholders
            Shareholder Marc = new Shareholder(market, "Marc", 1000.0M);
            Shareholder John = new Shareholder(market, "John", 2000.0M);
            Shareholder Martin = new Shareholder(market, "Martin", 7000.0M);
            Shareholder Camille = new Shareholder(market, "Camille", 10000.0M);
            Shareholder Olivier = new Shareholder(market, "Olivier", 12000.0M);

            // Filling the shareholders portfolios
            foreach ( Shareholder s in market.shareholderList )
            {
                market.AlterPortfolio( Market.ActionType.Fill, 20, Google, s ); //Google gives 100 shares, keeps 200
                market.AlterPortfolio( Market.ActionType.Fill, 20, Facebook, s ); //Facebook gives 100 shares, keeps 205
                market.AlterPortfolio( Market.ActionType.Fill, 15, Twitter, s ); //Twitter gives 75 shares, keeps 25
                market.AlterPortfolio( Market.ActionType.Fill, 20, Axa, s ); //Axa gives 100 shares, keeps 10
                market.AlterPortfolio( Market.ActionType.Fill, 10, Alliance, s ); //Alliance gives 50 shares, keeps 10
                market.AlterPortfolio( Market.ActionType.Fill, 15, Yoyo, s ); //Yoyo gives 75 shares, keeps 14
                market.AlterPortfolio( Market.ActionType.Fill, 20, Monsanto, s ); //Monsanto gives 100 shares, keeps 10
                market.AlterPortfolio( Market.ActionType.Fill, 15, Boiron, s ); //Boiron gives 75 shares, keeps 25
                market.AlterPortfolio( Market.ActionType.Fill, 15, Pfizer, s ); //Pfizer gives 75 shares, keeps 3
                market.AlterPortfolio( Market.ActionType.Fill, 20, Sanofi, s ); //Sanofi gives 100 shares, keeps 10
            }           
        }
    }
}
