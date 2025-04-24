using System;
using System.Collections.Generic;
using System.Linq;

namespace Bibliothekssoftware
{
    class Buch
    {
        public string Titel { get; }
        public string Autor { get; }
        public string ISBN { get; }
        public double Wiederbeschaffungswert { get; }

        public List<Exemplar> Exemplare { get; } 

        public Buch(string titel, string autor, string isbn, double wert)
        {
            Titel = titel;
            Autor = autor;
            ISBN = isbn;
            Wiederbeschaffungswert = wert;

            for (int i = 1; i <= 20; i++)
            {
                Exemplare.Add(new Exemplar(i));
            }
        }
    }

    class Exemplar
    {
        public int ExemplarID { get; }
        public bool IstVerfuegbar { get; private set; } = true;

        public Exemplar(int id)
        {
            ExemplarID = id;
        }

        public void SetVerfuegbar(bool status)
        {
            IstVerfuegbar = status;
        }
    }

    class Schueler
    {
        public int SchuelerID { get; }
        public string Name { get; }
        public string Email { get; }
        public int Mahnungen { get; private set; } = 0;
        public bool NutzungsrechtAktiv { get; private set; } = true;
        public DateTime? NutzungsrechtEntzogenBis { get; private set; } = null;

        public List<Ausleihe> Ausleihen  = new List<Ausleihe>();

        public Schueler(int id, string name, string email)
        {
            SchuelerID = id;
            Name = name;
            Email = email;
        }

        public void ErhalteMahnung()
        {
            Mahnungen++;
            if (Mahnungen >= 3)
            {
                EntzieheNutzungsrecht();
            }
        }

        public void EntzieheNutzungsrecht()
        {
            NutzungsrechtAktiv = false;
            NutzungsrechtEntzogenBis = DateTime.Now.AddMonths(6);
        }

        public bool PruefeNutzungsrecht()
        {
            if (NutzungsrechtEntzogenBis.HasValue && DateTime.Now < NutzungsrechtEntzogenBis.Value)
                return false;

            if (NutzungsrechtEntzogenBis.HasValue && DateTime.Now >= NutzungsrechtEntzogenBis.Value)
            {
                NutzungsrechtAktiv = true;
                NutzungsrechtEntzogenBis = null;
            }

            return NutzungsrechtAktiv && Ausleihen.Count(a => !a.IstZurueckgegeben) < 3;
        }
    }

    class Ausleihe
    {
        public DateTime AusleihDatum { get; }
        public DateTime RueckgabeDatum => AusleihDatum.AddDays(21);
        public bool IstZurueckgegeben { get; private set; } = false;
        public Exemplar Exemplar { get; }

        public Ausleihe(Exemplar exemplar)
        {
            AusleihDatum = DateTime.Now;
            Exemplar = exemplar;
        }

        public bool IstUeberfaellig() => !IstZurueckgegeben && DateTime.Now > RueckgabeDatum;

        public void MarkiereAlsZurueckgegeben()
        {
            IstZurueckgegeben = true;
            Exemplar.SetVerfuegbar(true);
        }
    }

    class Mahnung
    {
        public DateTime MahnungsDatum { get; } = DateTime.Now;
        public string Mahnungsart { get; }
        public bool IstErledigt { get; private set; } = false;

        public Mahnung(string art)
        {
            Mahnungsart = art;
        }

        public void MarkiereAlsErledigt() => IstErledigt = true;
    }

    class Bibliothekssystem
    {
        private List<Buch> buecher = new List<Buch>();
        private List<Schueler> schuelerListe = new List<Schueler>();
        private List<Mahnung> mahnungen = new List<Mahnung>();

        public void DemoModus()
        {
            // === Buchdaten ===
            var buch1 = new Buch("1984", "George Orwell", "1234567890", 15.90);
            var buch2 = new Buch("Brave New World", "Aldous Huxley", "0987654321", 17.50);
            buecher.AddRange(new[] { buch1, buch2 });

            // === Schülerdaten ===
            var s1 = new Schueler(1, "Max Mustermann", "max@example.com");
            var s2 = new Schueler(2, "Erika Musterfrau", "erika@example.com");
            schuelerListe.AddRange(new[] { s1, s2 });

            // === Ausleihen ===
            BuchAusleihen(s1, buch1);
            BuchAusleihen(s1, buch2);
            BuchAusleihen(s2, buch1);

            Console.WriteLine("\n==> Aktuelle Ausleihen:");
            foreach (var schueler in schuelerListe)
            {
                Console.WriteLine($"\n{schueler.Name} hat ausgeliehen:");
                foreach (var ausleihe in schueler.Ausleihen)
                {
                    var buch = buecher.FirstOrDefault(b => b.Exemplare.Contains(ausleihe.Exemplar));
                    Console.WriteLine($"- {buch?.Titel} (Exemplar {ausleihe.Exemplar.ExemplarID}), Rückgabe bis: {ausleihe.RueckgabeDatum.ToShortDateString()}");
                }
            }

            // === Zeitsimulation + Prüfung ===
            Console.WriteLine("\n==> Simuliere Fristprüfung...");
            UeberpruefeLeihfristen();

            // === Beispiel: Rückgabe eines Buches ===
            var rueckgabe = s1.Ausleihen.First();
            rueckgabe.MarkiereAlsZurueckgegeben();
            Console.WriteLine($"\n==> {s1.Name} hat ein Buch zurückgegeben.");
        }

        public void BuchAusleihen(Schueler s, Buch b)
        {
            if (!s.PruefeNutzungsrecht())
            {
                Console.WriteLine($"[!] {s.Name} darf aktuell kein Buch ausleihen.");
                return;
            }

            var exemplar = b.Exemplare.FirstOrDefault(e => e.IstVerfuegbar);
            if (exemplar == null)
            {
                Console.WriteLine($"[!] Kein Exemplar von {b.Titel} verfügbar.");
                return;
            }

            exemplar.SetVerfuegbar(false);
            var ausleihe = new Ausleihe(exemplar);
            s.Ausleihen.Add(ausleihe);

            Console.WriteLine($"{s.Name} hat '{b.Titel}' ausgeliehen (Exemplar-ID: {exemplar.ExemplarID}).");
        }

        public void UeberpruefeLeihfristen()
        {
            foreach (var s in schuelerListe)
            {
                foreach (var ausleihe in s.Ausleihen.Where(a => !a.IstZurueckgegeben))
                {
                    if (ausleihe.IstUeberfaellig())
                    {
                        ErinnerungSenden(s);

                        var tageUeberfaellig = (DateTime.Now - ausleihe.RueckgabeDatum).Days;
                        if (tageUeberfaellig > 28)
                        {
                            var mahnung = MahnungGenerieren(s, ausleihe);
                            Console.WriteLine($"Mahnung für {s.Name}: {mahnung.Mahnungsart}");

                            if (s.Mahnungen >= 3)
                            {
                                NutzungsrechtEntziehen(s);
                            }

                            if (tageUeberfaellig > 35)
                            {
                                RechnungStellen(s, ausleihe.Exemplar);
                            }
                        }
                    }
                }
            }
        }

        public void ErinnerungSenden(Schueler s)
        {
            Console.WriteLine($"[INFO] Erinnerung an {s.Name} gesendet (E-Mail: {s.Email})");
        }

        public Mahnung MahnungGenerieren(Schueler s, Ausleihe a)
        {
            s.ErhalteMahnung();
            var mahnung = new Mahnung("1. Mahnung");
            mahnungen.Add(mahnung);
            return mahnung;
        }

        public void NutzungsrechtEntziehen(Schueler s)
        {
            s.EntzieheNutzungsrecht();
            Console.WriteLine($"[WARNUNG] Nutzungsrecht für {s.Name} entzogen bis {s.NutzungsrechtEntzogenBis?.ToShortDateString()}");
        }

        public void RechnungStellen(Schueler s, Exemplar e)
        {
            var buch = buecher.FirstOrDefault(b => b.Exemplare.Contains(e));
            Console.WriteLine($"[RECHNUNG] {s.Name} muss {buch?.Wiederbeschaffungswert ?? 0.0} € für '{buch?.Titel}' zahlen.");
        }
    }
}
