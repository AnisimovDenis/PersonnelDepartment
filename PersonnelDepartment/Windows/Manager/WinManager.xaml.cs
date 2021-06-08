using MahApps.Metro.Controls;
using PersonnelDepartment.Data;
using PersonnelDepartment.Entities;
using PersonnelDepartment.Services;
using PersonnelDepartment.Windows.Additionally;
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

namespace PersonnelDepartment.Windows.Manager
{
    /// <summary>
    /// Interaction logic for WinMamager.xaml
    /// </summary>
    public partial class WinManager : MetroWindow
    {
        public WinManager()
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

            var currentTime = DateTime.Now.TimeOfDay.TotalHours;

            if (currentTime < 9 && currentTime > 4)
                LblHellover.Content = $"Доброе утро, {Entity.CurrentEmployee.FirstName}!";
            else if (currentTime > 9 && currentTime < 18)
                LblHellover.Content = $"Добрый день, {Entity.CurrentEmployee.FirstName}!";
            else if (currentTime > 18 && currentTime < 22)
                LblHellover.Content = $"Добрый вечер, {Entity.CurrentEmployee.FirstName}!";
            else
                LblHellover.Content = $"Доброй ночи, {Entity.CurrentEmployee.FirstName}!";

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

        private void OpenDepartmentList(object sender, RoutedEventArgs e)
        {
            DepartmentListView.Visibility = Visibility.Visible;
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

        private void AboutProgram(object sender, RoutedEventArgs e)
        {
            new WinAboutProgram().ShowDialog();
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
