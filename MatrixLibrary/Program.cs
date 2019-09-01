using System;

class MatrixLibrary
{
    public static void Main()
    {
        int[,] matrix = new int[,]
        {
            {7, 2, 19},
            {10, 19, 15},
            {15, 8, 7},
            {4, 8, 2},
            {4, 8, 2},
        };

        int[,] matrix2 = new int[,]
        {
            {5, 18, 11, 11},
            {6, 16, 5, 8},
            {17, 14, 8, 3},
        };

        int[,] resmatrix = MatrixMultiply(matrix, matrix2);
        string res = MatrixToString(resmatrix);
        System.Console.WriteLine(res);
    }

    //change matrix to string method
    public static string MatrixToString(int[,] multiArr)
    {
        string text = "";

        for (int i = 0; i < multiArr.GetLength(0); i++)
        {
            string rowText = "";
            for (int j = 0; j < multiArr.GetLength(1); j++)
            {
                rowText = rowText + string.Format("{0,-4}", multiArr[i, j]);
            }
            text = text + rowText + "\n";
        }

        return text;
    }

    //matrix multiply method
    public static int[,] MatrixMultiply(int[,] a, int[,] b)
    {

        //get new matrix size
        int rowSize = a.GetLength(0);
        int columSize = b.GetLength(1);
        int[,] c = new int[rowSize, columSize];

        for (int i = 0; i < c.GetLength(0); i++)
        {
            for (int j = 0; j < c.GetLength(1); j++)
            {
                for (int k = 0; k < b.GetLength(0); k++)
                {
                    c[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return c;

    }

}