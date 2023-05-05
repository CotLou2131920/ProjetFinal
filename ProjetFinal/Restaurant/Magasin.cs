using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace Restaurant
{
    partial class Restaurant
    {
        public List<Employer> employersMag { get; set; }

        public void MenuMagasin()
        {
            Console.Clear();
            Console.WriteLine("Bienvenu aux Marché");
            Console.WriteLine("(1) Engager un employer");
            Console.WriteLine("(2) Acheter un recette");
            Console.WriteLine("(3) Achter des ingredients");
            Console.WriteLine("(4) Retour");
            int choix = CheckChoix(4);
            switch (choix)
            {
                case 1:MenuAcheterEmployer();break;
                case 2: MenuAcheterPlat();break;
                case 3: MenuAcheterIngredient(); break;
                case 4: /*retour*/; break;
            }
        }
        public void MenuAcheterEmployer()
        {
            Console.Clear();
            Console.WriteLine("Bienvenu aux Marché");
            Console.WriteLine("(1) Engager un employer");
            Console.WriteLine("(2) Acheter un recette");
            Console.WriteLine("(3) Achter des ingredients");
            Console.WriteLine("(4) Retour");


        }
        public void InitializeEmployerMag()
        {
            employersMag.Clear();
            for(int i = 0; i < 5; i++)
            {
                employersMag.Add(new Employer((Rarete)rand.Next(5)));
            }
        }
        public void VirerEmployer()
        {
            Console.WriteLine("Choissisez quel employer voul voulez virez");
            for (int i = 1; i > employes.Count(); i++)
            {
                Console.WriteLine($"({i}) Nom: {employes[i].nomComplet}  Effet: {employes[i].effet.h}");


            }
       
            //enleve moitie de paye
        }
        public void MenuAcheterPlat()
        {

            List<Plats> plats = VerifierPlatPasAcheter();
            Console.WriteLine("Bienvenue aux Marche noir");
            int i;
            for (i = 1; i < plats.Count() + 1; i++)
            {
                Console.WriteLine($"({i}) Nom: {plats[i - 1].nom} Prix: {plats[i - 1].PrixAchat}$");
                Console.WriteLine(plats[i - 1].AfficherIngredients());
            }
            Console.WriteLine($"({i}) Retour");

            int choix = CheckChoix(i);
            if (choix == i)
                MenuMagasin();
            else
            {
                if (CheckArgent(plats[choix - 1].PrixAchat))
                {
                    string choix2;
                    do
                    {
                        Console.WriteLine($"Achter  {plats[choix - 1].nom}      O/N");
                        choix2 = Console.ReadLine().ToUpper();
                    }
                    while (choix2 != "O" && choix2 != "N");

                    if(choix2 == "O")
                    {
                        menu.platsDispo.Add(plats[choix - 1]);
                        Console.WriteLine($"{plats[choix - 1].nom} a ete ajouter au menu");
                        Console.ReadLine();
                        Console.Clear();
                        MenuMagasin();
                    }
                    else
                    {
                        Console.Clear();
                        MenuAcheterPlat();
                    }
                }
                else
                {
                    MenuMagasin();
                }
            }
        }
        public List<Plats> VerifierPlatPasAcheter()
        {
            List<Plats> plats = new List<Plats>();
            for (int i = 0; i < PlatsPossibles.Count(); i++)
            {
                bool check = true;
                foreach (Plats plat in menu.platsDispo)
                {
                    if (PlatsPossibles[i].nom == plat.nom)
                        check = false;
                }
                if (check)
                {
                    plats.Add(PlatsPossibles[i]);
                }
            }
            return plats;
        }
        public void MenuAcheterIngredient()
        {
            Console.WriteLine("Bienvenue a l'epicerie");
            int i;
            for (i = 1; i < IngredientsPossibles.Count() + 1; i++)
            {
                Console.WriteLine($"({i}) Nom: {IngredientsPossibles[i - 1].nom} Prix: {string.Format("{0:0.00}", IngredientsPossibles[i - 1].prix)}");
            }
            Console.WriteLine($"({i}) Retour");

            int choix = CheckChoix(i);
            if (choix == i)
                MenuMagasin();
            else
            {
                if (CheckArgent(IngredientsPossibles[choix - 1].prix))
                {
                    string choix2;
                    do
                    {
                        Console.WriteLine($"Achter  {IngredientsPossibles[choix - 1].nom}      O/N");
                        choix2 = Console.ReadLine().ToUpper();
                    }
                    while (choix2 != "O" && choix2 != "N");

                    if (choix2 == "O")
                    {
                        stock.Add(IngredientsPossibles[choix - 1]);
                        Console.WriteLine($"{IngredientsPossibles[choix - 1].nom} a ete ajouter a l'inventaire");
                        Console.ReadLine();
                        Console.Clear();
                        MenuMagasin();
                    }
                    else
                    {
                        Console.Clear();
                        MenuAcheterPlat();
                    }
                }
                else
                {
                    MenuMagasin();
                }
            }
        }
        public bool CheckArgent(double prix)
        {
            if(prix > argent)
            {
                Console.WriteLine("Vous avez pas assez d'argent");
                Console.ReadLine();
                Console.Clear();
                return false;
            }
            return true;
        }

    }
}
