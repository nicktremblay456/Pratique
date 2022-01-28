﻿using TNT;

public static class Program
{
    private static ProgramData data = new ProgramData();// Data structure qui contient les sous programmes
    private static Option userChoice = Option.NONE;// un enum...
    private static bool isRunning = true, isConsoleInit = false;
    private static string programName = "PseudoCode Version c#";

    /// <summary>
    /// Fait rouler le programme tant que isRunning = true
    /// </summary>
    public static void Run()
    {
        while (isRunning)
        {
            Process();
        }
    }
    /// <summary>
    /// Parametre du menu principale et de la fenêtre
    /// </summary>
    private static void SetMainMenuConsole()
    {
        if (Console.BackgroundColor != ConsoleColor.DarkBlue)
            SetBackgroundColor(ConsoleColor.DarkBlue);
        if (Console.Title != programName)
            Console.Title = programName;
        isConsoleInit = true;
    }
    /// <summary>
    /// Fait rouler le sous programme choisi par l'utilisateur.
    /// </summary>
    private static void Process()
    {
        if (!isConsoleInit)
            SetMainMenuConsole();

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
        //Console.Beep();// Fait un "beep" pour confirmer que le choix entrée est valide
        switch (userChoice)
        {
            case Option.QUIT: Stop(); break;// Arrêter le programme
            case Option.CAISSE_VERSION_1: data.Caisse.Process_Version_1(); break;
            case Option.CAISSE_VERSION_2: data.Caisse.Process_Version_2(); break;
            case Option.COMPTAGE_DE_MOT: data.Comptage.Process(); break;
            case Option.SAISIE_SANS_FAILLE: data.Saisie.Process(); break;
            case Option.DEVINE_VERSION_1: data.Devine.Process_Version_1(); break;
            case Option.DEVINE_VERSION_2: data.Devine.Process_Version_2(); break;
            case Option.DEVINE_VERSION_3: data.Devine.Process_Version_3(); break;
        }

        if (isRunning)
        {
            // Fin du sous programme
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principale...");
            Console.ReadKey();// Attend que l'utilisateur appuis sur une touche (n'importe laquelle) avant de continuer
            //Console.Beep();
            Console.Clear();
        }
    }
    /// <summary>
    /// Permet de cjanger la couleur du background de la console.
    /// </summary>
    /// <param name="color">La couleure qu'on veut utiliser</param>
    public static void SetBackgroundColor(ConsoleColor color)
    {
        if (Console.BackgroundColor != color)
            Console.BackgroundColor = color;
        Console.Clear();
    }
    /// <summary>
    /// Prend l'input de l'utilisateur pour connaitre son choix.
    /// </summary>
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
    /// <summary>
    /// Arrête le programme
    /// </summary>
    private static void Stop()
    {
        isRunning = false;
        SetBackgroundColor(ConsoleColor.Black);
        Console.Clear();
    }
}