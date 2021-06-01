using PersonnelDepartment.Data;
using PersonnelDepartment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonnelDepartment.Views.Manager
{
    /// <summary>
    /// Interaction logic for EmployeeListView.xaml
    /// </summary>
    public partial class EmployeeListView : UserControl
    {
        public EmployeeListView()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            LvItems.ItemsSource = DataService.GetContext().Employee.ToList();
            CbDepartments.ItemsSource = DataService.GetContext().Department.ToList().OrderByDescending(d => d.Name);
        }

        private void InfoEmployee(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((LvItems.SelectedItem as Employee).Id.ToString());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.LastName.StartsWith(TbSearch.Text)).ToList();
        }

        private void Filter(object sender, SelectionChangedEventArgs e)
        {
            var department = CbDepartments.SelectedItem as Department;
            if (department.Name == "Все")
                LvItems.ItemsSource = DataService.GetContext().Employee.ToList();
            else
                LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.Department.Name == department.Name).ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var employee = LvItems.SelectedItem as Employee;
            if (MB.MessageBoxQuestion($"Вы действительно хотите удалить сотрудника {employee.LastName} {employee.FirstName} {employee.MiddleName}?"))
            {
                DataService.GetContext().Employee.Remove(employee);
                DataService.GetContext().SaveChanges();

                LvItems.ItemsSource = DataService.GetContext().Employee.ToList();

                MB.MessageBoxInfo("Вы успешно удалили сотрудника");
            }
        }
    }
}
