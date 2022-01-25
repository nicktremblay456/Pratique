using TNT;
/// <copyright file="PseudoCode.cs">
/// Copyright © 2022 © All Rights Reserved
/// </copyright>
/// <author>Nicolas Tremblay</author>
/// <date>2022/01/22 16:26 PM </date>
/// <summary>Class representing all pseudocode in a single program</summary>
public class PseudoCode
{
    // Data structure qui contient les sous programmes
    private static ProgramData data = new ProgramData();// Initialise le data avec new
    private static Option userChoice = Option.NONE;// un enum.. 
    private static bool isRunning = true;

    /// <summary>
    /// Fonction principale qui fait rouler tout, on peut pas runner notre code sans
    /// voir même une erreur vas être generer disant qu'il manque une method static main()
    /// </summary>
    private static void Main()
    {
        while (isRunning)
        {
            Program();
        }
    }

    private static void Program()
    {
        Console.WriteLine("Entrer 0, 1, 2, 3, 4, 5, 6 ou 7 pour choisir quoi faire.\n\n" +
                          "1: Caisse automatique VERSION 1\n" +// \n pour skipper une ligne au lieu de faire plein de console.writeline()
                          "2: Caisse automatique VERSION 2\n" +
                          "3: Comptage de mot\n" +
                          "4: Saisie sans faille\n" +
                          "5: Devine le chiffre VERSION 1\n" +
                          "6: Devine le chiffre VERSION 2\n" +
                          "7: Devine le chiffre VERSION 3\n" +
                          "0: Quitter");
        GetInput();
        while ((int)userChoice < 0 || (int)userChoice > 7)
        {
            GetInput();
        }
        Console.Clear();// Comme on le lis.. Clear la console.
        switch (userChoice)// plus clean que faire 8 if et else if
        {
            case Option.QUIT: isRunning = false; break;// Coupe la boucle while dans la fonction Main() qui fait runner le programme
            case Option.CAISSE_VERSION_1: data.Caisse1.Process(); break; // Appel la fonction process en passant par la props setter dans la struct ProgramsData
            case Option.CAISSE_VERSION_2: data.Caisse2.Process(); break;
            case Option.COMPTAGE_DE_MOT: data.Comptage.Process(); break;
            case Option.SAISIE_SANS_FAILLE: data.Saisie.Process(); break;
            case Option.DEVINE_VERSION_1: data.DevineLeChiffre1.Process(); break;
            case Option.DEVINE_VERSION_2: data.DevineLeChiffre2.Process(); break;
            case Option.DEVINE_VERSION_3: data.DevineLeChiffre3.Process(); break;
        }

        if (isRunning)// Pour pas afficher le message inutilement et d'appuyer sur une touche si l'utilisateur veut quitter
        {
            // Fin du sous programme
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principale...");
            Console.ReadKey();// Attend que l'utilisateur appuis sur une touche (n'importe laquelle) avant de continuer
            Console.Clear();
        }
    }

    private static void GetInput()
    {
        try// bloc try parce que on a une chance d'esseyer d'assigner un caractere a une variable de type int, resultat -> crash :-)
        {
            userChoice = (Option)Int32.Parse(Console.ReadLine());
        }
        catch
        {
            // Au lieu de cracher fait ça
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 0 et 7");
            userChoice = Option.NONE;// Puisque l'input pris étais invalide, on met une valeur par défault qui sera elle aussi refuser pour que le programme redemande d'entrer l'input
        }
    }
}