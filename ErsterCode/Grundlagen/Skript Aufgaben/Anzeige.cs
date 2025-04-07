using System;

public class Anzeige
{
    public void Anzeigen()
    {
        Console.WriteLine("Anzeige-Objekt für geometrische Formen");
        Console.WriteLine("Methoden zur Berechnung von:");
        Console.WriteLine("- Flächeninhalten von Rechtecken und Kreisen");
        Console.WriteLine("- Längen von Linien");
    }

    public double Flaeche(Kreis k)
    {
        return Math.PI * Math.Pow(k.GetRadius(), 2);
    }

    public double Flaeche(Rechteck r)
    {
        // Berechnung der Rechteckfläche
        double breite = Math.Abs(r.GetP2().GetX() - r.GetP1().GetX());
        double hoehe = Math.Abs(r.GetP2().GetY() - r.GetP3().GetY());
        return breite * hoehe;
    }

    public double Laenge(Linie l)
    {
        double dx = l.GetP2().GetX() - l.GetP1().GetX();
        double dy = l.GetP2().GetY() - l.GetP1().GetY();
        return Math.Sqrt(dx * dx + dy * dy);
    }
} 