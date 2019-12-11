using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class PizzaZamowienie
    {
        public int PizzaIdPizza { get; set; }
        public int RozmiarPizzyIdRozmiaru { get; set; }
        public int ZamowienieIdZamowienie { get; set; }
        public decimal? Cena { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual RozmiarPizzy RozmiarPizzyIdRozmiaruNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowienieNavigation { get; set; }
    }
}
