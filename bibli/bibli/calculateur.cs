using System;

namespace bibli
{
    public class Calculateur
    {

        public int Adition(int entier1, int entier2)
        {
            return entier1 + entier2;
        }

        public int Soustraction(int nbASoustraire, int nbQuiSoustrait)
        {
            return nbASoustraire - nbQuiSoustrait;
        }


        public double Diviser(int nbDiviser, int nbQuiDivise)
        {
            try
            {
                double resultat = nbDiviser / nbQuiDivise;
                return resultat;
            }
            catch (DivideByZeroException ex)
            {
                return nbDiviser;
            }

        }

        public double Multiplier(int nbMultiplier, int nbQuiMultipie)
        {
            double resultat = nbMultiplier * nbQuiMultipie;
            return ++resultat;
        }


        public double Log(double a, double b)
        {
            return Math.Log(a, b);
        }
        
    }
}
