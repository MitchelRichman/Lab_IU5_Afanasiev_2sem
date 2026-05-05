//using System;
///*Домашнее задание 8.1 Работа со строками. Дан текстовый файл,
//содержащий ФИО и e-mail адрес. Разделителем между ФИО и адресом
//электронной почты является символ #:
//Иванов Иван Иванович # iviviv@mail.ru
//Петров Петр Петрович # petr@mail.ru
//Сформировать новый файл, содержащий список адресов электронной
//почты.
//Предусмотреть метод, выделяющий из строки адрес почты. Методу в
//57качестве параметра передается символьная строка s, e-mail возвращается в той
//же строке s:
//public void SearchMail (ref string s).*/
//using System;
//using System.IO;
//using System.Text;

//class EmailExtractor
//{
//    // Метод, выделяющий email из строки (по заданию: ref параметр)
//    public void SearchMail(ref string s)
//    {
//        // Ищем позицию символа #
//        int sharpIndex = s.IndexOf('#');

//        // Если # найден, берём всё, что после него
//        if (sharpIndex != -1)
//        {
//            // Вырезаем подстроку после # и удаляем пробелы
//            string email = s.Substring(sharpIndex + 1).Trim();

//            // Возвращаем email в той же переменной
//            s = email;
//        }
//        else
//        {
//            // Если # нет, возвращаем пустую строку
//            s = string.Empty;
//        }
//    }

//    // Альтернативный метод, возвращающий email (более удобный)
//    public string ExtractEmail(string line)
//    {
//        int sharpIndex = line.IndexOf('#');
//        if (sharpIndex != -1)
//        {
//            return line.Substring(sharpIndex + 1).Trim();
//        }
//        return string.Empty;
//    }

//    static void Main()
//    {
//        Console.WriteLine("=== Извлечение email-адресов из файла ===\n");

//        string inputFile = "contacts.txt";
//        string outputFile = "emails.txt";

//        // Проверяем существование входного файла
//        if (!File.Exists(inputFile))
//        {
//            Console.WriteLine($"Файл {inputFile} не найден!");
//            Console.WriteLine("Создаю пример файла...");
//            CreateSampleFile(inputFile);
//            Console.WriteLine($"Файл {inputFile} создан. Заполните его данными и запустите программу снова.");
//            Console.WriteLine("\nПример содержимого файла:");
//            Console.WriteLine("Иванов Иван Иванович # ivanov@mail.ru");
//            Console.WriteLine("Петров Петр Петрович # petrov@mail.ru");
//            return;
//        }

//        try
//        {
//            // Создаём экземпляр класса
//            EmailExtractor extractor = new EmailExtractor();

//            // Читаем все строки из файла
//            string[] lines = File.ReadAllLines(inputFile, Encoding.UTF8);

//            // Массив для хранения email-адресов
//            string[] emails = new string[lines.Length];

//            Console.WriteLine("Обработка строк:");
//            Console.WriteLine(new string('-', 50));

//            // Обрабатываем каждую строку
//            for (int i = 0; i < lines.Length; i++)
//            {
//                string originalLine = lines[i];

//                // Пропускаем пустые строки
//                if (string.IsNullOrWhiteSpace(originalLine))
//                {
//                    emails[i] = string.Empty;
//                    continue;
//                }

//                // Используем метод SearchMail с ref параметром
//                string email = originalLine;  // копируем строку
//                extractor.SearchMail(ref email);

//                emails[i] = email;

//                // Выводим результат обработки
//                Console.WriteLine($"Исходная: {originalLine}");
//                Console.WriteLine($"Email: {email}");
//                Console.WriteLine();
//            }

//            // Записываем email-адреса в новый файл (только непустые)
//            using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
//            {
//                foreach (string email in emails)
//                {
//                    if (!string.IsNullOrEmpty(email))
//                    {
//                        writer.WriteLine(email);
//                    }
//                }
//            }

//            Console.WriteLine(new string('-', 50));
//            Console.WriteLine($"Готово! Email-адреса сохранены в файл: {outputFile}");

//            // Показываем содержимое выходного файла
//            Console.WriteLine("\n--- Содержимое выходного файла ---");
//            string[] savedEmails = File.ReadAllLines(outputFile, Encoding.UTF8);
//            foreach (string email in savedEmails)
//            {
//                Console.WriteLine(email);
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Ошибка: {ex.Message}");
//        }

//        Console.WriteLine("\nНажмите любую клавишу для выхода...");
//        Console.ReadKey();
//    }

//    // Метод для создания примера файла
//    static void CreateSampleFile(string fileName)
//    {
//        string[] sampleLines = {
//            "Иванов Иван Иванович # ivanov@mail.ru",
//            "Петров Петр Петрович # petrov@mail.ru",
//            "Сидорова Анна Сергеевна # anna.sidorova@gmail.com",
//            "Козлов Дмитрий Алексеевич # d.kozlov@yandex.ru",
//            "Морозова Елена Владимировна # elena.m@inbox.ru",
//            "Соколов Андрей Николаевич # sok@bk.ru",
//            "Васильева Татьяна Петровна # t.vasilieva@mail.ru"
//        };

//        File.WriteAllLines(fileName, sampleLines, Encoding.UTF8);
//    }
//}