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
    /// Interaction logic for WinAddPosition.xaml
    /// </summary>
    public partial class WinAddPosition : MetroWindow
    {
        public WinAddPosition()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbPosition.Text))
            {
                MB.MessageBoxInfo("Введите должность");
                TbPosition.Focus();
            }
            else
            {
                try
                {
                    DataService.GetContext().Position.Add(new Data.Position()
                    {
                        Name = TbPosition.Text
                    });
                    DataService.GetContext().SaveChanges();
                    MB.MessageBoxInfo("Вы успешно добавили должность");
                }
                catch
                {
                    MB.MessageBoxError("Ошибка подключения к базе данных");
                }
            }
        }
    }
}
