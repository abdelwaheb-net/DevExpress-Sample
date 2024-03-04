using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGrid.Model
{
  public  class Department : ViewModelBase
    {
        #region Fields
        private int id;
        private string name;
        //private List<Employee> employees;
        private ObservableCollection<Employee> _employees;
        #endregion


        #region Properties
        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        //public List<Employee> Employees{ get { return employees; }}

        
        public ObservableCollection<Employee> Employees
        {

            get { return _employees; }
            set { SetProperty(ref _employees, value, () => Employees); }
        }

        #endregion


        #region  Constructors
        public Department(int id,string name)
        {
            Name = name;
            ID = id;
            //this._employees = new ObservableCollection<Employee>();

        }
        public Department()
        {

        }
        #endregion
    }
}
