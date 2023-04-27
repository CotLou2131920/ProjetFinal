﻿using System;
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
        string nomComplet;
        Rarete rare;
        
        public Personne(string prenom, string nom, Rarete rarete)
        {
            nomComplet = prenom + " " + nom;
            rare = rarete;
           
        }
    }
}

