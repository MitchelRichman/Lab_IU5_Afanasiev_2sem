//using System;
///*Упражнение 7.1 Создать класс счет в банке с закрытыми полями: номер
//счета, баланс, тип банковского счета (использовать перечислимый тип из упр.
//3.1). Предусмотреть методы для доступа к данным – заполнения и чтения.
//Создать объект класса, заполнить его поля и вывести информацию об объекте
//класса на печать*/

//using System;

//// Перечислимый тип из упражнения 3.1
//enum AccountType
//{
//    Current,   // Текущий счёт
//    Savings    // Сберегательный счёт
//}

//// Класс банковского счёта
//class BankAccount
//{
//    // Закрытые поля (private)
//    private long accountNumber;      // номер счета
//    private decimal balance;         // баланс
//    private AccountType accountType; // тип счета

//    // Методы для заполнения полей (сеттеры)
//    public void SetAccountNumber(long number)
//    {
//        accountNumber = number;
//    }

//    public void SetBalance(decimal amount)
//    {
//        balance = amount;
//    }

//    public void SetAccountType(AccountType type)
//    {
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

//    // Метод для вывода всей информации о счете
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
//        // Создаём объект класса BankAccount
//        BankAccount myAccount = new BankAccount();

//        // Заполняем поля через методы-сеттеры
//        myAccount.SetAccountNumber(123456789);
//        myAccount.SetBalance(15000.50m);
//        myAccount.SetAccountType(AccountType.Savings);

//        // Выводим информацию через метод PrintAccountInfo
//        myAccount.PrintAccountInfo();


//    }
//}
