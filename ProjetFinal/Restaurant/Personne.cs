using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    enum Rarete
    {
        commun,
        peuCommun,
        rare,
        epic,
        legendaire
    }

    partial class Personne
    {
        public string nomComplet { get; set; }
        Rarete rare;
        
        public Personne(Rarete rarete)
        {
            nomComplet = FabriqueNom.FabriquerPrenom() + " " + FabriqueNom.FabriquerNom();
            rare = rarete;
           
        }
    }
}

