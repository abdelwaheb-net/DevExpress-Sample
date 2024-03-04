using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGrid.Model
{
  public  class Employee : ViewModelBase
    {
        #region Fields
        private string firstName;
        private string lastName;
        private string title;
        private string notes;
        //private List<Order> orders;
private ObservableCollection<Order> _orders;
        #endregion


        #region Properties
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
  
        //public List<Order> Orders { get { return orders; } }       
        public ObservableCollection<Order> Orders
        {

            get { return _orders; }
            set { SetProperty(ref _orders, value, () => Orders); }
        }


        #endregion

        #region Constructors
        public Employee(string firstName, string lastName, string title, string notes)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.title = title;
            this.notes = notes;
            //this.orders = new List<Order>();
        }
        public Employee() { }
        #endregion

  
    }
}
