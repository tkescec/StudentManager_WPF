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
    public class StudentViewModel
    {
        public IList<Kolegij> Kolegiji { get; }
        public ObservableCollection<Student> Studenti { get; }
        
        public StudentViewModel()
        {
            Kolegiji= new List<Kolegij>(RepoFactory.GetKolegijRepo().DohvatiKolegije());
            Studenti = new ObservableCollection<Student>(RepoFactory.GetStudentRepo().DohvatiStudente());
            Studenti.CollectionChanged += Studenti_CollectionChanged;
        }

        private void Studenti_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RepoFactory.GetStudentRepo().DodajStudenta(Studenti[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RepoFactory.GetStudentRepo().IzbrisiStudenta(e.OldItems.OfType<Student>().ToList()[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RepoFactory.GetStudentRepo().AzurirajStudenta(e.NewItems.OfType<Student>().ToList()[0]);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        internal void Update(Student student) => Studenti[Studenti.IndexOf(student)] = student;
    }
}
