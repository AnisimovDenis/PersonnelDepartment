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
    /// Interaction logic for UserEditView.xaml
    /// </summary>
    public partial class UserEditView : UserControl
    {
        public UserEditView()
        {
            InitializeComponent();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MB.MessageBoxInfo("Введите логин");
                TbLogin.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbPassword.Text))
            {
                MB.MessageBoxInfo("Введите пароль");
                TbPassword.Focus();
            }
            else if (string.IsNullOrWhiteSpace(CbRole.Text))
            {
                MB.MessageBoxInfo("Выберите роль");
                CbRole.Focus();
            }
            else
            {
                try
                {
                    DataService.GetContext().SaveChanges();
                    MB.MessageBoxInfo("Пользователь успешно изменен");
                }
                catch
                {
                    MB.MessageBoxError("Ошибка подключения к базе данных");
                }
            }
        }

        private void OpenAddApplicant(object sender, DependencyPropertyChangedEventArgs e)
        {
            CbRole.ItemsSource = DataService.GetContext().Role.ToList();

            DataContext = Entity.User;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
