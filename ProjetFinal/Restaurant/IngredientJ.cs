using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Restaurant
{
    partial class Ingredient
    {
        [JsonConstructor]
        public Ingredient(string nom, int calorie, string qualite, float prix)
        {
            this.nom = nom;
            calories = calorie;
            this.qualite = qualite;
            this.prix = prix;
        }
        public Ingredient()
        {
            nom = "";
            calories = 0;
            qualite = "";
            prix = 0;
        }
    }
}
