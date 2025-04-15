using System;
using System.Collections.Generic;

public class Auswertung
{
    private List<double> werte = new List<double>();

    // Messwert hinzufügen
    public void AddWert(double wert)
    {
        werte.Add(wert);
    }

    // Durchschnitt berechnen
    public double BerechneDurchschnitt()
    {
        if (werte.Count == 0) return 0;
        double summe = 0;
        foreach (var wert in werte)
            summe += wert;
        return summe / werte.Count;
    }

    // Alle Werte ausgeben
    public void WerteAusgeben()
    {
        Console.WriteLine("Messwerte:");
        foreach (var wert in werte)
            Console.WriteLine(wert);
    }
}

// Beispiel für eine einfache Konsolen-Benutzeroberfläche
class Program
{
    static void run4()
    {
        Auswertung auswertung = new Auswertung();
        while (true)
        {
            Console.WriteLine("\n1: Wert hinzufügen, 2: Durchschnitt, 3: Werte anzeigen, 0: Beenden");
            var eingabe = Console.ReadLine();
            if (eingabe == "1")
            {
                Console.Write("Wert eingeben: ");
                if (double.TryParse(Console.ReadLine(), out double wert))
                    auswertung.AddWert(wert);
            }
            else if (eingabe == "2")
            {
                Console.WriteLine("Durchschnitt: " + auswertung.BerechneDurchschnitt());
            }
            else if (eingabe == "3")
            {
                auswertung.WerteAusgeben();
            }
            else if (eingabe == "0")
            {
                break;
            }
        }
    }
}