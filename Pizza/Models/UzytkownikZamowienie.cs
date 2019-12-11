using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class UzytkownikZamowienie
    {
        public int UzytkownikIdUser { get; set; }
        public int ZamowienieIdZamowienie { get; set; }

        public virtual Uzytkownik UzytkownikIdUserNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowienieNavigation { get; set; }
    }
}
