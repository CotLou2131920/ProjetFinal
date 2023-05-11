using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    partial class Plats
    {
        public string nom { get; set; }
        int prix;  
        public double prixCoutant { get; set; }
        public double prixMenu { get; set; }
        public int PrixAchat { get; set; }
        public int tempsCuisson { get; set; }
        public Ingredient[] ingredient { get; set; }
    }
}
