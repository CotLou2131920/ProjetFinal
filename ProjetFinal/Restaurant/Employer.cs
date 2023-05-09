using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    enum Effet
    {
        rien,
        maladroit, // 25% Oublie commande 
        impolie, // - 5% trouver bon plat
        competant, // Rien
        Bon, // 40% bon plats || 50% correct || 10% mauvais
        Chef, // +1$ PrixCoutant chaque plats 
        polie, // +1 Cote restaurant 
        Rapide, // +1 Action
        qualifie // +1 satisfaction

    }
    partial class Employer : Personne
    {
        public int salaire { get; set; }
        public int action { get; set; }
        public int actionMax { get; set; }
        public Effet effet { get; set; }
        Random rand = new Random();

        public Employer(Rarete rarete) : base( rarete)
        {
            salaire = TrouveSalaire(rarete);
            effet = (Effet)TrouveEffet(rarete);
            if (effet == Effet.Rapide)
                actionMax = 2;
            else
                actionMax = 1;
            action = actionMax;
        }

        public int TrouveEffet(Rarete rarete)
        {
            int effet = rand.Next(0, 101);
            
            if (rarete == Rarete.commun && effet > 50)
                effet = rand.Next((int)Effet.maladroit, (int)Effet.Chef);
            else if (rarete == Rarete.peuCommun && effet > 45)
                effet = rand.Next((int)Effet.impolie, (int)Effet.polie);
            else if (rarete == Rarete.rare && effet > 40)
                effet = rand.Next((int)Effet.competant, (int)Effet.Rapide);
            else if (rarete == Rarete.epic && effet > 35)
                effet = rand.Next((int)Effet.Bon, (int)Effet.qualifie);
            else if (rarete == Rarete.legendaire && effet > 30)
                effet = rand.Next(((int)Effet.Chef), (int)Effet.qualifie + 1);
            else
                effet = 0;
            return effet;
        }

        public int TrouveSalaire(Rarete rarete)
        {
            int salaire = rand.Next(15, 21);
            switch (rarete)
            {
                case Rarete.commun: salaire -= 5; break;
                case Rarete.peuCommun: salaire -= 2; break;
                case Rarete.epic: salaire += 2; break;
                case Rarete.legendaire: salaire += 5; break;
            }
            return salaire;
        }

        public override string ToString()
        {
            string info = $"Employer : {nomComplet} || " +
                $"Salaire : {salaire} || " +
                $"Effet : {effet} || " +
                $"Action restante : {action}";
            return info;
        }
    }
}
