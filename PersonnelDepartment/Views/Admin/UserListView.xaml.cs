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
    /// Interaction logic for UserListView.xaml
    /// </summary>
    public partial class UserListView : UserControl
    {
        public UserListView()
        {
            InitializeComponent();
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DataService.GetContext().User.Where(u => u.Login.StartsWith(TbSearch.Text)).ToList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            UserAddView.Visibility = Visibility.Visible;
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DgUser.ItemsSource = DataService.GetContext().User.ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DgUser.SelectedItem as User;
                if (MB.MessageBoxQuestion($"Вы действительно хотите удалить пользователя {user.Login}?"))
                DataService.GetContext().User.Remove(user);
                MB.MessageBoxInfo($"Пользователь {user.Login} успешно удален");
            }
            catch
            {
                MB.MessageBoxError("Ошибка подключения к базе данных");
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Entity.User = DgUser.SelectedItem as User;
            UserEditView.Visibility = Visibility.Visible;
        }

        private void AdminEditEmployeeView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DgUser.ItemsSource = DataService.GetContext().User.ToList();
        }
    }
}
