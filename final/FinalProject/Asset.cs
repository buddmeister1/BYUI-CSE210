using System;

namespace FinalProject
{
    public abstract class Asset
    {
        private string _name;
        private string _ticker;
        private string _sector;
        private double _price;
        private double _quantity;
        private DateTime _purchaseDate;

        public Asset(string name, string ticker, string sector, double price, double quantity, DateTime purchaseDate)
        {
            _name = name;
            _ticker = ticker;
            _sector = sector;
            _price = price;
            _quantity = quantity;
            _purchaseDate = purchaseDate;
        }

        public string GetName() { return _name; }
        public string GetTicker() { return _ticker; }
        public string GetSector() { return _sector; }
        public double GetPrice() { return _price; }
        public void SetPrice(double price) { _price = price; }
        public double GetQuantity() { return _quantity; }
        public DateTime GetPurchaseDate() { return _purchaseDate; }

        public virtual double CalculateCurrentValue()
        {
            return _price * _quantity;
        }

        public virtual string GetRiskLevel()
        {
            return "Unknown";
        }

        public virtual string GetSummary()
        {
            return $"{_name} ({_ticker}) - {_quantity:F4} shares @ ${_price:F2} = ${CalculateCurrentValue():F2}";
        }
    }
}