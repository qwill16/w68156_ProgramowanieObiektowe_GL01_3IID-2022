using System;

public enum StanSilnika
{
    Wlaczony,
    Wylaczony,
    CheckEngine
}

class Samochod
{
    public string Marka { get; }
    public string Model { get; }
    public int RokProdukcji { get; }

    private int predkosc;
    private int przebieg;
    private StanSilnika stanSilnika;

    public Samochod(string marka, string model, int rokProdukcji, int predkoscPoczatkowa, int przebiegPoczatkowy, StanSilnika poczatkowyStanSilnika)
    {
        Marka = marka;
        Model = model;
        RokProdukcji = rokProdukcji;
        predkosc = predkoscPoczatkowa;
        przebieg = przebiegPoczatkowy;
        stanSilnika = poczatkowyStanSilnika;
    }

    public void UstawTempomat(int nowaPredkosc)
    {
        if (stanSilnika == StanSilnika.Wlaczony)
        {
            predkosc = nowaPredkosc;
        }
    }

    public void ZwiekszPredkosc()
    {
        if (stanSilnika == StanSilnika.Wlaczony)
        {
            predkosc += 5;
        }
    }

    public void ZmniejszPredkosc()
    {
        if (stanSilnika == StanSilnika.Wlaczony)
        {
            predkosc -= 5;
        }
    }

    public void UruchomSilnik()
    {
        if (przebieg >= 10000)
        {
            stanSilnika = StanSilnika.CheckEngine;
            throw new InvalidOperationException("Nie można uruchomić silnika - check engine!");
        }
        else
        {
            stanSilnika = StanSilnika.Wlaczony;
        }
    }

    public void ZatrzymajSilnik()
    {
        stanSilnika = StanSilnika.Wylaczony;
    }

    public double PrzejedzDystans(int dystans)
    {
        if (stanSilnika == StanSilnika.Wylaczony)
        {
            throw new InvalidOperationException("Nie można jechać - silnik jest wyłączony!");
        }

        double czas = dystans / (double)predkosc;
        przebieg += dystans;

        if (przebieg >= 10000)
        {
            stanSilnika = StanSilnika.CheckEngine;
            throw new InvalidOperationException("Nie można jechać - check engine!");
        }

        return czas;
    }

    public void NaprawSilnik()
    {
        stanSilnika = StanSilnika.Wlaczony;
    }

    public int Predkosc
    {
        get { return predkosc; }
    }
}
