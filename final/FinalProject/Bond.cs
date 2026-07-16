using System;

namespace FinalProject
{
    public class Bond : Asset
    {
        private double _couponRate;
        private DateTime _maturityDate;

        public Bond(string name, string ticker, string sector, double price, double quantity, DateTime purchaseDate,
                    double couponRate, DateTime maturityDate)
            : base(name, ticker, sector, price, quantity, purchaseDate)
        {
            _couponRate = couponRate;
            _maturityDate = maturityDate;
        }

        public double GetCouponRate() { return _couponRate; }
        public DateTime GetMaturityDate() { return _maturityDate; }

        public override double CalculateCurrentValue()
        {
            double baseValue = base.CalculateCurrentValue();
            double accruedInterest = baseValue * (_couponRate / 100.0) * 0.25;
            return baseValue + accruedInterest;
        }

        public override string GetRiskLevel()
        {
            return "Low";
        }

        public override string GetSummary()
        {
            string baseSummary = base.GetSummary();
            return $"{baseSummary} | Coupon: {_couponRate}% | Matures: {_maturityDate:MMM dd, yyyy} | Risk: {GetRiskLevel()}";
        }
    }
}