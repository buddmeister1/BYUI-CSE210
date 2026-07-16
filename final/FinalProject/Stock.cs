using System;

namespace FinalProject
{
    public class Stock : Asset
    {
        private double _peRatio;
        private double _dividendYield;
        private string _riskNote;
        private string _momentumNote;
        private string _category;
        private string _dataConfidence;
        private DateTime _asOfDate;

        public Stock(string name, string ticker, string sector, double price, double quantity, DateTime purchaseDate,
                     double peRatio, double dividendYield, string riskNote, string momentumNote,
                     string category, string dataConfidence, DateTime asOfDate)
            : base(name, ticker, sector, price, quantity, purchaseDate)
        {
            _peRatio = peRatio;
            _dividendYield = dividendYield;
            _riskNote = riskNote;
            _momentumNote = momentumNote;
            _category = category;
            _dataConfidence = dataConfidence;
            _asOfDate = asOfDate;
        }

        public double GetPeRatio() { return _peRatio; }
        public double GetDividendYield() { return _dividendYield; }
        public string GetRiskNote() { return _riskNote; }
        public string GetMomentumNote() { return _momentumNote; }
        public string GetCategory() { return _category; }
        public string GetDataConfidence() { return _dataConfidence; }
        public DateTime GetAsOfDate() { return _asOfDate; }

        public override double CalculateCurrentValue()
        {
            return base.CalculateCurrentValue();
        }

        public override string GetRiskLevel()
        {
            if (_riskNote.Contains("High"))
            {
                return "High";
            }
            else if (_riskNote.Contains("Medium"))
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
            return $"{baseSummary} | P/E: {_peRatio} | Div Yield: {_dividendYield}% | Risk: {GetRiskLevel()} | {_momentumNote} | Data: {_dataConfidence} as of {_asOfDate:MMM dd, yyyy}";
        }
    }
}