using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace PersonnelDepartment.Windows.Manager
{
    /// <summary>
    /// Interaction logic for WinTransfer.xaml
    /// </summary>
    public partial class WinTransfer : MetroWindow
    {
        public WinTransfer()
        {
            InitializeComponent();

            CbDepartment.ItemsSource = DataService.GetContext().Department.Where(d => d.Name != "Все").ToList();
        }

        private void Transfer(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbDepartment.Text))
            {
                MB.MessageBoxInfo("Выберите отдел");
                CbDepartment.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbSalary.Text))
            {
                MB.MessageBoxInfo("Введите зарплату");
                TbSalary.Focus();
            }
            else
            {
                try
                {
                    var applicant = Entity.Applicant;
                    var employee = new Data.Employee()
                    {
                        Address = applicant.Address,
                        BirthDate = applicant.BirthDate,
                        Department = CbDepartment.SelectedItem as Department,
                        Gender = applicant.Gender,
                        Education = applicant.Education,
                        Email = applicant.Email,
                        FirstName = applicant.FirstName,
                        INN = applicant.INN,
                        LastName = applicant.LastName,
                        MedicalCertificate = applicant.MedicalCertificate,
                        MiddleName = applicant.MiddleName,
                        MilitaryId = applicant.MilitaryId,
                        PassportNumber = applicant.PassportNumber,
                        PassportSeries = applicant.PassportSeries,
                        PhoneNumber = applicant.PhoneNumber,
                        Photo = applicant.Photo,
                        Position = applicant.Position,
                        Salary = Convert.ToDecimal(TbSalary.Text),
                        SNILS = applicant.SNILS
                    };
                    DataService.GetContext().Employee.Add(employee);
                    DataService.GetContext().SaveChanges();
                    MB.MessageBoxInfo($"Вы успешно перевели сотрудника {employee.LastName} {employee.FirstName} {employee.MiddleName} на работу");
                }
                catch
                {
                    MB.MessageBoxError("Ошибка подключения к базе данных");
                }
            }
        }
    }
}
