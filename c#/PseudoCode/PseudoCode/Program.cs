using TNT;

public static class Program
{
    private static ProgramData data = new ProgramData();// Data structure qui contient les sous programmes
    private static Option userChoice = Option.NONE;// un enum...
    private static bool isRunning = true, isConsoleInit = false;
    private static string programName = "PseudoCode Version c#";

    public static void Run()
    {
        while (isRunning)
        {
            Process();
        }
    }

    private static void SetConsole()
    {
        if (Console.BackgroundColor != ConsoleColor.DarkBlue)
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        if (Console.Title != programName)
            Console.Title = programName;
        Console.Clear();
        isConsoleInit = true;
    }

    private static void Process()
    {
        if (!isConsoleInit)
            SetConsole();

        Console.WriteLine("Entrer 0, 1, 2, 3, 4, 5, 6 ou 7 pour choisir quoi faire.\n\n" +
                          $"{(int)Option.CAISSE_VERSION_1}: Caisse automatique VERSION 1\n" +
                          $"{(int)Option.CAISSE_VERSION_2}: Caisse automatique VERSION 2\n" +
                          $"{(int)Option.COMPTAGE_DE_MOT}: Comptage de mot\n" +
                          $"{(int)Option.SAISIE_SANS_FAILLE}: Saisie sans faille\n" +
                          $"{(int)Option.DEVINE_VERSION_1}: Devine le chiffre VERSION 1\n" +
                          $"{(int)Option.DEVINE_VERSION_2}: Devine le chiffre VERSION 2\n" +
                          $"{(int)Option.DEVINE_VERSION_3}: Devine le chiffre VERSION 3\n" +
                          $"{(int)Option.QUIT}: Quitter");
        GetInput();
        while (userChoice == Option.NONE)
        {
            GetInput();
        }
        isConsoleInit = false;// Remet a false pour qu'au retour au menu princile la fonction SetConsole soit caller pour remettre le background color du menu principale.
        Console.Beep();// Fait un "beep" pour confirmer que le choix entrée est valide
        switch (userChoice)
        {
            case Option.QUIT: isRunning = false; Console.Clear(); break;// Arrêter le programme
            case Option.CAISSE_VERSION_1: data.Caisse1.Process(); break;
            case Option.CAISSE_VERSION_2: data.Caisse2.Process(); break;
            case Option.COMPTAGE_DE_MOT: data.Comptage.Process(); break;
            case Option.SAISIE_SANS_FAILLE: data.Saisie.Process(); break;
            case Option.DEVINE_VERSION_1: data.DevineLeChiffre1.Process(); break;
            case Option.DEVINE_VERSION_2: data.DevineLeChiffre2.Process(); break;
            case Option.DEVINE_VERSION_3: data.DevineLeChiffre3.Process(); break;
        }

        if (isRunning)
        {
            // Fin du sous programme
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principale...");
            Console.ReadKey();// Attend que l'utilisateur appuis sur une touche (n'importe laquelle) avant de continuer
            Console.Clear();
        }
    }

    private static void GetInput()
    {
        try
        {
            userChoice = (Option)int.Parse(Console.ReadLine());
            if (userChoice >= Option.Count)
            {
                userChoice = Option.NONE;
            }
        }
        catch
        {
            userChoice = Option.NONE;
        }

        if (userChoice == Option.NONE)
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 0 et 7");
    }
}