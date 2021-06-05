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

namespace PersonnelDepartment.Views.Manager
{
    /// <summary>
    /// Interaction logic for ApplicantListView.xaml
    /// </summary>
    public partial class ApplicantListView : UserControl
    {
        public ApplicantListView()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            LvItems.ItemsSource = DataService.GetContext().Applicant.ToList();
            CbPosition.ItemsSource = DataService.GetContext().Position.ToList();
        }

        private void InfoApplicant(object sender, RoutedEventArgs e)
        {
            Entity.Applicant = LvItems.SelectedItem as Applicant;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            LvItems.ItemsSource = DataService.GetContext().Applicant.Where(emp => emp.LastName.StartsWith(TbSearch.Text)).ToList();
        }

        private void Filter(object sender, SelectionChangedEventArgs e)
        {
            var position = CbPosition.SelectedItem as Position;
            if (position.Name == "Все")
                LvItems.ItemsSource = DataService.GetContext().Applicant.ToList();
            else
                LvItems.ItemsSource = DataService.GetContext().Applicant.Where(emp => emp.Position.Name == position.Name).ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var applicant = LvItems.SelectedItem as Applicant;
            if (MB.MessageBoxQuestion($"Вы действительно хотите удалить соискателя {applicant.LastName} {applicant.FirstName} {applicant.MiddleName}?"))
            {
                DataService.GetContext().Applicant.Remove(applicant);
                DataService.GetContext().SaveChanges();

                LvItems.ItemsSource = DataService.GetContext().Applicant.ToList();

                MB.MessageBoxInfo($"Вы успешно удалили соискателя {applicant.LastName} {applicant.FirstName} {applicant.MiddleName}");
            }
        }

        private void OpenAddApplicant(object sender, RoutedEventArgs e)
        {
            ApplicantAddView.Visibility = Visibility.Visible;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Entity.Applicant = LvItems.SelectedItem as Applicant;

        }

        private void ApplicantAddViewClosed(object sender, DependencyPropertyChangedEventArgs e)
        {
            LvItems.ItemsSource = DataService.GetContext().Applicant.ToList();
        }
    }
}
