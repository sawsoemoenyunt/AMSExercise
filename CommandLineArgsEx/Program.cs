using System;

public class CommandLineArgs
{
    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            Console.WriteLine("Argument count is: {0}", args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Arg {0} is: {1}", i, args[i]);
            }
        }
        else
        {
            Console.WriteLine("Please enter at least one argument.");
        }
    }
}