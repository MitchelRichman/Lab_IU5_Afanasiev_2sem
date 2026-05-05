////Упражнение 10.1 . Создать интерфейс ICipher, который определяет
////методы поддержки шифрования строк. В интерфейсе объявляются два метода
////encode() и decode(), которые используются для шифрования и дешифрования
////строк, соответственно.
////Создать класс ACipher, реализующий интерфейс ICipher. Класс шифрует
////строку посредством сдвига каждого символа на одну «алфавитную» позицию
////выше. Например, в результате такого сдвига буква А становится буквой Б.
////Создать класс BCipher, реализующий интерфейс ICipher. Класс шифрует
////строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на
////букву того же регистра, расположенную в алфавите на i-й позиции с конца
////алфавита. Например, буква В заменяется на букву Э.
////Написать программу, демонстрирующую функционирование классов.


//using System;
//using System.Text;

//// Интерфейс ICipher
//interface ICipher
//{
//    string Encode(string input);   // шифрование
//    string Decode(string input);   // дешифрование
//}

//// Класс ACipher: сдвиг на одну позицию вперёд
//class ACipher : ICipher
//{
//    // Шифрование: сдвиг каждого символа на +1
//    public string Encode(string input)
//    {
//        if (string.IsNullOrEmpty(input))
//            return input;

//        StringBuilder result = new StringBuilder();

//        foreach (char c in input)
//        {
//            result.Append(ShiftCharForward(c));
//        }

//        return result.ToString();
//    }

//    // Дешифрование: сдвиг каждого символа на -1
//    public string Decode(string input)
//    {
//        if (string.IsNullOrEmpty(input))
//            return input;

//        StringBuilder result = new StringBuilder();

//        foreach (char c in input)
//        {
//            result.Append(ShiftCharBackward(c));
//        }

//        return result.ToString();
//    }

//    // Сдвиг буквы вперёд на одну позицию
//    private char ShiftCharForward(char c)
//    {
//        // Русские буквы
//        if (c >= 'А' && c <= 'Я')
//        {
//            if (c == 'Я')
//                return 'А';
//            return (char)(c + 1);
//        }
//        if (c >= 'а' && c <= 'я')
//        {
//            if (c == 'я')
//                return 'а';
//            return (char)(c + 1);
//        }

//        // Английские буквы
//        if (c >= 'A' && c <= 'Z')
//        {
//            if (c == 'Z')
//                return 'A';
//            return (char)(c + 1);
//        }
//        if (c >= 'a' && c <= 'z')
//        {
//            if (c == 'z')
//                return 'a';
//            return (char)(c + 1);
//        }

//        // Не буквы возвращаем без изменений
//        return c;
//    }

//    // Сдвиг буквы назад на одну позицию
//    private char ShiftCharBackward(char c)
//    {
//        // Русские буквы
//        if (c >= 'А' && c <= 'Я')
//        {
//            if (c == 'А')
//                return 'Я';
//            return (char)(c - 1);
//        }
//        if (c >= 'а' && c <= 'я')
//        {
//            if (c == 'а')
//                return 'я';
//            return (char)(c - 1);
//        }

//        // Английские буквы
//        if (c >= 'A' && c <= 'Z')
//        {
//            if (c == 'A')
//                return 'Z';
//            return (char)(c - 1);
//        }
//        if (c >= 'a' && c <= 'z')
//        {
//            if (c == 'a')
//                return 'z';
//            return (char)(c - 1);
//        }

//        return c;
//    }
//}

//// Класс BCipher: зеркальная замена букв
//class BCipher : ICipher
//{
//    // Русский алфавит (33 буквы)
//    private const string RussianAlphabetLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
//    private const string RussianAlphabetUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

//    // Английский алфавит (26 букв)
//    private const string EnglishAlphabetLower = "abcdefghijklmnopqrstuvwxyz";
//    private const string EnglishAlphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

//    // Шифрование: замена на зеркальную букву
//    public string Encode(string input)
//    {
//        if (string.IsNullOrEmpty(input))
//            return input;

//        StringBuilder result = new StringBuilder();

//        foreach (char c in input)
//        {
//            result.Append(MirrorChar(c));
//        }

//        return result.ToString();
//    }

//    // Дешифрование: для зеркальной замены оно же (=шифрованию)
//    // Потому что если применить замену дважды, вернётся исходная буква
//    public string Decode(string input)
//    {
//        // Для зеркальной замены encode и decode одинаковы
//        return Encode(input);
//    }

//    // Зеркальная замена буквы
//    private char MirrorChar(char c)
//    {
//        // Русские строчные буквы
//        int index = RussianAlphabetLower.IndexOf(c);
//        if (index != -1)
//        {
//            int mirrorIndex = RussianAlphabetLower.Length - 1 - index;
//            return RussianAlphabetLower[mirrorIndex];
//        }

//        // Русские заглавные буквы
//        index = RussianAlphabetUpper.IndexOf(c);
//        if (index != -1)
//        {
//            int mirrorIndex = RussianAlphabetUpper.Length - 1 - index;
//            return RussianAlphabetUpper[mirrorIndex];
//        }

//        // Английские строчные буквы
//        index = EnglishAlphabetLower.IndexOf(c);
//        if (index != -1)
//        {
//            int mirrorIndex = EnglishAlphabetLower.Length - 1 - index;
//            return EnglishAlphabetLower[mirrorIndex];
//        }

//        // Английские заглавные буквы
//        index = EnglishAlphabetUpper.IndexOf(c);
//        if (index != -1)
//        {
//            int mirrorIndex = EnglishAlphabetUpper.Length - 1 - index;
//            return EnglishAlphabetUpper[mirrorIndex];
//        }

//        // Не буквы возвращаем без изменений
//        return c;
//    }
//}

//// Главная программа для демонстрации
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Демонстрация работы шифров ===\n");

//        // Создаём экземпляры классов
//        ICipher aCipher = new ACipher();
//        ICipher bCipher = new BCipher();

//        // Тестовые строки
//        string[] testStrings = {
//            "ПРИВЕТ",
//            "привет",
//            "Hello",
//            "hello",
//            "Абвгдеёжз",
//            "АтАс",
//            "C# Programming",
//            "Яблоко",
//            "Zebra"
//        };

//        // Демонстрация ACipher (сдвиг на 1)
//        Console.WriteLine("=== ACipher (сдвиг на 1 позицию) ===\n");
//        Console.WriteLine($"{"Исходная",20} | {"Зашифрованная",20} | {"Расшифрованная",20}");
//        Console.WriteLine(new string('-', 70));

//        foreach (string text in testStrings)
//        {
//            string encoded = aCipher.Encode(text);
//            string decoded = aCipher.Decode(encoded);
//            Console.WriteLine($"{text,20} | {encoded,20} | {decoded,20}");
//        }

//        Console.WriteLine("\n");
//        Console.WriteLine("=== BCipher (зеркальная замена) ===\n");
//        Console.WriteLine($"{"Исходная",20} | {"Зашифрованная",20} | {"Расшифрованная",20}");
//        Console.WriteLine(new string('-', 70));

//        foreach (string text in testStrings)
//        {
//            string encoded = bCipher.Encode(text);
//            string decoded = bCipher.Decode(encoded);
//            Console.WriteLine($"{text,20} | {encoded,20} | {decoded,20}");
//        }

//        // Дополнительная демонстрация для BCipher с пояснением
//        Console.WriteLine("\n\n=== Пояснение работы BCipher (русский алфавит) ===\n");

//        Console.WriteLine("Алфавит прямой:   А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я");
//        Console.WriteLine("Алфавит зеркальный:Я Ю Э Ь Ы Ъ Щ Ш Ч Ц Х Ф У Т С Р П О Н М Л К Й И З Ж Ё Е Д Г В Б А");

//        string demoText = "АБВГДЕЁЖЗ";
//        string demoEncoded = bCipher.Encode(demoText);
//        Console.WriteLine($"\nИсходная строка: {demoText}");
//        Console.WriteLine($"Зашифрованная:   {demoEncoded}");
//        Console.WriteLine($"Расшифрованная:   {bCipher.Decode(demoEncoded)}");

//        // Интерактивный режим
//        Console.WriteLine("\n\n=== Интерактивный режим ===\n");

//        while (true)
//        {
//            Console.Write("Выберите шифр (1 - ACipher, 2 - BCipher, 0 - выход): ");
//            string choice = Console.ReadLine();

//            if (choice == "0") break;

//            Console.Write("Введите строку для шифрования: ");
//            string input = Console.ReadLine();

//            if (string.IsNullOrEmpty(input)) continue;

//            if (choice == "1")
//            {
//                string encoded = aCipher.Encode(input);
//                string decoded = aCipher.Decode(encoded);
//                Console.WriteLine($"Зашифрованная: {encoded}");
//                Console.WriteLine($"Расшифрованная: {decoded}");
//            }
//            else if (choice == "2")
//            {
//                string encoded = bCipher.Encode(input);
//                string decoded = bCipher.Decode(encoded);
//                Console.WriteLine($"Зашифрованная: {encoded}");
//                Console.WriteLine($"Расшифрованная: {decoded}");
//            }
//            else
//            {
//                Console.WriteLine("Неверный выбор!");
//            }

//            Console.WriteLine();
//        }

//        Console.WriteLine("\nПрограмма завершена.");
//    }
//}