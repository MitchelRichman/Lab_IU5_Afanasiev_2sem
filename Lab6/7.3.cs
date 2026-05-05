//using System;
///*Упражнение 7.3 Добавить в класс счет в банке два метода: снять со
//счета и положить на счет. Метод снять со счета проверяет, возможно ли снять
//запрашиваемую сумму, и в случае положительного результата изменяет баланс.*/

//// Перечислимый тип из упражнения 3.1
//enum AccountType
//{
//    Current,   // Текущий счёт
//    Savings    // Сберегательный счёт
//}

//// Класс банковского счёта
//class BankAccount
//{
//    // Статическая переменная для генерации номеров
//    private static long lastAccountNumber = 0;

//    // Закрытые поля
//    private long accountNumber;
//    private decimal balance;
//    private AccountType accountType;

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
//    }

//    public BankAccount(decimal initialBalance)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = initialBalance;
//        accountType = AccountType.Current;
//    }

//    public BankAccount(AccountType type)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = 0;
//        accountType = type;
//    }

//    public BankAccount(decimal initialBalance, AccountType type)
//    {
//        accountNumber = GenerateNextNumber();
//        balance = initialBalance;
//        accountType = type;
//    }

//    // Геттеры (методы чтения)
//    public long GetAccountNumber() { return accountNumber; }
//    public decimal GetBalance() { return balance; }
//    public AccountType GetAccountType() { return accountType; }

//    // Сеттеры (методы записи)
//    public void SetBalance(decimal amount) { balance = amount; }
//    public void SetAccountType(AccountType type) { accountType = type; }

//    // НОВЫЙ МЕТОД: Пополнение счета
//    public void Deposit(decimal amount)
//    {
//        if (amount <= 0)
//        {
//            Console.WriteLine("Ошибка: сумма пополнения должна быть больше нуля!");
//            return;
//        }

//        balance += amount;
//        Console.WriteLine($"Счёт #{accountNumber} пополнен на {amount} руб. Текущий баланс: {balance} руб.");
//    }

//    // НОВЫЙ МЕТОД: Снятие со счета
//    public bool Withdraw(decimal amount)
//    {
//        if (amount <= 0)
//        {
//            Console.WriteLine("Ошибка: сумма снятия должна быть больше нуля!");
//            return false;
//        }

//        if (amount > balance)
//        {
//            Console.WriteLine($"Ошибка: недостаточно средств! Баланс: {balance} руб., запрошено: {amount} руб.");
//            return false;
//        }

//        balance -= amount;
//        Console.WriteLine($"Счёт #{accountNumber}: снято {amount} руб. Остаток: {balance} руб.");
//        return true;
//    }

//    // Метод для вывода информации о счете
//    public void PrintAccountInfo()
//    {
//        Console.WriteLine("═══════════════════════════════════════");
//        Console.WriteLine($"Номер счета: {accountNumber}");
//        Console.WriteLine($"Баланс: {balance:F2} руб.");
//        Console.WriteLine($"Тип счета: {accountType}");
//        Console.WriteLine("═══════════════════════════════════════");
//    }
//}

//// Главный класс программы
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Банковская система ===\n");

//        // Создаём счёт с начальным балансом 10000 рублей
//        BankAccount myAccount = new BankAccount(10000m, AccountType.Current);
//        myAccount.PrintAccountInfo();

//        Console.WriteLine("\n--- Выполняем операции ---\n");

//        // Пополнение счета
//        myAccount.Deposit(5000m);

//        // Снятие денег (успешное)
//        myAccount.Withdraw(3000m);

//        // Попытка снять больше, чем есть на счету
//        myAccount.Withdraw(15000m);

//        // Снятие с отрицательной суммой
//        myAccount.Withdraw(-100m);

//        // Пополнение с отрицательной суммой
//        myAccount.Deposit(-500m);

//        // Финальное состояние счета
//        Console.WriteLine("\n--- Финальное состояние счета ---");
//        myAccount.PrintAccountInfo();

//        // Демонстрация работы с несколькими счетами
//        Console.WriteLine("\n=== Демонстрация нескольких счетов ===\n");

//        BankAccount savingsAccount = new BankAccount(50000m, AccountType.Savings);
//        savingsAccount.PrintAccountInfo();

//        savingsAccount.Withdraw(10000m);
//        savingsAccount.Deposit(20000m);
//        savingsAccount.PrintAccountInfo();
//    }
//}