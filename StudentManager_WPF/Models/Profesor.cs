using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StudentManager_WPF.Models
{
    public class Profesor
    {
        public int IDProfesor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Kolegij Kolegij { get; set; }
    }
}
