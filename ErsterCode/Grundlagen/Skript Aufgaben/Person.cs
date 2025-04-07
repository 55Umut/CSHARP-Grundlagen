using System;
using System.Resources;

namespace ErsterCode.Grundlagen.Skript_Aufgaben
{
    // einmal alles durchgehen über klassen 
    // neu # region " Name der region " #endregion 
    public class Person
    {
        #region -- Attribute --

        // Attribute
        private string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }

        #endregion

        #region --Konstruktor--

        public Person(string vorname)
        {
            this.Vorname = vorname;
        }

        // Konstruktor mehrfach
        public Person(string vorname, string nachname, int alter)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Alter = alter;
        }

        #endregion

        #region --Getter und Setter--

        // GETTER und SETTER
        public void SetVorname(string vorname)
        {
            this.Vorname = vorname;
        }

        public string GetVorname(string vorname)
        {
            return vorname;
        }

        public void SetNachname(string nachname)
        {
            this.Nachname = nachname;
        }

        public string GetNachname(string nachname)
        {
            return nachname;
        }

        public void SetAlter(int alter)
        {
            this.Alter = alter;
        }

        public int GetAlter(int alter)
        {
            return alter;
        }

        #endregion
    }
}