using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager_WPF.DAL.Student
{
    public interface IStudentRepo
    { 
        void DodajStudenta(Models.Student student);
        void IzbrisiStudenta(Models.Student student);
        IList<Models.Student> DohvatiStudente();
        Models.Student DohvatiStudenta(int idStudent);
        void AzurirajStudenta(Models.Student student);
    }
}
