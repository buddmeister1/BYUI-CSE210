using System;
using System.Collections.Generic;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Investment Portfolio & Stock Screener");
            Console.WriteLine(" Data From: June 15, 2026 (stocks_june2026.csv)");
  

            List<Stock> allStocks = StockDataLoader.LoadStocksFromCsv("stocks_june2026.csv");
            Console.WriteLine($"Loaded {allStocks.Count} stocks/ETFs from the dataset.\n");

            List<Stock> topStocks = GrowthScoreCalculator.GetTopStocks(allStocks, 15);
            Console.WriteLine("---- TOP 15 STOCKS (Ranked by Growth Score) ----");
            int rank = 1;
            foreach (Stock stock in topStocks)
            {
                double score = GrowthScoreCalculator.CalculateGrowthScore(stock);
                Console.WriteLine($"{rank}. {stock.GetTicker()} - {stock.GetName()} | Price: ${stock.GetPrice():F2} | Risk: {stock.GetRiskLevel()} | Score: {score:F1}");
                rank++;
            }
            Console.WriteLine();

            string investorName = PortfolioBuilder.PromptForInvestorName();
            Console.WriteLine();

            PortfolioBuilder.DisplayAvailableStocks(allStocks);

            List<Stock> selectedStocks = PortfolioBuilder.PromptForStockSelections(allStocks);
            Console.WriteLine();

            if (selectedStocks.Count == 0)
            {
                Console.WriteLine("No stocks were selected, so no custom portfolio was built.");
            }
            else
            {
                Dictionary<Stock, double> monthlyAmounts = PortfolioBuilder.PromptForMonthlyAmounts(selectedStocks);
                int projectionYears = PortfolioBuilder.PromptForProjectionYears();
                double totalMonthly = PortfolioBuilder.CalculateTotalMonthlyAmount(monthlyAmounts);

                Console.WriteLine();
                Console.WriteLine($" {investorName.ToUpper()}'S CUSTOM PORTFOLIO ALLOCATION");
                Console.WriteLine($"Total Monthly Investment: ${totalMonthly:F2}");

                Investor investor = new Investor(investorName, "Custom");
                Portfolio portfolio = new Portfolio(investorName);
                List<Transaction> transactions = new List<Transaction>();

                foreach (KeyValuePair<Stock, double> entry in monthlyAmounts)
                {
                    Stock stock = entry.Key;
                    double monthlyAmount = entry.Value;
                    double percentage = PortfolioBuilder.CalculatePercentageOfTotal(monthlyAmount, totalMonthly);

                    Console.WriteLine($"{stock.GetTicker()}: ${monthlyAmount:F2}/month ({percentage:F1}% of total)");

                    double impliedShares = monthlyAmount / stock.GetPrice();
                    Stock heldStock = new Stock(stock.GetName(), stock.GetTicker(), stock.GetSector(), stock.GetPrice(),
                                                 impliedShares, DateTime.Now, stock.GetPeRatio(), stock.GetDividendYield(),
                                                 stock.GetRiskNote(), stock.GetMomentumNote(), stock.GetCategory(),
                                                 stock.GetDataConfidence(), stock.GetAsOfDate());
                    portfolio.AddAsset(heldStock);

                    Transaction purchase = new Transaction(DateTime.Now, stock.GetTicker(), 1, monthlyAmount, "Buy");
                    transactions.Add(purchase);
                }
                investor.AddPortfolio(portfolio);

                Console.WriteLine();
                Console.WriteLine("PROJECTED GROWTH PER STOCK");
                foreach (KeyValuePair<Stock, double> entry in monthlyAmounts)
                {
                    Console.WriteLine(InterestCalculator.GetProjectionSummary(entry.Key, entry.Value, 12, projectionYears));
                    Console.WriteLine();
                }

                Console.WriteLine("PORTFOLIO DEMONSTRATION");
                Console.WriteLine(portfolio.GetSummary());
                Console.WriteLine(investor.GetSummary());
                Console.WriteLine();

                Console.WriteLine("DIVERSIFIED BY SECTOR");
                Dictionary<string, double> breakdown = portfolio.GetDiversificationBySector();
                foreach (KeyValuePair<string, double> sectorEntry in breakdown)
                {
                    Console.WriteLine($"{sectorEntry.Key}: ${sectorEntry.Value:F2}");
                }
                Console.WriteLine();

                Console.WriteLine("TRANSACTION RECORD");
                foreach (Transaction transaction in transactions)
                {
                    Console.WriteLine(transaction.GetSummary());
                }
            }
            Console.WriteLine(" End of demonstration.");

        }
    }
}