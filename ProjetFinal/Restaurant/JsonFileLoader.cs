using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restaurant
{
    public static class JsonFileLoader
    {
        public static T ChargerFichier<T>(string nomFichier)
        {
            try
            {
                using (StreamReader reader = new StreamReader(nomFichier))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erreur lors du chargement du fichier:"+ ex.Message);
                return default(T);
            }


        }

    }
}
