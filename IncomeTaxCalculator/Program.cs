using System;

class IncomeTax
{
    public static void Main()
    {
        int income, childrenCount;
        double totalTax;

        bool isValidIncome = false;
        bool isValidChildrencount = false;
        do
        {
            Console.Write("What is your total income: ");
            string incomeString = Console.ReadLine();
            bool isNumericIncome = int.TryParse(incomeString, out income);

            if (isNumericIncome)
            {
                if (income >= 0)
                {
                    isValidIncome = true;

                    do
                    {
                        Console.Write("How many children do you have: ");
                        string totalChildrenString = Console.ReadLine();
                        bool isNumericTotalChildren = int.TryParse(totalChildrenString, out childrenCount);

                        if (isNumericTotalChildren)
                        {
                            if (childrenCount >= 0)
                            {
                                isValidChildrencount = true;

                                //caculate tax
                                int deductedIncome = (income - 10000) - (childrenCount * 2000);
                                totalTax = deductedIncome * 0.02;

                                if (totalTax <= 0)
                                {
                                    Console.WriteLine("You owe no tax.");
                                }
                                else
                                {
                                    Console.WriteLine("You owe a total of ${0:F2} tax", totalTax);
                                }

                                System.Console.WriteLine("");
                                System.Console.WriteLine("");
                                System.Console.WriteLine(" Hit Enter to exit.");
                                _ = Console.Read();
                            }
                            else
                            {
                                isValidChildrencount = false;
                                Console.WriteLine("You must enter a positive number.");
                            }
                        }
                        else
                        {
                            isValidChildrencount = false;
                            Console.WriteLine("You must enter a valid number.");
                        }

                    } while (!isValidChildrencount);
                }
                else
                {
                    isValidIncome = false;
                    Console.WriteLine("Your income cannot be negative.");
                }

            }
            else
            {
                isValidIncome = false;
                Console.WriteLine("Enter your income as a whole-dollar figure.");
            }


        } while (!isValidIncome);
    }
}