//using System;
///*Упражнение 6.2 Написать программу, реализующую умножению двух
//матриц.В программе предусмотреть два метода: метод печати матрицы, метод
//умножения матриц (на вход две матрицы, возвращаемое значение – матрица)*/
//class MatrixMultiplier
//{
//    // Метод для печати матрицы3
//    static void PrintMatrix(int[,] matrix)
//    {
//        int rows = matrix.GetLength(0);
//        int cols = matrix.GetLength(1);
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                Console.Write(matrix[i, j] + "\t");
//            }
//            Console.WriteLine();
//        }
//    }

//    // Метод умножения двух матриц
//    static int[,] MultiplyMatrices(int[,] a, int[,] b)
//    {
//        int rowsA = a.GetLength(0);
//        int colsA = a.GetLength(1);
//        int rowsB = b.GetLength(0);
//        int colsB = b.GetLength(1);

//        // Проверка: число столбцов A должно равняться числу строк B
//        if (colsA != rowsB)
//        {
//            throw new ArgumentException("Невозможно умножить матрицы: число столбцов первой не равно числу строк второй.");
//        }

//        // Результирующая матрица размера rowsA x colsB
//        int[,] result = new int[rowsA, colsB];

//        // Умножение: result[i,j] = сумма по k (a[i,k] * b[k,j])
//        for (int i = 0; i < rowsA; i++)
//        {
//            for (int j = 0; j < colsB; j++)
//            {
//                int sum = 0;
//                for (int k = 0; k < colsA; k++)  // или k < rowsB
//                {
//                    sum += a[i, k] * b[k, j];
//                }
//                result[i, j] = sum;
//            }
//        }
//        return result;
//    }

//    static void Main()
//    {
//        try
//        {




//            // Ввод первой матрицы
//            Console.WriteLine("Введите размеры первой матрицы (строки и столбцы):");
//            Console.Write("Строки: ");
//            int rows1 = int.Parse(Console.ReadLine());
//            Console.Write("Столбцы: ");
//            int cols1 = int.Parse(Console.ReadLine());

//            int[,] matrix1 = new int[rows1, cols1];
//            Console.WriteLine("Введите элементы первой матрицы построчно:");
//            for (int i = 0; i < rows1; i++)
//            {
//                for (int j = 0; j < cols1; j++)
//                {
//                    Console.Write($"matrix1[{i},{j}] = ");
//                    matrix1[i, j] = int.Parse(Console.ReadLine());
//                }
//            }

//            // Ввод второй матрицы
//            Console.WriteLine("Введите размеры второй матрицы (строки и столбцы):");
//            Console.Write("Строки: ");
//            int rows2 = int.Parse(Console.ReadLine());
//            Console.Write("Столбцы: ");
//            int cols2 = int.Parse(Console.ReadLine());

//            int[,] matrix2 = new int[rows2, cols2];
//            Console.WriteLine("Введите элементы второй матрицы построчно:");
//            for (int i = 0; i < rows2; i++)
//            {
//                for (int j = 0; j < cols2; j++)
//                {
//                    Console.Write($"matrix2[{i},{j}] = ");
//                    matrix2[i, j] = int.Parse(Console.ReadLine());
//                }
//            }

//            // Печать введённых матриц
//            Console.WriteLine("\nПервая матрица:");
//            PrintMatrix(matrix1);
//            Console.WriteLine("Вторая матрица:");
//            PrintMatrix(matrix2);

//            // Умножение
//            int[,] product = MultiplyMatrices(matrix1, matrix2);

//            // Печать результата
//            Console.WriteLine("Результат умножения:");
//            PrintMatrix(product);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Ошибка: {ex.Message}");
//        }
//    }
//}