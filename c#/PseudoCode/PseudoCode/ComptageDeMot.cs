using System.Text.RegularExpressions;

/*
 
                              *****************WORK IN PROGRESS*****************
 
 */

/// <copyright file="Program.cs">
/// Copyright © 2022 © All Rights Reserved
/// </copyright>
/// <author>Nicolas Tremblay</author>
/// <date>2022/01/22 16:26 PM </date>
/// <summary>Class representing Comptage de mot</summary>
public class ComptageDeMot
{
    private string sentence = "";

    public void Process()
    {
        // Retirer quand fixer
        Console.WriteLine("*WORK IN PROGRESS* NE FONCTIONNE PAS DANS TOUS LES SITUATIONS");

        Console.WriteLine("Écrivez un phrase et le programme vas compter le nombre de 'le' dans la phrase");
        try { sentence = Console.ReadLine(); }
        catch { sentence = ""; }

        int count = Regex.Matches(sentence, "le").Count;
        Console.WriteLine("Total de LE: " + count);
    }
}