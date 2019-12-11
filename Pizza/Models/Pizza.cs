using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
            PizzaZamowienie = new HashSet<PizzaZamowienie>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
    }
}
