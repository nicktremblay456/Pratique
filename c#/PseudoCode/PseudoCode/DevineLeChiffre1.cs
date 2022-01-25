namespace TNT
{
    /// <copyright file="DevineLeChiffre1.cs">
    /// Copyright © 2022 © All Rights Reserved
    /// </copyright>
    /// <author>Nicolas Tremblay</author>
    /// <date>2022/01/22 16:26 PM </date>
    /// <summary>Class representing Devine le chiffre Version 1</summary>
    public class DevineLeChiffre1
    {
        private Random random = new Random();
        private int randNumber, userGuess;

        public void Process()
        {
            // 101 parce que le 2eme chiffre en parametre de la fonction Next est exclusif
            // ce qui fait qu'il aurais génerer un nombre entre 1 et 100.
            randNumber = random.Next(1, 101);
            Console.WriteLine($"*CHEAT REPONSE* : {randNumber}");
            Console.WriteLine("Entrer un nombre en 1 et 100");
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
                Console.WriteLine($"Trouvé! :-) \nLe nombre est: {randNumber}");
                return;
            }

            Console.WriteLine(userGuess < randNumber ? "Plus petit, esseyer un nombre plus grand" : "Plus grand, esseyer un nombre plus petit");
        }
    }
}