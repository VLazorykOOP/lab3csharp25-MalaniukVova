using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Завдання 1 ===");
        Task1();
        Console.WriteLine("\n=== Завдання 2 ===");
        Task2();

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey(); // Затримка перед завершенням програми
    }

    // Завдання 1 — Прямокутні трикутники
    static void Task1()
    {
        ATriangle[] triangles = new ATriangle[]
        {
            new ATriangle(3, 4, 1),
            new ATriangle(5, 5, 2),
            new ATriangle(6, 8, 3),
            new ATriangle(7, 7, 4),
        };

        int isoscelesCount = 0;

        foreach (ATriangle t in triangles)
        {
            t.PrintSides();
            Console.WriteLine($"Площа: {t.GetArea():F2}");
            Console.WriteLine($"Периметр: {t.GetPerimeter():F2}");
            if (t.IsIsosceles())
            {
                Console.WriteLine("Цей трикутник є рівнобедреним.");
                isoscelesCount++;
            }
            else
            {
                Console.WriteLine("Цей трикутник не є рівнобедреним.");
            }
            Console.WriteLine(new string('-', 40));
        }

        Console.WriteLine($"Кількість рівнобедрених трикутників: {isoscelesCount}");
    }

    // Завдання 2 — Ієрархія товарів
    static void Task2()
    {
        Product[] products = new Product[]
        {
            new Toy("Машинка", 150, 3),
            new FoodProduct("Хліб", 25, DateTime.Now.AddDays(3)),
            new DairyProduct("Молоко", 35, DateTime.Now.AddDays(5), 2.5),
            new DairyProduct("Йогурт", 40, DateTime.Now.AddDays(7), 3.2),
        };

        foreach (Product p in products)
        {
            p.Show();
            Console.WriteLine(new string('-', 40));
        }
    }
}

// ===== Клас для Завдання 1 =====

class ATriangle
{
    protected int a, b;
    protected int c;

    public ATriangle(int a, int b, int color)
    {
        this.a = a;
        this.b = b;
        this.c = color;
    }

    public int A
    {
        get { return a; }
        set { a = value; }
    }

    public int B
    {
        get { return b; }
        set { b = value; }
    }

    public int Color
    {
        get { return c; }
    }

    public void PrintSides()
    {
        double hypotenuse = GetHypotenuse();
        Console.WriteLine($"Катет a = {a}, Катет b = {b}, Гіпотенуза = {hypotenuse:F2}, Колір = {c}");
    }

    public double GetHypotenuse()
    {
        return Math.Sqrt(a * a + b * b);
    }

    public double GetPerimeter()
    {
        return a + b + GetHypotenuse();
    }

    public double GetArea()
    {
        return 0.5 * a * b;
    }

    public bool IsIsosceles()
    {
        return a == b;
    }
}

// ===== Класи для Завдання 2 =====

class Product
{
    protected string name;
    protected double price;

    public Product(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Товар: {name}, Ціна: {price} грн");
    }
}

class Toy : Product
{
    private int minAge;

    public Toy(string name, double price, int minAge)
        : base(name, price)
    {
        this.minAge = minAge;
    }

    public override void Show()
    {
        Console.WriteLine($"Іграшка: {name}, Ціна: {price} грн, Мінімальний вік: {minAge}+");
    }
}

class FoodProduct : Product
{
    protected DateTime expirationDate;

    public FoodProduct(string name, double price, DateTime expirationDate)
        : base(name, price)
    {
        this.expirationDate = expirationDate;
    }

    public override void Show()
    {
        Console.WriteLine($"Продукт: {name}, Ціна: {price} грн, Термін придатності: {expirationDate.ToShortDateString()}");
    }
}

class DairyProduct : FoodProduct
{
    private double fatContent;

    public DairyProduct(string name, double price, DateTime expirationDate, double fatContent)
        : base(name, price, expirationDate)
    {
        this.fatContent = fatContent;
    }

    public override void Show()
    {
        Console.WriteLine($"Молочний продукт: {name}, Ціна: {price} грн, Термін придатності: {expirationDate.ToShortDateString()}, Жирність: {fatContent}%");
    }
}
