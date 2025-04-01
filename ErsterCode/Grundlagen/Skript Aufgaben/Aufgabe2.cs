using System;

namespace ErsterCode.Grundlagen.Skript_Aufgaben
{
    public class Aufgabe2
    {
        public static void Inhalt_Aufgabe2()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string Frage2_1 = "AUFGABE 2 \n Analysiere die fehler im dargestellten C# Code \n";
            string Antwort2_1 =
                " 1. Der Code verwendet keine public oder private angaben \n 2. es gibt kein using System \n 3. nicht genutzte integer variablen \n 4. bei der Ausgabe fehlen doppelte anführungszeichen";
            Console.WriteLine(Frage2_1);
            Console.WriteLine(Antwort2_1);

            string Frage2_2 =
                "Erstelle ein Code Schnipsel anhand der Vorlage (Rauten als Rahmen und Text mit C# ist eine moderne Programmiersprache) \n";
            string Antwort2_2 =
                "#########################################################################################################\n"+
                "#################################### C# ist eine moderne Sprache    ####################################\n"+
                "#########################################################################################################\n";

            Console.WriteLine(Frage2_2);
            Console.WriteLine(Antwort2_2);
        }
    }
}