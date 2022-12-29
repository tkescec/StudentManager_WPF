using StudentManager_WPF.DAL;
using StudentManager_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager_WPF.ViewModels
{
    public class ProfesorViewModel
    {
        public IList<Kolegij> Kolegiji { get; }
        public ObservableCollection<Profesor> Profesori { get; }

        public ProfesorViewModel()
        {
            Kolegiji = new List<Kolegij>(RepoFactory.GetKolegijRepo().DohvatiKolegije());
            Profesori = new ObservableCollection<Profesor>(RepoFactory.GetProfesorRepo().DohvatiProfesore());
            Profesori.CollectionChanged += Profesori_CollectionChanged;
        }

        private void Profesori_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RepoFactory.GetProfesorRepo().DodajProfesora(Profesori[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RepoFactory.GetProfesorRepo().IzbrisiProfesora(e.OldItems.OfType<Profesor>().ToList()[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RepoFactory.GetProfesorRepo().AzurirajProfesora(e.NewItems.OfType<Profesor>().ToList()[0]);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        internal void Update(Profesor profesor) => Profesori[Profesori.IndexOf(profesor)] = profesor;
    }
}
