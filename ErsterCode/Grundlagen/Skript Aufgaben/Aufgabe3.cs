using System;

namespace ErsterCode.Grundlagen.Skript_Aufgaben
{
    public class Aufgabe3
    {
        public static void Inhalt_Aufgabe3()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Aufgabe 3.1: Berechnung der Spareinlage mit Zinseszins
            string frage3_1 =
                "AUFGABE 3\nBerechnung von Spareinlagen mit Ein- und Ausgaben\nLaufzeit: 3 Jahre (ACHTUNG: Zinseszins)\n";
            int laufzeit = 3;

            Console.Write("Wieviel Geld möchten Sie sparen? : ");
            float spareinlage = float.Parse(Console.ReadLine());

            Console.Write("Wieviel Zinsen soll es sein? : ");
            float zins = float.Parse(Console.ReadLine());

            // Berechnung des Endkapitals mit Zinseszins (in float)
            float endkapital = spareinlage * (float)Math.Pow((1 + zins / 100), laufzeit);

            // Formatierte Ausgabe mit drei Nachkommastellen
            string antwort3_1 = $"Deine Sparsumme beträgt: {spareinlage:F3} €\n" +
                                $"Dein Zinssatz beträgt: {zins:F3} %\n" +
                                $"Die Laufzeit beträgt: {laufzeit} Jahre\n" +
                                $"Das Ergebnis ist: {endkapital:F3} €\n";

            Console.WriteLine(frage3_1);
            Console.WriteLine(antwort3_1);

            // Aufgabe 3.2: ASCII-Werte von "ABBA"
            string frage3_2 = "AUFGABE 3_2: ASCII-Werte von 'ABBA'\n";
            string text = "ABBA"; // Hier wird "ABBA" korrekt definiert
            string Antwort3_2 = frage3_2; // Initialisiere den Antwort-String mit der Frage

            // String, um die ASCII-Werte zu sammeln
            string asciiValues = "";

            foreach (char c in text)
            {
                Antwort3_2 += $"Zeichen: {c} -> ASCII: {(int)c}\n";
                asciiValues += $"{(int)c} ";
            }

            // Ausgabe der gesamten Antwort für 3.2
            Console.WriteLine(Antwort3_2);

            // Aufgabe 3.3: Gewinnberechnung anhand von Fixkosten, Produktkosten und Erlös für Einzel- und Gesamtberechnung
            string Frage3_3 =
                "Gewinnberechnung anhand von Fixkosten, Produktkosten und Erlös für Einzel- und Gesamtberechnung\n";

            // Frage nach den Fixkosten
            Console.Write("Geben Sie die Fixkosten ein: ");
            float fixkosten = float.Parse(Console.ReadLine());
            string FrageFix = $"Fixkosten: {fixkosten:C}\n";

            // Frage nach den Produktkosten pro Stück
            Console.Write("Geben Sie die Produktkosten pro Stück ein: ");
            float produktkosten = float.Parse(Console.ReadLine());
            string FrageEinzel = $"Produktkosten pro Stück: {produktkosten:C}\n";

            // Frage nach der Menge der verkauften Produkte
            Console.Write("Geben Sie die Menge der verkauften Produkte ein: ");
            int menge = int.Parse(Console.ReadLine());
            string FrageMenge = $"Menge der verkauften Produkte: {menge}\n";

            // Frage nach dem Verkaufspreis pro Stück
            Console.Write("Geben Sie den Verkaufspreis pro Produkt ein: ");
            float verkaufspreis = float.Parse(Console.ReadLine());

            // Berechnungen
            float gesamtkosten = fixkosten + (produktkosten * menge); // Fixkosten + Produktkosten
            float gesamtErlös = verkaufspreis * menge; // Erlös = Verkaufspreis * Menge
            float gesamtGewinn = gesamtErlös - gesamtkosten; // Gesamtgewinn = Erlös - Gesamtkosten
            float einzelgewinn = verkaufspreis - produktkosten; // Gewinn pro Stück = Verkaufspreis - Produktkosten

            // Antworten zusammenstellen
            string FrageEinzelgewinn = $"Einzelgewinn pro Produkt: {einzelgewinn:C}\n";
            string FrageGesamtgewinn = $"Gesamtgewinn: {gesamtGewinn:C}\n";

            // Gesamte Antwort für 3.3
            string Antwort3_3 = FrageFix + FrageEinzel + FrageMenge + FrageEinzelgewinn + FrageGesamtgewinn;

            // Ausgabe der Fragen und Antworten
            Console.WriteLine(Frage3_3);
            Console.WriteLine(Antwort3_3);

            // Aufgabe 3_4: Lösen einer linearen Gleichung
            Console.WriteLine("\nAUFGABE 3_4: Lösung einer linearen Gleichung (a * x + b = 0)");

            // Eingabe von a und b
            Console.Write("Geben Sie den Wert für a ein: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Geben Sie den Wert für b ein: ");
            double b = Convert.ToDouble(Console.ReadLine());

            if (a != 0)
            {
                double x = -b / a;
                Console.WriteLine($"Die Lösung der Gleichung {a} * x + {b} = 0 ist: x = {x:F3}");
            }
            else
            {
                Console.WriteLine("Die Gleichung hat keine Lösung, da 'a' gleich 0 ist.");
            }
        }
    }
}