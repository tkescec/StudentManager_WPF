using StudentManager_WPF.ViewModels;
using System.Windows.Controls;

namespace StudentManager_WPF.Views.Kolegij
{
    public class KolegijPage : Page
    {
        public KolegijPage(KolegijViewModel kolegijViewModel)
        {
            KolegijViewModel = kolegijViewModel;
        }

        public KolegijViewModel KolegijViewModel { get; }
        public Frame Frame { get; set; }
    }
}
