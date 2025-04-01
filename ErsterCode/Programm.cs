//Import
// wenn das nicht in jeder datei ist wird es Console nicht erlauben

using System;
// Immer nutzen bei ausgaben
using ErsterCode.Grundlagen;

//Welches Projekt/Welcher Ordner
namespace ErsterCode
{
    // was wird genutzt ?
    internal class Programm
    {
        // Main es darf nur eine geben übersichtshalber
        public static void Main(string[] args)
        {
            // teile möglichst zuweisung und aufruf
            string hello;
            hello = "Herzlich Willkommen";
            // ausgabe 
            Console.WriteLine(hello);
            // Aufruf von Datentypen.cs und seinem Inhalt Achtung erst klasse danach die void 
            Datentypen.run();
        }
        // Konstruktor 
        // Funktionen
        // Methoden
        // getter
        // setter
    }
}