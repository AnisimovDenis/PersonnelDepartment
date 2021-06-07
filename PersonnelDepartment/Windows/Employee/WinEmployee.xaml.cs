using MahApps.Metro.Controls;
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
        }

        private void OpenEmployeeList(object sender, RoutedEventArgs e)
        {
            EmployeeListView.Visibility = Visibility.Visible;
        }

        private void OpenApplicantList(object sender, RoutedEventArgs e)
        {
            ApplicantListView.Visibility = Visibility.Visible;
        }
    }
}
