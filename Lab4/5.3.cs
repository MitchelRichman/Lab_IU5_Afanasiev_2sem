////Упражнение 5.2 Упражнение 5.3 Написать метод вычисления факториала числа,
////результат вычислений передавать в выходном параметре. Если метод отработал
////успешно, то вернуть значение true; если в процессе вычисления возникло
////переполнение, то вернуть значение false. Для отслеживания переполнения
////значения использовать блок checked
//using System;

//class Program
//{
//    static void Main()
//    {
//        long result;

//        if (Factorial(5, out result))
//            Console.WriteLine($"5! = {result}");
//        else
//            Console.WriteLine("Ошибка");

//        if (Factorial(20, out result))
//            Console.WriteLine($"20! = {result}");
//        else
//            Console.WriteLine("Ошибка");

//        if (Factorial(25, out result))
//            Console.WriteLine($"25! = {result}");
//        else
//            Console.WriteLine("Ошибка");
//    }

//    static bool Factorial(int n, out long result)
//    {
//        result = 1;

//        try
//        {
//            checked
//            {
//                for (int i = 2; i <= n; i++)
//                    result *= i;
//            }
//            return true;
//        }
//        catch
//        {
//            result = 0;
//            return false;
//        }
//    }
//}

