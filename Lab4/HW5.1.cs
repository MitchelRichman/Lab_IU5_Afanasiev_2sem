////Домашнее задание 5.1 Написать метод, который вычисляет НОД двух
////натуральных чисел (алгоритм Евклида). Написать метод с тем же именем,
////который вычисляет НОД трех натуральных чисел.

//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine(GCD(48, 18));
//        Console.WriteLine(GCD(1071, 462));
//        Console.WriteLine(GCD(17, 19));

//        Console.WriteLine(GCD(48, 18, 30));
//        Console.WriteLine(GCD(1071, 462, 84));
//    }

//    static int GCD(int a, int b)
//    {
//        while (b != 0)
//        {
//            int temp = b;
//            b = a % b;
//            a = temp;
//        }
//        return a;
//    }

//    static int GCD(int a, int b, int c)
//    {
//        return GCD(GCD(a, b), c);
//    }
//}
