//using System;
///*Домашнее задание 7.1 Реализовать класс для описания здания
//(уникальный номер здания, высота, этажность, количество квартир, подъездов).
//Поля сделать закрытыми, предусмотреть методы для заполнения полей и
//получения значений полей для печати. Добавить методы вычисления высоты
//этажа, количества квартир в подъезде, количества квартир на этаже и т.д.
//Предусмотреть возможность, чтобы уникальный номер здания генерировался
//программно. Для этого в классе предусмотреть статическое поле, которое бы
//хранило последний использованный номер здания, и предусмотреть метод,
//который увеличивал бы значение этого поля.*/


//class Building
//{
//    // Статические поля (общие для всех объектов)
//    private static int lastBuildingNumber = 0;  // последний использованный номер

//    // Закрытые поля экземпляра
//    private int buildingNumber;      // уникальный номер здания
//    private double height;           // высота здания (метры)
//    private int floors;              // количество этажей
//    private int apartments;          // количество квартир
//    private int entrances;           // количество подъездов

//    // Статический метод для генерации следующего номера
//    private static int GenerateNextNumber()
//    {
//        lastBuildingNumber++;
//        return lastBuildingNumber;
//    }

//    // Конструктор по умолчанию
//    public Building()
//    {
//        buildingNumber = GenerateNextNumber();
//        height = 0;
//        floors = 0;
//        apartments = 0;
//        entrances = 0;
//    }

//    // Конструктор с параметрами
//    public Building(double height, int floors, int apartments, int entrances)
//    {
//        buildingNumber = GenerateNextNumber();
//        this.height = height;
//        this.floors = floors;
//        this.apartments = apartments;
//        this.entrances = entrances;
//    }

//    // === МЕТОДЫ ДЛЯ ЗАПОЛНЕНИЯ ПОЛЕЙ (СЕТТЕРЫ) ===
//    public void SetHeight(double height)
//    {
//        if (height > 0)
//            this.height = height;
//        else
//            Console.WriteLine("Ошибка: высота должна быть больше 0");
//    }

//    public void SetFloors(int floors)
//    {
//        if (floors > 0)
//            this.floors = floors;
//        else
//            Console.WriteLine("Ошибка: количество этажей должно быть больше 0");
//    }

//    public void SetApartments(int apartments)
//    {
//        if (apartments > 0)
//            this.apartments = apartments;
//        else
//            Console.WriteLine("Ошибка: количество квартир должно быть больше 0");
//    }

//    public void SetEntrances(int entrances)
//    {
//        if (entrances > 0)
//            this.entrances = entrances;
//        else
//            Console.WriteLine("Ошибка: количество подъездов должно быть больше 0");
//    }

//    // === МЕТОДЫ ДЛЯ ПОЛУЧЕНИЯ ЗНАЧЕНИЙ (ГЕТТЕРЫ) ===
//    public int GetBuildingNumber() { return buildingNumber; }
//    public double GetHeight() { return height; }
//    public int GetFloors() { return floors; }
//    public int GetApartments() { return apartments; }
//    public int GetEntrances() { return entrances; }

//    // === МЕТОДЫ ВЫЧИСЛЕНИЙ ===

//    // Высота одного этажа
//    public double GetFloorHeight()
//    {
//        if (floors == 0)
//            return 0;
//        return height / floors;
//    }

//    // Количество квартир в одном подъезде
//    public int GetApartmentsPerEntrance()
//    {
//        if (entrances == 0)
//            return 0;
//        return apartments / entrances;
//    }

//    // Количество квартир на одном этаже
//    public int GetApartmentsPerFloor()
//    {
//        if (floors == 0)
//            return 0;
//        return apartments / floors;
//    }

//    // Количество квартир на этаже в одном подъезде
//    public int GetApartmentsPerFloorPerEntrance()
//    {
//        if (floors == 0 || entrances == 0)
//            return 0;
//        return apartments / (floors * entrances);
//    }

//    // Метод для вывода всей информации о здании
//    public void PrintBuildingInfo()
//    {
//        Console.WriteLine("═══════════════════════════════════════════════════════════");
//        Console.WriteLine($"Здание #{buildingNumber}");
//        Console.WriteLine($"Высота: {height} м");
//        Console.WriteLine($"Этажей: {floors}");
//        Console.WriteLine($"Квартир: {apartments}");
//        Console.WriteLine($"Подъездов: {entrances}");
//        Console.WriteLine("───────────────────────────────────────────────────────────");
//        Console.WriteLine($"Высота этажа: {GetFloorHeight():F2} м");
//        Console.WriteLine($"Квартир в подъезде: {GetApartmentsPerEntrance()}");
//        Console.WriteLine($"Квартир на этаже: {GetApartmentsPerFloor()}");
//        Console.WriteLine($"Квартир на этаже в подъезде: {GetApartmentsPerFloorPerEntrance()}");
//        Console.WriteLine("═══════════════════════════════════════════════════════════");
//    }
//}

//// Главный класс программы
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Система управления зданиями ===\n");

//        // Способ 1: создание через конструктор с параметрами
//        Building building1 = new Building(45.5, 15, 120, 4);
//        building1.PrintBuildingInfo();

//        Console.WriteLine();

//        // Способ 2: создание через конструктор по умолчанию и заполнение через сеттеры
//        Building building2 = new Building();
//        building2.SetHeight(28.0);
//        building2.SetFloors(9);
//        building2.SetApartments(72);
//        building2.SetEntrances(3);
//        building2.PrintBuildingInfo();

//        Console.WriteLine();

//        // Способ 3: ещё одно здание для проверки уникальности номеров
//        Building building3 = new Building(60.0, 20, 200, 5);
//        building3.PrintBuildingInfo();

//        // Демонстрация уникальности номеров
//        Console.WriteLine("\n=== Проверка уникальности номеров зданий ===");
//        Console.WriteLine($"Номер первого здания: {building1.GetBuildingNumber()}");
//        Console.WriteLine($"Номер второго здания: {building2.GetBuildingNumber()}");
//        Console.WriteLine($"Номер третьего здания: {building3.GetBuildingNumber()}");

//        // Пример работы с отдельными методами
//        Console.WriteLine("\n=== Пример работы с отдельными методами ===");
//        Console.WriteLine($"Высота этажа здания #1: {building1.GetFloorHeight():F2} м");
//        Console.WriteLine($"Квартир в подъезде здания #2: {building2.GetApartmentsPerEntrance()}");
//        Console.WriteLine($"Квартир на этаже здания #3: {building3.GetApartmentsPerFloor()}");
//    }
//}