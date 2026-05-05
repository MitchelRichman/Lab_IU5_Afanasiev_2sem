//using System;
///*Упражнение 8.2 Реализовать метод, который в качестве входного
//параметра принимает строку string, возвращает строку типа string, буквы в
//которой идут в обратном порядке. Протестировать метод*/
//using System;

//class StringReverser
//{
//    // Метод для переворота строки (вариант 1: через массив символов)
//    static string ReverseString1(string input)
//    {
//        if (string.IsNullOrEmpty(input))
//            return input;

//        char[] chars = input.ToCharArray();
//        Array.Reverse(chars);
//        return new string(chars);
//    }

//    // Метод для переворота строки (вариант 2: ручной переворот через цикл)
//    static string ReverseString2(string input)
//    {
//        if (string.IsNullOrEmpty(input))
//            return input;

//        char[] reversed = new char[input.Length];
//        for (int i = 0; i < input.Length; i++)
//        {
//            reversed[i] = input[input.Length - 1 - i];
//        }
//        return new string(reversed);
//    }

//    // Метод для переворота строки (вариант 3: через цикл и конкатенацию)
//    static string ReverseString3(string input)
//    {
//        if (string.IsNullOrEmpty(input))
//            return input;

//        string result = "";
//        for (int i = input.Length - 1; i >= 0; i--)
//        {
//            result += input[i];
//        }
//        return result;
//    }

//    static void Main()
//    {
//        Console.WriteLine("=== Переворот строки ===\n");

//        // Тестовые примеры
//        string[] testStrings = {
//            "Hello, World!",
//            "C# Programming",
//            "123456789",
//            "А роза упала на лапу Азора",  // палиндром
//            "a",
//            "",
//            "   пробелы   ",
//            "Madam, I'm Adam"
//        };

//        foreach (string test in testStrings)
//        {
//            Console.WriteLine($"Исходная:    \"{test}\"");
//            Console.WriteLine($"Перевёрнутая: \"{ReverseString1(test)}\"");
//            Console.WriteLine();
//        }

//        // Дополнительное тестирование: сравнение всех трёх методов
//        Console.WriteLine("=== Сравнение всех трёх методов ===\n");
//        string original = "Тестирование";
//        Console.WriteLine($"Исходная: {original}");
//        Console.WriteLine($"Метод 1 (Array.Reverse): {ReverseString1(original)}");
//        Console.WriteLine($"Метод 2 (ручной цикл):   {ReverseString2(original)}");
//        Console.WriteLine($"Метод 3 (конкатенация):  {ReverseString3(original)}");

//        // Проверка, что все методы дают одинаковый результат
//        Console.WriteLine("\n=== Проверка идентичности результатов ===\n");
//        bool allEqual = ReverseString1(original) == ReverseString2(original) &&
//                        ReverseString2(original) == ReverseString3(original);
//        Console.WriteLine($"Все три метода дают одинаковый результат: {allEqual}");

//        // Интерактивный режим
//        Console.WriteLine("\n=== Интерактивный режим ===\n");
//        Console.Write("Введите строку для переворота (или нажмите Enter для выхода): ");

//        string userInput = Console.ReadLine();
//        while (!string.IsNullOrEmpty(userInput))
//        {
//            Console.WriteLine($"Результат: \"{ReverseString1(userInput)}\"");
//            Console.Write("\nВведите следующую строку: ");
//            userInput = Console.ReadLine();
//        }

//        Console.WriteLine("\nПрограмма завершена.");
//    }
//}