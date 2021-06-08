using MahApps.Metro.Controls;
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

            var currentTime = DateTime.Now.TimeOfDay.TotalHours;

            if (currentTime < 9 && currentTime > 4)
                LblHellover.Content = $"Доброе утро, {Entity.CurrentEmployee.FirstName}!";
            else if (currentTime > 9 && currentTime < 18)
                LblHellover.Content = $"Добрый день, {Entity.CurrentEmployee.FirstName}!";
            else if (currentTime > 18 && currentTime < 22)
                LblHellover.Content = $"Добрый вечер, {Entity.CurrentEmployee.FirstName}!";
            else
                LblHellover.Content = $"Доброй ночи, {Entity.CurrentEmployee.FirstName}!";
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

        private void Update(object sender, DependencyPropertyChangedEventArgs e)
        {
            var currentTime = DateTime.Now.TimeOfDay.TotalHours;

            if (currentTime < 9 && currentTime > 4)
                LblHellover.Content = $"Доброе утро, {Entity.CurrentEmployee.FirstName}!";
            else if (currentTime > 9 && currentTime < 18)
                LblHellover.Content = $"Добрый день, {Entity.CurrentEmployee.FirstName}!";
            else if (currentTime > 18 && currentTime < 22)
                LblHellover.Content = $"Добрый вечер, {Entity.CurrentEmployee.FirstName}!";
            else
                LblHellover.Content = $"Доброй ночи, {Entity.CurrentEmployee.FirstName}!";
        }
    }
}
