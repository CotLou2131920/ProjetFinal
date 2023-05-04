using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    static class FabriqueNom
    {
        static List<string> listNom = new List<string>();
        static List<string> listPrenom = new List<string>();
        static Random rand = new Random();

        
        static public void RemplirListe()
        {
            AjouterNom();
            AjouterPrenom();
        }

        static public string FabriquerNom()
        {
            return listNom[rand.Next(listNom.Count)];
        }

        static public string FabriquerPrenom()
        {
            return listPrenom[rand.Next(listPrenom.Count)];
        }
        static public void InitialiseNom()
        {
            try
            {
                FabriqueNom.RemplirListe();
            }
            catch (Exception ex )
            {
                Console.WriteLine("Une erreur est survenue lors de la lecture du fichier : " + ex.Message);
            }
        }

        static void AjouterNom()
        {
            string fichierNomFamille = "nom_famille.txt";
            
            using (StreamReader reader = new StreamReader(fichierNomFamille))
            {
                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    listNom.Add(line);
                }
            }
        }

        static void AjouterPrenom()
        {
            string fichierPrenom = "Prenom.txt";

            using (StreamReader reader = new StreamReader(fichierPrenom))
            {
                string line;

                while((line = reader.ReadLine()) != null)
                {
                    listPrenom.Add(line);
                }
            }
        }
    }
}
