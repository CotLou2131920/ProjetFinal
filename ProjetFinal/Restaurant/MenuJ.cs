using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    partial class Menu
    {
        public void MenuMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu du Menu");
            Console.WriteLine("(1) Afficher le menu");
            Console.WriteLine("(2) Ajouter un plat aux menu");
            Console.WriteLine("(3) Enlever un plat du menu");
            Console.WriteLine("(4) Modifier le prix d'un plat");
            Console.WriteLine("(5) retour");

            int choix = CheckChoix(5);

            switch (choix)
            {
                case 1: AfficherMenu(); break;
                case 2: AjouterPlat(); break;
                case 3: EnleverPlat(); break;
                case 4: MenuModifierPrix(); break;
                case 5: /* retour menu */; break;
            }
        }
        public void AfficherMenu()
        {
            foreach(Plats p in platsMenu)
            {
                Console.WriteLine($"Nom: {p.nom} Prix Actuel: {p.prixMenu}$");
                Console.WriteLine(p.AfficherIngredients());
            }
            Console.ReadLine();
            Console.Clear();
            MenuMenu();
        }
        public void AjouterPlat()
        {
            if(platsMenu.Count() == maxPlats)
            {
                Console.WriteLine("Vous avex atteint le maximum de plat sur le menu");
                Console.WriteLine("Pour avoir plus de place ameliorexz votre restaurant");
                MenuMenu();              
            }
            else
            {
                List<Plats> plats = VerifierPlatsPasAjouter();
                Console.WriteLine("Quel Plat Voulez vous Ajouter aux menu?");
                int i;
                for (i = 1; i < plats.Count()+1; i++)
                {
                    Console.WriteLine($"({i}) Nom: {plats[i-1].nom} PrixCoutant: {plats[i - 1].prixCoutant}");
                    Console.WriteLine(plats[i - 1].AfficherIngredients());
                }
                Console.WriteLine($"({i}) Retour");

                int choix = CheckChoix(i);
                if (choix == i)
                    MenuMenu();
                else
                {
                    platsMenu.Add(plats[choix-1]);
                    Console.WriteLine($"{plats[choix-1].nom} a ete ajouter au menu");
                    Console.ReadLine();
                    Console.Clear();
                    MenuMenu();
                }

            }
        }
        public List<Plats> VerifierPlatsPasAjouter()
        {
            List<Plats> plats = new List<Plats>();
            for(int i = 0;i < platsDispo.Count();i++)
            {
                bool check = true;
                foreach (Plats plat in platsMenu)
                {
                    if (platsDispo[i].nom == plat.nom)
                        check = false;
                }
                if (check)
                {
                    plats.Add(platsDispo[i]);
                }

            }
            return plats;
        }
        public void EnleverPlat()
        {
            if (platsMenu.Count() == 0)
            {
                Console.WriteLine("vous pouvez pas avoir moins que 0 plats");
                MenuMenu();
            }
            else
            {
                int i;
                for (i = 1; i < platsMenu.Count()+1; i++)
                {
                    Console.WriteLine($"({i}) Nom: {platsMenu[i - 1].nom} PrixCoutant: {platsMenu[i - 1].prixCoutant}$");
                    Console.WriteLine(platsMenu[i - 1].AfficherIngredients());
                }
                Console.WriteLine($"({i}) Retour");
                int choix = CheckChoix(i);

                if (choix == i + 1)
                    MenuMenu();
                else
                {
                    Console.WriteLine(platsDispo.Count());
                    Console.WriteLine(platsMenu.Count());

                    platsMenu.RemoveAt(choix - 1);

                    Console.WriteLine(platsDispo.Count());
                    Console.WriteLine(platsMenu.Count());




                    Console.WriteLine("Le plat a ete retirer");
                    Console.ReadLine();
                    Console.Clear();
                    MenuMenu();
                }

            }
        }
        public void MenuModifierPrix()
        {

            Console.WriteLine("Quel prix voulez vous changer");
            int i;
            for (i = 1; i < platsMenu.Count(); i++)
            {
                Console.WriteLine($"({i}) Nom: {platsMenu[i-1].nom} Prix Actuel: {platsMenu[i - 1].prixMenu}$");
            }
            Console.WriteLine($"({i}) Retour\n");
            int choix = CheckChoix(i);
            if (choix == i + 1)
                MenuMenu();
            else
                ModifierPrix(choix - 1);
        }
        public void ModifierPrix(int choix)
        {
            Console.WriteLine("Astuce: Un client ne seras pas content de payer trop cher pour un plat,\n" +
                "        mais il serait tres content de payer moins cher\n\n\n\n");
            Console.WriteLine("Entrez le nouveaux prix");
            int prix = CheckChoix(10000);
            platsMenu[choix].prixMenu = prix;
            Console.WriteLine("Le prix a ete changer");
            Console.ReadLine();
            Console.Clear();
            MenuMenu();
        }
        public int CheckChoix(int max)
        {
            int choix = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (choix > max || choix < 0)
                {
                    throw new Exception("Le chiffre rentrer est incorrect");
                }
                return choix;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                choix = CheckChoix(max);
                return choix;
            }

        }




    }
}
