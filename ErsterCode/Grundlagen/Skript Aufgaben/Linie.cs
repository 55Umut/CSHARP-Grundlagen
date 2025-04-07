using System;

public class Linie
{
    private Punkt p1;
    private Punkt p2;

    public Linie()
    {
        p1 = new Punkt();
        p2 = new Punkt();
    }

    public Linie(Punkt p1, Punkt p2)
    {
        this.p1 = p1;
        this.p2 = p2;
    }

    public Punkt GetP1()
    {
        return p1;
    }

    public Punkt GetP2()
    {
        return p2;
    }

    public void SetP1(Punkt p)
    {
        this.p1 = p;
    }

    public void SetP2(Punkt p)
    {
        this.p2 = p;
    }

    public void RufeAnzeige()
    {
        Anzeige anzeige = new Anzeige();
        double laenge = anzeige.Laenge(this);
        Console.WriteLine($"Linie von ({p1.GetX()}, {p1.GetY()}) nach ({p2.GetX()}, {p2.GetY()})");
        Console.WriteLine($"Länge: {laenge:F2} LE");
    }
} 