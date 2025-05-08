using System;
using System.Collections.Generic;

namespace Poke
{
    public class Login
    {
        public static void LoginMenu(UsersData usersData, Anzeige anzeigen)
        {
            while (true)
            {
                anzeigen.DisplayLoginMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        TrainerLogin(usersData, anzeigen);
                        break;
                    case "2":
                        TrainerRegistrieren(usersData, anzeigen);
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl.");
                        break;
                }

                Console.WriteLine("Zum Fortfahren eine Taste drücken...");
                Console.ReadKey();
            }
        }

        private static void TrainerLogin(UsersData usersData, Anzeige anzeigen)
        {
            Console.Clear();
            Console.Write("Benutzername: ");
            string username = Console.ReadLine();
            Console.Write("Passwort: ");
            string password = Console.ReadLine();

            try
            {
                if (usersData.ValidateUser(username, password))
                {
                    anzeigen.DisplayLoginSuccess();
                    usersData.UpdateLastLogin(username);
                    TrainerMenu(username, usersData, anzeigen);
                }
                else
                {
                    anzeigen.DisplayLoginError();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Login: {ex.Message}");
            }

            Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();
        }

        private static void TrainerRegistrieren(UsersData usersData, Anzeige anzeigen)
        {
            Console.Clear();
            Console.Write("Neuer Benutzername: ");
            string username = Console.ReadLine();
            Console.Write("E-Mail-Adresse: ");
            string email = Console.ReadLine();
            Console.Write("Passwort: ");
            string password = Console.ReadLine();

            if (usersData.CheckUsernameExistence(username))
            {
                Console.WriteLine("Benutzername bereits vergeben. Bitte wählen Sie einen anderen.");
                return;
            }

            try
            {
                if (usersData.RegisterUser(username, password, email))
                {
                    Console.WriteLine("Erfolgreich registriert!");
                }
                else
                {
                    Console.WriteLine("Fehler bei der Registrierung.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler bei der Registrierung: {ex.Message}");
            }

            Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();
        }

        private static void TrainerMenu(string username, UsersData usersData, Anzeige anzeigen)
        {
            PokemonsData pokemonsData = new PokemonsData();
            TrainerData trainerData = new TrainerData();
            DataBaseConnection dbConnection = new DataBaseConnection();
            GameEngine gameEngine = new GameEngine(pokemonsData, dbConnection);
            NewGame newGame = new NewGame(trainerData, pokemonsData, dbConnection, anzeigen, gameEngine);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Willkommen, {username}!\n");
                anzeigen.DisplayMainMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ManageTrainers(trainerData, anzeigen);
                        break;
                    case "2":
                        ManagePokemons(pokemonsData, anzeigen);
                        break;
                    case "3":
                        anzeigen.DisplayLogoutMessage();
                        return;
                    case "4":
                        anzeigen.DisplayExitMessage();
                        Environment.Exit(0);
                        break;
                    case "5":
                        newGame.StartNewGame(username);
                        break;
                    case "6":
                        newGame.LoadGameProgress(username);
                        break;
                    case "7":
                        newGame.DeleteGameProgress(username);
                        break;
                    default:
                        anzeigen.DisplayInvalidChoice();
                        break;
                }
            }
        }

        private static void ManageTrainers(TrainerData trainerData, Anzeige anzeigen)
        {
            bool managingTrainers = true;

            while (managingTrainers)
            {
                anzeigen.DisplayTrainerMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        trainerData.ReadTrainers();
                        break;
                    case "2":
                        Console.Write("Trainername: ");
                        string name = Console.ReadLine();
                        Console.Write("Region: ");
                        string region = Console.ReadLine();
                        Console.Write("Mission: ");
                        string mission = Console.ReadLine();
                        Console.Write("Level: ");
                        if (!int.TryParse(Console.ReadLine(), out int level))
                        {
                            Console.WriteLine("Ungültiges Level.");
                            break;
                        }
                        Console.Write("Erfahrung (z. B. 1000): ");
                        if (!int.TryParse(Console.ReadLine(), out int experience))
                        {
                            Console.WriteLine("Ungültige Erfahrung.");
                            break;
                        }
                        trainerData.InsertTrainer(name, region, mission, level, experience);
                        break;
                    case "3":
                        Console.Write("Trainer ID zum Aktualisieren: ");
                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Ungültige ID.");
                            break;
                        }
                        Console.Write("Neuer Trainername: ");
                        string newName = Console.ReadLine();
                        Console.Write("Neue Region: ");
                        string newRegion = Console.ReadLine();
                        Console.Write("Neue Mission: ");
                        string newMission = Console.ReadLine();
                        Console.Write("Neues Level: ");
                        if (!int.TryParse(Console.ReadLine(), out int newLevel))
                        {
                            Console.WriteLine("Ungültiges Level.");
                            break;
                        }
                        Console.Write("Neue Erfahrung (z. B. 1000): ");
                        if (!int.TryParse(Console.ReadLine(), out int newExperience))
                        {
                            Console.WriteLine("Ungültige Erfahrung.");
                            break;
                        }
                        trainerData.UpdateTrainer(updateId, newName, newRegion, newMission, newLevel, newExperience);
                        break;
                    case "4":
                        Console.Write("Trainer ID zum Löschen: ");
                        if (!int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Console.WriteLine("Ungültige ID.");
                            break;
                        }
                        trainerData.DeleteTrainer(deleteId);
                        break;
                    case "5":
                        managingTrainers = false;
                        break;
                    default:
                        anzeigen.DisplayInvalidChoice();
                        break;
                }
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
            }
        }

        private static void ManagePokemons(PokemonsData pokemonsData, Anzeige anzeigen)
        {
            bool managingPokemons = true;

            while (managingPokemons)
            {
                anzeigen.DisplayPokemonMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        pokemonsData.ReadPoke();
                        break;
                    case "2":
                        Console.Write("Pokémon-Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Level: ");
                        if (!int.TryParse(Console.ReadLine(), out int level))
                        {
                            Console.WriteLine("Ungültiges Level.");
                            break;
                        }
                        Console.Write("Lebenspunkte: ");
                        if (!int.TryParse(Console.ReadLine(), out int lebenspunkte))
                        {
                            Console.WriteLine("Ungültige Lebenspunkte.");
                            break;
                        }
                        Console.Write("Attacke 1: ");
                        string attacke1 = Console.ReadLine();
                        Console.Write("Schaden Attacke 1: ");
                        string schaden1Input = Console.ReadLine();
                        int? schaden_attacke1 = string.IsNullOrEmpty(schaden1Input) ? (int?)null : int.Parse(schaden1Input);
                        Console.Write("Attacke 2 (optional, Enter für NULL): ");
                        string attacke2 = Console.ReadLine();
                        attacke2 = string.IsNullOrEmpty(attacke2) ? null : attacke2;
                        Console.Write("Schaden Attacke 2 (optional, Enter für NULL): ");
                        string schaden2Input = Console.ReadLine();
                        int? schaden_attacke2 = string.IsNullOrEmpty(schaden2Input) ? (int?)null : int.Parse(schaden2Input);
                        Console.Write("Spezialattacke (optional, Enter für NULL): ");
                        string spezialattacke = Console.ReadLine();
                        spezialattacke = string.IsNullOrEmpty(spezialattacke) ? null : spezialattacke;
                        Console.Write("Schaden Spezialattacke (optional, Enter für NULL): ");
                        string schadenSpezialInput = Console.ReadLine();
                        int? schaden_spezialattacke = string.IsNullOrEmpty(schadenSpezialInput) ? (int?)null : int.Parse(schadenSpezialInput);
                        Console.Write("EXP: ");
                        if (!int.TryParse(Console.ReadLine(), out int exp))
                        {
                            Console.WriteLine("Ungültige EXP.");
                            break;
                        }
                        Console.Write("Max EXP: ");
                        if (!int.TryParse(Console.ReadLine(), out int max_exp))
                        {
                            Console.WriteLine("Ungültige Max EXP.");
                            break;
                        }
                        pokemonsData.InsertPoke(name, level, lebenspunkte, attacke1, schaden_attacke1, attacke2, schaden_attacke2, spezialattacke, schaden_spezialattacke, exp, max_exp);
                        break;
                    case "3":
                        Console.Write("Pokémon-ID zum Aktualisieren: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("Ungültige ID.");
                            break;
                        }
                        Console.Write("Neuer Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Neues Level: ");
                        if (!int.TryParse(Console.ReadLine(), out int newLevel))
                        {
                            Console.WriteLine("Ungültiges Level.");
                            break;
                        }
                        Console.Write("Neue Lebenspunkte: ");
                        if (!int.TryParse(Console.ReadLine(), out int newLebenspunkte))
                        {
                            Console.WriteLine("Ungültige Lebenspunkte.");
                            break;
                        }
                        Console.Write("Neue Attacke 1: ");
                        string newAttacke1 = Console.ReadLine();
                        Console.Write("Neuer Schaden Attacke 1: ");
                        string newSchaden1Input = Console.ReadLine();
                        int? newSchaden_attacke1 = string.IsNullOrEmpty(newSchaden1Input) ? (int?)null : int.Parse(newSchaden1Input);
                        Console.Write("Neue Attacke 2 (optional, Enter für NULL): ");
                        string newAttacke2 = Console.ReadLine();
                        newAttacke2 = string.IsNullOrEmpty(newAttacke2) ? null : newAttacke2;
                        Console.Write("Neuer Schaden Attacke 2 (optional, Enter für NULL): ");
                        string newSchaden2Input = Console.ReadLine();
                        int? newSchaden_attacke2 = string.IsNullOrEmpty(newSchaden2Input) ? (int?)null : int.Parse(newSchaden2Input);
                        Console.Write("Neue Spezialattacke (optional, Enter für NULL): ");
                        string newSpezialattacke = Console.ReadLine();
                        newSpezialattacke = string.IsNullOrEmpty(newSpezialattacke) ? null : newSpezialattacke;
                        Console.Write("Neuer Schaden Spezialattacke (optional, Enter für NULL): ");
                        string newSchadenSpezialInput = Console.ReadLine();
                        int? newSchaden_spezialattacke = string.IsNullOrEmpty(newSchadenSpezialInput) ? (int?)null : int.Parse(newSchadenSpezialInput);
                        pokemonsData.UpdatePoke(id, newName, newLevel, newLebenspunkte, newAttacke1, newSchaden_attacke1, newAttacke2, newSchaden_attacke2, newSpezialattacke, newSchaden_spezialattacke);
                        break;
                    case "4":
                        Console.Write("Pokémon-ID zum Löschen: ");
                        if (!int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Console.WriteLine("Ungültige ID.");
                            break;
                        }
                        pokemonsData.DeletePoke(deleteId);
                        break;
                    case "5":
                        managingPokemons = false;
                        break;
                    default:
                        anzeigen.DisplayInvalidChoice();
                        break;
                }
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
            }
        }
    }
}