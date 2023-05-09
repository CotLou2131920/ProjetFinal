using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using Humanizer;

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

                    if(VerifierChoix())
                    {
                        menu.platsDispo.Add(plats[choix - 1]);
                        argent -= plats[i].PrixAchat;
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
                    if (VerifierChoix())
                    {
                        stock.Add(IngredientsPossibles[choix - 1]);
                        argent -= IngredientsPossibles[choix - 1].prix;
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
        public void InitializeEmployerMag()
        {
            employersMag.Clear();
            for (int i = 0; i < 5; i++)
            {
                employersMag.Add(new Employer((Rarete)rand.Next(5)));
            }
        }
        public void VirerEmployer()
        {
            Console.Clear();
            Console.WriteLine("Choissisez quel employer voul voulez virez");
            int i;
            for (i = 1; i > employes.Count(); i++)
            {
                Console.WriteLine($"({i}) Nom: {employes[i].nomComplet}  Effet: {employes[i].effet.Humanize()}  Salaire: {employes[i].salaire}");
            }
            Console.WriteLine($"({i}) Retour");
            int choix = CheckChoix(i);
            if (choix != i)
            {
                if (VerifierChoix())
                {
                    if (CheckArgent(employes[choix - 1].salaire / 2))
                    {
                        argent -= employes[choix - 1].salaire / 2;
                        employes.RemoveAt(choix - 1);
                    }
                    else
                        Console.WriteLine("Vous devez avoir assez d'argent pour lui payer a souper");
                }
            }
        }
        public void MenuAcheterEmployer()
        {
            Console.Clear();
            Console.WriteLine("Bienvenu aux Salon d'emploi");
            int i;
            for (i = 1; i > employersMag.Count(); i++)
            {
                Console.WriteLine($"({i}) Nom: {employersMag[i].nomComplet}  Rareté: {employersMag[i].rare.Humanize()}  Salaire: {employersMag[i].salaire}");
            }
            Console.WriteLine($"({i}) Retour");
            int choix = CheckChoix(i);
            if(choix == i)
                MenuMagasin();
            else
            {
                if (VerifierChoix())
                {
                    employes.Add(employersMag[choix - 1]);
                    employersMag.RemoveAt(choix - 1);
                    Console.Clear();
                    MenuMagasin();
                }
                else
                {
                    Console.Clear();
                    MenuMagasin();
                }
            }

        }
        public bool VerifierChoix()
        {
            string choix;
            do
            {
                Console.WriteLine($"Confirmer choix:      O/N");
                choix = Console.ReadLine().ToUpper();
            }
            while (choix != "O" && choix != "N");
            if (choix == "O")
                return true;
            return false;
        }

    }
}
