using MahApps.Metro.Controls;
using PersonnelDepartment.Data;
using PersonnelDepartment.Services;
using PersonnelDepartment.Windows.Manager;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace PersonnelDepartment.Windows.Autotification
{
    /// <summary>
    /// Interaction logic for WinSignIn.xaml
    /// </summary>
    public partial class WinSignIn : MetroWindow
    {
        int count = 0;
        public WinSignIn()
        {
            InitializeComponent();
        }

        private void ButtonPasswordRecovery_Click(object sender, RoutedEventArgs e)
        {
            ButtonBackToSignIn.IsEnabled = true;
            ButtonPasswordRecovery.IsEnabled = false;
        }

        private void ButtonBackToSignIn_Click(object sender, RoutedEventArgs e)
        {
            ButtonBackToSignIn.IsEnabled = false;
            ButtonPasswordRecovery.IsEnabled = true;
            TbEmail.Text = string.Empty;
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MB.MessageBoxInfo("Введите логин");
                TbLogin.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MB.MessageBoxInfo("Введите пароль");
                PbPassword.Focus();
            }
            else
            {
                var user = DataService.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text);

                if (user == null)
                {
                    MB.MessageBoxInfo("Введен неверно логин/пароль");
                    TbLogin.Focus();
                    count++;
                }
                else
                {
                    if (user.Password != PbPassword.Password)
                    {
                        MB.MessageBoxInfo("Введен неверно логин/пароль");
                        TbLogin.Clear();
                        PbPassword.Clear();
                        count++;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 1:
                                new WinManager().Show();
                                this.Close();
                                break;
                        }
                        count = 0;
                    }
                }
                if (count >= 3)
                {
                    TbLogin.Text = string.Empty;
                    PbPassword.Password = string.Empty;
                    GridSignIn.Visibility = Visibility.Hidden;
                    GridCaptcha.Visibility = Visibility.Visible;
                    TbCaptcha.Text = Captcha.GenerateString(5);
                    return;
                }
            }
        }

        private void ReCaptcha(object sender, RoutedEventArgs e)
        {
            TbCaptcha.Text = Captcha.GenerateString(5);
        }

        private void EnterCaptcha(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbCaptchaEnter.Text))
            {
                MB.MessageBoxInfo("Введите капчу");
                TbCaptcha.Focus();
            }
            else if (TbCaptcha.Text == TbCaptchaEnter.Text)
            {
                TbCaptcha.Text = string.Empty;
                TbCaptchaEnter.Text = string.Empty;
                GridSignIn.Visibility = Visibility.Visible;
                GridCaptcha.Visibility = Visibility.Collapsed;
                count = 0;
            }
            else
            {
                TbCaptcha.Text = string.Empty;
                TbCaptcha.Text = Captcha.GenerateString(5);
            }
        }

        private void RecoveryPassword(object sender, RoutedEventArgs e)
        {
            Employee employee = DataService.GetContext().Employee.FirstOrDefault(emp => emp.Email == TbEmail.Text);
            if (string.IsNullOrWhiteSpace(TbEmail.Text))
            {
                MB.MessageBoxInfo("Введите почту");
                TbEmail.Focus();
            }
            else if (employee.User == null)
            {
                MB.MessageBoxInfo("Пользователя с данной почтой не существует");
            }
            else
            {
                try
                {
                    string login = employee.User.Login;
                    string password = employee.User.Password;
                    string email = "primelegalestate@mail.ru";
                    var client = new SmtpClient("smtp.mail.ru", 25);
                    client.Credentials = new NetworkCredential(email, "WASD1337");
                    client.EnableSsl = true;
                    client.Send(email, TbEmail.Text, "Ваши данные учетной записи \"PersonnelDepartment\": ", $"Логин: {login}\nПароль: {password}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
