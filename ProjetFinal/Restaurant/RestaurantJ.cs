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
            Console.Clear();
            AffichageInfo();
            int choix = 1;
            int i = 5;
            while (choix != 0 && choix != i)
            {
                Console.WriteLine("(1) Menu du menu");
                Console.WriteLine("(2) Magasin");
                Console.WriteLine("(3) Virer un employer");
                Console.WriteLine("(4) Afficher Inventaire");
                if (cote >= CotePourUpgrade)
                {
                    Console.WriteLine("(5) Renovations");
                    Console.WriteLine("(6) Commencer Journee");
                    i = 6;
                }
                else
                {
                    Console.WriteLine("(5) Commencer Journee");
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
                        case 5: VraimentQuitter(); break;
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
                        case 6: VraimentQuitter(); break;
                    }
                }
            }
        }
        public void VraimentQuitter()
        {
            string choix;
            try
            {
                Console.WriteLine("Commencer Journee?   O/N");
                do
                {
                    choix = Console.ReadLine().ToUpper();
                } while (choix != "O" && choix != "N");
                if (choix == "N")
                    MenuResto();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veuillez choisir (O)ui ou (N)on");
                VraimentQuitter();
            }
        }
        public void UpgradeResto()
        {
            if (cote >= CotePourUpgrade)
            {
                Console.WriteLine($"La renovation coutera {CotePourUpgrade * 10}");
                if(argent >= CotePourUpgrade * 10)
                {
                    if (VerifierChoix())
                    {
                        argent -= CotePourUpgrade * 10;
                        Console.WriteLine("Le restaurant a été renover!!!!!!");
                        maxClient *= 2;
                        maxEmployer *= 2;
                        menu.maxPlats += 2;
                        CotePourUpgrade += 2;

                        Console.WriteLine($"Vous pouvez maintenant avoir {maxClient} de clients assis dans votre restaurant\n");
                        Console.WriteLine($"Vous pouvez maintenant avoir {maxEmployer} d'employers dans votre resaturant\n");
                        Console.WriteLine($"Vous pouvez maintenant avoir {menu.maxPlats} plats sur votre menu\n");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
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
        //public bool CheckDispoPlat(Plats platVoulu)
        //{
        //    List<Ingredient> copieStock = new List<Ingredient>();
        //    foreach (Ingredient i in stock)
        //    {
        //        copieStock.Add(i);
        //    }
        //    bool ingredientExiste;

        //    foreach (Ingredient p in platVoulu.ingredient)
        //    {
        //        ingredientExiste = false;
        //        for (int i = 0; i < copieStock.Count; i++)
        //        {
        //            if (p.nom == copieStock[i].nom)
        //            {
        //                copieStock.Remove(copieStock[i]);
        //                ingredientExiste = true;
        //            }
        //        }
        //        if (!ingredientExiste)
        //        {
        //            return false;
        //        }
        //    }
        //    stock = copieStock;
        //    return true;
        //}
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
    }
}
