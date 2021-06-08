using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace PersonnelDepartment.Windows.Employee
{
    /// <summary>
    /// Interaction logic for WinEmployee.xaml
    /// </summary>
    public partial class WinEmployee : MetroWindow
    {
        public WinEmployee()
        {
            InitializeComponent();

            try
            {
                var departments = DataService.GetContext().Department.ToList();
                foreach (var department in departments)
                {
                    department.QuantityAtTheMoment = DataService.GetContext().Employee.Where(emp => emp.Department.Name == department.Name).ToList().Count;
                }
                DataService.GetContext().SaveChanges();
            }
            catch
            {

            }

            CbDepartment.ItemsSource = DataService.GetContext().Department.Where(d => d.Name != "Все").ToList();
        }

        private void OpenEmployeeList(object sender, RoutedEventArgs e)
        {
            EmployeeListView.Visibility = Visibility.Visible;
        }

        private void OpenApplicantList(object sender, RoutedEventArgs e)
        {
            ApplicantListView.Visibility = Visibility.Visible;
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            RecTotal.Height = Convert.ToDouble((CbDepartment.SelectedItem as Department).TotalAmount * 8);
            RecCurrent.Height = Convert.ToDouble((CbDepartment.SelectedItem as Department).QuantityAtTheMoment * 8);
            RecFree.Height = Convert.ToDouble((CbDepartment.SelectedItem as Department).TotalAmount * 8 - (CbDepartment.SelectedItem as Department).QuantityAtTheMoment * 8);

            LblCurrent.Content = "Количество работников - " + (CbDepartment.SelectedItem as Department).QuantityAtTheMoment;
            LblTotal.Content = "Общее количество мест - " + (CbDepartment.SelectedItem as Department).TotalAmount;
            LblFree.Content = "Свободно мест - " + ((CbDepartment.SelectedItem as Department).TotalAmount - (CbDepartment.SelectedItem as Department).QuantityAtTheMoment);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            if (MB.MessageBoxQuestion("Вы действительно хотите выйти?"))
                App.Current.Shutdown();
        }

        private void Update(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var departments = DataService.GetContext().Department.ToList();
                foreach (var department in departments)
                {
                    department.QuantityAtTheMoment = DataService.GetContext().Employee.Where(emp => emp.Department.Name == department.Name).ToList().Count;
                }
                DataService.GetContext().SaveChanges();
            }
            catch
            {

            }
        }
    }
}
