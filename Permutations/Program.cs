using System;

namespace Permutations
{
    public class Permutations
    {
        // Helper method for outputting an array.
        private static void PrintArray(string[] array)
        {
            foreach (string element in array)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        // Helper method for invoking Generate.
        private static void Generate(int index, string[] arr)
        {
            if (index == 1)
            {
                PrintArray(arr);
            }
            else
            {
                // Generate permutations with kth unaltered
                // Initially k == length(A)
                
                if (index == arr.Length)
                {
                    Generate(index - 1, arr);

                    // Generate permutations for kth swapped with each k-1 initial
                    for (int i = 0; i < index - 1; i++)
                    {
                        // Swap choice dependent on parity of k (even or odd)
                        if (index % 2 == 0)
                        {
                            //even
                            arr[i] = arr[index - 1];
                            arr[index - 1] = arr[i];
                        }
                        else
                        {
                            //odd
                            string temp = arr[0];
                            arr[0] = arr[index - 1];
                            arr[index - 1] = temp;
                        }
                        Generate(index - 1, arr);
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            string[] arr = { "qaz", "wsx", "edc" };
            Generate(2, arr);
        }
    }
}
