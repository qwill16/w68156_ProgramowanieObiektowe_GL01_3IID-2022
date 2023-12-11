using System;

class Licz
{
    private int wartosc;

    public Licz(int wartoscPoczatkowa)
    {
        wartosc = wartoscPoczatkowa;
    }

    public void Dodaj(int wartoscDodawana)
    {
        wartosc += wartoscDodawana;
    }

    public void Odejmij(int wartoscOdejmowana)
    {
        wartosc -= wartoscOdejmowana;
    }

    public void WypiszStan()
    {
        Console.WriteLine("Aktualna wartość: " + wartosc);
    }
}
