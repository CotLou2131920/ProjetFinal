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

            MenuResto();

            AfficherInventaire();

        }
        public void MenuResto()
        {
            int choix = 1;
            while (choix != 0)
            {
                int i = 5;
                Console.WriteLine("(1) Menu du menu");
                Console.WriteLine("(2) Magasin");
                Console.WriteLine("(3) Afficher Inventaire");
                Console.WriteLine("(4) Afficher Inventaire");
                if (cote >= CotePourUpgrade)
                {
                    Console.WriteLine("(5) Retour");
                    Console.WriteLine("(6) Retour");
                    i = 6;
                }
                else
                {
                    Console.WriteLine("(5) Retour");
                }

                Console.WriteLine("Rentre choix");
                choix = CheckChoix(i);
                if (i == 5)
                {
                    switch (choix)
                    {
                        case 1: menu.MenuMenu(); break;
                        case 2: MenuMagasin(); break;
                        case 3: VirerEmployer(); break;
                        case 4: AfficherInventaire(); break;
                        case 5:; break;
                    }
                }
                else
                {
                    switch (choix)
                    {
                        case 1: menu.MenuMenu(); break;
                        case 2: MenuMagasin(); break;
                        case 3: VirerEmployer(); break;
                        case 4: AfficherInventaire(); break;
                        case 5: UpgradeResto(); break;
                        case 6:; break;
                    }
                }
            }
        }
        public void VraimentQuitter()
        {
            string choix;
            Console.WriteLine("Commencer Journee?   O/N");
            do
            {
                choix = Console.ReadLine().ToUpper();
            } while (choix != "O" && choix != "N");
            if (choix == "N")
                MenuResto();
        }
        public void UpgradeResto()
        {
            if (cote >= CotePourUpgrade)
            {
                Console.WriteLine($"La renovation coutera {CotePourUpgrade * 10}");
            }


        }
        public void IngredientsDepart()
        {
            stock = new List<Ingredient>();
            for (int i = 0; i < 10; i++)
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
            foreach (Ingredient i in IngredientsPossibles)
            {
                if (i.nom == nom)
                {
                    return i;
                }
            }
            return new Ingredient();
        }
        public List<Plats> PlatsDepart()
        {
            List<Plats> PlatsApris = new List<Plats>();
            PlatsApris.Add(RecherchePlat("Salade Fraiche"));
            PlatsApris.Add(RecherchePlat("Hamburger"));
            PlatsApris.Add(RecherchePlat("Spaghetti"));
            return PlatsApris;
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
                    if (p.nom == copieStock[i].nom)
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
                if (grp.Key.nom != "")
                    Console.WriteLine(grp.Key.nom + ": " + grp.Count());
            }
        }
        public bool CheckAssezIngredients(Plats p)
        {
            foreach (Ingredient i in p.ingredient)
            {
                if (!stock.Contains(RechercheIngredient(i.nom)))
                {
                    Console.WriteLine("Vous avez pas assez d'ingredient pour " + p.nom);
                    return false;
                }
            }
            foreach (Ingredient i in p.ingredient)
            {
                stock.Remove(i);
            }
            return true;
        }
        //verifier avec l'autre
        public void Cuisson()
        {
            for (int i = 0; i > clientJourne.Count(); i++)
            {
                if (clientJourne[i].etat == Etat.Attend)
                {
                    clientJourne[i].Commande.tempsCuisson--;
                    if (clientJourne[i].Commande.tempsCuisson == 0)
                        clientJourne[i].etat++;
                }
            }
        }
    }
}
