using System;
using System.Collections.Generic;

public class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public virtual void Draw()
    {
        Console.WriteLine("Rysowanie kształtu...");
    }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie prostokąta o wymiarach: {0} x {1} na pozycji ({2}, {3})", Width, Height, X, Y);
    }
}

public class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie trójkąta o wysokości {0} i szerokości {1} na pozycji ({2}, {3})", Height, Width, X, Y);
    }
}

public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie koła o promieniu {0} na pozycji ({1}, {2})", Width / 2, X, Y);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Rectangle { X = 10, Y = 20, Width = 30, Height = 40 });
        shapes.Add(new Triangle { X = 15, Y = 25, Width = 35, Height = 45 });
        shapes.Add(new Circle { X = 5, Y = 10, Width = 50, Height = 50 });

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}
