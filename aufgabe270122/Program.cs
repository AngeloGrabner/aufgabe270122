using System;

namespace Program
{
    public static class Program
    {
        static void Main()
        {
            double anschaffungskosten = 0; 
            int nutzungsdauer = 0;
            bool worked = false;


            //inputing data

            while (!worked)
            {
                Console.Write("geben sie die anschaffungskosten ein: ");
                worked = double.TryParse(Console.ReadLine(), out anschaffungskosten);
                if (!worked)
                    Console.WriteLine("fwhler bei der eingabe");
            }
            worked = false;
            while (!worked)
            {
                Console.Write("geben sie die nutzungsdauer ein: ");
                worked = int.TryParse(Console.ReadLine(), out nutzungsdauer);
                if (!worked)
                    Console.WriteLine("fwhler bei der eingabe");
            }

            Console.Clear();
            Console.WriteLine($"Nutzungsdauer:{nutzungsdauer,15}");
            Console.WriteLine($"Anschaffungskosten:{anschaffungskosten,10}\n");
            //working with the data
            //              "0123456789 123456789 123456789 123456789 123456789 123456789 1234567"
            string header = "Nutzungsjahr       Anfangswert         Abschreibung        Restwert ";
            double anfangswert = anschaffungskosten, restwert = 0;
            const double beschreibung = 1000;
            Console.WriteLine(header);
            for (int i = 0; i < nutzungsdauer; i++)
            {
                restwert = anfangswert - beschreibung;
                Console.WriteLine($"{i+1,-20}{anfangswert,-20}{beschreibung,-20}{restwert,-20}");
                anfangswert = restwert;
            }
            Console.ReadKey();
        }
    }
}