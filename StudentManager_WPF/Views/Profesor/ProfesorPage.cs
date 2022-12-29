using StudentManager_WPF.ViewModels;
using System.Windows.Controls;

namespace StudentManager_WPF.Views.Profesor
{
    public class ProfesorPage : Page
    {
        public ProfesorPage(ProfesorViewModel profesorViewModel)
        {
            ProfesorViewModel = profesorViewModel;
        }

        public ProfesorViewModel ProfesorViewModel { get; }
        public Frame Frame { get; set; }
    }
}
