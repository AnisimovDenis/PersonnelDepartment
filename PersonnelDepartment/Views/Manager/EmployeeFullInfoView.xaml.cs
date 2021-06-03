using PersonnelDepartment.Entities;
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
    /// Interaction logic for EmployeeFullInfoView.xaml
    /// </summary>
    public partial class EmployeeFullInfoView : UserControl
    {
        public EmployeeFullInfoView()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void OpenFullInfoEmployee(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataContext = Entity.Employee;
        }
    }
}
