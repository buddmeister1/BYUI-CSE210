using System.Collections.Generic;

namespace FinalProject
{
    public class Investor
    {
        private string _name;
        private string _riskTolerance;
        private List<Portfolio> _portfolios;

        public Investor(string name, string riskTolerance)
        {
            _name = name;
            _riskTolerance = riskTolerance;
            _portfolios = new List<Portfolio>();
        }

        public string GetName() { return _name; }
        public string GetRiskTolerance() { return _riskTolerance; }
        public List<Portfolio> GetPortfolios() { return _portfolios; }

        public void AddPortfolio(Portfolio portfolio)
        {
            _portfolios.Add(portfolio);
        }

        public double CalculateTotalNetWorth()
        {
            double total = 0;
            foreach (Portfolio portfolio in _portfolios)
            {
                total += portfolio.CalculateTotalValue();
            }
            return total;
        }

        public string GetSummary()
        {
            return $"Investor: {_name} | Risk Tolerance: {_riskTolerance} | Portfolios: {_portfolios.Count} | Total Net Worth: ${CalculateTotalNetWorth():F2}";
        }
    }
}