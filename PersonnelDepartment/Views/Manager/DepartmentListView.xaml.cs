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
    /// Interaction logic for DepartmentListView.xaml
    /// </summary>
    public partial class DepartmentListView : UserControl
    {
        public DepartmentListView()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DgDepartment.ItemsSource = DataService.GetContext().Department.ToList();
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

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            DgDepartment.ItemsSource = DataService.GetContext().Department.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            DepartmentAddView.Visibility = Visibility.Visible;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var department = DgDepartment.SelectedItem as Department;
                if (MB.MessageBoxQuestion($"Вы дейстивтельно хотите удалить отдел {department.Name}?"))
                {
                    DataService.GetContext().Department.Remove(department);
                    DataService.GetContext().SaveChanges();
                    DgDepartment.ItemsSource = DataService.GetContext().Department.ToList();
                    MB.MessageBoxInfo($"Отдел: {department.Name} успешно удален");
                }
            }
            catch 
            {
                MB.MessageBoxError("Ошибка подключения к базе данных");
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Entity.Department = DgDepartment.SelectedItem as Department;
            DepartmentEditView.Visibility = Visibility.Visible;
        }

        private void DepartmentAddViewClosed(object sender, DependencyPropertyChangedEventArgs e)
        {
            DgDepartment.ItemsSource = DataService.GetContext().Department.ToList();
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
