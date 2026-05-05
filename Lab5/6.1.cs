//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

///*Упражнение 6.1 Написать программу, которая вычисляет число гласных
//и согласных букв в файле. Имя файла передавать как аргумент в функцию Main.
//Содержимое текстового файла заносится в массив символов. Количество
//гласных и согласных букв определяется проходом по массиву. Предусмотреть
//метод, входным параметром которого является массив символов. Метод
//вычисляет количество гласных и согласных букв.*/
//class Program
//{
//    static void Main(string[] args)
//    {
//        // 1. Проверяем, передан ли аргумент с именем файла
//        if (args.Length == 0)
//        {
//            Console.WriteLine("Укажите имя файла как аргумент командной строки.");
//            return;
//        }

//        string fileName = args[0];

//        // 2. Проверяем, существует ли файл
//        if (!File.Exists(fileName))
//        {
//            Console.WriteLine($"Файл {fileName} не найден.");
//            return;
//        }

//        // 3. Читаем весь файл в строку, затем преобразуем в массив символов
//        string content = File.ReadAllText(fileName);
//        char[] symbols = content.ToCharArray();

//        // 4. Вызываем метод для подсчёта
//        CountVowelsAndConsonants(symbols, out int vowels, out int consonants);

//        // 5. Выводим результат
//        Console.WriteLine($"Гласных букв: {vowels}");
//        Console.WriteLine($"Согласных букв: {consonants}");
//    }

//    static void CountVowelsAndConsonants(char[] chars, out int vowels, out int consonants)
//    {
//        vowels = 0;
//        consonants = 0;

//        // Определяем гласные буквы (русские + английские, включая 'ё')
//        string vowelsRu = "аеёиоуыэюя";
//        string vowelsEn = "aeiouy";
//        string allVowels = vowelsRu + vowelsRu.ToUpper() + vowelsEn + vowelsEn.ToUpper();

//        foreach (char c in chars)
//        {
//            // Проверяем, является ли символ буквой (русской или латинской)
//            if (char.IsLetter(c))
//            {
//                // Если буква гласная
//                if (allVowels.Contains(char.ToLower(c)))
//                    vowels++;
//                else
//                    consonants++;
//            }
//        }
//    }
//}