//using System;
///*Упражнение 8.3 Написать программу, которая спрашивает у
//пользователя имя файла. Если такого файла не существует, то программа
//выдает пользователю сообщение и заканчивает работу, иначе в выходной файл
//записывается содержимое исходного файла, но заглавными буквами.*/


//using System;
//using System.IO;  // Для работы с файлами

//class FileProcessor
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Программа обработки файлов ===\n");

//        // Запрашиваем имя файла у пользователя
//        Console.Write("Введите имя файла: ");
//        string inputFileName = Console.ReadLine();

//        // Проверяем, существует ли файл
//        if (!File.Exists(inputFileName))
//        {
//            Console.WriteLine($"\nОшибка: Файл '{inputFileName}' не существует!");
//            Console.WriteLine("Программа завершает работу.");
//            return;  // Выходим из программы
//        }

//        try
//        {
//            // Читаем всё содержимое файла
//            string content = File.ReadAllText(inputFileName);

//            // Преобразуем в заглавные буквы
//            string upperContent = content.ToUpper();

//            // Формируем имя выходного файла
//            string outputFileName = GetOutputFileName(inputFileName);

//            // Записываем результат в новый файл
//            File.WriteAllText(outputFileName, upperContent);

//            // Выводим информацию об успешном завершении
//            Console.WriteLine($"\nФайл успешно обработан!");
//            Console.WriteLine($"Исходный файл: {inputFileName}");
//            Console.WriteLine($"Выходной файл: {outputFileName}");
//            Console.WriteLine($"Размер файла: {content.Length} символов");

//            // Показываем первые несколько строк исходного и результата
//            ShowPreview(content, upperContent);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"\nПроизошла ошибка: {ex.Message}");
//        }

//        Console.WriteLine("\nНажмите любую клавишу для выхода...");
//        Console.ReadKey();
//    }

//    // Метод для формирования имени выходного файла
//    static string GetOutputFileName(string inputFileName)
//    {
//        // Получаем имя файла без расширения и расширение
//        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputFileName);
//        string extension = Path.GetExtension(inputFileName);
//        string directory = Path.GetDirectoryName(inputFileName);

//        // Если файл в текущей папке, directory может быть пустым
//        if (string.IsNullOrEmpty(directory))
//        {
//            return $"{fileNameWithoutExt}_UPPER{extension}";
//        }
//        else
//        {
//            return Path.Combine(directory, $"{fileNameWithoutExt}_UPPER{extension}");
//        }
//    }

//    // Метод для показа содержимого
//    static void ShowPreview(string original, string upper)
//    {
//        Console.WriteLine("\n--- Превью обработки ---");

//        // Показываем первые 100 символов исходного файла
//        string originalPreview = original.Length > 100
//            ? original.Substring(0, 100) + "..."
//            : original;

//        string upperPreview = upper.Length > 100
//            ? upper.Substring(0, 100) + "..."
//            : upper;

//        Console.WriteLine("Исходный текст (начало):");
//        Console.WriteLine(originalPreview);
//        Console.WriteLine("\nТекст заглавными буквами (начало):");
//        Console.WriteLine(upperPreview);
//    }
//}