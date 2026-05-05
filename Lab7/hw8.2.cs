////Домашнее задание 8.2 Список песен. В методе Main создать список из
////четырех песен. В цикле вывести информацию о каждой песне. Сравнить между
////собой первую и вторую песню в списке.
////Песня представляет собой класс с методами для заполнения каждого из
////полей, методом вывода данных о песне на печать, методом, который сравнивает
////между собой два объекта:
////class Song
////{
////    string name; //название песни
////    string author; //автор песни
////    Song prev; //связь с предыдущей песней в списке
////               //метод для заполнения поля name
////               //метод для заполнения поля author
////               //метод для заполнения поля prev
////               //метод для печати названия песни и ее исполнителя
////    public string Title() {… /*возвращ название+исполнитель*/ …}
////    //метод, который сравнивает между собой два объекта-песни:
////    public bool override Equals(object d) {…}
////}
//using System;
//using System.Collections.Generic;

//class Song
//{
//    // Закрытые поля
//    private string name;      // название песни
//    private string author;    // автор песни
//    private Song prev;        // связь с предыдущей песней в списке

//    // Конструкторы
//    public Song()
//    {
//        name = "";
//        author = "";
//        prev = null;
//    }

//    public Song(string name, string author)
//    {
//        this.name = name;
//        this.author = author;
//        this.prev = null;
//    }

//    public Song(string name, string author, Song prev)
//    {
//        this.name = name;
//        this.author = author;
//        this.prev = prev;
//    }

//    // Методы для заполнения полей
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

//    // Методы для получения значений
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

//    // Метод для печати названия песни и её исполнителя
//    public string Title()
//    {
//        return $"{name} - {author}";
//    }

//    // Переопределённый метод ToString()
//    public override string ToString()
//    {
//        return $"Песня: {name}, Исполнитель: {author}";
//    }

//    // Переопределённый метод Equals для сравнения песен
//    public override bool Equals(object d)
//    {
//        // Проверка на null
//        if (d == null)
//            return false;

//        // Проверка, что объект того же типа
//        if (d is Song other)
//        {
//            // Сравниваем название и автора
//            return this.name == other.name && this.author == other.author;
//        }

//        return false;
//    }

//    // Переопределяем GetHashCode (рекомендуется при переопределении Equals)
//    public override int GetHashCode()
//    {
//        return (name?.GetHashCode() ?? 0) ^ (author?.GetHashCode() ?? 0);
//    }

//    // Перегрузка оператора ==
//    public static bool operator ==(Song a, Song b)
//    {
//        // Если оба null, то они равны
//        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
//            return true;

//        // Если один из них null, то они не равны
//        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
//            return false;

//        // Сравниваем через Equals
//        return a.Equals(b);
//    }

//    // Перегрузка оператора !=
//    public static bool operator !=(Song a, Song b)
//    {
//        return !(a == b);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Список песен ===\n");

//        // Создаём список из четырёх песен
//        List<Song> myPlaylist = new List<Song>();

//        // Способ 1: через конструктор
//        Song song1 = new Song("Bohemian Rhapsody", "Queen");
//        myPlaylist.Add(song1);

//        // Способ 2: через конструктор с указанием предыдущей песни
//        Song song2 = new Song("Imagine", "John Lennon", song1);
//        myPlaylist.Add(song2);

//        // Способ 3: через конструктор по умолчанию + сеттеры
//        Song song3 = new Song();
//        song3.SetName("Hotel California");
//        song3.SetAuthor("Eagles");
//        song3.SetPrev(song2);
//        myPlaylist.Add(song3);

//        // Способ 4: через конструктор с параметрами
//        Song song4 = new Song("Stairway to Heaven", "Led Zeppelin", song3);
//        myPlaylist.Add(song4);

//        // Выводим информацию о каждой песне в цикле
//        Console.WriteLine("=== Информация о всех песнях в списке ===\n");

//        for (int i = 0; i < myPlaylist.Count; i++)
//        {
//            Console.WriteLine($"Песня #{i + 1}:");
//            Console.WriteLine($"  {myPlaylist[i].Title()}");
//            Console.WriteLine($"  Полная информация: {myPlaylist[i].ToString()}");

//            // Выводим информацию о предыдущей песне, если она есть
//            if (myPlaylist[i].GetPrev() != null)
//            {
//                Console.WriteLine($"  Предыдущая песня: {myPlaylist[i].GetPrev().Title()}");
//            }
//            else
//            {
//                Console.WriteLine("  Предыдущая песня: нет");
//            }
//            Console.WriteLine();
//        }

//        // Сравниваем первую и вторую песню
//        Console.WriteLine("=== Сравнение песен ===\n");

//        Song firstSong = myPlaylist[0];
//        Song secondSong = myPlaylist[1];

//        Console.WriteLine($"Первая песня: {firstSong.Title()}");
//        Console.WriteLine($"Вторая песня: {secondSong.Title()}");
//        Console.WriteLine();

//        // Сравнение через переопределённый метод Equals
//        if (firstSong.Equals(secondSong))
//        {
//            Console.WriteLine("Результат сравнения (Equals): Песни ОДИНАКОВЫЕ");
//        }
//        else
//        {
//            Console.WriteLine("Результат сравнения (Equals): Песни РАЗНЫЕ");
//        }

//        // Сравнение через перегруженный оператор ==
//        if (firstSong == secondSong)
//        {
//            Console.WriteLine("Результат сравнения (==): Песни ОДИНАКОВЫЕ");
//        }
//        else
//        {
//            Console.WriteLine("Результат сравнения (==): Песни РАЗНЫЕ");
//        }

//        // Дополнительная демонстрация: создаём песню, идентичную первой
//        Console.WriteLine("\n=== Дополнительная проверка: создаём песню, идентичную первой ===\n");

//        Song song1Copy = new Song("Bohemian Rhapsody", "Queen");
//        Console.WriteLine($"Оригинал: {song1.Title()}");
//        Console.WriteLine($"Копия: {song1Copy.Title()}");

//        if (song1.Equals(song1Copy))
//        {
//            Console.WriteLine("Результат: Песни ОДИНАКОВЫЕ (по названию и автору)");
//        }
//        else
//        {
//            Console.WriteLine("Результат: Песни РАЗНЫЕ");
//        }

//        // Демонстрация работы со связями (prev)
//        Console.WriteLine("\n=== Демонстрация цепи из песен (через prev) ===\n");

//        Song current = song4;  // начинаем с последней песни
//        int position = 4;

//        while (current != null)
//        {
//            Console.WriteLine($"Позиция {position}: {current.Title()}");
//            current = current.GetPrev();
//            position--;
//        }

//        Console.WriteLine("\nНажмите любую клавишу для выхода...");
//        Console.ReadKey();
//    }
//}