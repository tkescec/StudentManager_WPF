using StudentManager_WPF.Utils;
using System.Windows.Media.Imaging;

namespace StudentManager_WPF.Models
{
    public class Student
    {
        public int IDStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jmbag { get; set; }
        public Kolegij Kolegij { get; set; }
        public byte[] Picture { get; set; }
        public BitmapImage Image
        {
            get => ImageUtils.ByteArrayToBitmapImage(Picture);
        }
    }
}
