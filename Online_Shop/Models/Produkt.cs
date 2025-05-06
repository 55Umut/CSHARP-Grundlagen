namespace Online_Shop.Models
{
    public class Produkt
    {
        private int _id;
        private int artikelnummer;
        private string produktname;
        private int preis;
        private string beschreibung;
        private int anzahl;
        
        public Produkt(int artikelnummer, string produktname, int preis, string beschreibung, int anzahl)
        {
            this.artikelnummer = artikelnummer;
            this.produktname = produktname;
            this.preis = preis;
            this.beschreibung = beschreibung;
            this.anzahl = anzahl;
        }
        
        
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int Artikelnummer
        {
            get => artikelnummer;
            set => artikelnummer = value;
        }

        public string Produktname
        {
            get => produktname;
            set => produktname = value;
        }

        public int Preis
        {
            get => preis;
            set => preis = value;
        }

        public string Beschreibung
        {
            get => beschreibung;
            set => beschreibung = value;
        }

        public int Anzahl
        {
            get => anzahl;
            set => anzahl = value;
        }
        
    }
}