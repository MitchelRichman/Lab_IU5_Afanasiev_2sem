////Домашнее задание 10.1 Создать класс Figure для работы с
////геометрическими фигурами. В качестве полей класса задаются цвет фигуры,
////состояние «видимое/невидимое». Реализовать операции: передвижение
////геометрической фигуры по горизонтали, по вертикали, изменение цвета, опрос
////состояния (видимый/невидимый). Метод вывода на экран должен выводить
////состояние всех полей объекта.
////Создать класс Point (точка) как потомок геометрической фигуры.
////Создать класс Circle (окружность) как потомок точки. В класс Circle добавить
////метод, который вычисляет площадь окружности. Создать класс Rectangle
////(прямоугольник) как потомок точки, реализовать метод вычисления площади
////прямоугольника.
////Точка, окружность, прямоугольник должны поддерживать методы
////передвижения по горизонтали и вертикали, изменения цвета.
////Подумать, какие методы можно объявить в интерфейсе, нужно ли
////объявлять абстрактный класс, какие методы и поля будут в абстрактном классе,
////какие методы будут виртуальными, какие перегруженными.

//using System;

//// ========== ИНТЕРФЕЙС ДЛЯ ПЕРЕДВИЖЕНИЯ ==========
//interface IMovable
//{
//    void MoveHorizontal(int dx);
//    void MoveVertical(int dy);
//}

//// ========== АБСТРАКТНЫЙ КЛАСС FIGURE ==========
//abstract class Figure : IMovable
//{
//    // Поля
//    protected string color;      // цвет фигуры
//    protected bool isVisible;    // видимость

//    // Конструкторы
//    public Figure()
//    {
//        color = "Белый";
//        isVisible = true;
//    }

//    public Figure(string color, bool isVisible)
//    {
//        this.color = color;
//        this.isVisible = isVisible;
//    }

//    // Методы для работы с цветом
//    public string GetColor()
//    {
//        return color;
//    }

//    public void SetColor(string color)
//    {
//        this.color = color;
//        Console.WriteLine($"  Цвет изменён на {color}");
//    }

//    // Методы для работы с видимостью
//    public bool IsVisible()
//    {
//        return isVisible;
//    }

//    public void SetVisible(bool isVisible)
//    {
//        this.isVisible = isVisible;
//        Console.WriteLine(isVisible ? "  Фигура стала видимой" : "  Фигура стала невидимой");
//    }

//    public void Show()
//    {
//        isVisible = true;
//        Console.WriteLine("  Фигура отображена");
//    }

//    public void Hide()
//    {
//        isVisible = false;
//        Console.WriteLine("  Фигура скрыта");
//    }

//    // Абстрактный метод для вычисления площади (должен быть реализован в потомках)
//    public abstract double GetArea();

//    // Виртуальный метод для вывода информации (может быть переопределён)
//    public virtual void DisplayInfo()
//    {
//        Console.WriteLine($"  Цвет: {color}");
//        Console.WriteLine($"  Видимость: {(isVisible ? "Видима" : "Невидима")}");
//        Console.WriteLine($"  Площадь: {GetArea():F2}");
//    }

//    // Абстрактный метод для передвижения (реализуется в потомках)
//    public abstract void MoveHorizontal(int dx);
//    public abstract void MoveVertical(int dy);
//}

//// ========== КЛАСС POINT (ТОЧКА) ==========
//class Point : Figure
//{
//    protected int x;  // координата X
//    protected int y;  // координата Y

//    // Конструкторы
//    public Point() : base()
//    {
//        x = 0;
//        y = 0;
//    }

//    public Point(int x, int y) : base()
//    {
//        this.x = x;
//        this.y = y;
//    }

//    public Point(int x, int y, string color, bool isVisible) : base(color, isVisible)
//    {
//        this.x = x;
//        this.y = y;
//    }

//    // Геттеры и сеттеры для координат
//    public int GetX() { return x; }
//    public int GetY() { return y; }
//    public void SetX(int x) { this.x = x; }
//    public void SetY(int y) { this.y = y; }

//    // Реализация передвижения
//    public override void MoveHorizontal(int dx)
//    {
//        x += dx;
//        Console.WriteLine($"  Точка перемещена по горизонтали на {dx}. Новая координата X = {x}");
//    }

//    public override void MoveVertical(int dy)
//    {
//        y += dy;
//        Console.WriteLine($"  Точка перемещена по вертикали на {dy}. Новая координата Y = {y}");
//    }

//    // Площадь точки = 0
//    public override double GetArea()
//    {
//        return 0;
//    }

//    // Вывод информации
//    public override void DisplayInfo()
//    {
//        Console.WriteLine("\n=== ТОЧКА ===");
//        base.DisplayInfo();
//        Console.WriteLine($"  Координаты: ({x}, {y})");
//    }
//}

//// ========== КЛАСС CIRCLE (ОКРУЖНОСТЬ) ==========
//class Circle : Point
//{
//    private int radius;  // радиус

//    // Конструкторы
//    public Circle() : base()
//    {
//        radius = 0;
//    }

//    public Circle(int x, int y, int radius) : base(x, y)
//    {
//        this.radius = radius;
//    }

//    public Circle(int x, int y, int radius, string color, bool isVisible) : base(x, y, color, isVisible)
//    {
//        this.radius = radius;
//    }

//    // Геттер и сеттер для радиуса
//    public int GetRadius() { return radius; }
//    public void SetRadius(int radius)
//    {
//        this.radius = radius;
//        Console.WriteLine($"  Радиус изменён на {radius}");
//    }

//    // Переопределяем передвижение (с дополнительным выводом)
//    public override void MoveHorizontal(int dx)
//    {
//        base.MoveHorizontal(dx);
//        Console.WriteLine($"  Окружность перемещена");
//    }

//    public override void MoveVertical(int dy)
//    {
//        base.MoveVertical(dy);
//        Console.WriteLine($"  Окружность перемещена");
//    }

//    // Вычисление площади окружности: π * R²
//    public override double GetArea()
//    {
//        return Math.PI * radius * radius;
//    }

//    // Вывод информации
//    public override void DisplayInfo()
//    {
//        Console.WriteLine("\n=== ОКРУЖНОСТЬ ===");
//        Console.WriteLine($"  Координаты центра: ({x}, {y})");
//        Console.WriteLine($"  Радиус: {radius}");
//        base.DisplayInfo();
//    }
//}

//// ========== КЛАСС RECTANGLE (ПРЯМОУГОЛЬНИК) ==========
//class Rectangle : Point
//{
//    private int width;   // ширина
//    private int height;  // высота

//    // Конструкторы
//    public Rectangle() : base()
//    {
//        width = 0;
//        height = 0;
//    }

//    public Rectangle(int x, int y, int width, int height) : base(x, y)
//    {
//        this.width = width;
//        this.height = height;
//    }

//    public Rectangle(int x, int y, int width, int height, string color, bool isVisible)
//        : base(x, y, color, isVisible)
//    {
//        this.width = width;
//        this.height = height;
//    }

//    // Геттеры и сеттеры
//    public int GetWidth() { return width; }
//    public int GetHeight() { return height; }
//    public void SetWidth(int width)
//    {
//        this.width = width;
//        Console.WriteLine($"  Ширина изменена на {width}");
//    }
//    public void SetHeight(int height)
//    {
//        this.height = height;
//        Console.WriteLine($"  Высота изменена на {height}");
//    }

//    // Переопределяем передвижение
//    public override void MoveHorizontal(int dx)
//    {
//        base.MoveHorizontal(dx);
//        Console.WriteLine($"  Прямоугольник перемещён");
//    }

//    public override void MoveVertical(int dy)
//    {
//        base.MoveVertical(dy);
//        Console.WriteLine($"  Прямоугольник перемещён");
//    }

//    // Вычисление площади прямоугольника: ширина * высота
//    public override double GetArea()
//    {
//        return width * height;
//    }

//    // Вывод информации
//    public override void DisplayInfo()
//    {
//        Console.WriteLine("\n=== ПРЯМОУГОЛЬНИК ===");
//        Console.WriteLine($"  Координаты левого верхнего угла: ({x}, {y})");
//        Console.WriteLine($"  Ширина: {width}, Высота: {height}");
//        base.DisplayInfo();
//    }
//}

//// ========== ГЛАВНАЯ ПРОГРАММА ==========
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Геометрические фигуры ===\n");
//        Console.WriteLine(new string('=', 60));

//        // 1. Демонстрация работы с точкой
//        Console.WriteLine("\n1. СОЗДАНИЕ ТОЧКИ");
//        Point point = new Point(5, 10, "Красный", true);
//        point.DisplayInfo();

//        Console.WriteLine("\n2. ОПЕРАЦИИ С ТОЧКОЙ");
//        point.MoveHorizontal(3);
//        point.MoveVertical(-2);
//        point.SetColor("Синий");
//        point.Hide();
//        point.DisplayInfo();

//        // 2. Демонстрация работы с окружностью
//        Console.WriteLine("\n" + new string('=', 60));
//        Console.WriteLine("\n3. СОЗДАНИЕ ОКРУЖНОСТИ");
//        Circle circle = new Circle(10, 20, 5, "Зелёный", true);
//        circle.DisplayInfo();

//        Console.WriteLine("\n4. ОПЕРАЦИИ С ОКРУЖНОСТЬЮ");
//        circle.MoveHorizontal(5);
//        circle.MoveVertical(3);
//        circle.SetRadius(8);
//        circle.SetColor("Жёлтый");
//        circle.Show();
//        circle.DisplayInfo();

//        // 3. Демонстрация работы с прямоугольником
//        Console.WriteLine("\n" + new string('=', 60));
//        Console.WriteLine("\n5. СОЗДАНИЕ ПРЯМОУГОЛЬНИКА");
//        Rectangle rect = new Rectangle(0, 0, 10, 20, "Фиолетовый", true);
//        rect.DisplayInfo();

//        Console.WriteLine("\n6. ОПЕРАЦИИ С ПРЯМОУГОЛЬНИКОМ");
//        rect.MoveHorizontal(2);
//        rect.MoveVertical(1);
//        rect.SetWidth(15);
//        rect.SetHeight(25);
//        rect.SetColor("Оранжевый");
//        rect.DisplayInfo();

//        // 4. Полиморфизм: работа с фигурами через базовый класс
//        Console.WriteLine("\n" + new string('=', 60));
//        Console.WriteLine("\n7. ПОЛИМОРФИЗМ (массив фигур)");

//        Figure[] figures = new Figure[]
//        {
//            new Point(1, 1, "Белый", true),
//            new Circle(5, 5, 3, "Чёрный", true),
//            new Rectangle(10, 10, 8, 6, "Серый", true)
//        };

//        foreach (Figure fig in figures)
//        {
//            fig.DisplayInfo();
//            Console.WriteLine();
//        }

//        // 5. Демонстрация интерфейса IMovable
//        Console.WriteLine(new string('=', 60));
//        Console.WriteLine("\n8. РАБОТА ЧЕРЕЗ ИНТЕРФЕЙС IMovable");

//        IMovable movablePoint = new Point(0, 0);
//        IMovable movableCircle = new Circle(0, 0, 5);

//        Console.WriteLine("Перемещаем точку через интерфейс:");
//        movablePoint.MoveHorizontal(10);

//        Console.WriteLine("\nПеремещаем окружность через интерфейс:");
//        movableCircle.MoveVertical(20);

//        Console.WriteLine("\n" + new string('=', 60));
//        Console.WriteLine("\nПрограмма завершена.");
//    }
//}