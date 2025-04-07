using System;

public class Rechteck
{
    private Punkt p1;
    private Punkt p2;
    private Punkt p3;
    private Punkt p4;
    private Anzeige anz;

    public Rechteck()
    {
        p1 = new Punkt();
        p2 = new Punkt();
        p3 = new Punkt();
        p4 = new Punkt();
        anz = new Anzeige();
    }

    public Rechteck(Punkt p1, Punkt p2, Punkt p3, Punkt p4)
    {
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.p4 = p4;
        this.anz = new Anzeige();
    }

    public Punkt GetP1() { return p1; }
    public Punkt GetP2() { return p2; }
    public Punkt GetP3() { return p3; }
    public Punkt GetP4() { return p4; }

    public void SetP1(Punkt p) { this.p1 = p; }
    public void SetP2(Punkt p) { this.p2 = p; }
    public void SetP3(Punkt p) { this.p3 = p; }
    public void SetP4(Punkt p) { this.p4 = p; }

    public void RufeAnzeige()
    {
        double flaeche = anz.Flaeche(this);
        Console.WriteLine("Rechteck mit Eckpunkten:");
        Console.WriteLine($"P1: ({p1.GetX()}, {p1.GetY()})");
        Console.WriteLine($"P2: ({p2.GetX()}, {p2.GetY()})");
        Console.WriteLine($"P3: ({p3.GetX()}, {p3.GetY()})");
        Console.WriteLine($"P4: ({p4.GetX()}, {p4.GetY()})");
        Console.WriteLine($"Fläche: {flaeche:F2} LE²");
    }
} 