﻿using TNT;

/// <copyright file="Program.cs">
/// Copyright © 2022 © All Rights Reserved
/// </copyright>
/// <author>Nicolas Tremblay</author>
/// <date>2022/01/22 16:26 PM </date>
/// <summary>Class representing all pseudocode in a single program</summary>
public class Program
{
    private ProgramData data = new ProgramData();// Data structure qui contient les sous programmes
    private Option userChoice = Option.NONE;// un enum...
    private bool isRunning = true;

    public void Run()
    {
        while (isRunning)
        {
            Process();
        }
    }

    private void Process()
    {
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
        while ((int)userChoice < 0 || (int)userChoice > 7)
        {
            GetInput();
        }
        Console.Clear();
        switch (userChoice)
        {
            case Option.QUIT: isRunning = !isRunning; break;// Arrêter le programme
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

    private void GetInput()
    {
        try
        {
            userChoice = (Option)int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 0 et 7");
            userChoice = Option.NONE;
        }
    }
}