using System;
using System.IO;
using System.Collections.Generic;

/*
 errors on i = 2 4 7 8 : numbers are incorrect
 */

namespace Program
{
    public static class Program
    {
        static void Main()
        {
            double dNumber = 0;
            char[] profits;
            int profitNumberStartsAt = 0;
            string[] inputText;
            string newFileName = @"", inputPath = @"";
            //int errorState = 0;
            while (true)
            {
                Console.WriteLine("geben sie den pfard zur datei ein:");
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
            Console.WriteLine("\n\nthe following is only for debuging\n\n");
            int startAt = inputPath.LastIndexOf('\\');
            for (int i = 0; i < startAt; i++)
            {
                newFileName += inputPath[i];
            }
            newFileName += "\\Kundendateien_erweitert.txt";
            Console.WriteLine(newFileName);
            File.Delete(newFileName); // getting ride of an older instance of the file
            File.WriteAllText(newFileName,inputText[0]+"\n"); // writes the first line 
            for (int i = 1; i < inputText.Length; i++) //loops through all rows 
            {
                profitNumberStartsAt = inputText[i].LastIndexOf('\t'); //this could work
                try
                {
                    profits = new char[inputText[i].Length - profitNumberStartsAt]; //overflow
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"overflow occured: {inputText.Length}");
                    profits = new char[inputText[i].Length];
                }
                Console.Write("from inputText: ");
                for (int j = profitNumberStartsAt; j < inputText[i].Length; j++) //filling profits wich stors the number
                {
                    profits[j - profitNumberStartsAt] = inputText[i][j]; //profitsNumberStartsAt is not const
                    Console.Write(inputText[i][j]);
                }
                Console.Write("\nunedited: ");
                foreach (char profitsChar in profits)
                {
                    Console.Write(profitsChar);
                }
                Console.WriteLine();
                profits[profits.Length - 1] = ' '; //clears the '€' from the string 
                int findPoint = Array.IndexOf(profits, '.'); //getting rid of the dot in the number notation
                Console.WriteLine($"\tfindpoint = {findPoint}");
                if (findPoint == -1)
                {
                    Console.WriteLine("\tcouldn't find a point"); // the nomber error is related to this
                }
                else
                {
                    for (int j = findPoint; j < profits.Length - 1; j++)
                    {
                        profits[j] = profits[j + 1]; //index out of range excption
                    }
                }
                Console.Write("edited: ");
                for (int k = 0; k < profits.Length; k++)
                    Console.Write(profits[k]);
                Console.WriteLine();
                try
                {
                    dNumber = Convert.ToDouble( new String(profits));
                    Console.WriteLine($"worked, dNumber = {dNumber} i = {i}\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("error on converting to double");
                    Console.WriteLine($"dNumber = {dNumber}, i = {i}\n");
                }
                string output = inputText[i].Replace('\n', ' ');
                // nope i won't use Filestreams here, even tho it should be more efficient, becourse it's easier 
                File.AppendAllText(newFileName, output);
                if (dNumber >= 10000) // rating is A
                {
                    File.AppendAllText(newFileName, " -A\n");
                }
                else if (dNumber >= 1000) //rating is B
                {
                    File.AppendAllText(newFileName, " -B\n");
                }
                else if (dNumber < 1000) //rating is C
                {
                    File.AppendAllText(newFileName, " -C\n");
                }
            }
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}