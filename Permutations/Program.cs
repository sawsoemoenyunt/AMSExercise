using System;

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

    private static void Generate(int k, string[] a)
    {
        if (k == 1)
        {
            PrintArray(a);
        }
        else
        {
            // Generate permutations with kth unaltered
            // Initially k == length(A)
            Generate(k - 1, a);

            //// Generate permutations for kth swapped with each k-1 initial
            for (int i = 0; i < k - 1; i++)
            {
                string temp1, temp2;

                if (k % 2 == 0)
                {
                    temp1 = a[i];
                    temp2 = a[k - 1];
                    a[i] = temp2;
                    a[k - 1] = temp1;
                }
                else
                {
                    temp1 = a[0];
                    temp2 = a[k - 1];
                    a[0] = temp2;
                    a[k - 1] = temp1;
                }
                Generate(k - 1, a);
            }
        }
    }

    public static void Main(string[] args)
    {
        Generate(args.Length, args);
    }
}

