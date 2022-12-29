using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager_WPF.DAL.Kolegij
{
    public interface IKolegijRepo
    {
        void DodajKolegij(Models.Kolegij kolegij);
        void IzbrisiKolegij(Models.Kolegij kolegij);
        IList<Models.Kolegij> DohvatiKolegije();
        Models.Kolegij DohvatiKolegij(int idKolegij);
        void AzurirajKolegij(Models.Kolegij kolegij);
    }
}
