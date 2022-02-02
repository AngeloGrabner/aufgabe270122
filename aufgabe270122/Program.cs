using System;
using System.IO;
using System.Collections.Generic;

namespace Program
{
    public static class Program
    {
        //static int findProfitsFirstIndex(string input)
        //{
        //    int[] found = new int[10];
        //    char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //    for (int i = 0; i < 10; i++)
        //    {
        //        found[i] = Array.IndexOf<char>(input.ToCharArray(), numbers[i]);
        //    }

        //    return 0;
        //}
        static int findNthof(char[] input, char c, int n = 1)
        {
            return findNthof(input.ToString(), c, n);
        }
        static int findNthof(string input, char c, int n = 1) //retuns the index of the n'th char of a string or -1 if no char was found 
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == c)
                    count++;
                if (count == n)
                {
                    return i;
                }          
            }
            return -1;
        }
        static int findNthofReverse(string input, char c, int n = 1) //does what findNthof() just starts with the last char and goes to the first
        {
            int count = 0;
            for (int i = input.Length-1; i >=0; i--)
            {
                if (input[i] == c)
                    count++;
                if (count == n)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main()
        {
            double dNumber = 0;
            char[] profits;
            const int profitNumberStartsAt = 20;
            string[] inputText;
            while (true)
            {
                Console.WriteLine("geben sie den pfard zur datei ein:");
                string? inputPath = @"";
                inputPath = Console.ReadLine();
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("file does nt exits at {0}", inputPath);
                    continue;
                }
                else
                {
                    inputText = File.ReadAllLines(inputPath);
                    break;
                }
            }
            for (int i = 1; i < inputText.Length; i++) //loops through all rows 
            {
                //converting text to number (form 2.735,50 € to 2735.5)
                //profitNumberStartsAt = findProfitsFirstIndex(inputText[i]); coursed error | use the set location on index instedead of searching it
                try
                {
                    profits = new char[inputText[i].Length - profitNumberStartsAt]; //overflow
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"overflow occured: {inputText.Length}");
                    profits = new char[inputText[i].Length];
                }
                for (int j = profitNumberStartsAt; j < inputText[i].Length; j++) 
                {
                    profits[j - profitNumberStartsAt] = inputText[i][j]; 
                }
                profits[profits.Length - 1] = ' '; //clears the '€' from the string
                //int findPoint = findNthof(profits, '.'); 
                int findPoint = Array.IndexOf(profits, '.'); //getting rid of the dot in the number notation
                if (findPoint == -1)
                    Console.WriteLine("couldn't find a point");
                for (int j = findPoint-1; j < profits.Length-1; j++) 
                    profits[j] = profits[j + 1];
                //int findkomma = findNthof(profits, ',');
                bool changedKomma = false;
                for (int j = 0;j< profits.Length; j++)
                {
                    if (profits[j] == ',')
                    {
                        profits[j] = '.';
                        changedKomma = true;
                        //for debug
                        Console.Write("verarbeitet: ");
                        for (int k = 0; k < profits.Length; k++)
                            Console.Write(profits[k]);
                        Console.WriteLine();
                        break;
                    }
                }
                if (!changedKomma)
                    Console.WriteLine("error: didn't find komma");
                try
                {
                    dNumber = Convert.ToDouble(profits.ToString());
                }
                catch (FormatException)
                {
                    Console.WriteLine("error on converting to double");
                    Console.WriteLine($"dNumber = {dNumber}, i = {i}");
                }
                
            }

            Console.ReadLine();
        }
    }
}