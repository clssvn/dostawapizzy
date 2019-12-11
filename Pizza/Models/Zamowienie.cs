using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            DodatekZamowienie = new HashSet<DodatekZamowienie>();
            PizzaZamowienie = new HashSet<PizzaZamowienie>();
            UzytkownikZamowienie = new HashSet<UzytkownikZamowienie>();
        }

        public int IdZamowienie { get; set; }
        public string Komentarz { get; set; }
        public DateTime? DataCzasZamowienia { get; set; }
        public DateTime DataCzasRealizacjiZamowienia { get; set; }
        public decimal? SumaZamowienia { get; set; }

        public virtual ICollection<DodatekZamowienie> DodatekZamowienie { get; set; }
        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
        public virtual ICollection<UzytkownikZamowienie> UzytkownikZamowienie { get; set; }
    }
}
