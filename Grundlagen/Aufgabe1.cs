using System;

namespace ErsterCode.Grundlagen
{
    public class Aufgabe1
    {
        public static void Inhalt_Aufgabe1()
        {
            // Antworten als Variablen
            string MSDN =
                "MSDN =  Microsoft Developer Network (MSDN) war ein Informations- und Software-Angebot für Programmierer und Software-Architekten. ";
            string Assembly =
                "Assembly = Assemblys sind ausführbare Dateien ( .exe) oder Dynamic Link Library-Dateien ( .dll) und bilden die Bausteine von .NET-Anwendungen. ";
            string Manifest =
                "Manifest = Ein Assemblymanifest enthält alle Metadaten, die zum Angeben von Versionsanforderungen und Sicherheitsidentität der Assembly erforderlich sind, sowie alle Metadaten, die zum Definieren des Gültigkeitsbereichs der Assembly und zum Auflösen von Verweisen auf Ressourcen und Klassen benötigt werden. ";
            string GlobalAssemblyCache =
                "Im globalen Assemblycache werden Assemblys gespeichert, die speziell für die gemeinsame Verwendung durch mehrere Anwendungen auf dem Computer vorgesehen sind.\n\nGeben Sie Assemblys nur dann durch eine Installation im globalen Assemblycache frei, wenn dies unbedingt erforderlich ist. ";
            string Frage1_1 =
                "Was ist eine MSDN ? Beschreibe kurz .NET Begriffe Assembly , Manifest und Global Assembly Cache?";
            string Antwort1_1 = MSDN + Assembly + Manifest + GlobalAssemblyCache;
            
            Console.WriteLine(Frage1_1);
            Console.WriteLine(Antwort1_1);

            string CSharp = "C# stammt von C und C++ ab und wurde im Jahr 2000 von Microsoft veröffentlicht.";
            string CPlusPlus = "C++ ist eine Erweiterung von C und wurde 1983 von Bjarne Stroustrup entwickelt.";
            string Java = "Java basiert auf C und C++ und wurde 1995 von Sun Microsystems eingeführt.";
            string Delphi = "Delphi basiert auf Pascal und wurde 1995 von Borland veröffentlicht.";
            string BASIC =
                "BASIC stammt von FORTRAN und Algol ab und wurde 1964 von John G. Kemeny und Thomas E. Kurtz entwickelt.";
            string Cobol =
                "COBOL wurde 1959 auf Basis von FLOW-MATIC entwickelt und ist eine der ältesten Programmiersprachen.";

            string Frage1_2 =
                "Erstelle einen Stammbaum der wichtigsten Programmiersprachen (C#, C++, Java, Delphi, BASIC, COBOL) mit ihren Ursprüngen und Entstehungsjahren.";
            string Antwort1_2 = CSharp + "\n" + CPlusPlus + "\n" + Java + "\n" + Delphi + "\n" + BASIC + "\n" + Cobol;

            Console.WriteLine(Frage1_2);
            Console.WriteLine(Antwort1_2);
            
            // Ablauf eines .NET-Programms
            string Frage1_3 = "Stelle den Ablauf von Programmen in .NET (vom Quellcode bis zur .exe) in einem einfachen Diagramm dar.";
            string Antwort1_3 =
                "Quellcode (.cs) → Compiler (C# Compiler) → IL Code (Intermediate Language) → JIT Compiler (Just-In-Time Compilation) → Maschinencode → Ausführung (.exe)";
            
            Console.WriteLine(Frage1_3);
            Console.WriteLine(Antwort1_3);
            
        }
    }
}