using System;

public class Kreis
{
    private Punkt p1;
    private double radius;

    public Kreis()
    {
        p1 = new Punkt();
        radius = 0;
    }

    public Kreis(Punkt mittelpunkt, double radius)
    {
        this.p1 = mittelpunkt;
        this.radius = radius;
    }

    public Punkt GetMittelpunkt()
    {
        return p1;
    }

    public double GetRadius()
    {
        return radius;
    }

    public void SetMittelpunkt(Punkt p)
    {
        this.p1 = p;
    }

    public void SetRadius(double radius)
    {
        this.radius = radius;
    }

    public void RufeAnzeige()
    {
        Anzeige anzeige = new Anzeige();
        double flaeche = anzeige.Flaeche(this);
        Console.WriteLine($"Kreis mit Mittelpunkt ({p1.GetX()}, {p1.GetY()}) und Radius {radius}");
        Console.WriteLine($"Fläche: {flaeche:F2} LE²");
    }
} 