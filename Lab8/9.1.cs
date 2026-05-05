////Упражнение 9.1 В классе банковский счет, созданном в предыдущих
////упражнениях, удалить методы заполнения полей. Вместо этих методов создать
////конструкторы. Переопределить конструктор по умолчанию, создать
////конструктор для заполнения поля баланс, конструктор для заполнения поля тип
////банковского счета, конструктор для заполнения баланса и типа банковского
////счета. Каждый конструктор должен вызывать метод, генерирующий номер
////счета
//using System;

//enum AccountType { Current, Savings }

//class BankAccount
//{
//    private static long lastNumber = 0;
//    private long accountNumber;
//    private decimal balance;
//    private AccountType accountType;

//    private static long GenerateNextNumber()
//    {
//        return ++lastNumber;
//    }

//    // Конструктор по умолчанию
//    public BankAccount()
//    {
//        accountNumber = GenerateNextNumber();
//        balance = 0;
//        accountType = AccountType.Current;
//    }

//    // Конструктор для заполнения баланса
//    public BankAccount(decimal balance)
//    {
//        accountNumber = GenerateNextNumber();
//        this.balance = balance;
//        accountType = AccountType.Current;
//    }

//    // Конструктор для заполнения типа счёта
//    public BankAccount(AccountType type)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = 0;
//        accountType = type;
//    }

//    // Конструктор для заполнения баланса и типа
//    public BankAccount(decimal balance, AccountType type)
//    {
//        accountNumber = GenerateNextNumber();
//        this.balance = balance;
//        accountType = type;
//    }

//    // Геттеры
//    public long GetAccountNumber() { return accountNumber; }
//    public decimal GetBalance() { return balance; }
//    public AccountType GetAccountType() { return accountType; }

//    public void PrintInfo()
//    {
//        Console.WriteLine($"Счёт #{accountNumber}: баланс = {balance}, тип = {accountType}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        BankAccount acc1 = new BankAccount();
//        BankAccount acc2 = new BankAccount(1000m);
//        BankAccount acc3 = new BankAccount(AccountType.Savings);
//        BankAccount acc4 = new BankAccount(5000m, AccountType.Savings);

//        acc1.PrintInfo();  // Счёт #1: баланс = 0, тип = Current
//        acc2.PrintInfo();  // Счёт #2: баланс = 1000, тип = Current
//        acc3.PrintInfo();  // Счёт #3: баланс = 0, тип = Savings
//        acc4.PrintInfo();  // Счёт #4: баланс = 5000, тип = Savings
//    }
//}