using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Search
{
    class Program
    {


        static void Main(string[] args)
        {

            const string Start_Message = "\n\tWelcome to Linear Search Demonstration\n"
                                        + "\n The array contains the following 9 words:\n\n";

            string[] words = {"the", "quick", "brown", "fox",
                              "jumps", "over", "the", "lazy", "dog"};

            int location;

            OutputMessage(Start_Message);
            DisplayArray(words);

            location = LinearSearch(words, "the");
            OutputSearchResult(location, "the");

            location = LinearSearch(words, "able");
            OutputSearchResult(location, "able");


            location = LinearSearch(words, "over");
            OutputSearchResult(location, "over");

            location = LinearSearch(words, "zebra");
            OutputSearchResult(location, "zebra");

            location = LinearSearch(words, "dog");
            OutputSearchResult(location, "dog");

            ExitProgram();

        } //end Main

        /// <summary>
        ///  Linear search of "words" for the "word" 
        /// </summary>
        /// <param name="words">list of words to be searched</param>
        /// <param name="word">the word being searched for</param>
        /// <returns> position of "word" in "words" if it is there
        ///             otherwise returns -1    </returns>
        public static int LinearSearch(string[] words, string word)
        {

            int position = 0;

            while ((position < words.Length) && (words[position] != word))
            {
                position++;
            }

            if (position < words.Length)
            {
                return position; //found the record, return the result
            }
            else
            {
                return -1; //not found
            }

        } //end LinearSearch


        /// <summary>
        /// Displays the elements of the array "words"
        /// </summary>
        /// <param name="words">array to be displayed</param>
        static void DisplayArray(string[] words)
        {

            foreach (string element in words)
            {
                OutputMessage("\t" + element + "\n");
            }
            Console.WriteLine();

        }//end DisplayArray

        /// <summary>
        /// Displays the outcome of the linear search
        /// </summary>
        /// <param name="position">either the position of "word" if it was found
        ///                         or -1 if "word" was not found</param>
        /// <param name="word"></param>
        static void OutputSearchResult(int position, string word)
        {
            string continueMessage = "\nPress any key to continue:";

            if (position < 0)
            {
                Console.WriteLine("the word \"{0}\" not found in the list\n ", word);
            }
            else
            {
                Console.WriteLine("the word \"{0}\" found in position {1} in the list\n", word, position);
            }

            OutputMessage(continueMessage);
            Console.ReadKey();

        } //end OutputSearchResult

        /// <summary>
        /// Outputs the string "s"
        /// </summary>
        /// <param name="s">String to be output</param>
        static void OutputMessage(string s)
        {

            Console.Write(s);
        }// end OutPutMessage

        static void ExitProgram()
        {
            OutputMessage("\n\nPress any key to exit program: ");
            Console.ReadKey();
        }//end ExitProgram

    }//end class
}