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

namespace PersonnelDepartment.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminEmployeeListView.xaml
    /// </summary>
    public partial class AdminEmployeeListView : UserControl
    {
        public AdminEmployeeListView()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DgEmployee.ItemsSource = DataService.GetContext().Employee.ToList();
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            DgEmployee.ItemsSource = DataService.GetContext().Employee
                .Where(s => string.Concat(s.LastName, " ", s.FirstName, " ", s.MiddleName)
                .StartsWith(TbSearch.Text)).ToList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Entity.Employee = DgEmployee.SelectedItem as Employee;

            AdminEditEmployeeView.Visibility = Visibility.Visible;
        }

        private void AdminEditEmployeeView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DgEmployee.ItemsSource = DataService.GetContext().Employee.ToList();
        }
    }
}
