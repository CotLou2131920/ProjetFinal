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
        public int CotePourUpgrade { get; set; }

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
            CotePourUpgrade = 25;

            FabriqueNom.InitialiseNom();

            for (int i = 0; i < maxEmployer; i++)
                employes.Add(new Employer((Rarete)rand.Next(0, 5)));
            IngredientsDepart();

        }

        public int ChoisiEmployer()
        {
            Console.WriteLine("Quelle employer voulez vous emvoyer ?\n");
            int i = 0;
            for (i = 0; i < employes.Count; i++)
                Console.WriteLine($"({i + 1}) " + employes[i]);
            Console.WriteLine($"Pour passer un tour ({i + 1})");
            int choixEmploye = CheckChoix(employes.Count + 1);
            if (choixEmploye == i + 1)
            {
                CheckManger();
                Cuisson();
                RemetActionEmloye();
                Console.Clear();
                choixEmploye = ChoisiEmployer();
            }
            if (employes[choixEmploye - 1].action <= 0)
            {
                Console.WriteLine("Désolé l'employer est Déjà occupé \nAppuyer sur nimporte quel touche pour continuer");
                Console.ReadKey();
                Console.Clear();
                choixEmploye = ChoisiEmployer();
            }
            return choixEmploye;
        }

        public int ChoisirAction(int choixEmploye)
        {
            foreach (Client client in clientJourne)
                if (client.etat == Etat.Assit || client.etat == Etat.Attend || client.etat == Etat.Mange || client.etat == Etat.Fini)
                    Console.WriteLine("\n" + client);
            Console.WriteLine("\nQuel Action Voulez-vous Faire ?\n" +
                        "  (1) Assoire un client dans le resto  \n" +
                        "  (2) Aller Prendre une commande a un client  \n" +
                        "  (3) Aller Rammaser une table \n" +
                        "  (4) Retour \n");
            int choixAction = CheckChoix(4);
            if (choixAction == 4)
            {
                Console.Clear();
                choixEmploye = ChoisiEmployer();
                choixAction = ChoisirAction(choixEmploye);
            }
            else if (choixAction == 1 && VerfieClientPret())
            {
                choixAction = ChoisirAction(choixEmploye);
            }
            else if (choixAction == 2 && VerifieClientAssit())
            {
                choixAction = ChoisirAction(choixEmploye);
            }
            else if (choixAction == 3 && VerifieClientFini())
            {
                choixAction = ChoisirAction(choixEmploye);
            }


            return choixAction;
        }

        public bool VerifieClientFini()
        {
            bool valide = true;
            foreach (Client client in clientJourne)
            {
                if (client.etat == Etat.Fini)
                    valide = false;
            }
            if (valide)
            {
                Console.WriteLine("Désoler Vous n'avez aucune table à rammaser !\nAppuyer sur nimporte quel touche pour continuer");
                Console.ReadKey();
                Console.Clear();

            }
            return valide;
        }

        public bool VerifieClientAssit()
        {
            bool valide = true;
            foreach (Client client in clientJourne)
            {
                if (client.etat == Etat.Assit)
                    valide = false;
            }
            if (valide)
            {
                Console.WriteLine("Désoler Vous n'avez aucun client prêt à commander !\nAppuyer sur nimporte quel touche pour continuer");
                Console.ReadKey();
                Console.Clear();

            }
            return valide;
        }

        public bool VerfieClientPret()
        {
            bool valide = true;
            int clientAssi = 0;
            foreach (Client client in clientJourne)
            {
                if (client.etat == Etat.Assit || client.etat == Etat.Attend || client.etat == Etat.Mange || client.etat == Etat.Fini)
                    clientAssi++;
                else if (client.etat == Etat.Pret)
                    valide = false;
            }
            if (valide)
            {
                Console.WriteLine("Désoler Vous n'avez aucun client prêt à être assit !\nAppuyer sur nimporte quel touche pour continuer");
                Console.ReadKey();
                Console.Clear();
            }
            if (clientAssi == maxClient)
            {
                Console.WriteLine("Désoler la capacitée maximale du restaurant à été atteinte !\nAppuyer sur nimporte quel touche pour continuer");
                Console.ReadKey();
                Console.Clear();
                valide = true;
            }
            return valide;
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
                        int clientChoisi = rand.Next(nbClientJournee);
                        if (clientJourne[clientChoisi].etat == Etat.Pret && choixAction == 1)
                        {
                            employes[choixEmploye - 1].action--;
                            clientJourne[clientChoisi].etat++;
                            valide = false;
                        }
                        else if (clientJourne[clientChoisi].etat == Etat.Assit && choixAction == 2)
                        {
                            AssignePlatClient(clientChoisi);
                            employes[choixEmploye - 1].action--;
                            clientJourne[clientChoisi].etat++;
                            valide = false;
                        }
                        else if (clientJourne[clientChoisi].etat == Etat.Fini && choixAction == 3)
                        {
                            employes[choixEmploye - 1].action--;
                            clientJourne[clientChoisi].etat++;
                            valide = false;
                        }
                    } while (valide);

                } while (valide);

                Console.Clear();
            }
        }

        public void AssignePlatClient(int clientChoisi)
        {
            clientJourne[clientChoisi].Commande = menu.platsMenu[rand.Next(menu.platsMenu.Count)];
            if (!CheckAssezIngredients(clientJourne[clientChoisi].Commande))
                AssignePlatClient(clientChoisi);
        }
        public void RemetActionEmloye()
        {
            for (int i = 0; i < employes.Count; i++)
                employes[i].action = employes[i].actionMax;
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






        public void Cuisson()
        {
            for (int i = 0; i < clientJourne.Count(); i++)
            {
                if (clientJourne[i].etat == Etat.Attend)
                {
                    clientJourne[i].Commande.tempsCuisson--;
                    if (clientJourne[i].Commande.tempsCuisson <= 0)
                        clientJourne[i].etat++;
                }
            }
        }
        public void CheckManger()
        {
            for (int i = 0; i < clientJourne.Count(); i++)
            {
                if (clientJourne[i].etat == Etat.Mange)
                {
                    clientJourne[i].etat++;
                    argent += clientJourne[i].Commande.prixMenu;
                }
            }
        }
        public void GererCote()
        {
            int satisfaction = 0;
            foreach (Client c in clientJourne)
            {
                satisfaction += c.satisfaction;
            }
            cote += satisfaction;
        }
        public void AffichageInfo()
        {
            Console.WriteLine($"Argent: {argent}$   Employes: {employes.Count}/{maxEmployer}    Capacité maximum: {maxClient}   Cote Restaurant: {cote}/{CotePourUpgrade}\n\n\n");
        }
        public bool VerifierChoix()
        {
            string choix;
            do
            {
                Console.WriteLine($"Confirmer choix:      O/N");
                choix = Console.ReadLine().ToUpper();
            }
            while (choix != "O" && choix != "N");
            if (choix == "O")
                return true;
            return false;
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
