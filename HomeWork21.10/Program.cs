using System;

class MatrixOperations
{
    static void Main()
    {
        // Get the dimensions of the first two matrices from the user
        Console.Write("Enter the number of rows for the first matrix: ");
        int rows1 = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns for the first matrix: ");
        int cols1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of rows for the second matrix: ");
        int rows2 = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns for the second matrix: ");
        int cols2 = int.Parse(Console.ReadLine());

        // Operators to choose matrix operation
        Console.WriteLine("Choose a matrix operation:");
        Console.WriteLine("1. Multiply matrix by a number");
        Console.WriteLine("2. Add matrices");
        Console.WriteLine("3. Multiply matrices");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                // Operator to multiply matrix by a number
                Console.Write("Enter the number to multiply: ");
                double multiplier = double.Parse(Console.ReadLine());
                double[,] matrix1 = InputMatrix(rows1, cols1);
                double[,] resultMatrix1 = MultiplyMatrixByNumber(matrix1, multiplier);
                Console.WriteLine("Result:");
                PrintMatrix(resultMatrix1);
                break;

            case 2:
                // Operator to add matrices
                double[,] matrixA = InputMatrix(rows1, cols1);
                double[,] matrixB = InputMatrix(rows1, cols1);
                double[,] resultMatrix2 = AddMatrices(matrixA, matrixB);
                Console.WriteLine("Result:");
                PrintMatrix(resultMatrix2);
                break;

            case 3:
                // Operator to multiply matrices
                double[,] matrixC = InputMatrix(rows1, cols1);
                double[,] matrixD = InputMatrix(rows2, cols2);
                double[,] resultMatrix3 = MultiplyMatrices(matrixC, matrixD);
                Console.WriteLine("Result:");
                PrintMatrix(resultMatrix3);
                break;

            default:
                Console.WriteLine("Invalid operation choice.");
                break;
        }
    }

    // Function to input a matrix
    static double[,] InputMatrix(int rows, int cols)
    {
        double[,] matrix = new double[rows, cols];
        Console.WriteLine("Enter matrix elements:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Element [{i}, {j}]: ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }

        return matrix;
    }

    // Function to multiply a matrix by a number
    static double[,] MultiplyMatrixByNumber(double[,] matrix, double number)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * number;
            }
        }

        return result;
    }

    // Function to add two matrices
    static double[,] AddMatrices(double[,] matrixA, double[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int cols = matrixA.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }

        return result;
    }

    // Function to multiply two matrices
    static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = matrixB.GetLength(0);
        int colsB = matrixB.GetLength(1);

        if (colsA != rowsB)
        {
            Console.WriteLine("Matrix multiplication is not possible. The number of columns in the first matrix should be equal to the number of rows in the second matrix.");
            return null;
        }

        double[,] result = new double[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                for (int k = 0; k < colsA; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return result;
    }

    // Function to print a matrix
    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}