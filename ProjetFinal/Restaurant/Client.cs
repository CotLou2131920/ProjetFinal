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

        public Client(string prenom, string nom, Rarete rarete) : base(prenom, nom, rarete)
        {
            //platPref = AssignePlatPref();
        }
    }
}
