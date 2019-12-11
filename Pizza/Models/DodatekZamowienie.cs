using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class DodatekZamowienie
    {
        public int DodatekIdDodatek { get; set; }
        public int ZamowienieIdZamowienie { get; set; }

        public virtual Dodatek DodatekIdDodatekNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowienieNavigation { get; set; }
    }
}
