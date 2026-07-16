using System;
using System.Collections.Generic;

namespace FinalProject
{
    // Handles all the interactive console input for building a custom, user-driven portfolio. Keeping this separate from Program.cs gives a clear responsibility.

    public static class PortfolioBuilder
    {
        public static string PromptForInvestorName()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Investor";
            }

            return name.Trim();
        }

        public static void DisplayAvailableStocks(List<Stock> stocks)
        {
            Console.WriteLine("---- AVAILABLE STOCKS / ETFS ----");
            foreach (Stock stock in stocks)
            {
                Console.WriteLine($"{stock.GetTicker(),-6} {stock.GetName(),-32} Price: ${stock.GetPrice(),8:F2}  Risk: {stock.GetRiskLevel()}");
            }
            Console.WriteLine();
        }

        public static List<Stock> PromptForStockSelections(List<Stock> allStocks)
        {
            List<Stock> selectedStocks = new List<Stock>();

            Console.WriteLine("Enter a ticker symbol to add it to your portfolio.");
            Console.WriteLine("Type DONE when you are finished selecting stocks.");

            bool finished = false;
            while (!finished)
            {
                Console.Write("Ticker (or DONE): ");
                string input = Console.ReadLine() ?? "";
                string trimmedInput = input.Trim().ToUpper();

                if (trimmedInput == "DONE")
                {
                    finished = true;
                }
                else
                {
                    Stock foundStock = FindStockByTicker(allStocks, trimmedInput);

                    if (foundStock == null)
                    {
                        Console.WriteLine("That ticker was not found in the dataset. Please try again.");
                    }
                    else if (selectedStocks.Contains(foundStock))
                    {
                        Console.WriteLine("You already added that stock.");
                    }
                    else
                    {
                        selectedStocks.Add(foundStock);
                        Console.WriteLine($"Added {foundStock.GetTicker()} - {foundStock.GetName()}.");
                    }
                }
            }

            return selectedStocks;
        }

        private static Stock FindStockByTicker(List<Stock> stocks, string ticker)
        {
            foreach (Stock stock in stocks)
            {
                if (stock.GetTicker() == ticker)
                {
                    return stock;
                }
            }
            return null;
        }

        public static Dictionary<Stock, double> PromptForMonthlyAmounts(List<Stock> selectedStocks)
        {
            Dictionary<Stock, double> monthlyAmounts = new Dictionary<Stock, double>();

            foreach (Stock stock in selectedStocks)
            {
                double amount = PromptForPositiveDouble($"How much would you like to invest per month in {stock.GetTicker()}? $");
                monthlyAmounts.Add(stock, amount);
            }

            return monthlyAmounts;
        }

        public static int PromptForProjectionYears()
        {
            return (int)PromptForPositiveDouble("How many years would you like to project your investment growth? ");
        }

        private static double PromptForPositiveDouble(string message)
        {
            double result = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(message);
                string input = Console.ReadLine() ?? "";
                bool parsed = double.TryParse(input, out result);

                if (parsed && result > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number.");
                }
            }

            return result;
        }

        public static double CalculateTotalMonthlyAmount(Dictionary<Stock, double> monthlyAmounts)
        {
            double total = 0;
            foreach (KeyValuePair<Stock, double> entry in monthlyAmounts)
            {
                total += entry.Value;
            }
            return total;
        }

        public static double CalculatePercentageOfTotal(double amount, double total)
        {
            if (total <= 0)
            {
                return 0;
            }
            return (amount / total) * 100;
        }
    }
}