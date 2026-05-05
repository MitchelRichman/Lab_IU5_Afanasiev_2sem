//using System;

///*Упражнение 7.2 Изменить класс счет в банке из упражнения 7.1 таким
//образом, чтобы номер счета генерировался сам и был уникальным. Для этого
//надо создать в классе статическую переменную и метод, который увеличивает
//значение этого переменной*/


//// Перечислимый тип из упражнения 3.1
//enum AccountType
//{
//    Current,   // Текущий счёт
//    Savings    // Сберегательный счёт
//}

//// Класс банковского счёта
//class BankAccount
//{
//    // Статическая переменная (общая для всех объектов класса)
//    private static long lastAccountNumber = 0;

//    // Закрытые поля
//    private long accountNumber;      // номер счета
//    private decimal balance;         // баланс
//    private AccountType accountType; // тип счета

//    // Статический метод для генерации нового номера
//    private static long GenerateNextNumber()
//    {
//        // Увеличиваем значение и возвращаем новый номер
//        lastAccountNumber++;
//        return lastAccountNumber;
//    }

//    // Конструктор (вызывается при создании объекта)
//    public BankAccount()
//    {
//        // Автоматически генерируем уникальный номер счета
//        accountNumber = GenerateNextNumber();

//        // Остальные поля инициализируем значениями по умолчанию
//        balance = 0;
//        accountType = AccountType.Current;
//    }

//    // Конструктор с возможностью задать баланс
//    public BankAccount(decimal initialBalance)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = initialBalance;
//        accountType = AccountType.Current;
//    }

//    // Конструктор с возможностью задать тип счета
//    public BankAccount(AccountType type)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = 0;
//        accountType = type;
//    }

//    // Конструктор с возможностью задать баланс и тип счета
//    public BankAccount(decimal initialBalance, AccountType type)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = initialBalance;
//        accountType = type;
//    }

//    // Методы для чтения полей (геттеры)
//    public long GetAccountNumber()
//    {
//        return accountNumber;
//    }

//    public decimal GetBalance()
//    {
//        return balance;
//    }

//    public AccountType GetAccountType()
//    {
//        return accountType;
//    }

//    // Методы для изменения полей (сеттеры) - для баланса и типа
//    public void SetBalance(decimal amount)
//    {
//        balance = amount;
//    }

//    public void SetAccountType(AccountType type)
//    {
//        accountType = type;
//    }

//    // Метод для вывода информации о счете
//    public void PrintAccountInfo()
//    {
//        Console.WriteLine("Информация о банковском счете:");
//        Console.WriteLine($"Номер счета: {accountNumber}");
//        Console.WriteLine($"Баланс: {balance} руб.");
//        Console.WriteLine($"Тип счета: {accountType}");
//    }
//}

//// Главный класс программы
//class Program
//{
//    static void Main()
//    {
//        // Создаём несколько объектов - номера будут генерироваться автоматически
//        Console.WriteLine("=== Создание счетов с автоматической генерацией номеров ===\n");

//        BankAccount account1 = new BankAccount();
//        account1.SetBalance(10000m);
//        account1.SetAccountType(AccountType.Current);
//        account1.PrintAccountInfo();

//        Console.WriteLine();

//        BankAccount account2 = new BankAccount(25000m, AccountType.Savings);
//        account2.PrintAccountInfo();

//        Console.WriteLine();

//        BankAccount account3 = new BankAccount();
//        account3.SetBalance(5000m);
//        account3.SetAccountType(AccountType.Current);
//        account3.PrintAccountInfo();

//        Console.WriteLine();

//        BankAccount account4 = new BankAccount(AccountType.Savings);
//        account4.SetBalance(30000m);
//        account4.PrintAccountInfo();

//        // Демонстрация уникальности номеров
//        Console.WriteLine("\n=== Проверка уникальности номеров ===");
//        Console.WriteLine($"Номер первого счета: {account1.GetAccountNumber()}");
//        Console.WriteLine($"Номер второго счета: {account2.GetAccountNumber()}");
//        Console.WriteLine($"Номер третьего счета: {account3.GetAccountNumber()}");
//        Console.WriteLine($"Номер четвертого счета: {account4.GetAccountNumber()}");
//    }
//}

