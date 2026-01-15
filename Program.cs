using System;

class Sphere
{
    double x, y, z;
    double r;

    public void Input()
    {
        Console.Write("x центра: ");
        x = double.Parse(Console.ReadLine());

        Console.Write("y центра: ");
        y = double.Parse(Console.ReadLine());

        Console.Write("z центра: ");
        z = double.Parse(Console.ReadLine());

        Console.Write("R: ");
        r = double.Parse(Console.ReadLine());
    }

    public void Print()
    {
        Console.WriteLine("Куля");
        Console.WriteLine($"Центр: ({x}, {y}, {z})");
        Console.WriteLine($"R = {r}");
    }

    public double Volume()
    {
        return 4.0 / 3.0 * Math.PI * r * r * r;
    }
}

class Ellipsoid
{
    double x, y, z;
    double a, b, c;

    public void Input()
    {
        Console.Write("x центра: ");
        x = double.Parse(Console.ReadLine());

        Console.Write("y центра: ");
        y = double.Parse(Console.ReadLine());

        Console.Write("z центра: ");
        z = double.Parse(Console.ReadLine());

        Console.Write("a: ");
        a = double.Parse(Console.ReadLine());

        Console.Write("b: ");
        b = double.Parse(Console.ReadLine());

        Console.Write("c: ");
        c = double.Parse(Console.ReadLine());
    }

    public void Print()
    {
        Console.WriteLine("Еліпсоїд");
        Console.WriteLine($"Центр: ({x}, {y}, {z})");
        Console.WriteLine($"a={a}, b={b}, c={c}");
    }

    public double Volume()
    {
        return 4.0 / 3.0 * Math.PI * a * b * c;
    }
}

class Program
{
    static void Main()
    {
        Sphere s = new Sphere();
        Ellipsoid e = new Ellipsoid();

        Console.WriteLine("Ввід даних для кулі");
        s.Input();
        Console.WriteLine();

        Console.WriteLine("Ввід даних для еліпсоїда");
        e.Input();
        Console.WriteLine();

        s.Print();
        Console.WriteLine("Об'єм кулі = " + s.Volume());
        Console.WriteLine();

        e.Print();
        Console.WriteLine("Об'єм еліпсоїда = " + e.Volume());
    }
}
