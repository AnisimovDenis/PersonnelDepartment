using MahApps.Metro.Controls;
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

namespace PersonnelDepartment.Windows.Admin
{
    /// <summary>
    /// Interaction logic for WinAdmin.xaml
    /// </summary>
    public partial class WinAdmin : MetroWindow
    {
        public WinAdmin()
        {
            InitializeComponent();
        }

        private void OpenEmployeeList(object sender, RoutedEventArgs e)
        {
            AdminEmployeeListView.Visibility = Visibility.Visible;
        }

        private void OpenUserList(object sender, RoutedEventArgs e)
        {
            UserListView.Visibility = Visibility.Visible;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            if (MB.MessageBoxQuestion("Вы действительно хотите выйти?"))
                App.Current.Shutdown();
        }
    }
}
