using System;
using System.Text.RegularExpressions;

namespace TestRegex
{

    public class MainClass
    {
        public static void Main(string[] args)
        {
            //string[] partNumbers = { "1298-673-4192", "A08Z-931-468A",
            //                  "_A90-123-129X", "12345-KKA-1230",
            //                  "0919-2893-1256" };
            //string pattern = @"^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$";
            //foreach (string partNumber in partNumbers)
            //    Console.WriteLine("{0} {1} a valid part number.",
            //                      partNumber,
            //                      Regex.IsMatch(partNumber, pattern) ? "is" : "is not");
            string dna = "ACTG*GTAC*CA*";
            Console.WriteLine(dna);
            string dnaPattern = @"[A][C][T][G](\w*)[G][T][A][C](\w*)[C][A]";

            string customPattern = GenerateRegexPattern(dna);
            Console.WriteLine(customPattern);

            string[] dnaList = { "ACTGGTACCAA", "ACTGGTACCA", "ACTGCGTACCA", "ACTGGTACGCA", "ACTGAGTACTCA", "ACTGACGTACTGTGCCA", "ACTGACCGTACTGCA" };

            foreach (string ddna in dnaList)
            {
                Console.WriteLine("{0} is {1}", ddna, Regex.IsMatch(ddna, customPattern));
            }
        }

        public static string GenerateRegexPattern(string text)
        {
            char[] characters = text.ToCharArray();
            string pattern = @"";

            foreach (char character in characters)
            {
                if (character.Equals('*'))
                {
                    pattern += "(\\w*)";
                }
                else
                {
                    pattern += "[" + character + "]";
                }
            }

            if (characters[characters.Length - 1].Equals('*'))
            {
                pattern = "^" + pattern;
            }
            else
            {
                pattern = "^" + pattern + "$";
            }
            return pattern;
        }
    }

}


// The example displays the following output:
//       1298-673-4192 is a valid part number.
//       A08Z-931-468A is a valid part number.
//       _A90-123-129X is not a valid part number.
//       12345-KKA-1230 is not a valid part number.
//       0919-2893-1256 is not a valid part number.
