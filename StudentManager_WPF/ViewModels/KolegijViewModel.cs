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
    public class KolegijViewModel
    {
        public ObservableCollection<Kolegij> Kolegiji { get; }

        public KolegijViewModel()
        {
            Kolegiji = new ObservableCollection<Kolegij>(RepoFactory.GetKolegijRepo().DohvatiKolegije());
            Kolegiji.CollectionChanged += Kolegiji_CollectionChanged;
        }

        private void Kolegiji_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RepoFactory.GetKolegijRepo().DodajKolegij(Kolegiji[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RepoFactory.GetKolegijRepo().IzbrisiKolegij(e.OldItems.OfType<Kolegij>().ToList()[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RepoFactory.GetKolegijRepo().AzurirajKolegij(e.NewItems.OfType<Kolegij>().ToList()[0]);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        internal void Update(Kolegij kolegij) => Kolegiji[Kolegiji.IndexOf(kolegij)] = kolegij;
    }
}
