using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Dodatek
    {
        public Dodatek()
        {
            DodatekZamowienie = new HashSet<DodatekZamowienie>();
        }

        public int IdDodatek { get; set; }
        public string Nazwa { get; set; }
        public decimal? Cena { get; set; }

        public virtual ICollection<DodatekZamowienie> DodatekZamowienie { get; set; }
    }
}
