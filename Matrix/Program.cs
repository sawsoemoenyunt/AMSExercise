using System;
public class Matrix
{
    public static void Main()
    {
        int rows, columns, number;

        Console.WriteLine("What is the matrix row count?");
        rows = int.Parse(Console.ReadLine());

        Console.WriteLine("What is the matrix column count?");
        columns = int.Parse(Console.ReadLine());

        System.Console.WriteLine("What is your number?");
        number = int.Parse(Console.ReadLine());

        int foundRow = 0;
        int foundColumn = 0;
        int numCounter = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if (number == numCounter)
                {
                    foundRow = row;
                    foundColumn = column;
                }
                numCounter++;
            }
        }

        System.Console.WriteLine("{0} is in row {1} and column {2}", number, foundRow, foundColumn);
    }
}