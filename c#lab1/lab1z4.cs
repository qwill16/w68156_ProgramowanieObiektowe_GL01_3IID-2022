using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj liczbę dla której chcesz obliczyć silnię: ");
        int liczba = Convert.ToInt32(Console.ReadLine());

        long silnia = ObliczSilnie(liczba);
        Console.WriteLine("Silnia z liczby " + liczba + " wynosi: " + silnia);
    }

    static long ObliczSilnie(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Silnia jest zdefiniowana tylko dla liczb nieujemnych.");
        }

        if (n == 0 || n == 1)
        {
            return 1;
        }

        long wynik = 1;
        for (int i = 2; i <= n; i++)
        {
            wynik *= i;
        }
        return wynik;
    }
}
