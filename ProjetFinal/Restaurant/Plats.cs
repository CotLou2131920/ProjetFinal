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
        int prixCoutant;
        int tempsCuisson;
        public Ingredient[] ingredient { get; set; }
    }
}
