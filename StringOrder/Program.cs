using System;

public class StringOrder
{
    enum Order { Precedes = -1, Equals = 0, Follows = 1 }

    public static void Main()
    {
        String a, b;

        System.Console.WriteLine("What is name A?");
        a = Console.ReadLine();

        System.Console.WriteLine("What is name B?");
        b = Console.ReadLine();

        a = a.Remove(0, 6);
        b = b.Remove(0, 6);
        Order result = (Order)a.CompareTo(b);

        System.Console.WriteLine("{0} {2} {1}", a, b, result);
    }
}