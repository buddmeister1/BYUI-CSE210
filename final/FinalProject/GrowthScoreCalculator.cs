using System.Collections.Generic;

namespace FinalProject
{
    public static class GrowthScoreCalculator
    {
        public static double CalculateGrowthScore(Stock stock)
        {
            double peScore;
            if (stock.GetPeRatio() > 0)
            {
                peScore = 100 - stock.GetPeRatio();
                if (peScore < 0)
                {
                    peScore = 0;
                }
            }
            else
            {
                peScore = 50;
            }

            double priceScore;
            if (stock.GetPrice() <= 50)
            {
                priceScore = 100;
            }
            else if (stock.GetPrice() <= 150)
            {
                priceScore = 60;
            }
            else
            {
                priceScore = 30;
            }

            double riskScore;
            string riskLevel = stock.GetRiskLevel();
            if (riskLevel == "High")
            {
                riskScore = 80;
            }
            else if (riskLevel == "Medium")
            {
                riskScore = 60;
            }
            else
            {
                riskScore = 40;
            }

            return (peScore * 0.40) + (priceScore * 0.30) + (riskScore * 0.30);
        }

        public static string AssignRiskCategory(Stock stock)
        {
            return stock.GetRiskLevel();
        }

        public static List<Stock> GetTopStocks(List<Stock> stocks, int count)
        {
            List<Stock> sortedStocks = SortStocksByScoreDescending(stocks);
            List<Stock> topStocks = new List<Stock>();

            int numberToTake = count;
            if (numberToTake > sortedStocks.Count)
            {
                numberToTake = sortedStocks.Count;
            }

            for (int i = 0; i < numberToTake; i++)
            {
                topStocks.Add(sortedStocks[i]);
            }

            return topStocks;
        }

        private static List<Stock> SortStocksByScoreDescending(List<Stock> stocks)
        {
            List<Stock> sortedList = new List<Stock>(stocks);

            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                int highestIndex = i;
                for (int j = i + 1; j < sortedList.Count; j++)
                {
                    double scoreJ = CalculateGrowthScore(sortedList[j]);
                    double scoreHighest = CalculateGrowthScore(sortedList[highestIndex]);
                    if (scoreJ > scoreHighest)
                    {
                        highestIndex = j;
                    }
                }

                if (highestIndex != i)
                {
                    Stock temp = sortedList[i];
                    sortedList[i] = sortedList[highestIndex];
                    sortedList[highestIndex] = temp;
                }
            }

            return sortedList;
        }
    }
}