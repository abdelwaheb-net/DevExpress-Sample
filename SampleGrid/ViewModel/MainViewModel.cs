using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleGrid.Model;
using System.Windows.Input;
using System.Diagnostics;
using SampleGrid.View;

namespace SampleGrid.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private ObservableCollection<Department> _listDepartment;
        public ObservableCollection<Department> ListDepartment
        {

            get { return _listDepartment; }
            set { SetProperty(ref _listDepartment, value, () => ListDepartment); }
        }

        private ObservableCollection<GridLink> _links;
        public ObservableCollection<GridLink> ListLinks
        {

            get { return _links; }
            set { SetProperty(ref _links, value, () => ListLinks); }
        }

        public ICommand DataGridControlViewCommand { get; private set; }
        public ICommand NavigateToCommand { get; private set; }

        //public ObservableCollection<Person> ListPerson { get; set; }

        //private ObservableCollection<Employee> _listEmployee;
        //public ObservableCollection<Employee> Employees
        //{

        //    get { return _listEmployee; }
        //    set { SetProperty(ref _listEmployee, value, () => Employees); }
        //}

        public MainViewModel()
        {
            ListDepartment = new ObservableCollection<Department>();
            
            var department0 = new Department() { ID = 1, Name = "department1", Employees = new ObservableCollection<Employee>() };
            var vemployee0 = new Employee() { FirstName = "Bruce", LastName = "Cambell", Orders = new ObservableCollection<Order>() };
            var vorder0 = new Order("Supplier 1", DateTime.Now, "TV", 20);
            var vorder1 = new Order("Supplier 2", DateTime.Now.AddDays(3), "Projector", 15);
            var vorder2 = new Order("Supplier 3", DateTime.Now.AddDays(3), "HDMI Cable", 50);
            vemployee0.Orders.Add(vorder0);
            vemployee0.Orders.Add(vorder1);
            vemployee0.Orders.Add(vorder2);
            department0.Employees.Add(vemployee0);
            
            
           var vemployee1= new Employee() { FirstName = "Cindy", LastName = "Haneline", Orders = new ObservableCollection<Order>() };
            var vorder3 = new Order("Supplier 1", DateTime.Now.AddDays(1), "Blu-Ray Player", 10);
            var vorder4 = new Order("Supplier 2", DateTime.Now.AddDays(1), "Blu-Ray Player", 10);
            var vorder5 = new Order("Supplier 3", DateTime.Now.AddDays(1), "Blu-Ray Player", 10);
            var vorder6 = new Order("Supplier 4", DateTime.Now.AddDays(1), "Blu-Ray Player", 10);
            vemployee1.Orders.Add(vorder3);
            vemployee1.Orders.Add(vorder4);
            vemployee1.Orders.Add(vorder5);
            vemployee1.Orders.Add(vorder6);
            department0.Employees.Add(vemployee1);
            ListDepartment.Add(department0);
            var department1= new Department() { ID = 2, Name = "department2", Employees = new ObservableCollection<Employee>() };
            var vemployee2=new Employee() { FirstName = "Jack", LastName = "Lee", Orders = new ObservableCollection<Order>() };
            var vorder7 = new Order("Supplier 1", DateTime.Now, "AV Receiver", 20);
            var vorder8 = new Order("Supplier 2", DateTime.Now.AddDays(3), "Projector", 15);
            vemployee2.Orders.Add(vorder7);
            vemployee2.Orders.Add(vorder8);
            department1.Employees.Add(vemployee2);
            var vemployee3 = new Employee() { FirstName = "Cindy", LastName = "Johnson", Orders = new ObservableCollection<Order>() };
            department1.Employees.Add(vemployee3);
            ListDepartment.Add(department1);


            ListLinks = new ObservableCollection<GridLink>();
            ListLinks.Add(new GridLink() { Link = "department1" });
            ListLinks.Add(new GridLink() { Link= "department2" });
            ListLinks.Add(new GridLink() {Link= "department1->Bruce" });


            NavigateToCommand = new DelegateCommand<object>(OnNavigateToCommand, CanNavigateToCommand);
            DataGridControlViewCommand = new DelegateCommand<bool>(OnShowDataGridControlViewCommandExecute, true);


        }

        private void OnShowDataGridControlViewCommandExecute(bool obj)
        {
            var s = ServiceContainer.GetService<INavigationService>() as DevExpress.Xpf.WindowsUI.Navigation.FrameNavigationService;
            var view = new DataGridControl();
            view.DataContext = this;
            s.Frame.Navigate(view);
        }

        public void OnNavigateToCommand(object arg)
        {
            var parameters = arg as GridLink;
            var param = parameters.Link;
            string[] stringSeparators = new string[] { "->" };
            var path = param.Split(stringSeparators, System.StringSplitOptions.None);
            var viewName = path.FirstOrDefault().Trim();
            //NavigateTo(PhysicalHarnessViewConstant);

            DataGridControlViewCommand.Execute(null);
        }


        [DebuggerStepThrough]
        private bool CanNavigateToCommand(object arg)
        {
            return true;
        }


        

    }



}
