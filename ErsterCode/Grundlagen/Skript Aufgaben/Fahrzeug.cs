namespace ErsterCode.Grundlagen.Skript_Aufgaben
{
    using System;

    public class Fahrzeug
    {
        private string marke;
        private string modell;
        private int baujahr;
        private string farbe;
        private double preis;

        // Konstruktor
        public Fahrzeug()
        {
            Console.WriteLine("Fahrzeug LEER");
        }

        public Fahrzeug(string marke, string modell, int baujahr, string farbe, double preis)
        {
            this.marke = marke;
            this.modell = modell;
            this.baujahr = baujahr;
            this.farbe = farbe;
            this.preis = preis;
        }

        #region Getter / / Setter 

        
        // Getter und Setter
        public string Marke
        {
            get { return marke; }
            set { marke = value; }
        }

        public string Modell
        {
            get { return modell; }
            set { modell = value; }
        }

        public int Baujahr
        {
            get { return baujahr; }
            set { baujahr = value; }
        }

        public string Farbe
        {
            get { return farbe; }
            set { farbe = value; }
        }

        public double Preis
        {
            get { return preis; }
            set { preis = value; }
        }


        #endregion
        
        
        
        
        
        
        
        
        // Methode zum Anzeigen der Fahrzeuginformationen
        public void ZeigeInformationen()
        {
            Console.WriteLine("Fahrzeuginformationen:");
            Console.WriteLine($"Marke: {Marke}");
            Console.WriteLine($"Modell: {Modell}");
            Console.WriteLine($"Baujahr: {Baujahr}");
            Console.WriteLine($"Farbe: {Farbe}");
            Console.WriteLine($"Preis: {Preis:C}");
        }
    }
}