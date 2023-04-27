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
        static Random ramd = new Random();

        static public void RemplirListe()
        {
            AjouterNom();
            AjouterPrenom();
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
