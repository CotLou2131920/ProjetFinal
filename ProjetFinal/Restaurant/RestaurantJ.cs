using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    partial class Restaurant
    {
        
        public void Main2()
        {
            IngredientsPossibles = new List<Ingredient>();
            IngredientsPossibles = JsonFileLoader.ChargerFichier<List<Ingredient>>("json_ingredient.json");
            PlatsPossibles = new List<Plats>();
            PlatsPossibles = JsonFileLoader.ChargerFichier<List<Plats>>("json_plats.json");
            foreach(Plats p in PlatsPossibles)
            {
                Console.WriteLine("Nom de plat:");
                Console.WriteLine(p.nom);
                Console.WriteLine("Ingredients:");
                foreach (Ingredient n in p.ingredient)
                {
                    Console.WriteLine(n.nom);
                }
            }
            IngredientsDepart();


            //foreach (var i in stock)
            //    Console.WriteLine(i.nom);

        }
        public void IngredientsDepart()
        {
            stock = new List<Ingredient>();
            stock.Add(RechercheIngredient("Oeuf"));
            stock.Add(RechercheIngredient("Oeuf"));
            stock.Add(RechercheIngredient("Lait"));
            stock.Add(RechercheIngredient("Sel"));
            stock.Add(RechercheIngredient("Poivre"));
            stock.Add(RechercheIngredient("Sel"));
        }
        public Ingredient RechercheIngredient(string nom)
        {
            foreach(Ingredient i in IngredientsPossibles)
            {
                if(i.nom == nom)
                {
                    return i;
                }
            }
            return new Ingredient();
        }
        public void PlatsDepart()
        {
            PlatsApris = new List<Plats>();
        }
    }
}
