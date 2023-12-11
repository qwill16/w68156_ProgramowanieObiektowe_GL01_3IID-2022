using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Rectangle());
        shapes.Add(new Triangle());
        shapes.Add(new Circle());

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}

abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public abstract void Draw();
}

class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie prostokąta...");
    }
}

class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie trójkąta...");
    }
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie koła...");
    }
}
