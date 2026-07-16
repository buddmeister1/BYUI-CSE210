using System;

namespace FinalProject
{
    public class Transaction
    {
        private DateTime _date;
        private string _assetTicker;
        private int _quantity;
        private double _price;
        private string _transactionType;

        public Transaction(DateTime date, string assetTicker, int quantity, double price, string transactionType)
        {
            _date = date;
            _assetTicker = assetTicker;
            _quantity = quantity;
            _price = price;
            _transactionType = transactionType;
        }

        public DateTime GetDate() { return _date; }
        public string GetAssetTicker() { return _assetTicker; }
        public int GetQuantity() { return _quantity; }
        public double GetPrice() { return _price; }
        public string GetTransactionType() { return _transactionType; }

        public double GetTotalAmount()
        {
            return _quantity * _price;
        }

        public string GetSummary()
        {
            return $"{_date:MMM dd, yyyy}: {_transactionType} {_quantity} shares of {_assetTicker} @ ${_price:F2} (Total: ${GetTotalAmount():F2})";
        }
    }
}