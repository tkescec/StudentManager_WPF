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
    /// Interaction logic for EditProfesorPage.xaml
    /// </summary>
    public partial class EditProfesorPage : ProfesorPage
    {
        private readonly Models.Profesor profesor;

        public EditProfesorPage(ProfesorViewModel profesorViewModel, Models.Profesor profesor = null) : base(profesorViewModel)
        {
            InitializeComponent();
            CbKolegiji.ItemsSource = profesorViewModel.Kolegiji;
            this.profesor = profesor ?? new Models.Profesor();
            DataContext = this.profesor;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                profesor.FirstName = TbIme.Text.Trim();
                profesor.LastName= TbPrezime.Text.Trim();
                profesor.Kolegij = (Models.Kolegij)CbKolegiji.SelectedItem;

                if (profesor.IDProfesor == 0)
                {
                    ProfesorViewModel.Profesori.Add(profesor);
                }
                else
                {
                    ProfesorViewModel.Update(profesor);
                }
                Frame.NavigationService.GoBack();
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });

            return valid;
        }
    }
}
