﻿using System;

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

            bool eingabenGueltig = false; // Kontrollvariable

            while (!eingabenGueltig) // Schleife läuft 
            {
                
                Console.Write("Geben Sie den Tag ein: ");
                int tag = Convert.ToInt32(Console.ReadLine());

                Console.Write("Geben Sie den Monat ein: ");
                int monat = Convert.ToInt32(Console.ReadLine());

                Console.Write("Geben Sie das Jahr ein: ");
                int jahr = Convert.ToInt32(Console.ReadLine());

                // Eingaben gültig ? (Monat, Tag und Jahr)
                if (monat >= 1 && monat <= 12 && tag >= 1 && tag <= 31 && jahr >= 0)
                {
                    eingabenGueltig = true; //schleife wird beendet

                    // Schaltjahr
                    if (DateTime.IsLeapYear(jahr))
                    {
                        Console.WriteLine($"{jahr} war ein Schaltjahr.");
                    }
                    else
                    {
                        Console.WriteLine($"{jahr} war kein Schaltjahr.");
                    }

                    // Überprüfung Datum tatsächlich existiert
                    try
                    {
                        DateTime datum = new DateTime(jahr, monat, tag);
                        Console.WriteLine($"Das eingegebene Datum {datum.ToString("dd.MM.yyyy")} ist gültig.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Das eingegebene Datum ist ungültig.");
                        eingabenGueltig = false; // Falls das Datum ungültig ist
                    }
                }
                else
                {
                    // Ungültige Eingabe
                    Console.WriteLine("Die Eingaben sind ungültig. Bitte stellen Sie sicher: \n");
                    Console.WriteLine(" - Monat muss zwischen 1 und 12 liegen. \n");
                    Console.WriteLine(" - Tag darf nicht größer als 31 sein. \n");
                    Console.WriteLine(" - Jahr muss größer oder gleich 0 sein. \n");
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
                
                for (j = i; j >= 0; j--)
                {
                    Console.Write(j + " ");
                }

                Console.WriteLine(); // Zeilenumbruch
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

            string Frage5_6 = "Bitte geben Sie eine positive Zahl beliebig oft ein (0 zum Beenden):";
            Console.WriteLine(Frage5_6);

            // datentyp long, um auch große Zahlen zu verarbeiten
            long eingabe;
            int anzahl = 0;
            long min2 = long.MaxValue; 
            long max2 = long.MinValue; 

            while (true)
            {
                Console.Write("Zahl: ");
                string input = Console.ReadLine();

                if (!long.TryParse(input, out eingabe) || eingabe < 0)
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte eine positive Zahl eingeben.");
                    continue;
                }

                if (eingabe == 0)
                {
                    break;
                }

                // Aktualisierung min und max
                if (eingabe < min2) min2 = eingabe;
                if (eingabe > max2) max2 = eingabe;

                anzahl++;
            }

            string Antwort5_6;
            if (anzahl > 0)
            {
                Antwort5_6 = $"\nAnzahl der eingegebenen Zahlen: {anzahl}\n" +
                             $"Kleinste Zahl: {min2}\n" +
                             $"Größte Zahl: {max2}";
            }
            else
            {
                Antwort5_6 = "\nKeine gültige Zahl eingegeben.";
            }

            Console.WriteLine(Antwort5_6);

            string Frage5_7 =
                "Erstelle eine Passwortabfrage\n" +
                "\n" +
                "Mit Login falsch und Login richtig\n" +
                "\n";

            Console.WriteLine(Frage5_7);

            // das richtige 
            char[] correctPassword = { 'P', 'R', 'O', 'G' };

            // Benutzer auffordern
            Console.WriteLine("Gib das Passwort ein: ");

            string eingabe1 = Console.ReadLine();

            // einheitlich
            char[] inputArray = eingabe1.ToUpper().ToCharArray();

            // alle drin ?
            if (inputArray.Length == correctPassword.Length && ContainsAllCharacters(inputArray, correctPassword))
            {
                Console.WriteLine("Login erfolgreich!");
            }
            else
            {
                Console.WriteLine("Login gescheitert!");
            }
        }

        // Hilfsmethode
        static bool ContainsAllCharacters(char[] inputArray, char[] correctPassword)
        {
            foreach (char c in correctPassword)
            {
                bool found = false;
                foreach (char inputChar in inputArray)
                {
                    if (char.ToUpper(inputChar) == c)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found) return false;
            }

            return true;
        }
    }
}