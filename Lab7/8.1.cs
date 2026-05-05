//using System;

///*Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1-
//7.3 добавить метод, который переводит деньги с одного счета на другой. У
//метода два параметра: ссылка на объект класса банковский счет откуда
//снимаются деньги, второй параметр – сумма*/


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

//    // Геттеры
//    public long GetAccountNumber() { return accountNumber; }
//    public decimal GetBalance() { return balance; }
//    public AccountType GetAccountType() { return accountType; }

//    // Сеттеры
//    public void SetBalance(decimal amount) { balance = amount; }
//    public void SetAccountType(AccountType type) { accountType = type; }

//    // Пополнение счета
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

//    // Снятие со счета
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

//    // НОВЫЙ МЕТОД: Перевод денег с одного счета на другой
//    public bool TransferTo(BankAccount targetAccount, decimal amount)
//    {
//        // Проверка: нельзя переводить на тот же самый счет
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

//        // Проверка суммы
//        if (amount <= 0)
//        {
//            Console.WriteLine("Ошибка: сумма перевода должна быть больше нуля!");
//            return false;
//        }

//        // Проверка достаточности средств
//        if (amount > this.balance)
//        {
//            Console.WriteLine($"Ошибка: недостаточно средств для перевода! Доступно: {this.balance} руб., запрошено: {amount} руб.");
//            return false;
//        }

//        // Выполняем перевод
//        this.balance -= amount;           // снимаем с текущего счета
//        targetAccount.balance += amount;  // зачисляем на целевой счет

//        Console.WriteLine($"Перевод {amount} руб. со счёта #{this.accountNumber} на счёт #{targetAccount.GetAccountNumber()} выполнен успешно!");
//        Console.WriteLine($"Баланс отправителя: {this.balance} руб.");
//        Console.WriteLine($"Баланс получателя: {targetAccount.GetBalance()} руб.");

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
//        Console.WriteLine("=== Банковская система: переводы между счетами ===\n");

//        // Создаём счета
//        BankAccount account1 = new BankAccount(10000m, AccountType.Current);
//        BankAccount account2 = new BankAccount(5000m, AccountType.Savings);
//        BankAccount account3 = new BankAccount(2000m, AccountType.Current);

//        // Выводим начальное состояние
//        Console.WriteLine("--- Начальное состояние счетов ---");
//        account1.PrintAccountInfo();
//        account2.PrintAccountInfo();
//        account3.PrintAccountInfo();

//        Console.WriteLine("\n--- Выполняем переводы ---\n");

//        // Перевод 1: с account1 на account2 (успешный)
//        Console.WriteLine("1. Перевод 3000 руб. со счета #1 на счет #2");
//        account1.TransferTo(account2, 3000m);

//        Console.WriteLine();

//        // Перевод 2: с account2 на account3 (успешный)
//        Console.WriteLine("2. Перевод 2000 руб. со счета #2 на счет #3");
//        account2.TransferTo(account3, 2000m);

//        Console.WriteLine();

//        // Перевод 3: попытка перевести больше, чем есть на счету
//        Console.WriteLine("3. Попытка перевести 10000 руб. со счета #3 на счет #1 (недостаточно средств)");
//        account3.TransferTo(account1, 10000m);

//        Console.WriteLine();

//        // Перевод 4: попытка перевести на тот же самый счёт
//        Console.WriteLine("4. Попытка перевести деньги на тот же самый счёт");
//        account1.TransferTo(account1, 1000m);

//        Console.WriteLine();

//        // Перевод 5: перевод с отрицательной суммой
//        Console.WriteLine("5. Попытка перевести отрицательную сумму");
//        account1.TransferTo(account2, -500m);

//        Console.WriteLine();

//        // Выводим конечное состояние
//        Console.WriteLine("--- Конечное состояние счетов ---");
//        account1.PrintAccountInfo();
//        account2.PrintAccountInfo();
//        account3.PrintAccountInfo();

//        // Дополнительная демонстрация: создаём новый счёт и переводим на него
//        Console.WriteLine("\n--- Дополнительный пример ---");
//        BankAccount newAccount = new BankAccount(AccountType.Current);
//        Console.WriteLine("Создан новый счёт:");
//        newAccount.PrintAccountInfo();

//        Console.WriteLine("\nПереводим 1500 руб. со счета #1 на новый счёт");
//        account1.TransferTo(newAccount, 1500m);

//        Console.WriteLine("\nСостояние после перевода:");
//        account1.PrintAccountInfo();
//        newAccount.PrintAccountInfo();
//    }
//}