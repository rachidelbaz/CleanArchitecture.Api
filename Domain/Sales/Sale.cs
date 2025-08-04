using Domain.Common;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;

namespace Domain.Sales
{
    public class Sale : IEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Product  Product { get; set; }

        private decimal _unitPrice;

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; UpdateTotalPrice(); }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; UpdateTotalPrice(); }
        }

        private decimal _totalPrice;

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        private void UpdateTotalPrice()
        {
            _totalPrice = _unitPrice * _quantity;
        }

    }
}
