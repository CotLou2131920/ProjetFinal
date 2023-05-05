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
        public Client[] clientJourne { get; set; }
        List<Ingredient> IngredientsPossibles;
        public List<Plats> PlatsPossibles { get; set; }
        public Random rand = new Random();

        public Restaurant()
        {
            argent = 2000;
            cote = 0;
            maxEmployer = 3;
            maxClient = 5;

            IngredientsPossibles = new List<Ingredient>();
            IngredientsPossibles = JsonFileLoader.ChargerFichier<List<Ingredient>>("json_ingredient.json");
            PlatsPossibles = new List<Plats>();
            PlatsPossibles = JsonFileLoader.ChargerFichier<List<Plats>>("json_plats.json");
            menu = new Menu(PlatsDepart());
            employes = new List<Employer>();
            employersMag = new List<Employer>();

            FabriqueNom.InitialiseNom();

            for (int i = 0; i < maxEmployer; i++)
                employes.Add(new Employer((Rarete)rand.Next(0, 5)));
            IngredientsDepart();

        }

        public int ChoisiEmployer()
        {
            Console.WriteLine("Quelle employer voulez vous emvoyer ?\n");
            for (int i = 0; i < employes.Count; i++)
                Console.WriteLine($"({i + 1}) " + employes[i]);
            int choixEmploye = CheckChoix(employes.Count);
            if (employes[choixEmploye - 1].action <= 0)
            {
                Console.WriteLine("Désolé l'employer est Déjà occupé");
                Console.Clear();
                ChoisiEmployer();
            }
            return choixEmploye;
        }

        public int ChoisirAction(int choixEmploye)
        {
            foreach (Client client in clientJourne)
                Console.WriteLine("\n" + client);
            Console.WriteLine("\nQuel Action Voulez-vous Faire ?\n" +
                        "  (1) Assoire un client dans le resto  \n" +
                        "  (2) Aller Prendre une commande a un client  \n" +
                        "  (3) Aller Porter une commande a un client \n" +
                        "  (4) Aller Rammaser une table \n" +
                        "  (5) Retour \n");
            int choixAction = CheckChoix(5);
            if (choixAction == 5)
            {
                Console.Clear();
                choixEmploye = ChoisiEmployer();
                choixAction = ChoisirAction(choixEmploye);
            }
            return choixAction;
        }


        public void LanceJournee()
        {
            InitializeEmployerMag();
            MenuResto();

            int nbClientJournee = rand.Next(maxClient, maxClient * 2);
            clientJourne = new Client[nbClientJournee];
            for (int i = 0; i < nbClientJournee; i++)
                clientJourne[i] = new Client((Rarete)rand.Next(0, 5), menu);



            bool JourneFini = true;
            while (JourneFini)
            {
                bool valide = true;
                do
                {
                    int choixEmploye = ChoisiEmployer();
                    int choixAction = ChoisirAction(choixEmploye);
                        do
                        {
                            int clienChoisi = rand.Next(nbClientJournee);
                            if (clientJourne[clienChoisi].etat == Etat.Pret)
                            {
                                employes[choixEmploye - 1].action--;
                                clientJourne[clienChoisi].etat++;
                                valide = false;
                            }
                        } while (valide);
                    
                } while (valide);
                Console.Clear();
            }


        }

        public void AfficheMenuPrincipale()
        {
            Console.Write("+---------------------------------------------------------------------------------------------------------------------+\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "|                                                                                                                     |\n" +
                          "+---------------------------------------------------------------------------------------------------------------------+\n");
        }


        
        public Plats AssignePlatPref()
        {
            return menu.platsDispo[rand.Next(0, menu.platsDispo.Count + 1)];

        }









        public int CheckChoix(int max)
        {
            int choix;
            try
            {
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix > max || choix <= 0)
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
