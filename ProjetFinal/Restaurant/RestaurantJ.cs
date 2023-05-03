using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    partial class Restaurant
    {
        List<Ingredient> IngredientsPossibles;
        List<Plats> PlatsPossibles;
        List<Plats> PlatsApris;
        public void Main2()
        {
            IngredientsPossibles = new List<Ingredient>();
            IngredientsPossibles = JsonFileLoader.ChargerFichier<List<Ingredient>>("json_ingredient.json");
            PlatsPossibles = new List<Plats>();
            PlatsPossibles = JsonFileLoader.ChargerFichier<List<Plats>>("json_plats.json");
            //foreach(Plats p in PlatsPossibles)
            //{
            //    Console.WriteLine("Nom de plat:");
            //    Console.WriteLine(p.nom);
            //    Console.WriteLine("Ingredients:");
            //    foreach (Ingredient n in p.ingredient)
            //    {
            //        Console.WriteLine(n.nom);
            //    }
            //    Console.WriteLine("");
            //}
            IngredientsDepart();
            PlatsDepart();
            AfficherInventaire();

        }
        public void IngredientsDepart()
        {
            stock = new List<Ingredient>();
            for(int i = 0; i < 10; i++)
                stock.Add(RechercheIngredient("Pâtes"));
            for (int i = 0; i < 10; i++)
                stock.Add(RechercheIngredient("Oeuf"));
            for (int i = 0; i < 10; i++)
                stock.Add(RechercheIngredient("Sauce"));
            for (int i = 0; i < 15; i++)
                stock.Add(RechercheIngredient("Tomate"));
            for (int i = 0; i < 10; i++)
                stock.Add(RechercheIngredient("Boeuf"));
            for (int i = 0; i < 10; i++)
                stock.Add(RechercheIngredient("Pain"));
            for (int i = 0; i < 15; i++)
                stock.Add(RechercheIngredient("Laitue"));
            for (int i = 0; i < 10; i++)
                stock.Add(RechercheIngredient("Vinegraite"));
            for (int i = 0; i < 20; i++)
                stock.Add(RechercheIngredient("Farine"));
          
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
            PlatsApris.Add(RecherchePlat("Salade Fraiche"));
            PlatsApris.Add(RecherchePlat("Hamburger"));
            PlatsApris.Add(RecherchePlat("Spaghetti"));
        }
        public Plats RecherchePlat(string nom)
        {
            foreach (Plats p in PlatsPossibles)
            {
                if (p.nom == nom)
                {
                    return p;
                }
            }
            return new Plats();
        }
        public bool CheckDispoPlat(Plats platVoulu)
        {
            List<Ingredient> copieStock = stock;
            bool ingredientExiste;

            foreach (Ingredient p in platVoulu.ingredient)
            {
                ingredientExiste = false;
                for (int i = 0; i < copieStock.Count; i++)
                {
                    if(p.nom == copieStock[i].nom)
                    {
                        copieStock.Remove(copieStock[i]);
                        ingredientExiste = true;
                        break;
                    }
                }
                if (!ingredientExiste)
                {
                    return false;
                }
            }
            stock = copieStock;
            return true;
        }
        public void AfficherInventaire()
        {
            var g = stock.GroupBy(i => i).OrderBy(group => group.Key.nom);

            foreach (var grp in g)
            {
                if(grp.Key.nom != "")
                    Console.WriteLine( grp.Key.nom+": "+grp.Count());
            }
        }
        public void Cuisson()
        {

        }
    }
}
