using PersonnelDepartment.Data;
using PersonnelDepartment.Services;
using PersonnelDepartment.Windows.Additionally;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
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
    /// Interaction logic for EmployeeAddView.xaml
    /// </summary>
    public partial class EmployeeAddView : UserControl
    {
        Employee employee;
        bool flagMC = false;
        bool flagMID = false;

        public EmployeeAddView()
        {
            InitializeComponent();
        }

        private void LoadPhoto(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ImgPhoto.Source = new BitmapImage(new Uri(filename));
                employee.Photo = File.ReadAllBytes(filename);
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void OpenAddEmployee(object sender, DependencyPropertyChangedEventArgs e)
        {
            employee = new Employee();
            DataContext = employee;

            CbAdress.ItemsSource = DataService.GetContext().Address.ToList();
            CbDepartment.ItemsSource = DataService.GetContext().Department.Where(d => d.Name != "Все").ToList();
            CbGender.ItemsSource = DataService.GetContext().Gender.ToList();
            CbPosition.ItemsSource = DataService.GetContext().Position.ToList();

            DpBirthDate.SelectedDate = DateTime.Now;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbEducation.Text))
            {
                MB.MessageBoxInfo("Заполните образование");
                TbEducation.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbEmail.Text))
            {
                MB.MessageBoxInfo("Заполните почту");
                TbEmail.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbINN.Text))
            {
                MB.MessageBoxInfo("Заполните ИНН");
                TbINN.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MB.MessageBoxInfo("Заполните фамилию");
                TbLastName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbFirstName.Text))
            {
                MB.MessageBoxInfo("Заполните имя");
                TbFirstName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbNumberPhone.Text))
            {
                MB.MessageBoxInfo("Заполните телефон");
                TbNumberPhone.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbPassportNumber.Text))
            {
                MB.MessageBoxInfo("Заполните номер паспорта");
                TbPassportNumber.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbPassportSeries.Text))
            {
                MB.MessageBoxInfo("Заполните серию паспорта");
                TbPassportSeries.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbSalary.Text))
            {
                MB.MessageBoxInfo("Заполните зарплату");
                TbSalary.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbSNILS.Text))
            {
                MB.MessageBoxInfo("Заполните СНИЛС");
                TbSNILS.Focus();
            }
            else if (string.IsNullOrWhiteSpace(CbAdress.Text))
            {
                MB.MessageBoxInfo("Заполните адрес");
                CbAdress.Focus();
            }
            else if (string.IsNullOrWhiteSpace(CbDepartment.Text))
            {
                MB.MessageBoxInfo("Заполните отдел");
                CbDepartment.Focus();
            }
            else if (string.IsNullOrWhiteSpace(CbGender.Text))
            {
                MB.MessageBoxInfo("Заполните пол");
                CbGender.Focus();
            }
            else if (string.IsNullOrWhiteSpace(CbPosition.Text))
            {
                MB.MessageBoxInfo("Заполните должность");
                CbPosition.Focus();
            }
            else if (CbGender.Text == "Мужчина" && flagMID == false)
            {
                MB.MessageBoxInfo("Добавьте фотографию военного билета");
                BtnMilitaryId.Focus();
            }
            else if (flagMC == false)
            {
                MB.MessageBoxInfo("Добавьте фотографию медицинской карты");
                BtnMedicalCertificate.Focus();
            }
            else
            {
                try
                {
                    DataService.GetContext().Employee.Add(employee);
                    DataService.GetContext().SaveChanges();
                    MB.MessageBoxInfo("Сотрудник успешно добавлен");
                }
                catch
                {
                    MB.MessageBoxError("Ошибка подключения к базе данных");
                }
            }
        }

        private void LoadMilitaryId(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ImgMilitaryId.Source = new BitmapImage(new Uri(filename));
                employee.MilitaryId = File.ReadAllBytes(filename);
                flagMID = true;
            }
        }

        private void LoadMedicalCertificate(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ImgMedicalСertificate.Source = new BitmapImage(new Uri(filename));
                employee.MedicalСertificate = File.ReadAllBytes(filename);
                flagMC = true;
            }
        }

        private void AddAddress(object sender, RoutedEventArgs e)
        {
            new WinAddAddress().ShowDialog();

            CbAdress.ItemsSource = DataService.GetContext().Address.ToList();
        }

        private void AddPosition(object sender, RoutedEventArgs e)
        {
            new WinAddPosition().ShowDialog();

            CbPosition.ItemsSource = DataService.GetContext().Position.ToList();
        }
    }
}
