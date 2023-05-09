using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    enum Etat
    {
        Pret,
        Assit,
        Attend,
        Mange,
        Fini,
        Partie
    }
    partial class Client : Personne
    {
        public Plats Commande { get; set; }
        public Etat etat { get; set; }
        public int satisfaction { get; set; }
        string platPref;
        string platDeteste;
        public Random rand = new Random();

        public Client(Rarete rarete, Menu menu) : base(rarete)
        {
            platPref = AssignePlatPref(menu);
            platDeteste = AssignePlatDeteste(menu);
            satisfaction = AjusteRarete(rarete);
            etat = Etat.Pret;
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
            int choix = rand.Next(0, menu.platsMenu.Count);
            return menu.platsMenu[choix].nom;
        }

        public string AssignePlatDeteste(Menu menu)
        {
            int choix = rand.Next(0, menu.platsMenu.Count);
            return menu.platsMenu[choix].nom;
        }

        public override string ToString()
        {
            string info = $"Client : {nomComplet} || " +
                $"État : {etat} ";
               
            return info;
        }
    }
}
