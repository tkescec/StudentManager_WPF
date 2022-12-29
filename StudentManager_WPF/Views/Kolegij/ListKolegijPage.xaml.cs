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
    /// Interaction logic for ListKolegijPage.xaml
    /// </summary>
    public partial class ListKolegijPage : KolegijPage
    {
        public ListKolegijPage(KolegijViewModel kolegijViewModel) : base(kolegijViewModel)
        {
            InitializeComponent();
            LvKolegij.ItemsSource = kolegijViewModel.Kolegiji;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditKolegijPage(KolegijViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvKolegij.SelectedItem != null)
            {
                Frame.Navigate(new EditKolegijPage(KolegijViewModel, LvKolegij.SelectedItem as Models.Kolegij) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvKolegij.SelectedItem != null)
            {
                KolegijViewModel.Kolegiji.Remove(LvKolegij.SelectedItem as Models.Kolegij);
            }
        }
    }
}
