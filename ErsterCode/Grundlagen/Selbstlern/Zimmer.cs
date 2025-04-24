using System;

namespace ErsterCode.Grundlagen.Selbstlern 
{
    public class Zimmer
    {
        // Attribute 
        private string bezeichnung;
        private double laenge;
        private double breite;
        private double hoehe;
        private int anzahlTueren;
        private int anzahlFenster;

        // Konstruktor
        public Zimmer()
        {
            
        }
        public Zimmer(string bezeichnung,double laenge, double breite,double hoehe, int anzahlTueren,int anzahlFenster) 
        {
            this.bezeichnung = bezeichnung;
            this.laenge = laenge;
            this.breite = breite;
            this.hoehe = hoehe;
            this.anzahlTueren = anzahlTueren;
            this.anzahlFenster = anzahlFenster;
            
        }

        // Getter
        public string getBezeichnung()
        {
            return bezeichnung;
        }

        public double getLaenge()
        {
            return laenge;
        }

        public double getBreite()
        {
            return breite;
        }

        public double getHoehe()
        {
            return hoehe;
        }

        public int getanzahlTueren()
        {
            return anzahlTueren;
        }

        public int getanzahlFenster()
        {
            return anzahlFenster;
        }

        // Setter
        public void setBezeichnung(string bezeichnung)
        {
            this.bezeichnung = bezeichnung;
        }

        public void setLaenge(double laenge)
        {
            this.laenge = laenge;
        }

        public void setBreite(double breite)
        {
            this.breite = breite;
        }

        public void setHoehe(double hoehe)
        {
            this.hoehe = hoehe;
        }

        public void SetAnzahlTueren(int anzahl)
        {
            this.anzahlTueren = anzahl;
        }

        public void setAnzahlFenster(int anzahl)
        {
            this.anzahlFenster = anzahl;
        }

        // Eigene Methoden
        public double BerechneGrundflaeche()
        {
            double grundflaeche = breite * hoehe;
            return grundflaeche;
        }

        public double BerechneWandflaeche()
        {
            double wand1, wand2, tuerflaeche, fensterflaeche;
            wand1 = laenge * hoehe * 2;
            wand2 = breite * hoehe * 2;
            tuerflaeche = anzahlTueren * 1 * 2;
            fensterflaeche = anzahlFenster * 0.8f;
            double wandflaeche = wand1 + wand2 - (tuerflaeche + fensterflaeche);
            return wandflaeche;
        }

        public void DetailsAusgaben()
        {
            Console.WriteLine(getBezeichnung());
            Console.WriteLine($"Grundfäche: {BerechneGrundflaeche()}");
            Console.WriteLine($"Wandfäche: {BerechneWandflaeche()}");
        }
    }
}