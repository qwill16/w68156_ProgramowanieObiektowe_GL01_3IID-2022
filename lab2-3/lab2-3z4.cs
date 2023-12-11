class Osoba
{
    private string imie;
    private string nazwisko;
    private int wiek;
    private Samochod samochod;

    public Osoba(string imie, string nazwisko, int wiek)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.wiek = wiek;
    }

    public string ImieINazwisko
    {
        get { return $"{imie} {nazwisko}"; }
    }

    public bool CzyPelnoletnia()
    {
        return wiek >= 18;
    }

    public void ZmienNazwisko(string noweNazwisko)
    {
        nazwisko = noweNazwisko;
    }

    public void UstawSamochod(Samochod nowySamochod)
    {
        samochod = nowySamochod;
    }

    public string InformacjaOSamochodzie()
    {
        if (samochod != null)
        {
            return $"Osoba {ImieINazwisko} posiada samochód marki {samochod.Marka} modelu {samochod.Model}.";
        }
        else
        {
            return $"Osoba {ImieINazwisko} nie posiada samochodu.";
        }
    }
}
