using System;

namespace RandomArray
{
    public class RandomArrayNoDuplicates
    {
        static Random rng = new Random();

        public static void Main()
        {
            int[] arr = ArrayWithNoDuplicates(10);
            DisplayArray(arr);
        }

        public static int[] ArrayWithNoDuplicates(int size)
        {
            int[] randomNumbers = new int[size];

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                int uniqueNumber = GenerateUniqueNumber(randomNumbers, i);
                randomNumbers[i] = uniqueNumber;
            }

            return randomNumbers;
        }

        public static int GenerateUniqueNumber(int[] numbers, int index)
        {

            int result = 0;

            bool isUnique = false;
            do
            {
                int randomNum = rng.Next(1, 45);

                for (int i = 0; i <= index; i++)
                {
                    if (numbers[i] == randomNum)
                    {
                        isUnique = false;
                        break;
                    }
                    else
                    {
                        if (i == index)
                        {
                            isUnique = true;
                            result = randomNum;
                        }
                    }
                }

            } while (!isUnique);

            return result;
        }

        public static void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }
        }
    }
}