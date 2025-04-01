using System;

namespace ErsterCode.Grundlagen.Skript_Aufgaben
{
    public class Aufgabe5
    {
        public static void Inhalt_Aufgabe5()
        {
            string Frage5_1 =
                "Bitte geben Sie 3 float Zahlen ein und nutzen nur 3 IF Abfragen das Minimum oder Maximum auszugeben \n";
            Console.WriteLine(Frage5_1);

            float Zahl1 = float.Parse(Console.ReadLine());
            float Zahl2 = float.Parse(Console.ReadLine());
            float Zahl3 = float.Parse(Console.ReadLine());

            float min = Zahl1;
            float max = Zahl2;

            if (Zahl1 > Zahl2)
            {
                max = Zahl1;
                min = Zahl2;
            }

            if (Zahl3 < Zahl1 && Zahl3 < Zahl2)
            {
                min = Zahl3;
            }

            if (Zahl3 > Zahl2 && Zahl3 > Zahl1)
            {
                max = Zahl3;
            }

            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");

            // Aufgabe 5.2: Datumseingabe und Schaltjahrprüfung
            string Frage5_2 =
                "Zahlen für ein Datum eingeben mit 3 int Variablen, um herauszufinden, ob es ein Schaltjahr war oder nicht.\n";
            Console.WriteLine(Frage5_2);

            bool eingabenGueltig = false; // Kontrollvariable für die Schleife

            while (!eingabenGueltig) // Schleife läuft so lange, bis die Eingaben gültig sind
            {
                // Eingabe der Variablen
                Console.Write("Geben Sie den Tag ein: ");
                int tag = Convert.ToInt32(Console.ReadLine());

                Console.Write("Geben Sie den Monat ein: ");
                int monat = Convert.ToInt32(Console.ReadLine());

                Console.Write("Geben Sie das Jahr ein: ");
                int jahr = Convert.ToInt32(Console.ReadLine());

                // Überprüfen, ob die Eingaben gültig sind (Monat, Tag und Jahr)
                if (monat >= 1 && monat <= 12 && tag >= 1 && tag <= 31 && jahr >= 0)
                {
                    eingabenGueltig = true; // Eingaben sind gültig, Schleife wird beendet

                    // Schaltjahrprüfung
                    if (DateTime.IsLeapYear(jahr))
                    {
                        Console.WriteLine($"{jahr} war ein Schaltjahr.");
                    }
                    else
                    {
                        Console.WriteLine($"{jahr} war kein Schaltjahr.");
                    }

                    // Überprüfung, ob das eingegebene Datum tatsächlich existiert
                    try
                    {
                        DateTime datum = new DateTime(jahr, monat, tag);
                        Console.WriteLine($"Das eingegebene Datum {datum.ToString("dd.MM.yyyy")} ist gültig.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Das eingegebene Datum ist ungültig.");
                        eingabenGueltig = false; // Falls das Datum ungültig ist, wird die Schleife fortgesetzt
                    }
                }
                else
                {
                    // Ungültige Eingabe, Benutzer wird erneut zur Eingabe aufgefordert
                    Console.WriteLine("Die Eingaben sind ungültig. Bitte stellen Sie sicher:");
                    Console.WriteLine("- Monat muss zwischen 1 und 12 liegen.");
                    Console.WriteLine("- Tag darf nicht größer als 31 sein.");
                    Console.WriteLine("- Jahr muss größer oder gleich 0 sein.");
                }
            }

            string Frage5_3 =
                "Bestimme anhand vom Vorgabe Code die integer i , k , j und ihre werte \n";
            Console.WriteLine(Frage5_3);
            int i, j, k;
            k = 0;
            for (i = 1; i < 10; i = i + 1) k = k + i;
            {
                Console.WriteLine("Wert von k : " + k + "\n");
            }

            Console.WriteLine("----------------------\n");

            k = 0;
            for (i = 2; i < 10; i = i + 2) k = k + i;
            {
                Console.WriteLine("Wert von k : " + k + "\n");
            }

            Console.WriteLine("++++++++++++++++++++++++\n");

            k = 0;
            for (i = 1, j = 5; (i < 5) && (j > 1); i++, j--) k = k + i * j;
            {
                Console.WriteLine("Wert von k : " + k + "\n");
            }

            Console.WriteLine("**************************\n");

            k = 0;
            for (i = 1; i < 5; i++)
            {
                if (i == 3) continue;
                k = k + i;
            }

            Console.WriteLine("Wert von k : " + k + "\n");


            Console.WriteLine(":::::::::::::::::::::::::::::::\n");

            k = 0;
            for (i = 1; i < 10; i++)
            {
                k = k + i;
                if (i == 6) break;
            }

            Console.WriteLine("Wert von k : " + k + "\n");

            string Frage5_4 =
                "Mit nur 2 Forschleifen ausgabe von 10 bis 0 zählen \n";
            Console.WriteLine(Frage5_4);

            // Erste Schleife: Startet bei 10 und zählt bis 0
            for (i = 10; i >= 0; i--)
            {
                // Zweite Schleife: Gibt die Zahlen von i bis 0 aus
                for (j = i; j >= 0; j--)
                {
                    Console.Write(j + " ");
                }

                Console.WriteLine(); // Zeilenumbruch nach jeder inneren Schleife
            }

            string Frage5_5 =
                "Folgende Probleme gilt es zu lösen: Es sollen Integer-Zahlen von der Tastatur eingelesen werden und dann:\n" +
                "\n" +
                "Programm1: Alle natürlichen Zahlen bis zu dieser Zahl von 1 beginnend anzeigen.\n" +
                "\n" +
                "Programm2: In 2er-Schritten bis 2 runterzählen.\n" +
                "\n" +
                "Programm3: Von 1 bis 10 zählen und wieder zurück (ACHTUNG: Nur 1 Forschleife für Programm3).\n" +
                "\n";

            Console.WriteLine(Frage5_5);

            // Eingabe der Zahlen
            Console.Write("Bitte geben Sie die Zahl für Programm1 ein: \n");
            int zahl1 = Convert.ToInt32(Console.ReadLine()); // Zahl für Programm1

            Console.Write("Bitte geben Sie die Zahl für Programm2 ein: \n");
            int zahl2 = Convert.ToInt32(Console.ReadLine()); // Zahl für Programm2

            // Programm1: Alle natürlichen Zahlen bis zur eingegebenen Zahl anzeigen
            Console.WriteLine("\nProgramm1: Alle natürlichen Zahlen bis zur eingegebenen Zahl: \n");
            for (i = 1; i <= zahl1; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            // Programm2: In 2er-Schritten bis 2 runterzählen
            Console.WriteLine("\n ---------- Programm2: In 2er-Schritten bis 2 runterzählen: \n");
            for (i = zahl2; i >= 2; i -= 2)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            // Programm3: Von 1 bis 10 zählen und wieder zurück mit nur einer Forschleife
            Console.WriteLine("\n +++++++++++++++ Programm3: Von 1 bis 10 zählen und wieder zurück:");
            for (i = 1; i <= 19; i++)
            {
                int output = (i <= 10) ? i : (20 - i);
                Console.Write(output + " ");
            }

            Console.WriteLine();
        }
    }
}