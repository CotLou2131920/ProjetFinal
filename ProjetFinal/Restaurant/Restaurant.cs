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

<<<<<<< HEAD
        

        public Plats AssignePlatPref()
        {
            return menu.platsDispo[rand.Next(0, menu.platsDispo.Count)];

        }
        

        
=======





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
>>>>>>> Jerome
    }

    
}
