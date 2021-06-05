using PersonnelDepartment.Data;
using PersonnelDepartment.Entities;
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
            LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired != true).ToList();
            CbDepartments.ItemsSource = DataService.GetContext().Department.ToList().OrderByDescending(d => d.Name);
        }

        private void InfoEmployee(object sender, RoutedEventArgs e)
        {
            Entity.Employee = LvItems.SelectedItem as Employee;

            EmployeeFullInfoView.Visibility = Visibility.Visible;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.LastName.StartsWith(TbSearch.Text) && emp.IsFired != true).ToList();
        }

        private void Filter(object sender, SelectionChangedEventArgs e)
        {
            var department = CbDepartments.SelectedItem as Department;
            if (department.Name == "Все")
                LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired != true).ToList();
            else
                LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.Department.Name == department.Name && emp.IsFired != true).ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var employee = LvItems.SelectedItem as Employee;
            if (MB.MessageBoxQuestion($"Вы действительно хотите удалить сотрудника {employee.LastName} {employee.FirstName} {employee.MiddleName}?"))
            {
                employee.IsFired = true;
                DataService.GetContext().SaveChanges();

                LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired != true).ToList();

                MB.MessageBoxInfo("Вы успешно удалили сотрудника");
            }
        }

        private void OpenAddEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeAddView.Visibility = Visibility.Visible;
        }

        private void ShowFiredEployees(object sender, RoutedEventArgs e)
        {
            BtnShowEployees.Visibility = Visibility.Visible;
            BtnShowFiredEployees.Visibility = Visibility.Collapsed;

            LvItems.Visibility = Visibility.Collapsed;
            LvFiredEmployees.Visibility = Visibility.Visible;

            LblHeadLine.Content = "Список уволенных сотрудников";

            LvFiredEmployees.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired == true).ToList();
            LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired != true).ToList();
        }

        private void ShowEployees(object sender, RoutedEventArgs e)
        {
            BtnShowEployees.Visibility = Visibility.Collapsed;
            BtnShowFiredEployees.Visibility = Visibility.Visible;

            LvItems.Visibility = Visibility.Visible;
            LvFiredEmployees.Visibility = Visibility.Collapsed;

            LblHeadLine.Content = "Список сотрудников";

            LvFiredEmployees.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired == true).ToList();
            LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired != true).ToList();
        }

        private void InfoFiredEmployee(object sender, RoutedEventArgs e)
        {
            Entity.Employee = LvFiredEmployees.SelectedItem as Employee;

            EmployeeFullInfoView.Visibility = Visibility.Visible;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Entity.Employee = LvItems.SelectedItem as Employee;

            EmployeeEditView.Visibility = Visibility.Visible;
        }

        private void EmployeeRecovery(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = LvFiredEmployees.SelectedItem as Employee;
                employee.IsFired = false;
                DataService.GetContext().SaveChanges();
                MB.MessageBoxInfo($"Сотрудник {employee.LastName} {employee.FirstName} {employee.MiddleName} успешно восстановлен");

                LvFiredEmployees.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired == true).ToList();
                LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired != true).ToList();
            }
            catch
            {
                MB.MessageBoxError("Ошибка подключения к базе данных");
            }
        }

        private void EmployeeAddViewClosed(object sender, DependencyPropertyChangedEventArgs e)
        {
            LvItems.ItemsSource = DataService.GetContext().Employee.Where(emp => emp.IsFired != true).ToList();
        }
    }
}
