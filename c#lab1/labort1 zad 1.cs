using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj liczbę: ");
        int liczba = Convert.ToInt32(Console.ReadLine());

        if (liczba % 2 == 0)
        {
            Console.WriteLine("Liczba jest parzysta.");
        }
        else
        {
            Console.WriteLine("Liczba jest nieparzysta.");
        }
    }
}
