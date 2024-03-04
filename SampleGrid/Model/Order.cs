using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGrid.Model
{
    public class Order : ViewModelBase
    {
        #region Fields
        private string supplier;
        private DateTime date;
        private string productName;
        private int quantity;
        #endregion

        #region Properties
        public string Supplier { get { return supplier; } set { supplier = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public string ProductName { get { return productName; } set { productName = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        #endregion

        #region Constructor
        public Order(string supplier, DateTime date, string productName, int quantity)
        {
            this.supplier = supplier;
            this.date = date;
            this.productName = productName;
            this.quantity = quantity;
        }
        #endregion



    }
}
