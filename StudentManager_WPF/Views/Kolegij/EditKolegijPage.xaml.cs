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

namespace StudentManager_WPF.Views.Kolegij
{
    /// <summary>
    /// Interaction logic for EditKolegijPage.xaml
    /// </summary>
    public partial class EditKolegijPage : KolegijPage
    {
        private readonly Models.Kolegij kolegij;
        public EditKolegijPage(KolegijViewModel kolegijViewModel, Models.Kolegij kolegij = null) : base(kolegijViewModel)
        {
            InitializeComponent();
            this.kolegij = kolegij ?? new Models.Kolegij();
            DataContext = kolegij;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                kolegij.Naziv = TbNazivKolegija.Text.Trim();

                if (kolegij.IDKolegij == 0)
                {
                    KolegijViewModel.Kolegiji.Add(kolegij);
                }
                else
                {
                    KolegijViewModel.Update(kolegij);
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
