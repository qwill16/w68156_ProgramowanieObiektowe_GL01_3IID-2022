using System;

// Definicja klasy abstrakcyjnej Shape
public abstract class Shape
{
    public abstract double CalculateArea();
}

// Klasa Circle dziedziczšca po klasie Shape
public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

// Klasa Square dziedziczšca po klasie Shape
public class Square : Shape
{
    public double SideLength { get; set; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public override double CalculateArea()
    {
        return Math.Pow(SideLength, 2);
    }
}

// Przykłady użycia
class Program
{
    static void Main()
    {
        Circle circle = new Circle(5);
        Square square = new Square(4);

        Console.WriteLine($"Powierzchnia koła: {circle.CalculateArea()}");
        Console.WriteLine($"Powierzchnia kwadratu: {square.CalculateArea()}");
    }
}