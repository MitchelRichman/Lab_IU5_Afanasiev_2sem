////Упражнение 5.2 Написать метод, который меняет местами значения
////двух передаваемых параметров. Параметры передавать по ссылке.
////Протестировать метод
//using System.Diagnostics.CodeAnalysis;
//using System.Security.Cryptography;

//class Program
//{
//    static void twoChange(ref int a1, ref int a2)
//    {
//        a1 += a2;
//        a2 = a1 - a2;
//        a1 = a1 - a2;

//    }
//    public static void Main()
//    {

//        Console.WriteLine("Enter 2 number:");
//        int a1 = Convert.ToInt32(Console.ReadLine());
//        int a2 = Convert.ToInt32(Console.ReadLine());


//        twoChange(ref a1, ref a2);

//        Console.WriteLine("\n  {0}  {1} \n", a1, a2);
//    }
//}

