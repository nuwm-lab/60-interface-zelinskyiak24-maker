using System;

namespace Lab_AbstractClassesAndInterfaces_Task8
{
    public interface IShape
    {
        void SetCoefficients();
        void PrintCoefficients();

        bool ContainsPoint(double x, double y);
        bool ContainsPoint(double x, double y, double z);
    }

    public abstract class ShapeBase : IShape
    {
        public string Name { get; protected set; }

        protected ShapeBase(string name)
        {
            Name = name;
        }

        ~ShapeBase()
        {
        }

        public abstract void SetCoefficients();
        public abstract void PrintCoefficients();

        public abstract bool ContainsPoint(double x, double y);
        public abstract bool ContainsPoint(double x, double y, double z);

        public static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                    return value;

                Console.WriteLine("Помилка: введіть число ще раз.");
            }
        }

        protected static void EnsureOrder(ref double b, ref double a)
        {
            if (b > a)
            {
                double t = b;
                b = a;
                a = t;
            }
        }
    }

    public class Rectangle : ShapeBase
    {
        public double B1 { get; private set; }
        public double A1 { get; private set; }
        public double B2 { get; private set; }
        public double A2 { get; private set; }

        public Rectangle() : base("Прямокутник")
        {
            B1 = 0;
            A1 = 0;
            B2 = 0;
            A2 = 0;
        }

        public Rectangle(double b1, double a1, double b2, double a2) : base("Прямокутник")
        {
            EnsureOrder(ref b1, ref a1);
            EnsureOrder(ref b2, ref a2);

            B1 = b1;
            A1 = a1;
            B2 = b2;
            A2 = a2;
        }

        ~Rectangle()
        {
        }

        public override void SetCoefficients()
        {
            double b1 = ReadDouble("Введіть b1 (для x): ");
            double a1 = ReadDouble("Введіть a1 (для x): ");
            double b2 = ReadDouble("Введіть b2 (для y): ");
            double a2 = ReadDouble("Введіть a2 (для y): ");

            EnsureOrder(ref b1, ref a1);
            EnsureOrder(ref b2, ref a2);

            B1 = b1;
            A1 = a1;
            B2 = b2;
            A2 = a2;
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"[{Name}] Умови:");
            Console.WriteLine($"b1 ≤ x ≤ a1 : {B1} ≤ x ≤ {A1}");
            Console.WriteLine($"b2 ≤ y ≤ a2 : {B2} ≤ y ≤ {A2}");
        }

        public override bool ContainsPoint(double x, double y)
        {
            return x >= B1 && x <= A1 && y >= B2 && y <= A2;
        }

        public override bool ContainsPoint(double x, double y, double z)
        {
            return ContainsPoint(x, y);
        }
    }

    public class Parallelepiped : Rectangle
    {
        public double B3 { get; private set; }
        public double A3 { get; private set; }

        public Parallelepiped() : base()
        {
            Name = "Паралелепіпед";
            B3 = 0;
            A3 = 0;
        }

        public Parallelepiped(double b1, double a1, double b2, double a2, double b3, double a3)
            : base(b1, a1, b2, a2)
        {
            Name = "Паралелепіпед";
            EnsureOrder(ref b3, ref a3);
            B3 = b3;
            A3 = a3;
        }

        ~Parallelepiped()
        {
        }

        public override void SetCoefficients()
        {
            base.SetCoefficients();

            double b3 = ReadDouble("Введіть b3 (для z): ");
            double a3 = ReadDouble("Введіть a3 (для z): ");

            EnsureOrder(ref b3, ref a3);

            B3 = b3;
            A3 = a3;
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"[{Name}] Умови:");
            Console.WriteLine($"b1 ≤ x ≤ a1 : {B1} ≤ x ≤ {A1}");
            Console.WriteLine($"b2 ≤ y ≤ a2 : {B2} ≤ y ≤ {A2}");
            Console.WriteLine($"b3 ≤ z ≤ a3 : {B3} ≤ z ≤ {A3}");
        }

        public override bool ContainsPoint(double x, double y, double z)
        {
            return base.ContainsPoint(x, y) && z >= B3 && z <= A3;
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Rectangle rectangle = new Rectangle();
            Parallelepiped parallelepiped = new Parallelepiped();

            Console.WriteLine("=== Налаштування прямокутника ===");
            rectangle.SetCoefficients();
            rectangle.PrintCoefficients();

            Console.WriteLine();
            Console.WriteLine("=== Налаштування паралелепіпеда ===");
            parallelepiped.SetCoefficients();
            parallelepiped.PrintCoefficients();

            Console.WriteLine();
            Console.WriteLine("=== Перевірка точки для прямокутника (x, y) ===");
            double x2 = ShapeBase.ReadDouble("Введіть x: ");
            double y2 = ShapeBase.ReadDouble("Введіть y: ");

            bool inRect = rectangle.ContainsPoint(x2, y2);
            Console.WriteLine(inRect ? "Точка належить прямокутнику." : "Точка НЕ належить прямокутнику.");

            Console.WriteLine();
            Console.WriteLine("=== Перевірка точки для паралелепіпеда (x, y, z) ===");
            double x3 = ShapeBase.ReadDouble("Введіть x: ");
            double y3 = ShapeBase.ReadDouble("Введіть y: ");
            double z3 = ShapeBase.ReadDouble("Введіть z: ");

            bool inPar = parallelepiped.ContainsPoint(x3, y3, z3);
            Console.WriteLine(inPar ? "Точка належить паралелепіпеду." : "Точка НЕ належить паралелепіпеду.");

            Console.ReadLine();
        }
    }
}
