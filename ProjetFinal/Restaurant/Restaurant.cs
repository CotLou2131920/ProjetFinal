using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    partial class Restaurant
    {
        double agrent;
        int cote;
        int maxEmployer;
        int maxClient;
        Menu menu;
        List<Employer> employes;
        List<Ingredient> stock;
        Random rand = new Random();

        

        public Plats AssignePlatPref()
        {
            return menu.platsDispo[rand.Next(0, menu.platsDispo.Count)];

        }
        

        
    }

    
}
