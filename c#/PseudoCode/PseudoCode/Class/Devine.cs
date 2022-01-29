﻿namespace TNT
{
    public class Devine
    {
        #region Variables/Const
        private Random random = new Random();
        private int randNumber, userGuess;
        private bool isConsoleInit = false;
        private int maxTries;
        private string endingInput = "";
        
        private ConsoleColor color = ConsoleColor.DarkMagenta;
        
        private const int MAX_TRIES = 10;
        #endregion

        /// <summary>
        /// Fonction traitement
        /// </summary>
        public void Process()
        {
            if (!isConsoleInit)
                SetConsole();

            maxTries = MAX_TRIES;
            randNumber = random.Next(1, 101);

            Console.WriteLine($"*CHEAT REPONSE* : {randNumber}");
            Console.WriteLine("Entrer un nombre entre 1 et 100, vous avez droit à 10 essais");
            GetInput(isFirstVersion: false);

            while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
            {
                if (maxTries == 0) break;
                GetInput(isFirstVersion: false);
            }

            End();
        }
        /// <summary>
        /// Change la couleur du background de la console
        /// </summary>
        private void SetConsole()
        {
            Program.SetBackgroundColor(color);
            isConsoleInit = true;
        }
        /// <summary>
        /// Prend l'input de l'utilisateur, effectue les vérifications et affiche un message dans la console pour donner un indice.
        /// Il peut aussi gêrer le nombre d'essais de l'utilisateur.
        /// </summary>
        /// <param name="isFirstVersion">Si il est true alors il ne comptera pas le nombre d'essai.</param>
        private void GetInput(bool isFirstVersion)
        {
            try { userGuess = int.Parse(Console.ReadLine()); }
            catch
            {
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre entre 1 et 100");
                userGuess = 0;
                return;
            }

            if (userGuess == randNumber)
            {
                Console.WriteLine($"Trouvé! :-) \nLe nombre est: {randNumber}");
                return;
            }

            Console.WriteLine(userGuess < randNumber ? "Plus petit, essayer un nombre plus grand" : "Plus grand, essayer un nombre plus petit");
        
            if (!isFirstVersion)
            {
                maxTries--;
                Console.WriteLine(maxTries == 0 ? "Perdu :-(" : $"Il reste {maxTries} essais");
            }
        }
        /// <summary>
        /// Prend l'input de fin de partie pour demander si on refait une partie ou si on retourne au menu principale
        /// </summary>
        private void End()
        {
            Console.WriteLine("Entrer y pour commencer une nouvelle partie ou n pour retourner au menu principale");
            GetEndingInput();

            while (endingInput != "y" && endingInput != "Y" && endingInput != "n" && endingInput != "N")
            {
                Console.WriteLine("La valeur entrée est invalide \n Entrer 'y' pour commencer une nouvelle partie ou 'n' pour quitter");
                GetEndingInput();
            }
        }
        /// <summary>
        /// Vérifie l'input entrée. si input = "y" => continue si non input == "n" break le while loop et retourne au menu principale.
        /// </summary>
        private void GetEndingInput()
        {
            endingInput = Console.ReadLine();

            if (endingInput == "y" || endingInput == "Y")
            {
                maxTries = MAX_TRIES;
                endingInput = "";
                Console.Clear();
                Process();
            }
            else if (endingInput == "n" || endingInput == "N")
            {
                isConsoleInit = false;
            }
        }
    }
}