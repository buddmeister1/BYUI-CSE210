namespace FinalProject
{
    public static class InterestCalculator
    {
        public static double ProjectFutureValue(double contributionAmount, int contributionsPerYear, int numberOfYears, double annualGrowthRatePercent)
        {
            double ratePerPeriod = (annualGrowthRatePercent / 100.0) / contributionsPerYear;
            int totalPeriods = contributionsPerYear * numberOfYears;

            double futureValue = 0;

            for (int period = 1; period <= totalPeriods; period++)
            {
                futureValue = futureValue + contributionAmount;
                futureValue = futureValue * (1 + ratePerPeriod);
            }

            return futureValue;
        }

        public static double EstimateAnnualGrowthRateFromRiskLevel(string riskLevel)
        {
            if (riskLevel == "High")
            {
                return 15.0;
            }
            else if (riskLevel == "Medium")
            {
                return 9.0;
            }
            else
            {
                return 6.0;
            }
        }

        public static string GetProjectionSummary(Stock stock, double contributionAmount, int contributionsPerYear, int numberOfYears)
        {
            double growthRate = EstimateAnnualGrowthRateFromRiskLevel(stock.GetRiskLevel());
            double futureValue = ProjectFutureValue(contributionAmount, contributionsPerYear, numberOfYears, growthRate);
            double totalContributed = contributionAmount * contributionsPerYear * numberOfYears;
            double estimatedGrowth = futureValue - totalContributed;

            return $"If you invest ${contributionAmount:F2} {contributionsPerYear} times per year in {stock.GetTicker()} for {numberOfYears} years at an estimated {growthRate}% annual growth rate:\n" +
                   $"  Total Contributed: ${totalContributed:F2}\n" +
                   $"  Projected Future Value: ${futureValue:F2}\n" +
                   $"  Estimated Growth: ${estimatedGrowth:F2}";
        }
    }
}