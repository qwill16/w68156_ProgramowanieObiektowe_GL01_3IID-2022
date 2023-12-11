using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int min = 1;
        int max = 100; // Zakres od 1 do 100, można go zmienić wedle potrzeb

        int liczba = random.Next(min, max + 1);
        int proby = 0;
        bool odgadniete = false;

        Console.WriteLine("Komputer wylosował liczbę z zakresu od " + min + " do " + max + ". Spróbuj ją odgadnąć!");

        while (!odgadniete)
        {
            Console.Write("Podaj swoją propozycję liczby: ");
            int propozycja;

            if (!int.TryParse(Console.ReadLine(), out propozycja))
            {
                Console.WriteLine("To nie jest poprawna liczba!");
                continue;
            }

            proby++;

            if (propozycja < liczba)
            {
                Console.WriteLine("Podana liczba jest za mała. Spróbuj ponownie.");
            }
            else if (propozycja > liczba)
            {
                Console.WriteLine("Podana liczba jest za duża. Spróbuj ponownie.");
            }
            else
            {
                Console.WriteLine("Brawo! Odgadłeś liczbę " + liczba + " w " + proby + " próbach.");
                odgadniete = true;
            }
        }
    }
}
