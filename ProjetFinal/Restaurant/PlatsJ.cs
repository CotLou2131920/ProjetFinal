using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restaurant
{
    partial class Plats
    {
        [JsonConstructor]
        public Plats(string nom, int tempsCuisson, string[] ingredients)
        {
            List<Ingredient> IngredientsPossibles = JsonFileLoader.ChargerFichier<List<Ingredient>>("json_ingredient.json");
            this.nom = nom;
            this.tempsCuisson = tempsCuisson;
            this.ingredient = AjoutIngrediantsPlat(ingredients, IngredientsPossibles);
        }
        public Ingredient[] AjoutIngrediantsPlat(string[] list, List<Ingredient> IngredientsPossibles)
        {
            List<Ingredient> newIngredients = new List<Ingredient>();
            foreach(string i in list)
            {
                foreach(Ingredient I in IngredientsPossibles)
                {
                    if(i == I.nom)
                    {
                        newIngredients.Add(I);
                        break;
                    }
                }
            }
            int nmbr = newIngredients.Count();
            Ingredient[] tabIngredients = new Ingredient[nmbr];
            for(int i = 0; i < tabIngredients.Length; i++)
            {
                tabIngredients[i] = newIngredients[i];
            }
            return tabIngredients;
        }
    }
}
