using System;

namespace CompoundInterestCalculator
{
    public class CompoundCalculator
    {
        const int EXIT = 0;
        const int CALCULATE_DAILY = 1;
        const int CALCULATE_QUARTERLY = 2;
        const int CALCULATE_VARIABLE = 3;
        const int NUM_OPTIONS = 3;

        public static void Main()
        {
            int menuOption;
            WelcomeMessage();
            do
            {
                DisplayMenu();
                menuOption = ReadOption();

                if (menuOption != EXIT)
                {
                    double finalAmount = CalculateInterest(menuOption);
                    OutputResult(finalAmount);
                }
            } while (menuOption != EXIT);

            ExitProgram();
        } // end Main

        // Fill in the appropriate modifier and return type (_ _) in the method declaration
        public static void WelcomeMessage()
        {
            Console.WriteLine("\n\n\tCompound Interest Calculator\n");
        } // end WelcomeMessage

        // Fill in the appropriate modifier and return type (_ _) in the method declaration
        public static void ExitProgram()
        {
            Console.Write("\n\nPress enter to exit.");
            Console.ReadLine();
        } // end ExitProgram

        static void DisplayMenu()
        {
            string menu = "\n\n1) Calculate final amount after interest (compounded daily)"
                        + "\n2) Calculate final amount after interest (compounded quarterly)"
                        + "\n3) Calculate final amount after interest (define number of times compounded yearly)"
                        + "\n\nEnter your option(1-3 or 0 to exit): ";

            Console.Write(menu);
        } // end DisplayMenu

        public static void OutputResult(double finalAmount)
        {
            // Display the message "The final amount of money plus interest is: $(amount)"
            // The amount should display as currency, with two decimal places, e.g. $10,000.00
            System.Console.WriteLine("The final amount of money pluse interest is: {0}", finalAmount.ToString("C"));
        } // end OutputResult

        static int ReadOption()
        {
            string choice;
            int option;
            bool okayChoice;

            do
            {
                choice = Console.ReadLine();
                okayChoice = int.TryParse(choice, out option);
                if (!okayChoice || option < 0 || option > NUM_OPTIONS)
                {
                    okayChoice = false;
                    Console.WriteLine("You did not enter a correct option.\n\n Please try again");
                    DisplayMenu();
                }
            } while (!okayChoice);

            return option;
        } // end ReadOption

        public static double CalculateInterest(int menuOption)
        {
            // (For this exercise, we will assume the user is inputting correct input.)
            double principal;
            double interestRate;
            int numYears;
            double finalAmount;

            Console.Write("Enter the principal amount: ");
            principal = Double.Parse(Console.ReadLine());

            Console.Write("Enter the interest rate: ");
            interestRate = Double.Parse(Console.ReadLine());

            Console.Write("Enter the number of years that interest is accumulated for: ");
            numYears = Int32.Parse(Console.ReadLine());

            if (menuOption == CALCULATE_DAILY || menuOption == CALCULATE_QUARTERLY)
            {
                if (menuOption == CALCULATE_DAILY)
                {
                    // Call the appropriate CalculateCompoundInterest method

                    finalAmount = CalculateCompoundInterest(principal, interestRate, numYears);
                }
                else
                {
                    // Call the appropriate CalculateCompoundInterest method
                    finalAmount = CalculateCompoundInterest(principal, interestRate, numYears, 4);
                }
            }
            else
            {
                Console.Write("Enter the number of times the interest is compounded yearly: ");
                int numTimesCompounded = Int32.Parse(Console.ReadLine());
                // Call the appropriate CalculateCompoundInterest method
                finalAmount = CalculateCompoundInterest(principal, interestRate, numYears, numTimesCompounded);
            }

            Console.WriteLine();
            // return the amount calculated by the compound interest method
            return finalAmount;
        } // End CalculateInterest

        // Declare and implement the method CalculateCompoundInterest whose parameters are the principal, interest rate, and number of years (in that order)- make sure it is public!
        // For the declaration select an appropriate modifier, return type, and types for the parameters
        // This version assumes the interest is compounded daily (365 times a year)
        public static double CalculateCompoundInterest(double p, double r, int y)
        {
            double result;
            result = p * Math.Pow(1 + r / 365, y * 365);
            return result;
        }

        // Declare and implement the method CalculateCompoundInterest whose parameters are the principal, interest rate, number of years, and number of times compounded yearly - make sure it is public!
        // For the declaration  select an appropriate modifier, return type, and types for the parameters
        // This version allows the number of times compounded yearly to be specified.
        public static double CalculateCompoundInterest(double p, double r, int y, int t)
        {
            double result;
            result = p * Math.Pow(1 + r / t, y * t);
            return result;
        }

    }//end class
}//end namespace