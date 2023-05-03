using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    partial class Menu
    {



        public void ModifierMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu du Menu");
            Console.WriteLine("(1) Ajouter un plat aux menu");
            Console.WriteLine("(2) Enlever un plat du menu");
            Console.WriteLine("(3) Modifier le prix d'un plat");
            Console.WriteLine("(4) retour");

            int choix = CheckChoix(4);

            switch (choix)
            {
                case 1: AjouterPlat(); break;
                case 2: EnleverPlat(); break;
                case 3: MenuModifierPrix(); break;
                case 4: /* retour menu */; break;
            }

        }
        public void AjouterPlat()
        {
            if(platsMenu.Count() == maxPlats)
            {
                Console.WriteLine("Vous avex atteint le maximum de plat sur le menu");
                Console.WriteLine("Pour avoir plus de place ameliorexz votre restaurant");
                ModifierMenu();              
            }
            else
            {
                List<Plats> plats = VerifierPlatsPasAjouter();
                Console.WriteLine("Quel Plat Voulez vous Ajouter aux menu?");
                int i;
                for (i = 1; i < plats.Count(); i++)
                {
                    Console.WriteLine($"({i}) Nom: {plats[i-1].nom} PrixCoutant: {plats[i - 1].prixCoutant}");
                    Console.WriteLine(plats[i - 1].AfficherIngredients());
                }
                Console.WriteLine($"({i+1}) Retour");

                int choix = CheckChoix(i+1);
                if (choix == i + 1)
                    ModifierMenu();
                else
                {
                    platsMenu.Add(plats[choix]);
                    Console.WriteLine($"{platsDispo[i].nom} a ete ajouter au menu");
                    Console.ReadLine();
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
                ModifierMenu();
            }
            else
            {
                int i;
                for (i = 1; i < platsMenu.Count(); i++)
                {
                    Console.WriteLine($"({i}) Nom: {platsMenu[i - 1].nom} PrixCoutant: {platsMenu[i - 1].prixCoutant}$");
                    Console.WriteLine(platsMenu[i - 1].AfficherIngredients());
                }
                Console.WriteLine($"({i+1}) Retour");
                int choix = CheckChoix(i + 1);

                if (choix == i + 1)
                    ModifierMenu();
                else
                {
                    platsMenu.RemoveAt(choix - 1);
                    Console.WriteLine("Le plat a ete retirer");
                    Console.ReadLine();
                }

            }
        }
        public void MenuModifierPrix()
        {

            Console.WriteLine("Quel prix voulez vous changer");
            int i;
            for (i = 1; i < platsMenu.Count(); i++)
            {
                Console.WriteLine($"({i}) Nom: {platsMenu[i-1].nom} PrixCoutant: {platsMenu[i - 1].prixCoutant}$");
            }
            Console.WriteLine($"({i+1}) Retour\n");
            int choix = CheckChoix(i + 1);
            if (choix == i + 1)
                ModifierMenu();
            else
                ModifierPrix(choix - 1);
        }
        public void ModifierPrix(int choix)
        {
            Console.WriteLine("Entrez le nouveaux prix");
            int prix = CheckChoix(10000);
            platsMenu[choix].prixMenu = prix;
            Console.WriteLine("Le prix a ete changer");
            Console.ReadLine();
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
