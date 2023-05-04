using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    partial class Restaurant
    {
        public double argent { get; set; }
        public int cote { get; set; }
        public int maxEmployer { get; set; }
        public int maxClient { get; set; }
        public Menu menu { get; set; }
        public List<Employer> employes { get; set; }
        public List<Ingredient> stock { get; set; }
        List<Ingredient> IngredientsPossibles;
        List<Plats> PlatsPossibles;
        List<Plats> PlatsApris;
        public Random rand = new Random();

        public Restaurant()
        {
            argent = 2000;
            cote = 0;
            maxEmployer = 100;
            maxClient = 5;

            IngredientsPossibles = new List<Ingredient>();
            IngredientsPossibles = JsonFileLoader.ChargerFichier<List<Ingredient>>("json_ingredient.json");
            PlatsPossibles = new List<Plats>();
            PlatsPossibles = JsonFileLoader.ChargerFichier<List<Plats>>("json_plats.json");
            menu = new Menu(PlatsDepart());
            employes = new List<Employer>();
            PlatsApris = new List<Plats>();

            FabriqueNom.InitialiseNom();

            for (int i = 0; i < maxEmployer; i++)
            {
                Employer employer = new Employer(FabriqueNom.FabriquerPrenom(), FabriqueNom.FabriquerNom(), (Rarete)rand.Next(0, 5));
                employes.Add(employer);
            }
            IngredientsDepart();
        }


        public Plats AssignePlatPref()
        {
            return menu.platsDispo[rand.Next(0, menu.platsDispo.Count+1)];

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
