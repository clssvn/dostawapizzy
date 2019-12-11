using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class RozmiarPizzy
    {
        public RozmiarPizzy()
        {
            PizzaZamowienie = new HashSet<PizzaZamowienie>();
        }

        public int IdRozmiaru { get; set; }
        public string Nazwa { get; set; }
        public int? SrednicaWCm { get; set; }

        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
    }
}
