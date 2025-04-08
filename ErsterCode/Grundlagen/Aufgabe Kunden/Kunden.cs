using System;

namespace ErsterCode.Grundlagen.Aufgabe_Kunden
{
    public class Kunden 
    {
        public string vorname;
        public string nachname;
        public string strasse;
        public string kundennummer; 
        public string ort;
        public int plz;
        public int hausnummer;

        // Standardkonstruktor
        public Kunden()
        {
            this.vorname = "Gerhard";
            this.nachname = "Joachim";
            this.strasse = "Öpücük strasse";
            this.plz = 20357;
            this.ort = "Hamburg";
            this.hausnummer = 57;
            this.kundennummer = "01"; // Die Kundennummer als String
        }

        // Konstruktor mit Parametern
        public Kunden(string vorname, string nachname, string strasse, int plz, string ort, int hausnummer,
            string kundennummer)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.strasse = strasse;
            this.plz = plz;
            this.ort = ort;
            this.hausnummer = hausnummer;
            this.kundennummer = kundennummer;
        }

        // Methode zum Reden mit vollständigen Details
        public void Reden()
        {
            Console.WriteLine($"Ich bin {vorname} {nachname}. Freut mich, dich kennenzulernen!");
            Console.WriteLine($"Meine Adresse: {strasse} {hausnummer}, {plz} {ort}");
            Console.WriteLine($"Meine Kundennummer lautet: {kundennummer}");
        }
    }
}