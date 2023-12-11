using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj liczbę N: ");
        int N = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Parzyste liczby od 1 do " + N + " to:");
        for (int i = 1; i <= N; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
