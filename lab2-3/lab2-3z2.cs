using System;

class Sumator
{
    private int[] Liczby;

    public Sumator(int[] tablicaLiczb)
    {
        Liczby = tablicaLiczb;
    }

    public int Suma()
    {
        int suma = 0;
        foreach (int liczba in Liczby)
        {
            suma += liczba;
        }
        return suma;
    }

    public int SumaPodzielnePrzez3()
    {
        int suma = 0;
        foreach (int liczba in Liczby)
        {
            if (liczba % 3 == 0)
            {
                suma += liczba;
            }
        }
        return suma;
    }

    public int IleElementow()
    {
        return Liczby.Length;
    }

    public void WypiszElementy()
    {
        Console.WriteLine("Elementy tablicy Liczby:");
        foreach (int liczba in Liczby)
        {
            Console.Write(liczba + " ");
        }
        Console.WriteLine();
    }

    public void WypiszZakres(int lowIndex, int highIndex)
    {
        Console.WriteLine($"Elementy od indeksu {lowIndex} do {highIndex}:");
        for (int i = Math.Max(0, lowIndex); i < Math.Min(Liczby.Length, highIndex + 1); i++)
        {
            Console.Write(Liczby[i] + " ");
        }
        Console.WriteLine();
    }
}
