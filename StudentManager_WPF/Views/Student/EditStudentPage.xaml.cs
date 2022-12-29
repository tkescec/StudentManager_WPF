using Microsoft.Win32;
using StudentManager_WPF.Models;
using StudentManager_WPF.Utils;
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
    /// Interaction logic for EditStudentPage.xaml
    /// </summary>
    public partial class EditStudentPage : StudentPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Models.Student student;

        public EditStudentPage(StudentViewModel studentViewModel, Models.Student student = null) : base(studentViewModel)
        {
            InitializeComponent();
            CbKolegiji.ItemsSource = StudentViewModel.Kolegiji;
            this.student = student ?? new Models.Student();
            DataContext = this.student;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                student.FirstName = TbIme.Text.Trim();
                student.LastName = TbPrezime.Text.Trim();
                student.Jmbag = TbJmbag.Text.Trim();
                student.Kolegij = (Models.Kolegij)CbKolegiji.SelectedItem;
                student.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);
                if (student.IDStudent == 0)
                {
                    StudentViewModel.Studenti.Add(student);
                }
                else
                {
                    StudentViewModel.Update(student);
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
            if (Picture.Source == null)
            {
                PictureBorder.BorderBrush = Brushes.LightCoral;
                valid = false;
            }
            else
            {
                PictureBorder.BorderBrush = Brushes.WhiteSmoke;
            }
            return valid;
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = Filter
            };
            if (openFileDialog.ShowDialog() == true)
            {
                Picture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
