using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager_WPF.DAL.Profesor
{
    public interface IProfesorRepo
    {
        void DodajProfesora(Models.Profesor profesor);
        void IzbrisiProfesora(Models.Profesor profesor);
        IList<Models.Profesor> DohvatiProfesore();
        Models.Profesor DohvatiProfesora(int idProfesor);
        void AzurirajProfesora(Models.Profesor profesor);
    }
}
