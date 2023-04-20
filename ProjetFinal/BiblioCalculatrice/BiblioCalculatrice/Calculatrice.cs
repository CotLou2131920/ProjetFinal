using System;

namespace BiblioCalculatrice
{
    public class Calculatrice
    {
        public double Addition(double x, double y)
        {
            return x + y;
        }
        public double Soustraction(double x, double y)
        {
            return x + y;
        }
        public double Diviser(double x, double y)
        {
            double reponse = 0;
            try
            {
                if (x == 0 || y == 0)
                {
                    throw new DivideByZeroException();
                }
                reponse = x / y;

            }
            catch (DivideByZeroException ex)
            {
                reponse = y;
            }
            return reponse;
        }
        public double Multiplier(double x, double y)
        {
            double reponse = 0;
            try
            {
                reponse = x * y;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Erreur!");
                Console.WriteLine(ex.Message);
            }
            return reponse;
        }
        public long Multiplier(long x, long y)
        {
            long reponse = 0;
            try
            {
                reponse = x * y;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Erreur!");
                Console.WriteLine(ex.Message);
            }
            return reponse;
        }
        public double Exposant(double x, double y)
        {
            return Math.Exp(x);
        }
        public double Log(double x, double y)
        {
            return Math.Log(x,y);
        }


    }
}
