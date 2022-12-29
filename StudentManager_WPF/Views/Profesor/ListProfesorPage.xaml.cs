using StudentManager_WPF.Models;
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

namespace StudentManager_WPF.Views.Profesor
{
    /// <summary>
    /// Interaction logic for ListProfesorPage.xaml
    /// </summary>
    public partial class ListProfesorPage : ProfesorPage
    {
        public ListProfesorPage(ProfesorViewModel profesorViewModel) : base(profesorViewModel)
        {
            InitializeComponent();
            LvProfesor.ItemsSource = profesorViewModel.Profesori;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditProfesorPage(ProfesorViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvProfesor.SelectedItem != null)
            {
                Frame.Navigate(new EditProfesorPage(ProfesorViewModel, LvProfesor.SelectedItem as Models.Profesor) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvProfesor.SelectedItem != null)
            {
                ProfesorViewModel.Profesori.Remove(LvProfesor.SelectedItem as Models.Profesor);
            }
        }
    }
}
