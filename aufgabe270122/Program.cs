using System;
using System.IO;
using System.Collections.Generic;

namespace Program
{
    public static class Program
    {
        static int findProfitsFirstIndex(string input)
        {
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int output;
            for (int i = 0; i < 10; i++)
            {
                output = findNthof(input, numbers[i], 6);
                if (output != -1)
                    return output;
            }
            return -1;
        }
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
            int profitNumberStartsAt = 0;
            string[] inputText;
            while (true)
            {
                Console.WriteLine("geben sie den pfard zur datei ein:");
                string? inputPath = @"";
                inputPath = Console.ReadLine();
                if (inputPath != null)
                {
                    Console.WriteLine("input was emty");
                    continue;
                }
                else if (!File.Exists(inputPath))
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
                profitNumberStartsAt = findProfitsFirstIndex(inputText[i]);
                if (profitNumberStartsAt == -1)
                    Console.WriteLine("error on profitNumberStartsAt");
                profits = new char[inputText.Length - profitNumberStartsAt - 1];
                for (int j = profitNumberStartsAt; j < inputText[i].Length; j++)
                {
                    profits[j-profitNumberStartsAt] = inputText[i][j];
                }
                int findPoint = findNthof(profits, '.'); //getting rid of the dot in the number notation
                if (findPoint == -1)
                    Console.WriteLine("error on finding point");
                for (int j = findPoint; j < profits.Length-1; j++) 
                    profits[j] = profits[j + 1];
                profits[profits.Length-1] = ' '; //clears the '€' from the string
                int findkomma = findNthof(profits, ',');
                if (findkomma == -1)
                    Console.WriteLine("error on finding komma");
                profits[findkomma] = '.';
                try
                {
                    dNumber = Convert.ToDouble(profits);
                }
                catch (FormatException)
                {
                    Console.WriteLine("error on converting to double");
                }
                Console.WriteLine($"dNumber = {dNumber}, i = {i}");
            }

            Console.ReadLine();
        }
    }
}