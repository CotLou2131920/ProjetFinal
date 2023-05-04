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
        public Plats()
        {
            
        }
        [JsonConstructor]
        public Plats(string nom, int tempsCuisson,int prixAchat, string[] ingredients)
        {
            List<Ingredient> IngredientsPossibles = JsonFileLoader.ChargerFichier<List<Ingredient>>("json_ingredient.json");
            this.nom = nom;
            this.tempsCuisson = tempsCuisson;
            PrixAchat = prixAchat;
            this.ingredient = AjoutIngrediantsPlat(ingredients, IngredientsPossibles);
            prixCoutant = (int)CalculPrixCoutant(ingredient);
            prixMenu = (int)prixCoutant;
        }
        public double CalculPrixCoutant(Ingredient[] tabIngredient)
        {
            double prix = 0;
            foreach (Ingredient i in tabIngredient)
            {
                prix += i.prix;
            }
            return prix;
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
        public string AfficherIngredients()
        {
            string msg = "Ingredients:\n";
            foreach (Ingredient i in ingredient)
                msg += i.nom+ "\n";
            return msg;
        }
    }
}
