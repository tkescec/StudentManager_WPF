using StudentManager_WPF.ViewModels;
using System.Windows.Controls;

namespace StudentManager_WPF.Views.Student
{
    public class StudentPage : Page
    {
        public StudentPage(StudentViewModel studentViewModel)
        {
            StudentViewModel = studentViewModel;
        }

        public StudentViewModel StudentViewModel { get; }
        public Frame Frame { get; set; }
    }
}
