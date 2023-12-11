using System;

class Program
{
    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1. Sprawdź czy liczba jest parzysta czy nieparzysta");
            Console.WriteLine("2. Wypisz parzyste liczby od 1 do N");
            Console.WriteLine("3. Wyjdź z programu");
            Console.WriteLine("Wybierz opcję (1-3): ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    SprawdzParzystosc();
                    break;
                case 2:
                    WypiszParzyste();
                    break;
                case 3:
                    exit = true;
                    Console.WriteLine("Wybrano wyjście z programu.");
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Wybierz liczbę od 1 do 3.");
                    break;
            }
        }
    }

    static void SprawdzParzystosc()
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

    static void WypiszParzyste()
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
