using MahApps.Metro.Controls;
using PersonnelDepartment.Data;
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

namespace PersonnelDepartment.Windows.Additionally
{
    /// <summary>
    /// Interaction logic for WinAddAddress.xaml
    /// </summary>
    public partial class WinAddAddress : MetroWindow
    {
        public WinAddAddress()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbAddress.Text))
            {
                MB.MessageBoxInfo("Введите должность");
                TbAddress.Focus();
            }
            else
            {
                try
                {
                    DataService.GetContext().Address.Add(new Data.Address()
                    {
                        Name = TbAddress.Text
                    });
                    DataService.GetContext().SaveChanges();
                    MB.MessageBoxInfo("Вы успешно добавили адрес");
                }
                catch
                {
                    MB.MessageBoxError("Ошибка подключения к базе данных");
                }
            }
        }
    }
}
