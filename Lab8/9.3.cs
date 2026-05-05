////Упражнение 9.3 В классе банковский счет создать метод Dispose,
////который данные о проводках из очереди запишет в файл. Не забудьте внутри
////метода Dispose вызвать метод GC.SuppressFinalize, который сообщает системе,
////что она не должна вызывать метод завершения для указанного объекта.



//using System;
//using System.Collections.Generic;
//using System.IO;     // для работы с файлами
//using System.Text;   // для кодировки

//// Перечислимый тип
//enum AccountType
//{
//    Current,
//    Savings
//}

//// Класс BankTransaction: хранит информацию об одной банковской операции
//class BankTransaction
//{
//    private readonly DateTime transactionDate;
//    private readonly decimal amount;

//    public BankTransaction(decimal amount)
//    {
//        this.amount = amount;
//        this.transactionDate = DateTime.Now;
//    }

//    public DateTime GetTransactionDate() { return transactionDate; }
//    public decimal GetAmount() { return amount; }

//    public string GetFormattedString()
//    {
//        string operationType = amount >= 0 ? "Пополнение" : "Снятие";
//        return $"{transactionDate:dd.MM.yyyy HH:mm:ss} | {operationType,11} | {Math.Abs(amount),10:F2} руб.";
//    }
//}

//// Класс банковского счёта (реализует IDisposable)
//class BankAccount : IDisposable
//{
//    // Статическая переменная для генерации номеров
//    private static long lastAccountNumber = 0;
//    private static readonly object fileLock = new object(); // для синхронизации доступа к файлу

//    // Закрытые поля
//    private long accountNumber;
//    private decimal balance;
//    private AccountType accountType;
//    private Queue<BankTransaction> transactions;
//    private bool disposed = false;  // флаг, указывает, был ли уже вызван Dispose

//    // Статический метод для генерации нового номера
//    private static long GenerateNextNumber()
//    {
//        lastAccountNumber++;
//        return lastAccountNumber;
//    }

//    // Конструкторы
//    public BankAccount()
//    {
//        accountNumber = GenerateNextNumber();
//        balance = 0;
//        accountType = AccountType.Current;
//        transactions = new Queue<BankTransaction>();
//    }

//    public BankAccount(decimal initialBalance)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = initialBalance;
//        accountType = AccountType.Current;
//        transactions = new Queue<BankTransaction>();

//        if (initialBalance != 0)
//        {
//            transactions.Enqueue(new BankTransaction(initialBalance));
//        }
//    }

//    public BankAccount(AccountType type)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = 0;
//        accountType = type;
//        transactions = new Queue<BankTransaction>();
//    }

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

//    // Геттеры
//    public long GetAccountNumber() { return accountNumber; }
//    public decimal GetBalance() { return balance; }
//    public AccountType GetAccountType() { return accountType; }
//    public int GetTransactionCount() { return transactions.Count; }

//    // Методы операций
//    public void Deposit(decimal amount)
//    {
//        if (amount <= 0)
//        {
//            Console.WriteLine("Ошибка: сумма пополнения должна быть больше нуля!");
//            return;
//        }

//        transactions.Enqueue(new BankTransaction(amount));
//        balance += amount;
//        Console.WriteLine($"✅ Счёт #{accountNumber} пополнен на {amount} руб.");
//    }

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

//        transactions.Enqueue(new BankTransaction(-amount));
//        balance -= amount;
//        Console.WriteLine($"✅ Счёт #{accountNumber}: снято {amount} руб.");
//        return true;
//    }

//    // ========== МЕТОД DISPOSE (ОСНОВНОЕ ЗАДАНИЕ) ==========

//    /// <summary>
//    /// Метод Dispose: записывает все транзакции в файл и освобождает ресурсы
//    /// </summary>
//    public void Dispose()
//    {
//        // Запрещаем повторный вызов Dispose
//        if (disposed)
//            return;

//        Console.WriteLine($"\n💾 Сохранение данных счёта #{accountNumber}...");

//        // Записываем транзакции в файл
//        SaveTransactionsToFile();

//        // Сообщаем системе, что финализатор (деструктор) вызывать не нужно
//        GC.SuppressFinalize(this);

//        disposed = true;
//        Console.WriteLine($"✅ Счёт #{accountNumber} успешно сохранён и освобождён.");
//    }

//    /// <summary>
//    /// Записывает все транзакции в файл
//    /// </summary>
//    private void SaveTransactionsToFile()
//    {
//        // Формируем имя файла (уникальное для каждого счёта)
//        string fileName = $"account_{accountNumber}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

//        try
//        {
//            // Используем lock для безопасной записи из разных потоков (на всякий случай)
//            lock (fileLock)
//            {
//                using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
//                {
//                    // Записываем заголовок
//                    writer.WriteLine("═══════════════════════════════════════════════════════════════");
//                    writer.WriteLine($"                ВЫПИСКА ПО СЧЁТУ #{accountNumber}");
//                    writer.WriteLine("═══════════════════════════════════════════════════════════════");
//                    writer.WriteLine();
//                    writer.WriteLine($"Дата выписки: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
//                    writer.WriteLine($"Тип счёта: {accountType}");
//                    writer.WriteLine($"Финальный баланс: {balance:F2} руб.");
//                    writer.WriteLine();
//                    writer.WriteLine(new string('-', 60));
//                    writer.WriteLine($"{"Дата и время",20} | {"Операция",11} | {"Сумма",10}");
//                    writer.WriteLine(new string('-', 60));

//                    // Записываем все транзакции из очереди
//                    foreach (BankTransaction transaction in transactions)
//                    {
//                        writer.WriteLine(transaction.GetFormattedString());
//                    }

//                    writer.WriteLine(new string('-', 60));
//                    writer.WriteLine();
//                    writer.WriteLine($"Итого операций: {transactions.Count}");
//                    writer.WriteLine($"Конечный баланс: {balance:F2} руб.");
//                    writer.WriteLine();
//                    writer.WriteLine("═══════════════════════════════════════════════════════════════");
//                }
//            }

//            Console.WriteLine($"   Файл сохранён: {fileName}");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"   ❌ Ошибка при сохранении: {ex.Message}");
//        }
//    }

//    // Деструктор (финализатор) - вызывается сборщиком мусора
//    ~BankAccount()
//    {
//        // Если Dispose не был вызван, вызываем его автоматически
//        if (!disposed)
//        {
//            Console.WriteLine($"⚠️ Счёт #{accountNumber} уничтожается сборщиком мусора без вызова Dispose!");
//            SaveTransactionsToFile();
//        }
//    }

//    // Метод для вывода информации о счете
//    public void PrintAccountInfo()
//    {
//        Console.WriteLine("════════════════════════════════════════════════════════════");
//        Console.WriteLine($"💰 Счёт #{accountNumber}");
//        Console.WriteLine($"   Баланс: {balance:F2} руб.");
//        Console.WriteLine($"   Тип счёта: {accountType}");
//        Console.WriteLine($"   Транзакций: {transactions.Count}");
//        Console.WriteLine("════════════════════════════════════════════════════════════");
//    }

//    // Метод для печати истории транзакций
//    public void PrintTransactionHistory()
//    {
//        Console.WriteLine($"\n📋 История операций по счёту #{accountNumber}:");
//        Console.WriteLine(new string('-', 60));
//        Console.WriteLine($"{"Дата и время",20} | {"Операция",11} | {"Сумма",10}");
//        Console.WriteLine(new string('-', 60));

//        foreach (BankTransaction transaction in transactions)
//        {
//            Console.WriteLine(transaction.GetFormattedString());
//        }
//        Console.WriteLine(new string('-', 60));
//        Console.WriteLine($"Баланс на текущий момент: {balance:F2} руб.\n");
//    }
//}

//// Главный класс программы
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Банковская система с записью транзакций в файл ===\n");

//        // Используем конструкцию using для автоматического вызова Dispose
//        Console.WriteLine("--- Демонстрация 1: автоматический Dispose через using ---\n");

//        using (BankAccount account1 = new BankAccount(10000m, AccountType.Current))
//        {
//            account1.PrintAccountInfo();

//            Console.WriteLine("\nВыполняем операции:");
//            account1.Deposit(5000m);
//            account1.Withdraw(3000m);
//            account1.Deposit(2000m);
//            account1.Withdraw(1000m);

//            account1.PrintTransactionHistory();
//        }  // Здесь автоматически вызывается account1.Dispose()

//        Console.WriteLine();
//        Console.WriteLine(new string('=', 80));
//        Console.WriteLine();

//        // Ручной вызов Dispose
//        Console.WriteLine("--- Демонстрация 2: ручной вызов Dispose ---\n");

//        BankAccount account2 = new BankAccount(5000m, AccountType.Savings);
//        account2.PrintAccountInfo();

//        Console.WriteLine("\nВыполняем операции:");
//        account2.Deposit(2000m);
//        account2.Withdraw(1000m);

//        account2.PrintTransactionHistory();

//        // Ручной вызов Dispose
//        account2.Dispose();

//        // После Dispose объект всё ещё существует, но его нельзя использовать
//        Console.WriteLine("\nПопытка использовать счёт после Dispose:");
//        account2.Deposit(1000m);  // Это всё ещё работает, но лучше так не делать

//        Console.WriteLine("\n--- Демонстрация 3: несколько счетов ---\n");

//        // Создаём несколько счетов
//        using (BankAccount accA = new BankAccount(1000m, AccountType.Current))
//        using (BankAccount accB = new BankAccount(2000m, AccountType.Savings))
//        using (BankAccount accC = new BankAccount(3000m, AccountType.Current))
//        {
//            accA.Deposit(500m);
//            accB.Withdraw(500m);
//            accC.Deposit(1000m);
//            accC.Withdraw(500m);

//            Console.WriteLine($"\nСчёт {accA.GetAccountNumber()}: {accA.GetBalance()} руб.");
//            Console.WriteLine($"Счёт {accB.GetAccountNumber()}: {accB.GetBalance()} руб.");
//            Console.WriteLine($"Счёт {accC.GetAccountNumber()}: {accC.GetBalance()} руб.");
//        }  // Здесь все три Dispose вызовутся автоматически

//        Console.WriteLine("\n=== Все данные сохранены в файлы ===");
//        Console.WriteLine("Проверьте папку с программой - там должны появиться файлы account_*.txt");

//        Console.WriteLine("\nНажмите любую клавишу для выхода...");
//        Console.ReadKey();
//    }
//}