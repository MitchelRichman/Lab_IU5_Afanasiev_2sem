////Домашнее задание 9.1 В класс Song (из домашнего задания 8.2)
////добавить следующие конструкторы:
////1) параметры конструктора – название и автор песни, указатель на
////предыдущую песню инициализировать null.
////2) параметры конструктора – название, автор песни, предыдущая песня.
////В методе Main создать объект mySong. Возникнет ли ошибка при
////инициализации объекта mySong следующим образом: Song mySong = new
////Song(); ?
////Исправьте ошибку, создав необходимый конструктор


//using System;
//using System.Collections.Generic;

//class Song
//{
//    // Закрытые поля
//    private string name;      // название песни
//    private string author;    // автор песни
//    private Song prev;        // связь с предыдущей песней в списке

//    // ========== КОНСТРУКТОРЫ ==========

//    // 1. Конструктор по умолчанию (НЕОБХОДИМ ДЛЯ Song mySong = new Song())
//    //    Инициализирует поля значениями по умолчанию
//    public Song()
//    {
//        name = "";
//        author = "";
//        prev = null;
//        Console.WriteLine("Создана пустая песня (конструктор по умолчанию)");
//    }

//    // 2. Конструктор: название и автор, prev = null
//    public Song(string name, string author)
//    {
//        this.name = name;
//        this.author = author;
//        this.prev = null;
//        Console.WriteLine($"Создана песня: {name} - {author} (без ссылки на предыдущую)");
//    }

//    // 3. Конструктор: название, автор, предыдущая песня
//    public Song(string name, string author, Song prev)
//    {
//        this.name = name;
//        this.author = author;
//        this.prev = prev;
//        Console.WriteLine($"Создана песня: {name} - {author} (с ссылкой на предыдущую)");
//    }

//    // ========== МЕТОДЫ ДЛЯ ЗАПОЛНЕНИЯ ПОЛЕЙ (сеттеры) ==========
//    public void SetName(string name)
//    {
//        this.name = name;
//    }

//    public void SetAuthor(string author)
//    {
//        this.author = author;
//    }

//    public void SetPrev(Song prev)
//    {
//        this.prev = prev;
//    }

//    // ========== МЕТОДЫ ДЛЯ ПОЛУЧЕНИЯ ЗНАЧЕНИЙ (геттеры) ==========
//    public string GetName()
//    {
//        return name;
//    }

//    public string GetAuthor()
//    {
//        return author;
//    }

//    public Song GetPrev()
//    {
//        return prev;
//    }

//    // Метод для получения строки "Название - Автор"
//    public string Title()
//    {
//        return $"{name} - {author}";
//    }

//    // Переопределённый метод ToString()
//    public override string ToString()
//    {
//        if (prev != null)
//        {
//            return $"Песня: {name}, Исполнитель: {author}, Предыдущая: {prev.Title()}";
//        }
//        return $"Песня: {name}, Исполнитель: {author}";
//    }

//    // Переопределённый метод сравнения
//    public override bool Equals(object d)
//    {
//        if (d == null) return false;
//        if (d is Song other)
//        {
//            return this.name == other.name && this.author == other.author;
//        }
//        return false;
//    }

//    public override int GetHashCode()
//    {
//        return (name?.GetHashCode() ?? 0) ^ (author?.GetHashCode() ?? 0);
//    }

//    // Перегрузка операторов == и !=
//    public static bool operator ==(Song a, Song b)
//    {
//        if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
//        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
//        return a.Equals(b);
//    }

//    public static bool operator !=(Song a, Song b)
//    {
//        return !(a == b);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Демонстрация конструкторов класса Song ===\n");

//        // ========== ТЕСТИРУЕМ Song mySong = new Song() ==========
//        Console.WriteLine("1. Вызов конструктора по умолчанию (new Song()):");
//        Song mySong = new Song();  // ✅ БОЛЬШЕ НЕТ ОШИБКИ!
//        Console.WriteLine($"   Результат: {mySong.Title()}");
//        Console.WriteLine($"   ToString(): {mySong}");
//        Console.WriteLine();

//        // Заполняем поля через сеттеры
//        mySong.SetName("Bohemian Rhapsody");
//        mySong.SetAuthor("Queen");
//        Console.WriteLine("   После заполнения полей:");
//        Console.WriteLine($"   {mySong.Title()}");
//        Console.WriteLine();

//        // 2. Конструктор с названием и автором (prev = null)
//        Console.WriteLine("2. Конструктор с названием и автором (new Song(\"Imagine\", \"John Lennon\")):");
//        Song song2 = new Song("Imagine", "John Lennon");
//        Console.WriteLine($"   {song2.Title()}");
//        Console.WriteLine($"   Предыдущая песня: {song2.GetPrev()}");
//        Console.WriteLine();

//        // 3. Конструктор с названием, автором и предыдущей песней
//        Console.WriteLine("3. Конструктор с названием, автором и предыдущей песней:");
//        Song song3 = new Song("Hotel California", "Eagles", song2);
//        Console.WriteLine($"   {song3.Title()}");
//        Console.WriteLine($"   Предыдущая песня: {song3.GetPrev()?.Title() ?? "нет"}");
//        Console.WriteLine();

//        // Создаём полноценный список песен
//        Console.WriteLine("\n=== Создание плейлиста ===\n");

//        Song song1 = new Song("Bohemian Rhapsody", "Queen");
//        Song song4 = new Song("Stairway to Heaven", "Led Zeppelin", song3);
//        Song song5 = new Song("Back in Black", "AC/DC", song4);

//        // Выводим весь плейлист с помощью цикла по ссылкам prev
//        Console.WriteLine("Плейлист (с конца к началу):");
//        Song current = song5;
//        int position = 5;

//        while (current != null)
//        {
//            Console.WriteLine($"  [{position}] {current.Title()}");
//            current = current.GetPrev();
//            position--;
//        }

//        Console.WriteLine();

//        // Демонстрация сравнения песен
//        Console.WriteLine("=== Сравнение песен ===\n");

//        Song sameAsSong1 = new Song("Bohemian Rhapsody", "Queen");

//        Console.WriteLine($"song1: {song1.Title()}");
//        Console.WriteLine($"sameAsSong1: {sameAsSong1.Title()}");
//        Console.WriteLine($"song1 == sameAsSong1: {song1 == sameAsSong1}");
//        Console.WriteLine();

//        Console.WriteLine($"song1: {song1.Title()}");
//        Console.WriteLine($"song2: {song2.Title()}");
//        Console.WriteLine($"song1 == song2: {song1 == song2}");

//        Console.WriteLine("\nНажмите любую клавишу для выхода...");
//        Console.ReadKey();
//    }
//}