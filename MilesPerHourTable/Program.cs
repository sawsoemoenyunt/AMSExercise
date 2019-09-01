using System;

class MilesPerHourTable
{
    public static void Main()
    {
        bool isQuit = false;
        int number;
        double MileInKM = 0.62137;
        do
        {
            System.Console.Write("Enter row count or quit(q): ");
            string userInputString = Console.ReadLine();
            bool isNumericNumber = int.TryParse(userInputString, out number);

            if (isNumericNumber)
            {
                System.Console.WriteLine("MPH\tKPH");

                int mph = 15;
                double kph = 24.14;

                for (int i = 0; i < number; i++)
                {
                    System.Console.WriteLine("{0}\t{1:F2}", mph, kph);
                    mph += 10;
                    kph = mph / MileInKM;
                }
                isQuit = false;
            }
            else
            {
                if (userInputString.Equals("q"))
                {
                    isQuit = true;
                }
            }

        } while (!isQuit);
    }
}