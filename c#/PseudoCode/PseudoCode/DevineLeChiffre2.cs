/// <copyright file="DevineLeChiffre2.cs">
/// Copyright © 2022 © All Rights Reserved
/// </copyright>
/// <author>Nicolas Tremblay</author>
/// <date>2022/01/22 16:26 PM </date>
/// <summary>Class representing Devine le chiffre Version 2</summary>
public class DevineLeChiffre2
{
    private Random random = new Random();
    private int randNumber, userGuess, maxTry = 10;

    public void Process()
    {
        randNumber = random.Next(1, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100, vous avez droit à 10 essais");
        GetInput();

        while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
        {
            GetInput();
        }
    }

    private void GetInput()
    {
        try { userGuess = Int32.Parse(Console.ReadLine()); }
        catch
        {
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
            userGuess = 0;
            return;
        }

        if (userGuess == randNumber)
        {
            Console.WriteLine("Trouvé! :-) \nLe nombre est: " + randNumber);
            return;// early return parce qu'on veut pas perdre une vie si on a trouvé la réponse
        }

        Console.WriteLine(userGuess < randNumber ? "Plus petit, esseyer un nombre plus grand" : "Plus grand, esseyer un nombre plus petit");

        maxTry--;// Retire 1 vie
        Console.WriteLine(maxTry == 0 ? "Perdu :-(" : "Il reste " + maxTry + " essai");
    }
}