using System;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurant resto = new Restaurant();
            foreach (Employer employe in resto.employes)
            {
                Console.WriteLine(employe);
            }
           

        }
    }
}