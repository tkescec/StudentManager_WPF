using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager_WPF.Models
{
    public class Kolegij
    {
        public int IDKolegij { get; set; }
        public string Naziv { get; set; }
    }
    
    public override bool Equals(object obj)
    {
        return obj is Kolegij kolegij &&
               IDKolegij == kolegij.IDKolegij;
    }

    public override int GetHashCode()
    {
        return -96594627 + IDKolegij.GetHashCode();
    }
}
