using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Wybierz rodzaj przeliczenia:");
        Console.WriteLine("1. Przeliczanie temperatury (Celsjusz -> Fahrenheit)");
        Console.WriteLine("2. Przeliczanie temperatury (Fahrenheit -> Celsjusz)");
        Console.WriteLine("3. Przeliczanie długości (metry -> centymetry)");
        Console.WriteLine("4. Przeliczanie długości (centymetry -> metry)");
        Console.WriteLine("Wybierz opcję (1-4): ");

        int opcja = Convert.ToInt32(Console.ReadLine());

        switch (opcja)
        {
            case 1:
                PrzeliczCelsjuszaNaFahrenheita();
                break;
            case 2:
                PrzeliczFahrenheitaNaCelsjusza();
                break;
            case 3:
                PrzeliczMetryNaCentymetry();
                break;
            case 4:
                PrzeliczCentymetryNaMetry();
                break;
            default:
                Console.WriteLine("Niepoprawny wybór.");
                break;
        }
    }

    static void PrzeliczCelsjuszaNaFahrenheita()
    {
        Console.WriteLine("Podaj temperaturę w stopniach Celsjusza: ");
        double celsjusz = Convert.ToDouble(Console.ReadLine());

        double fahrenheit = (celsjusz * 9 / 5) + 32;
        Console.WriteLine(celsjusz + " stopni Celsjusza to " + fahrenheit + " stopni Fahrenheita.");
    }

    static void PrzeliczFahrenheitaNaCelsjusza()
    {
        Console.WriteLine("Podaj temperaturę w stopniach Fahrenheita: ");
        double fahrenheit = Convert.ToDouble(Console.ReadLine());

        double celsjusz = (fahrenheit - 32) * 5 / 9;
        Console.WriteLine(fahrenheit + " stopni Fahrenheita to " + celsjusz + " stopni Celsjusza.");
    }

    static void PrzeliczMetryNaCentymetry()
    {
        Console.WriteLine("Podaj długość w metrach: ");
        double metry = Convert.ToDouble(Console.ReadLine());

        double centymetry = metry * 100;
        Console.WriteLine(metry + " metrów to " + centymetry + " centymetrów.");
    }

    static void PrzeliczCentymetryNaMetry()
    {
        Console.WriteLine("Podaj długość w centymetrach: ");
        double centymetry = Convert.ToDouble(Console.ReadLine());

        double metry = centymetry / 100;
        Console.WriteLine(centymetry + " centymetrów to " + metry + " metrów.");
    }
}
