using System;
using System.Collections.Generic;

abstract class Osoba
{
    public string Imie { get; private set; }
    public string Nazwisko { get; private set; }
    public string Pesel { get; private set; }

    public void SetFirstName(string imie)
    {
        Imie = imie;
    }

    public void SetLastName(string nazwisko)
    {
        Nazwisko = nazwisko;
    }

    public void SetPesel(string pesel)
    {
        Pesel = pesel;
    }

    public int GetAge()
    {
        int year = int.Parse("19" + Pesel.Substring(0, 2)); // Założenie dla osób urodzonych przed 2000 rokiem
        int currentYear = DateTime.Now.Year;
        return currentYear - year;
    }

    public string GetGender()
    {
        int genderPosition = int.Parse(Pesel.Substring(9, 1));
        return (genderPosition % 2 == 0) ? "Kobieta" : "Mężczyzna";
    }

    public abstract string GetEducationInfo();

    public string GetFullName()
    {
        return $"{Imie} {Nazwisko}";
    }

    public abstract bool CanGoAloneToHome();
}

class Uczen : Osoba
{
    public string Szkola { get; private set; }
    public bool MozeSamWracacDoDomu { get; private set; }

    public void SetSchool(string szkola)
    {
        Szkola = szkola;
    }

    public void ChangeSchool(string nowaSzkola)
    {
        Szkola = nowaSzkola;
    }

    public void SetCanGoHomeAlone(bool canGoHome, int age)
    {
        MozeSamWracacDoDomu = canGoHome && age >= 12;
    }

    public override string GetEducationInfo()
    {
        return $"Uczeń uczęszcza do szkoły: {Szkola}";
    }

    public override bool CanGoAloneToHome()
    {
        return MozeSamWracacDoDomu;
    }
}

class Nauczyciel : Uczen
{
    public string TytulNaukowy { get; private set; }
    public List<Uczen> PodwladniUczniowie { get; private set; }

    public void AddStudent(Uczen uczen)
    {
        if (PodwladniUczniowie == null)
        {
            PodwladniUczniowie = new List<Uczen>();
        }

        PodwladniUczniowie.Add(uczen);
    }

    public void WhichStudentCanGoHomeAlone()
    {
        if (PodwladniUczniowie != null)
        {
            Console.WriteLine("Uczniowie, którzy mogą iść sami do domu:");

            foreach (var uczen in PodwladniUczniowie)
            {
                if (uczen.CanGoAloneToHome())
                {
                    Console.WriteLine(uczen.GetFullName());
                }
            }
        }
    }

    public void ShowSchoolDayInfo(string school, DayOfWeek day, string title, string tFirstName, string tLastName)
    {
        Console.WriteLine($"{school} Dnia: {day}");
        Console.WriteLine($"Nauczyciel: {title} {tFirstName} {tLastName}");
        Console.WriteLine("Lista studentów:");

        if (PodwladniUczniowie != null)
        {
            int lp = 1;
            foreach (var uczen in PodwladniUczniowie)
            {
                Console.WriteLine($"{lp}. {uczen.GetFullName()} - {uczen.GetGender()} - {uczen.CanGoAloneToHome()}");
                lp++;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Przykładowe użycie klasy Nauczyciel i Uczen
        Uczen uczen1 = new Uczen();
        uczen1.SetFirstName("Maciek");
        uczen1.SetLastName("Kowalski");
        uczen1.SetPesel("89090579832");
        uczen1.SetSchool("Szkoła Podstawowa Nr 1");
        uczen1.SetCanGoHomeAlone(true, uczen1.GetAge());

        Uczen uczen2 = new Uczen();
        uczen2.SetFirstName("Anna");
        uczen2.SetLastName("Nowak");
        uczen2.SetPesel("14290591715");
        uczen2.SetSchool("Szkoła Podstawowa Nr 2");
        uczen2.SetCanGoHomeAlone(false, uczen2.GetAge());

        Nauczyciel nauczyciel = new Nauczyciel();
        nauczyciel.SetFirstName("Maria");
        nauczyciel.SetLastName("Wójcik");
        nauczyciel.SetPesel("75121298765");
        nauczyciel.TytulNaukowy = "mgr";
        nauczyciel.AddStudent(uczen1);
        nauczyciel.AddStudent(uczen2);

        nauczyciel.WhichStudentCanGoHomeAlone(); // Wyświetlenie uczniów, którzy mogą wrócić do domu sami

        nauczyciel.ShowSchoolDayInfo("Szkoła Podstawowa", DayOfWeek.Monday, nauczyciel.TytulNaukowy, nauczyciel.Imie, nauczyciel.Nazwisko);
    }
}
