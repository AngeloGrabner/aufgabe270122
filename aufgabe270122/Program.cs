using System;

namespace Program
{
    public static class Program
    {
        static int findHighst(double[] input)
        {
            int heighest = 0;
            for (int i = 1; i < input.Length-1; i++)
            {
                if (input[heighest] < input[i])
                {
                    heighest = i;
                }
            }
            return heighest;
        }
        static void Main()
        {
            string[] tNamen = { "AGIP", "BP", "SHELL", "ESSO", "TOTAL" };
            double[] tUms = { 11200.10, 23433.20, 7134.90, 14655.00, 4175.80 };
            int index = findHighst(tUms);
            Console.WriteLine($"Das Unternehmen {tNamen[index]} hat den höchsten umsatz mit einem wert von {tUms[index]}");
            Console.ReadKey();
        }
    }
}