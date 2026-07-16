using System.Collections.Generic;

namespace FinalProject
{
    public class Portfolio
    {
        private string _ownerName;
        private List<Asset> _holdings;

        public Portfolio(string ownerName)
        {
            _ownerName = ownerName;
            _holdings = new List<Asset>();
        }

        public string GetOwnerName() { return _ownerName; }
        public List<Asset> GetHoldings() { return _holdings; }

        public void AddAsset(Asset asset)
        {
            _holdings.Add(asset);
        }

        public double CalculateTotalValue()
        {
            double total = 0;
            foreach (Asset asset in _holdings)
            {
                total += asset.CalculateCurrentValue();
            }
            return total;
        }

        public Dictionary<string, double> GetDiversificationBySector()
        {
            Dictionary<string, double> breakdown = new Dictionary<string, double>();
            foreach (Asset asset in _holdings)
            {
                string sector = asset.GetSector();
                double value = asset.CalculateCurrentValue();
                if (breakdown.ContainsKey(sector))
                {
                    breakdown[sector] = breakdown[sector] + value;
                }
                else
                {
                    breakdown.Add(sector, value);
                }
            }
            return breakdown;
        }

        public string GetSummary()
        {
            string summary = $"Portfolio for {_ownerName}: {_holdings.Count} holdings, Total Value: ${CalculateTotalValue():F2}\n";
            foreach (Asset asset in _holdings)
            {
                summary += "  - " + asset.GetSummary() + "\n";
            }
            return summary;
        }
    }
}