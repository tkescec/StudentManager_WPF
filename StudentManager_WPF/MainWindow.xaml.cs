using StudentManager_WPF.ViewModels;
using StudentManager_WPF.Views.Kolegij;
using StudentManager_WPF.Views.Profesor;
using StudentManager_WPF.Views.Student;
using System.Windows;


namespace StudentManager_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StudentFrame.Navigate(new ListStudentPage(new StudentViewModel()) { Frame = StudentFrame });
            ProfesorFrame.Navigate(new ListProfesorPage(new ProfesorViewModel()) { Frame = ProfesorFrame });
            KolegijFrame.Navigate(new ListKolegijPage(new KolegijViewModel()) { Frame = KolegijFrame });
        }
    }
}
