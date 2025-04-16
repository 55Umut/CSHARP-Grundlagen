using System;
using System.Collections.Generic;
using System.Resources;
// Immer nutzen bei ausgaben
using ErsterCode.Grundlagen;
using ErsterCode.Grundlagen.Abstrakt;
using ErsterCode.Grundlagen.Aufgabe_Kunden;
using ErsterCode.Grundlagen.Objektorientiert;
using static ErsterCode.Grundlagen.Objektorientiert.Bubblesort;
using ErsterCode.Grundlagen.Skript_Aufgaben;
using ErsterCode.Grundlagen.Vererbung;
public class Auswertung
{
    private List<double> werte = new List<double>();

    public void AddWert(double wert)
    {
        werte.Add(wert);
    }

    public double BerechneDurchschnitt()
    {
        if (werte.Count == 0) return 0;
        double summe = 0;
        foreach (var wert in werte)
            summe += wert;
        return summe / werte.Count;
    }

    public void WerteAusgeben()
    {
        Console.WriteLine("\n======= GESPEICHERTE MESSWERTE =======");
        if (werte.Count == 0)
        {
            Console.WriteLine("Keine Messwerte vorhanden.");
            return;
        }
        
        double summe = 0;
        Console.WriteLine("Nr.\tWert");
        Console.WriteLine("-----------------");
        
        for (int i = 0; i < werte.Count; i++)
        {
            Console.WriteLine($"{i+1}\t{werte[i]}");
            summe += werte[i];
        }
        
        Console.WriteLine("-----------------");
        Console.WriteLine($"Summe aller Werte: {summe}");
        Console.WriteLine($"Anzahl der Werte: {werte.Count}");
        Console.WriteLine($"Durchschnitt: {BerechneDurchschnitt()}");
        Console.WriteLine("====================================");
    }
    
    public void ZeigeDurchschnittMitWerten()
    {
        Console.WriteLine("\n Die Werte waren ");
        
        if (werte.Count == 0)
        {
            Console.WriteLine("Keine Messwerte vorhanden.");
            return;
        }
        
        for (int i = 0; i < werte.Count; i++)
        {
            Console.WriteLine($"Messwert {i+1} = {werte[i]}");
        }
        
        Console.WriteLine($"\nDer Durchschnitt aller Messwerte beträgt: {BerechneDurchschnitt()}");
    }
    
    public void run4()
    {
        while (true)
        {
            Console.WriteLine("\n======= MESSWERTE-MANAGER =======");
            Console.WriteLine("1: Neuen Messwert hinzufügen");
            Console.WriteLine("2: Durchschnitt berechnen");
            Console.WriteLine("3: Alle Messwerte anzeigen");
            Console.WriteLine("0: Programm beenden");
            Console.WriteLine("===============================");
            Console.Write("Bitte wählen Sie eine Option (0-3): ");
            
            var eingabe = Console.ReadLine();
            
            switch (eingabe)
            {
                case "1":
                    Console.WriteLine("\nBitte geben Sie mindesten 2 Messwerte ein:");
                    Console.WriteLine("(Zum Abbrechen 'x' eingeben)");
                    
                    // Ersten Messwert eingeben
                    Console.Write("Bitte geben Sie 1 Messwert ein: ");
                    var input1 = Console.ReadLine();
                    
                    // Prüfen ob Abbruch gewünscht
                    if (input1.ToLower() == "x")
                    {
                        Console.WriteLine("Eingabe abgebrochen.");
                        break;
                    }
                    
                    // Wenn kein Abbruch, dann Wert konvertieren
                    if (double.TryParse(input1, out double wert1))
                    {
                        this.AddWert(wert1);
                        Console.WriteLine($"Messwert {wert1} wurde erfolgreich hinzugefügt.");
                    }
                    else
                    {
                        Console.WriteLine("Fehler: Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
                        break;
                    }
                    
                    // Zweiten Messwert eingeben
                    Console.Write("Bitte geben Sie 2 Messwert ein: ");
                    var input2 = Console.ReadLine();
                    
                    // Prüfen ob Abbruch gewünscht
                    if (input2.ToLower() == "x")
                    {
                        Console.WriteLine("Eingabe abgebrochen.");
                        break;
                    }
                    
                    // Wenn kein Abbruch, dann Wert konvertieren
                    if (double.TryParse(input2, out double wert2))
                    {
                        this.AddWert(wert2);
                        Console.WriteLine($"Messwert {wert2} wurde erfolgreich hinzugefügt.");
                    }
                    else
                    {
                        Console.WriteLine("Fehler: Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
                    }
                    break;
                    
                case "2":
                    this.ZeigeDurchschnittMitWerten();
                    break;
                    
                case "3":
                    this.WerteAusgeben();
                    break;
                    
                case "0":
                    Console.WriteLine("\nProgramm wird beendet. Auf Wiedersehen!");
                    return;
                    
                default:
                    Console.WriteLine("\nFehler: Ungültige Eingabe. Bitte wählen Sie eine Option zwischen 0 und 3.");
                    break;
            }
        }
    }
}