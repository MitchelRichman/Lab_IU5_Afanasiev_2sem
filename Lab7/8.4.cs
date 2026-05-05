//using System;
///*Упражнение 8.4 Реализовать метод, который проверяет реализует ли
//входной параметр метода интерфейс System.IFormattable. Использовать
//оператор is и as. (Интерфейс IFormattable обеспечивает функциональные
//возможности форматирования значения объекта в строковое представление.)*/


//using System;

//class InterfaceChecker
//{
//    // Метод 1: проверка через оператор is
//    static void CheckWithIs(object obj)
//    {
//        Console.WriteLine("--- Проверка через оператор is ---");

//        if (obj is IFormattable)
//        {
//            Console.WriteLine($" Объект типа '{obj.GetType().Name}' реализует интерфейс IFormattable");

//            // Безопасное форматирование в зависимости от типа
//            string formattedValue = GetFormattedValue(obj);
//            Console.WriteLine($"   Форматированное представление: {formattedValue}");
//        }
//        else
//        {
//            Console.WriteLine($"❌ Объект типа '{obj?.GetType().Name ?? "null"}' НЕ реализует интерфейс IFormattable");
//        }
//        Console.WriteLine();
//    }

//    // Метод 2: проверка через оператор as
//    static void CheckWithAs(object obj)
//    {
//        Console.WriteLine("--- Проверка через оператор as ---");

//        IFormattable formattable = obj as IFormattable;

//        if (formattable != null)
//        {
//            Console.WriteLine($"Объект типа '{obj.GetType().Name}' реализует интерфейс IFormattable");

//            // Безопасное форматирование в зависимости от типа
//            string formattedValue = GetFormattedValue(obj);
//            Console.WriteLine($"Форматированное представление: {formattedValue}");
//        }
//        else
//        {
//            Console.WriteLine($"Объект типа '{obj?.GetType().Name ?? "null"}' НЕ реализует интерфейс IFormattable");
//        }
//        Console.WriteLine();
//    }

//    // Вспомогательный метод для безопасного форматирования
//    static string GetFormattedValue(object obj)
//    {
//        if (obj == null) return "null";

//        Type type = obj.GetType();

//        // Для целых чисел используем D (десятичный формат)
//        if (type == typeof(int) || type == typeof(long) ||
//            type == typeof(short) || type == typeof(byte))
//        {
//            return ((IFormattable)obj).ToString("D", null);
//        }
//        // Для чисел с плавающей точкой используем F (фиксированный)
//        else if (type == typeof(double) || type == typeof(float) || type == typeof(decimal))
//        {
//            return ((IFormattable)obj).ToString("F2", null);
//        }
//        // Для DateTime используем G (общий формат)
//        else if (type == typeof(DateTime))
//        {
//            return ((IFormattable)obj).ToString("G", null);
//        }
//        // Для строк используем G
//        else if (type == typeof(string))
//        {
//            return (string)obj;
//        }
//        // Для всех остальных используем G
//        else
//        {
//            try
//            {
//                return ((IFormattable)obj).ToString("G", null);
//            }
//            catch
//            {
//                return obj.ToString();
//            }
//        }
//    }

//    // Универсальный метод, возвращающий bool
//    static bool IsIFormattable(object obj)
//    {
//        return obj is IFormattable;
//    }

//    static void Main()
//    {
//        Console.WriteLine("=== Проверка реализации интерфейса IFormattable ===\n");

//        // Создаём разные объекты для проверки
//        object[] testObjects = {
//            123,                    // int (реализует IFormattable)
//            3.14159,                // double (реализует IFormattable)
//            DateTime.Now,           // DateTime (реализует IFormattable)
//            "Hello, World!",        // string (реализует IFormattable)
//            DayOfWeek.Monday,       // enum (реализует IFormattable)
//            new object(),           // object (НЕ реализует IFormattable)
//            null,                   // null (особый случай)
//            new Random(),           // Random (НЕ реализует IFormattable)
//            255L                    // long (реализует IFormattable)
//        };

//        // Проверяем каждый объект
//        for (int i = 0; i < testObjects.Length; i++)
//        {
//            Console.WriteLine($"Тест #{i + 1}: {testObjects[i]?.GetType().Name ?? "null"}");
//            Console.WriteLine($"Значение: {testObjects[i] ?? "null"}");
//            Console.WriteLine(new string('-', 50));

//            // Проверяем обоими способами
//            CheckWithIs(testObjects[i]);
//            CheckWithAs(testObjects[i]);

//            Console.WriteLine(new string('=', 60));
//            Console.WriteLine();
//        }

//        // Использование метода, возвращающего bool
//        Console.WriteLine("=== Использование метода IsIFormattable ===\n");

//        int number = 42;
//        string text = "Hello";
//        object plainObject = new object();

//        Console.WriteLine($"int 42 реализует IFormattable: {IsIFormattable(number)}");
//        Console.WriteLine($"string 'Hello' реализует IFormattable: {IsIFormattable(text)}");
//        Console.WriteLine($"object реализует IFormattable: {IsIFormattable(plainObject)}");

//        // Демонстрация форматирования
//        Console.WriteLine("\n=== Демонстрация форматирования ===\n");

//        // Для чисел с плавающей точкой
//        double pi = 3.14159265359;
//        IFormattable formattablePi = pi as IFormattable;

//        if (formattablePi != null)
//        {
//            Console.WriteLine($"Число: {pi}");
//            Console.WriteLine($"Формат F2: {formattablePi.ToString("F2", null)}");
//            Console.WriteLine($"Формат F5: {formattablePi.ToString("F5", null)}");
//            Console.WriteLine($"Формат C (валюта): {formattablePi.ToString("C", null)}");
//            Console.WriteLine($"Формат E (экспонента): {formattablePi.ToString("E", null)}");
//        }

//        // Для целых чисел
//        int integer = 255;
//        IFormattable formattableInt = integer as IFormattable;

//        if (formattableInt != null)
//        {
//            Console.WriteLine($"\nЦелое число: {integer}");
//            Console.WriteLine($"Формат D (десятичный): {formattableInt.ToString("D", null)}");
//            Console.WriteLine($"Формат X (шестнадцатеричный): {formattableInt.ToString("X", null)}");
//            Console.WriteLine($"Формат X4 (шестнадцатеричный, 4 символа): {formattableInt.ToString("X4", null)}");
//        }

//        // Для DateTime
//        DateTime now = DateTime.Now;
//        IFormattable formattableDate = now as IFormattable;

//        if (formattableDate != null)
//        {
//            Console.WriteLine($"\nТекущая дата: {now}");
//            Console.WriteLine($"Формат d (короткая дата): {formattableDate.ToString("d", null)}");
//            Console.WriteLine($"Формат D (длинная дата): {formattableDate.ToString("D", null)}");
//            Console.WriteLine($"Формат t (короткое время): {formattableDate.ToString("t", null)}");
//            Console.WriteLine($"Формат T (длинное время): {formattableDate.ToString("T", null)}");
//            Console.WriteLine($"Формат F (полная дата/время): {formattableDate.ToString("F", null)}");
//        }

//        Console.WriteLine("\nНажмите любую клавишу для выхода...");
//        Console.ReadKey();
//    }
//}