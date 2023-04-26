using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    enum Effet
    {
        maladroit, // 25% Oublie commande 
        impolie, // - 5% trouver bon plat
        competant, // Rien
        Bon, // 40% bon plats || 50% correct || 10% mauvais
        Chef, // +1$ PrixCoutant chaque plats 
        polie, // +1 satisfaction
        Rapide, // +1 Action
        qualifie // +1 Cote restaurant 

    }
    partial class Employer : Personne
    {
        int salaire;
        int action;
        int actionMax;
    }
}
