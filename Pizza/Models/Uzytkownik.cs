using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Uzytkownik
    {
        public Uzytkownik()
        {
            UzytkownikZamowienie = new HashSet<UzytkownikZamowienie>();
        }

        public int IdUser { get; set; }
        public string Imie { get; set; }
        public string Telefon { get; set; }
        public string Haslo { get; set; }
        public string Ulica { get; set; }
        public int NrDomu { get; set; }
        public int NrMieszkania { get; set; }
        public string Indeks { get; set; }

        public virtual ICollection<UzytkownikZamowienie> UzytkownikZamowienie { get; set; }
    }
}
