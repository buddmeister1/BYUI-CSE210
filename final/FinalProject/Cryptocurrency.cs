using System;

namespace FinalProject
{
    public class Cryptocurrency : Asset
    {
        private string _blockchainNetwork;
        private double _volatilityIndex;

        public Cryptocurrency(string name, string ticker, string sector, double price, double quantity, DateTime purchaseDate,
                               string blockchainNetwork, double volatilityIndex)
            : base(name, ticker, sector, price, quantity, purchaseDate)
        {
            _blockchainNetwork = blockchainNetwork;
            _volatilityIndex = volatilityIndex;
        }

        public string GetBlockchainNetwork() { return _blockchainNetwork; }
        public double GetVolatilityIndex() { return _volatilityIndex; }

        public override double CalculateCurrentValue()
        {
            return base.CalculateCurrentValue();
        }

        public override string GetRiskLevel()
        {
            if (_volatilityIndex >= 70)
            {
                return "High";
            }
            else if (_volatilityIndex >= 40)
            {
                return "Medium";
            }
            else
            {
                return "Low";
            }
        }

        public override string GetSummary()
        {
            string baseSummary = base.GetSummary();
            return $"{baseSummary} | Network: {_blockchainNetwork} | Volatility Index: {_volatilityIndex} | Risk: {GetRiskLevel()}";
        }
    }
}