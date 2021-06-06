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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonnelDepartment.Views.Manager
{
    /// <summary>
    /// Interaction logic for DepartmentAddView.xaml
    /// </summary>
    public partial class DepartmentAddView : UserControl
    {
        Department department;

        public DepartmentAddView()
        {
            InitializeComponent();
        }

        private void OpenAddApplicant(object sender, DependencyPropertyChangedEventArgs e)
        {
            department = new Department();
            DataContext = department;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbName.Text))
            {
                MB.MessageBoxInfo("Введите наименование отдела");
                TbName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbDaysWorking.Text))
            {
                MB.MessageBoxInfo("Введите рабочие дни");
                TbDaysWorking.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbTimeWorking.Text))
            {
                MB.MessageBoxInfo("Введите время работы");
                TbTimeWorking.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbTotalAmount.Text))
            {
                MB.MessageBoxInfo("Введите общее количество мест");
                TbTotalAmount.Focus();
            }
            else
            {
                try
                {
                    DataService.GetContext().Department.Add(department);
                    DataService.GetContext().SaveChanges();
                    MB.MessageBoxInfo("Вы успешно добавлили отдел");
                }
                catch (Exception ex)
                {
                    MB.MessageBoxError(ex.Message);
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
