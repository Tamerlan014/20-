using System.Globalization;

namespace _20_заданий;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            SafeClear();
            Console.WriteLine("=== 20 практических задач по C# ===");
            Console.WriteLine("1. Чётные и нечётные числа");
            Console.WriteLine("2. Второе максимальное число");
            Console.WriteLine("3. Удаление дубликатов");
            Console.WriteLine("4. Переворот массива");
            Console.WriteLine("5. Подсчёт символов");
            Console.WriteLine("6. Самое длинное слово");
            Console.WriteLine("7. Палиндром");
            Console.WriteLine("8. Простые числа");
            Console.WriteLine("9. Угадай число");
            Console.WriteLine("10. Банкомат");
            Console.WriteLine("11. Калькулятор с методами");
            Console.WriteLine("12. Статистика оценок");
            Console.WriteLine("13. Частота слов");
            Console.WriteLine("14. Телефонная книга");
            Console.WriteLine("15. Класс Student");
            Console.WriteLine("16. Класс BankAccount");
            Console.WriteLine("17. Система товаров");
            Console.WriteLine("18. Сортировка без Sort()");
            Console.WriteLine("19. Камень, ножницы, бумага");
            Console.WriteLine("20. Мини-система авторизации");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите задачу: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": Task1_EvenOdd(); break;
                case "2": Task2_SecondMax(); break;
                case "3": Task3_RemoveDuplicates(); break;
                case "4": Task4_ReverseArray(); break;
                case "5": Task5_CountSymbols(); break;
                case "6": Task6_LongestWord(); break;
                case "7": Task7_Palindrome(); break;
                case "8": Task8_Primes(); break;
                case "9": Task9_GuessNumber(); break;
                case "10": Task10_Atm(); break;
                case "11": Task11_Calculator(); break;
                case "12": Task12_GradesStats(); break;
                case "13": Task13_WordFrequency(); break;
                case "14": Task14_PhoneBook(); break;
                case "15": Task15_Students(); break;
                case "16": Task16_BankAccountDemo(); break;
                case "17": Task17_ProductSystem(); break;
                case "18": Task18_BubbleSort(); break;
                case "19": Task19_RockPaperScissors(); break;
                case "20": Task20_AuthSystem(); break;
                case "0": return;
                default:
                    Console.WriteLine("Неверный ввод. Нажмите любую клавишу...");
                    if (Environment.UserInteractive && !Console.IsInputRedirected && !Console.IsOutputRedirected)
                        Console.ReadKey();
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Pause();
        }
    }

    static void SafeClear()
    {
        try
        {
            if (Environment.UserInteractive && !Console.IsInputRedirected && !Console.IsOutputRedirected)
                Console.Clear();
        }
        catch
        {
            // Ignore if console is not available (for redirected input/output).
        }
    }

    static void Pause()
    {
        if (Environment.UserInteractive && !Console.IsInputRedirected && !Console.IsOutputRedirected)
        {
            Console.ReadKey();
        }
    }

    static void Task1_EvenOdd()
    {
        Console.WriteLine("Задача 1. Чётные и нечётные числа");
        var numbers = ReadIntArray(10, "Введите 10 чисел через пробел:");

        var even = numbers.Where(n => n % 2 == 0).ToArray();
        var odd = numbers.Where(n => n % 2 != 0).ToArray();

        Console.WriteLine($"Чётные: {string.Join(" ", even)}");
        Console.WriteLine($"Нечётные: {string.Join(" ", odd)}");
        Console.WriteLine($"Количество чётных: {even.Length}");
        Console.WriteLine($"Количество нечётных: {odd.Length}");
    }

    static void Task2_SecondMax()
    {
        Console.WriteLine("Задача 2. Второе максимальное число");
        var numbers = ReadIntArray(10, "Введите 10 чисел через пробел:");

        var distinct = numbers.Distinct().OrderByDescending(n => n).ToArray();
        Console.WriteLine(distinct.Length >= 2
            ? $"Второе максимальное число: {distinct[1]}"
            : "В массиве меньше двух уникальных чисел.");
    }

    static void Task3_RemoveDuplicates()
    {
        Console.WriteLine("Задача 3. Удаление дубликатов");
        Console.Write("Введите массив чисел через пробел: ");
        var text = Console.ReadLine() ?? string.Empty;
        var parts = text.Split(new[] { ' ', ',', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        var numbers = new List<int>();
        foreach (var part in parts)
        {
            if (int.TryParse(part, out var value))
            {
                numbers.Add(value);
            }
        }

        var arr = numbers.Distinct().ToArray();
        Console.WriteLine($"Результат: [{string.Join(", ", arr)}]");
    }

    static void Task4_ReverseArray()
    {
        Console.WriteLine("Задача 4. Переворот массива");
        var numbers = ReadIntArray(10, "Введите 10 чисел через пробел:");
        var reversed = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            reversed[i] = numbers[numbers.Length - 1 - i];
        }

        Console.WriteLine($"Исходный: [{string.Join(", ", numbers)}]");
        Console.WriteLine($"Обратный: [{string.Join(", ", reversed)}]");
    }

    static void Task5_CountSymbols()
    {
        Console.WriteLine("Задача 5. Подсчёт символов");
        Console.Write("Введите строку: ");
        var text = Console.ReadLine() ?? string.Empty;

        int letters = 0, digits = 0, spaces = 0, others = 0;

        foreach (var ch in text)
        {
            if (char.IsLetter(ch)) letters++;
            else if (char.IsDigit(ch)) digits++;
            else if (char.IsWhiteSpace(ch)) spaces++;
            else others++;
        }

        Console.WriteLine($"Букв: {letters}");
        Console.WriteLine($"Цифр: {digits}");
        Console.WriteLine($"Пробелов: {spaces}");
        Console.WriteLine($"Других: {others}");
    }

    static void Task6_LongestWord()
    {
        Console.WriteLine("Задача 6. Самое длинное слово");
        Console.Write("Введите предложение: ");
        var sentence = Console.ReadLine() ?? string.Empty;

        var words = sentence
            .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w.Trim(new[] { '.', ',', '!', '?', ':', ';', '"', '\'', '(', ')', '[', ']' }))
            .Where(w => !string.IsNullOrEmpty(w))
            .ToArray();

        var longest = words.OrderByDescending(w => w.Length).FirstOrDefault();
        Console.WriteLine(string.IsNullOrEmpty(longest)
            ? "Слов не найдено."
            : $"Самое длинное слово: {longest}");
    }

    static void Task7_Palindrome()
    {
        Console.WriteLine("Задача 7. Палиндром");
        Console.Write("Введите строку: ");
        var text = Console.ReadLine() ?? string.Empty;

        string filtered = new string(text.Where(ch => !char.IsWhiteSpace(ch)).ToArray()).ToLower();
        var reversed = new string(filtered.Reverse().ToArray());

        Console.WriteLine(filtered == reversed ? "Палиндром" : "Не палиндром");
    }

    static void Task8_Primes()
    {
        Console.WriteLine("Задача 8. Простые числа");
        Console.Write("Введите число N: ");

        if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
        {
            Console.WriteLine("Введите корректное положительное число.");
            return;
        }

        var primes = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }

        Console.WriteLine(primes.Count == 0
            ? "Простых чисел нет."
            : $"Простые числа: {string.Join(" ", primes)}");
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }

        return true;
    }

    static void Task9_GuessNumber()
    {
        Console.WriteLine("Задача 9. Угадай число");
        Random random = new Random();
        int target = random.Next(1, 101);
        int attempts = 0;

        while (true)
        {
            Console.Write("Введите число от 1 до 100: ");
            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine("Введите корректное число.");
                continue;
            }

            attempts++;

            if (guess < target)
            {
                Console.WriteLine("Загаданное число больше.");
            }
            else if (guess > target)
            {
                Console.WriteLine("Загаданное число меньше.");
            }
            else
            {
                Console.WriteLine($"Вы угадали! Попыток: {attempts}");
                return;
            }
        }
    }

    static void Task10_Atm()
    {
        Console.WriteLine("Задача 10. Банкомат");
        decimal balance = 100000m;

        while (true)
        {
            Console.WriteLine("1. Проверить баланс");
            Console.WriteLine("2. Снять деньги");
            Console.WriteLine("3. Пополнить баланс");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите действие: ");

            if (!int.TryParse(Console.ReadLine(), out int action))
            {
                Console.WriteLine("Неверный ввод.");
                continue;
            }

            switch (action)
            {
                case 1:
                    Console.WriteLine($"Текущий баланс: {balance} руб.");
                    break;
                case 2:
                    Console.Write("Введите сумму для снятия: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                    {
                        if (amount > balance)
                        {
                            Console.WriteLine("Недостаточно средств.");
                        }
                        else
                        {
                            balance -= amount;
                            Console.WriteLine($"Снято: {amount}. Остаток: {balance}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректная сумма.");
                    }
                    break;
                case 3:
                    Console.Write("Введите сумму пополнения: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal deposit) && deposit > 0)
                    {
                        balance += deposit;
                        Console.WriteLine($"Пополнено: {deposit}. Остаток: {balance}");
                    }
                    else
                    {
                        Console.WriteLine("Некорректная сумма.");
                    }
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Неверный пункт меню.");
                    break;
            }
        }
    }

    static void Task11_Calculator()
    {
        Console.WriteLine("Задача 11. Калькулятор с методами");
        Console.Write("Введите первое число: ");
        double a = ReadDouble();
        Console.Write("Введите второе число: ");
        double b = ReadDouble();

        Console.WriteLine("1. Сложение");
        Console.WriteLine("2. Вычитание");
        Console.WriteLine("3. Умножение");
        Console.WriteLine("4. Деление");
        Console.Write("Выберите операцию: ");

        var op = Console.ReadLine();

        switch (op)
        {
            case "1":
                Console.WriteLine($"Результат: {Add(a, b)}");
                break;
            case "2":
                Console.WriteLine($"Результат: {Subtract(a, b)}");
                break;
            case "3":
                Console.WriteLine($"Результат: {Multiply(a, b)}");
                break;
            case "4":
                if (Math.Abs(b) < double.Epsilon)
                {
                    Console.WriteLine("Ошибка: деление на 0.");
                }
                else
                {
                    Console.WriteLine($"Результат: {Divide(a, b)}");
                }
                break;
            default:
                Console.WriteLine("Неверная операция.");
                break;
        }
    }

    static double Add(double a, double b) => a + b;
    static double Subtract(double a, double b) => a - b;
    static double Multiply(double a, double b) => a * b;
    static double Divide(double a, double b) => a / b;

    static void Task12_GradesStats()
    {
        Console.WriteLine("Задача 12. Статистика оценок");
        var grades = ReadIntArray(10, "Введите 10 оценок через пробел:");

        double average = grades.Average();
        int max = grades.Max();
        int min = grades.Min();
        int fives = grades.Count(g => g == 5);
        int twos = grades.Count(g => g == 2);
        double passedPercent = grades.Count(g => g >= 3) * 100.0 / grades.Length;

        Console.WriteLine($"Средний балл: {average:F1}");
        Console.WriteLine($"Максимум: {max}");
        Console.WriteLine($"Минимум: {min}");
        Console.WriteLine($"Пятёрок: {fives}");
        Console.WriteLine($"Двоек: {twos}");
        Console.WriteLine($"Процент успешно сдавших: {passedPercent:F1}%");
    }

    static void Task13_WordFrequency()
    {
        Console.WriteLine("Задача 13. Частота слов");
        Console.Write("Введите предложение: ");
        var sentence = Console.ReadLine() ?? string.Empty;

        var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var words = sentence.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            var normalized = word.Trim(new[] { '.', ',', '!', '?', ':', ';', '"', '\'', '(', ')', '[', ']' });
            if (string.IsNullOrEmpty(normalized)) continue;

            if (dict.ContainsKey(normalized))
                dict[normalized]++;
            else
                dict[normalized] = 1;
        }

        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static void Task14_PhoneBook()
    {
        Console.WriteLine("Задача 14. Телефонная книга");
        var phoneBook = new Dictionary<string, string>();

        while (true)
        {
            Console.WriteLine("1. Добавить контакт");
            Console.WriteLine("2. Найти контакт");
            Console.WriteLine("3. Удалить контакт");
            Console.WriteLine("4. Показать все контакты");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие: ");

            if (!int.TryParse(Console.ReadLine(), out int action))
            {
                Console.WriteLine("Неверный ввод.");
                continue;
            }

            switch (action)
            {
                case 1:
                    Console.Write("Введите имя: ");
                    var name = Console.ReadLine() ?? string.Empty;
                    Console.Write("Введите телефон: ");
                    var phone = Console.ReadLine() ?? string.Empty;
                    phoneBook[name] = phone;
                    Console.WriteLine("Контакт добавлен.");
                    break;
                case 2:
                    Console.Write("Введите имя для поиска: ");
                    var searchName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine(phoneBook.ContainsKey(searchName)
                        ? $"{searchName}: {phoneBook[searchName]}"
                        : "Контакт не найден.");
                    break;
                case 3:
                    Console.Write("Введите имя для удаления: ");
                    var removeName = Console.ReadLine() ?? string.Empty;
                    if (phoneBook.Remove(removeName))
                        Console.WriteLine("Контакт удалён.");
                    else
                        Console.WriteLine("Контакт не найден.");
                    break;
                case 4:
                    if (phoneBook.Count == 0)
                        Console.WriteLine("Телефонная книга пуста.");
                    else
                    {
                        foreach (var contact in phoneBook)
                            Console.WriteLine($"{contact.Key}: {contact.Value}");
                    }
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Неверная команда.");
                    break;
            }
        }
    }

    static void Task15_Students()
    {
        Console.WriteLine("Задача 15. Класс Student");
        var students = new List<Student>
        {
            new Student("Иван", 18, 5),
            new Student("Мария", 20, 4),
            new Student("Алексей", 19, 5),
            new Student("Ольга", 21, 3),
            new Student("Дмитрий", 22, 4)
        };

        Console.WriteLine("Студенты:");
        foreach (var s in students)
        {
            Console.WriteLine(s);
        }

        var oldest = students.OrderByDescending(s => s.Age).First();
        var best = students.OrderByDescending(s => s.Grade).First();
        double average = students.Average(s => s.Grade);

        Console.WriteLine($"Самый старший: {oldest.Name} ({oldest.Age})");
        Console.WriteLine($"Лучший балл: {best.Name} ({best.Grade})");
        Console.WriteLine($"Средний балл группы: {average:F1}");
    }

    static void Task16_BankAccountDemo()
    {
        Console.WriteLine("Задача 16. Класс BankAccount");
        var account = new BankAccount("Иван");
        account.Deposit(50000m);
        Console.WriteLine(account.ShowBalance());
        account.Withdraw(15000m);
        Console.WriteLine(account.ShowBalance());
    }

    static void Task17_ProductSystem()
    {
        Console.WriteLine("Задача 17. Система товаров");
        var products = new List<Product>
        {
            new Product("Ноутбук", 350000m, 2),
            new Product("Мышь", 2000m, 5),
            new Product("Клавиатура", 5000m, 3)
        };

        Console.WriteLine("Список товаров:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        var total = products.Sum(p => p.Price * p.Quantity);
        Console.WriteLine($"Общая стоимость: {total}");

        Console.WriteLine("Поиск товара 'Мышь':");
        var found = products.FirstOrDefault(p => p.Name == "Мышь");
        Console.WriteLine(found is null ? "Не найден" : found.ToString());
    }

    static void Task18_BubbleSort()
    {
        Console.WriteLine("Задача 18. Сортировка без Sort()");
        var numbers = new[] { 8, 3, 1, 9, 5, 2, 7 };
        var arr = numbers.ToArray();

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }

        Console.WriteLine($"Отсортировано: [{string.Join(", ", arr)}]");
    }

    static void Task19_RockPaperScissors()
    {
        Console.WriteLine("Задача 19. Камень, ножницы, бумага");
        Console.WriteLine("1. Камень\n2. Ножницы\n3. Бумага\n0. Выход");

        Random random = new Random();
        int playerScore = 0;
        int computerScore = 0;

        while (true)
        {
            Console.Write("Ваш выбор: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 3)
            {
                Console.WriteLine("Неверный выбор.");
                continue;
            }

            if (choice == 0)
            {
                Console.WriteLine($"Итог: Игрок {playerScore} : {computerScore} Компьютер");
                return;
            }

            int computer = random.Next(1, 4);
            Console.WriteLine($"Компьютер: {computer}");

            if (choice == computer)
            {
                Console.WriteLine("Ничья");
            }
            else if ((choice == 1 && computer == 2) || (choice == 2 && computer == 3) || (choice == 3 && computer == 1))
            {
                playerScore++;
                Console.WriteLine("Вы победили!");
            }
            else
            {
                computerScore++;
                Console.WriteLine("Компьютер победил!");
            }
        }
    }

    static void Task20_AuthSystem()
    {
        Console.WriteLine("Задача 20. Мини-система авторизации");
        var users = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["student"] = "12345"
        };

        const int maxAttempts = 3;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            Console.Write("Логин: ");
            var login = Console.ReadLine() ?? string.Empty;
            Console.Write("Пароль: ");
            var password = Console.ReadLine() ?? string.Empty;

            if (users.TryGetValue(login, out var storedPassword) && storedPassword == password)
            {
                Console.WriteLine("Вход выполнен успешно!");
                return;
            }

            Console.WriteLine($"Неверный логин или пароль. Осталось попыток: {maxAttempts - attempt}");
            if (attempt == maxAttempts)
            {
                Console.WriteLine("Доступ заблокирован.");
                return;
            }
        }
    }

    static int[] ReadIntArray(int count, string prompt)
    {
        Console.WriteLine(prompt);
        while (true)
        {
            var text = Console.ReadLine() ?? string.Empty;
            var parts = text.Split(new[] { ' ', ',', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var values = new List<int>();

            foreach (var part in parts)
            {
                if (int.TryParse(part, out var value))
                {
                    values.Add(value);
                }
                else
                {
                    Console.WriteLine("Ввод содержит некорректное число. Повторите попытку.");
                    break;
                }
            }

            if (values.Count == count)
                return values.ToArray();

            Console.WriteLine($"Введите ровно {count} чисел.");
        }
    }

    static double ReadDouble()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
                return value;

            Console.WriteLine("Введите корректное число.");
        }
    }
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Grade { get; set; }

    public Student(string name, int age, int grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public override string ToString() => $"{Name} | Age: {Age} | Grade: {Grade}";
}

class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner)
    {
        Owner = owner;
        Balance = 0m;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма пополнения должна быть положительной.");
            return;
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма снятия должна быть положительной.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("Нельзя вывести больше, чем есть на счёте.");
            return;
        }

        Balance -= amount;
    }

    public string ShowBalance() => $"Owner: {Owner} | Balance: {Balance}";
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString() => $"Product | Name: {Name} | Price: {Price} | Quantity: {Quantity}";
}
