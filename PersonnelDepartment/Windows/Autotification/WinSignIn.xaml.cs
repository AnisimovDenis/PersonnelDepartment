using MahApps.Metro.Controls;
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

namespace PersonnelDepartment.Windows.Autotification
{
    /// <summary>
    /// Interaction logic for WinSignIn.xaml
    /// </summary>
    public partial class WinSignIn : MetroWindow
    {
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
        }
    }
}
