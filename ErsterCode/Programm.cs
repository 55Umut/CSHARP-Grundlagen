//Import
// wenn das nicht in jeder datei ist wird es Console nicht erlauben

using System;
using System.Resources;
// Immer nutzen bei ausgaben
using ErsterCode.Grundlagen;
using ErsterCode.Grundlagen.Aufgabe_Kunden;
using ErsterCode.Grundlagen.Objektorientiert;
using ErsterCode.Grundlagen.Skript_Aufgaben;

//Welches Projekt/Welcher Ordner
namespace ErsterCode
{
    // was wird genutzt ?
    internal class Programm
    {
        // Main es darf nur eine geben übersichtshalber
        public static void Main(string[] args)
        {
            /*
            // teile möglichst zuweisung und aufruf
            string hello;
            hello = "Herzlich Willkommen";
            // ausgabe
            Console.WriteLine(hello);
            // Aufruf von Datentypen.cs und seinem Inhalt Achtung erst klasse danach die void
            Datentypen.run();
            */

            /*Auto Golf = new Auto("Volkswagen", "Golf V", 36789, "Himmelblau");

            Golf.Fahren();
            Golf.Bremsen();

            Krieger witthmaaaaan = new Krieger();
            witthmaaaaan.name = "Witthmaaaaan";
            witthmaaaaan.rasse = "Arian";
            witthmaaaaan.level = 1;
            witthmaaaaan.lebenspunkte = 20;

            Krieger conan = new Krieger();
            witthmaaaaan.name = "Conan";
            witthmaaaaan.rasse = "Muslim";
            witthmaaaaan.level = 1;
            witthmaaaaan.lebenspunkte = 10;

            witthmaaaaan.FressePolieren(conan);


            Kunden kunde1 = new Kunden("Hans", "Liebherr", "Reeperbahn", 20357, "Hamburg", 55, 02);
            Console.WriteLine(kunde1);

            Kunden kunde2 = new Kunden();
            Console.WriteLine(kunde2);


            // für den Standardkunden
            Kunden kunde1 = new Kunden();
            kunde1.Reden();

            // Kunde mit benutzerdefinierten Werten
            Kunden kunde2 = new Kunden("Max", "Mustermann", "Musterstraße 10", 12345, "Berlin", 12, "12345");
            kunde2.Reden();

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Person susiSorglos = new Person();

            susiSorglos.Vorname = "Susi";
            susiSorglos.Nachname = "Sorglos";
            susiSorglos.Alter = 19;

            Person[] personenListe = new Person[24];




            // Beispiel-Fahrzeug erstellen
            Fahrzeug meinAuto = new Fahrzeug("BMW", "X5", 2020, "Schwarz", 75000.00);

            // Fahrzeuginformationen anzeigen
            meinAuto.ZeigeInformationen();

            // Beispiel für das Ändern von Eigenschaften
            Console.WriteLine("\nÄndere die Farbe des Fahrzeugs...");
            meinAuto.Farbe = "Weiß";
            meinAuto.ZeigeInformationen();






            // -- - - - - - - - - //

            Punkt punkt= new Punkt(10,20);
            Punkt punkt2= new Punkt(x);
            Punkt punkt3= new Punkt();



            */


            {
                Console.WriteLine("Geometrische Grundformen - Testprogramm");
                Console.WriteLine("-----------------------------------------");


                Punkt rP1 = new Punkt(3, 4);
                Punkt rP2 = new Punkt(6, 4);
                Punkt rP3 = new Punkt(6, 6);
                Punkt rP4 = new Punkt(3, 6);
                Rechteck rechteck = new Rechteck(rP1, rP2, rP3, rP4);


                Punkt kMittelpunkt = new Punkt(7, 9);
                double radius = 2.0;
                Kreis kreis = new Kreis(kMittelpunkt, radius);

                Punkt lP1 = new Punkt(7, 1);
                Punkt lP2 = new Punkt(12, 5);
                Linie linie = new Linie(lP1, lP2);

                Anzeige anzeige = new Anzeige();


                Console.WriteLine("\nRechteck-Punkte:");
                AusgabePunkt("P1", rechteck.GetP1());
                AusgabePunkt("P2", rechteck.GetP2());
                AusgabePunkt("P3", rechteck.GetP3());
                AusgabePunkt("P4", rechteck.GetP4());

                Console.WriteLine("\nKreis:");
                AusgabePunkt("Mittelpunkt", kreis.GetMittelpunkt());
                Console.WriteLine($"Radius: {kreis.GetRadius()} LE");

                Console.WriteLine("\nLinie:");
                AusgabePunkt("P1", linie.GetP1());
                AusgabePunkt("P2", linie.GetP2());


                Console.WriteLine("\nBerechnete Werte:");
                Console.WriteLine($"Fläche Rechteck: {anzeige.Flaeche(rechteck):F2} LE²");
                Console.WriteLine($"Fläche Kreis: {anzeige.Flaeche(kreis):F2} LE²");
                Console.WriteLine($"Länge Linie: {anzeige.Laenge(linie):F2} LE");


                Console.WriteLine("\nErwartete Werte laut Aufgabenstellung:");
                Console.WriteLine("Fläche Rechteck: 3 * 2 = 6 LE²");
                Console.WriteLine("Fläche Kreis: π * 2² = 12,57 LE²");
                Console.WriteLine("Länge Linie: √(5² + 4²) = 6,40 LE");


                Console.WriteLine("\nAnzeigen durch RufeAnzeige-Methoden:");
                Console.WriteLine("-------------------------------------");
                rechteck.RufeAnzeige();
                Console.WriteLine();
                kreis.RufeAnzeige();
                Console.WriteLine();
                linie.RufeAnzeige();

                Console.WriteLine("\nDrücken Sie eine Taste, um das Programm zu beenden...");
                Console.ReadKey();
            }

            void AusgabePunkt(string name, Punkt p)
            {
                Console.WriteLine($"{name}: ({p.GetX()}, {p.GetY()})");
            }
        }
        // Konstruktor 
        // Funktionen
        // Methoden
        // getter
        // setter
    }
}