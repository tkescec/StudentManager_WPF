using StudentManager_WPF.ViewModels;
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

namespace StudentManager_WPF.Views.Student
{
    /// <summary>
    /// Interaction logic for ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : StudentPage
    {
        public ListStudentPage(StudentViewModel studentViewModel) : base(studentViewModel)
        {
            InitializeComponent();
            LvStudenti.ItemsSource = studentViewModel.Studenti;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditStudentPage(StudentViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvStudenti.SelectedItem != null)
            {
                Frame.Navigate(new EditStudentPage(StudentViewModel, LvStudenti.SelectedItem as Models.Student) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvStudenti.SelectedItem != null)
            {
                StudentViewModel.Studenti.Remove(LvStudenti.SelectedItem as Models.Student);
            }
        }
    }
}
