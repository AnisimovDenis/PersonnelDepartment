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
    /// Interaction logic for AdminEditEmployeeView.xaml
    /// </summary>
    public partial class AdminEditEmployeeView : UserControl
    {
        public AdminEditEmployeeView()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbUser.Text))
            {
                MB.MessageBoxInfo("Выберите логин");
                CbUser.Focus();
            }
            else
            {
                try
                {
                    DataService.GetContext().SaveChanges();
                    MB.MessageBoxInfo("Логин успешно присвоен");
                }
                catch 
                {
                    MB.MessageBoxError("Ошибка подключения к базе данных");
                }
            }
        }

        private void OpenAddApplicant(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataContext = Entity.Employee;
            CbUser.ItemsSource = DataService.GetContext().User.ToList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
