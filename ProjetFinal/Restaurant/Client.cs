using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    partial class Client : Personne
    {
        Plats Commande;
        int satisfaction;
        string platPref;
        string platDeteste;
        public Random rand = new Random();

        public Client(string prenom, string nom, Rarete rarete, Menu menu) : base(prenom, nom, rarete)
        {
            platPref = AssignePlatPref(menu);
            platDeteste = AssignePlatDeteste(menu);
            satisfaction = AjusteRarete(rarete);
        }

        public int AjusteRarete(Rarete rarete)
        {
            int satisf = 0;
            switch (rarete)
            {
                case Rarete.peuCommun: satisf = 2; break;
                case Rarete.commun: satisf = 1; break;
                case Rarete.rare: satisf = 0; break;
                case Rarete.epic: satisf = -1; break;
                case Rarete.legendaire: satisf = -2; break;
            }
            return satisf;
        }

        public string AssignePlatPref(Menu menu)
        {
            int choix = rand.Next(0, menu.platsMenu.Count+1);
            return menu.platsMenu[choix].nom;
        }

        public string AssignePlatDeteste(Menu menu)
        {
            int choix = rand.Next(0, menu.platsMenu.Count+1);
            return menu.platsMenu[choix].nom;
        }
    }
}
