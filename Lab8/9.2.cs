////Упражнение 9.2 Создать новый класс BankTransaction, который будет
////хранить информацию о всех банковских операциях. При изменении баланса
////счета создается новый объект класса BankTransaction, который содержит
////текущую дату и время, добавленную или снятую со счета сумму. Поля класса
////должны быть только для чтения (readonly). Конструктору класса передается
////один параметр – сумма.
////В классе банковский счет добавить закрытое поле типа
////System.Collections.Queue, которое будет хранить объекты класса
////BankTransaction для данного банковского счета; изменить методы снятия со
////65счета и добавления на счет так, чтобы в них создавался объект класса
////BankTransaction и каждый объект добавлялся в переменную типа
////System.Collections.Queue.



//using System;
//using System.Collections.Generic;  // для Queue
//using System.Collections;         // для Queue (старая версия)

//// Перечислимый тип
//enum AccountType
//{
//    Current,   // Текущий счёт
//    Savings    // Сберегательный счёт
//}

//// Класс BankTransaction: хранит информацию об одной банковской операции
//class BankTransaction
//{
//    // Поля только для чтения (readonly)
//    private readonly DateTime transactionDate;   // дата и время операции
//    private readonly decimal amount;             // сумма операции (положительная или отрицательная)

//    // Конструктор класса (принимает сумму)
//    public BankTransaction(decimal amount)
//    {
//        this.amount = amount;
//        this.transactionDate = DateTime.Now;     // текущие дата и время
//    }

//    // Свойства для чтения (геттеры)
//    public DateTime GetTransactionDate() { return transactionDate; }
//    public decimal GetAmount() { return amount; }

//    // Метод для вывода информации о транзакции
//    public void PrintTransaction()
//    {
//        string operationType = amount >= 0 ? "Пополнение" : "Снятие";
//        Console.WriteLine($"  {transactionDate:dd.MM.yyyy HH:mm:ss} | {operationType,11} | {Math.Abs(amount),10:F2} руб.");
//    }
//}

//// Класс банковского счёта
//class BankAccount
//{
//    // Статическая переменная для генерации номеров
//    private static long lastAccountNumber = 0;

//    // Закрытые поля
//    private long accountNumber;      // номер счета
//    private decimal balance;         // баланс
//    private AccountType accountType; // тип счета

//    // НОВОЕ ПОЛЕ: очередь для хранения транзакций (используем generic Queue)
//    private Queue<BankTransaction> transactions;

//    // Статический метод для генерации нового номера
//    private static long GenerateNextNumber()
//    {
//        lastAccountNumber++;
//        return lastAccountNumber;
//    }

//    // ========== КОНСТРУКТОРЫ ==========

//    // Конструктор по умолчанию
//    public BankAccount()
//    {
//        accountNumber = GenerateNextNumber();
//        balance = 0;
//        accountType = AccountType.Current;
//        transactions = new Queue<BankTransaction>();  // инициализируем очередь
//    }

//    // Конструктор с балансом
//    public BankAccount(decimal initialBalance)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = initialBalance;
//        accountType = AccountType.Current;
//        transactions = new Queue<BankTransaction>();

//        // Записываем начальный баланс как транзакцию (если не ноль)
//        if (initialBalance != 0)
//        {
//            transactions.Enqueue(new BankTransaction(initialBalance));
//        }
//    }

//    // Конструктор с типом счёта
//    public BankAccount(AccountType type)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = 0;
//        accountType = type;
//        transactions = new Queue<BankTransaction>();
//    }

//    // Конструктор с балансом и типом
//    public BankAccount(decimal initialBalance, AccountType type)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = initialBalance;
//        accountType = type;
//        transactions = new Queue<BankTransaction>();

//        if (initialBalance != 0)
//        {
//            transactions.Enqueue(new BankTransaction(initialBalance));
//        }
//    }

//    // ========== ГЕТТЕРЫ ==========
//    public long GetAccountNumber() { return accountNumber; }
//    public decimal GetBalance() { return balance; }
//    public AccountType GetAccountType() { return accountType; }

//    // Метод для получения всех транзакций (копия очереди)
//    public Queue<BankTransaction> GetTransactions()
//    {
//        return new Queue<BankTransaction>(transactions);
//    }

//    // ========== МЕТОДЫ ОПЕРАЦИЙ ==========

//    // Пополнение счета (ИЗМЕНЁН: добавляет транзакцию)
//    public void Deposit(decimal amount)
//    {
//        if (amount <= 0)
//        {
//            Console.WriteLine("Ошибка: сумма пополнения должна быть больше нуля!");
//            return;
//        }

//        // Создаём транзакцию и добавляем в очередь
//        BankTransaction transaction = new BankTransaction(amount);
//        transactions.Enqueue(transaction);

//        // Изменяем баланс
//        balance += amount;

//        Console.WriteLine($" Счёт #{accountNumber} пополнен на {amount} руб.");
//        Console.WriteLine($" Новый баланс: {balance} руб.");
//    }

//    // Снятие со счета (ИЗМЕНЁН: добавляет транзакцию с отрицательной суммой)
//    public bool Withdraw(decimal amount)
//    {
//        if (amount <= 0)
//        {
//            Console.WriteLine("Ошибка: сумма снятия должна быть больше нуля!");
//            return false;
//        }

//        if (amount > balance)
//        {
//            Console.WriteLine($"❌ Ошибка: недостаточно средств! Доступно: {balance} руб.");
//            return false;
//        }

//        // Создаём транзакцию с отрицательной суммой (для снятия)
//        BankTransaction transaction = new BankTransaction(-amount);
//        transactions.Enqueue(transaction);

//        // Изменяем баланс
//        balance -= amount;

//        Console.WriteLine($" Счёт #{accountNumber}: снято {amount} руб.");
//        Console.WriteLine($" Новый баланс: {balance} руб.");
//        return true;
//    }

//    // Перевод на другой счёт (тоже добавляет транзакции для обоих счетов)
//    public bool TransferTo(BankAccount targetAccount, decimal amount)
//    {
//        if (targetAccount == null)
//        {
//            Console.WriteLine("Ошибка: счёт получатель не существует!");
//            return false;
//        }

//        if (this.accountNumber == targetAccount.GetAccountNumber())
//        {
//            Console.WriteLine("Ошибка: нельзя перевести деньги на тот же самый счёт!");
//            return false;
//        }

//        if (amount <= 0)
//        {
//            Console.WriteLine("Ошибка: сумма перевода должна быть больше нуля!");
//            return false;
//        }

//        if (amount > this.balance)
//        {
//            Console.WriteLine($"Ошибка: недостаточно средств! Доступно: {this.balance} руб.");
//            return false;
//        }

//        // Снимаем деньги с текущего счёта (создаётся транзакция в Withdraw)
//        this.Withdraw(amount);  // уже создаст транзакцию для снятия

//        // Зачисляем на целевой счёт (создаётся транзакция в Deposit)
//        targetAccount.Deposit(amount);  // уже создаст транзакцию для пополнения

//        Console.WriteLine($"   Перевод выполнен успешно!");
//        return true;
//    }

//    // Метод для вывода всей информации о счете (включая историю транзакций)
//    public void PrintAccountInfo()
//    {
//        Console.WriteLine("════════════════════════════════════════════════════════════");
//        Console.WriteLine($"   Счёт #{accountNumber}");
//        Console.WriteLine($"   Баланс: {balance:F2} руб.");
//        Console.WriteLine($"   Тип счёта: {accountType}");
//        Console.WriteLine($"   Количество транзакций: {transactions.Count}");
//        Console.WriteLine("════════════════════════════════════════════════════════════");
//    }

//    // Метод для печати истории транзакций (без удаления из очереди)
//    public void PrintTransactionHistory()
//    {
//        Console.WriteLine($"\n📋 История операций по счёту #{accountNumber}:");
//        Console.WriteLine(new string('-', 50));
//        Console.WriteLine($"{"Дата и время",20} | {"Операция",11} | {"Сумма",10}");
//        Console.WriteLine(new string('-', 50));

//        foreach (BankTransaction transaction in transactions)
//        {
//            transaction.PrintTransaction();
//        }
//        Console.WriteLine(new string('-', 50));
//        Console.WriteLine($"Баланс на текущий момент: {balance:F2} руб.\n");
//    }
//}

//// Главный класс программы
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Банковская система с историей транзакций ===\n");

//        // Создаём счёт с начальным балансом
//        BankAccount myAccount = new BankAccount(10000m, AccountType.Current);
//        myAccount.PrintAccountInfo();

//        // Выполняем операции
//        Console.WriteLine("\n--- Выполняем операции ---\n");

//        myAccount.Deposit(5000m);
//        myAccount.Withdraw(3000m);
//        myAccount.Deposit(2000m);
//        myAccount.Withdraw(1000m);

//        // Попытка снять больше, чем есть
//        myAccount.Withdraw(15000m);

//        // Показываем историю транзакций
//        myAccount.PrintTransactionHistory();

//        // Создаём второй счёт и выполняем перевод
//        Console.WriteLine("--- Демонстрация перевода между счетами ---\n");

//        BankAccount account1 = new BankAccount(5000m, AccountType.Current);
//        BankAccount account2 = new BankAccount(1000m, AccountType.Savings);

//        account1.PrintAccountInfo();
//        account2.PrintAccountInfo();

//        Console.WriteLine("\nПереводим 2000 руб. со счёта #1 на счёт #2...");
//        account1.TransferTo(account2, 2000m);

//        // Показываем историю транзакций обоих счетов
//        account1.PrintTransactionHistory();
//        account2.PrintTransactionHistory();

//        // Создаём счёт с начальным балансом через конструктор
//        Console.WriteLine("--- Создание счёта с начальным балансом ---\n");
//        BankAccount newAccount = new BankAccount(15000m, AccountType.Current);
//        newAccount.PrintAccountInfo();
//        newAccount.PrintTransactionHistory();

//        Console.WriteLine("\nНажмите любую клавишу для выхода...");
//        Console.ReadKey();
//    }
//}