using System;

public class HelloWorldV2
{
    public static void Main()
    {
        String name;

        System.Console.Write("Please enter your name:  ");
        name = Console.ReadLine();

        System.Console.WriteLine("");

        System.Console.WriteLine("Hello {0}, and welcome to CAB201", name);
        System.Console.WriteLine("Press enter to exit");
        Console.Read();
    }
}