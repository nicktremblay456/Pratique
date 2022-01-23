﻿/// <copyright file="Program.cs">
/// Copyright © 2022 © All Rights Reserved
/// </copyright>
/// <author>Nicolas Tremblay</author>
/// <date>2022/01/22 16:26 PM </date>
/// <summary>Class representing all pseudocode in a single program</summary>
public class PseudoCode
{
    // Data structure qui contient les sous programmes
    private static ProgramsData data = new ProgramsData();// Initialise le data avec new

    private static int input = 0;
    private static bool isRunning = true;

    /// <summary>
    /// Fonction principale qui fait rouler tout
    /// </summary>
    private static void Main()
    {
        while(isRunning)
        {
            Program();
        }
    }

    private static void Program()
    {
        Console.WriteLine("Entrer 0, 1, 2, 3, 4, 5, 6 ou 7 pour choisir quoi faire. \n" +
                          "1: Caisse automatique VERSION 1 \n" +// \n pour skipper une ligne au lieu de faire plein de console.writeline()
                          "2: Caisse automatique VERSION 2 \n" +
                          "3: Comptage de mot *WORK IN PROGRESS* \n" +
                          "4: Saisie sans faille \n" +
                          "5: Devine le chiffre VERSION 1 \n" +
                          "6: Devine le chiffre VERSION 2 \n" +
                          "7: Devine le chiffre VERSION 3 \n" +
                          "0: Quitter");
        GetInput();
        // La fonction comptage de mot n'est 100% fonctionnel
        while (input < 0 || input > 7)
        {
            GetInput();
        }
        Console.Clear();// Comme on le lis.. Clear la console.
        switch (input)// plus clean que faire 8 if et else if
        {
            case 0: isRunning = false; break;// Coupe la boucle while dans la fonction Main() qui fait runner le programme
            case 1: data.Caisse1.Process(); break; // Appel la fonction process un passant par la props setter dans la struct en haut
            case 2: data.Caisse2.Process(); break;
            case 3: data.Comptage.Process(); break;
            case 4: data.Saisie.Process(); break;
            case 5: data.DevineLeChiffre1.Process(); break;
            case 6: data.DevineLeChiffre2.Process(); break;
            case 7: data.DevineLeChiffre3.Process(); break;
        }

        if (isRunning)// Pas afficher le message inutilement et d'appuyer sur une touche si l'utilisateur veut quitter
        {
            // Fin du sous programme
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();// Attend que l'utilisateur appuis sur une touche avant de continuer
            Console.Clear();
        }
    }

    private static void GetInput()
    {
        try// bloc try parce que on a une chance d'esseyer d'assigner un caractere a une variable de type int, resultat -> crash :-)
        {
            input = Int32.Parse(Console.ReadLine());
        }
        catch
        {
            // Au lieu de cracher fait ça
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 0 et 7");
            input = -1;// Puisque l'input pris étais invalide, on met une valeur par défault qui sera elle aussi refuser pour que le programme redemande d'entrer l'input
        }
    }
}