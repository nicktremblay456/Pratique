﻿namespace TNT
{
    public class Devine
    {
        #region Variables/Const
        private Random random = new Random();
        private int minNumber, maxNumber, randNumber, userGuess, difficultyInput;
        private bool isConsoleInit = false, isInvinsible = false;
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

            SetDifficulty();
            while (difficultyInput == 0)
            {
                SetDifficulty();
            }

            maxTries = MAX_TRIES;
            randNumber = random.Next(minNumber, maxNumber);

            Console.WriteLine($"Entrer un nombre entre {minNumber} et {maxNumber}, vous avez droit à {MAX_TRIES} essais");
            GetInput();

            while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
            {
                if (maxTries == 0) break;
                GetInput();
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
        /// Demande a l'utilisateur de choisir la difficultée
        /// </summary>
        private void SetDifficulty()
        {
            Console.WriteLine("Entrer 1, 2 ou 3 pour choisir la difficulter.\n\n" +
                              "1: Facile\n" +
                              "2: Moyen\n" +
                              "3: Difficile\n");
            try { difficultyInput = int.Parse(Console.ReadLine()); }
            catch { difficultyInput = 0; }

            switch (difficultyInput)
            {
                case 1: maxNumber = 100; break;
                case 2: maxNumber = 150; break;
                case 3: maxNumber = 200; break;
            }

            Console.Clear();
        }
        /// <summary>
        /// Prend l'input de l'utilisateur, effectue les vérifications et affiche un message dans la console pour donner un indice.
        /// Il peut aussi gêrer le nombre d'essais de l'utilisateur.
        /// </summary>
        private void GetInput()
        {
            try 
            { 
                userGuess = int.Parse(Console.ReadLine());
                if (userGuess == -1)// Cheat code commande
                {
                    Cheat();
                    userGuess = 0;
                    return;
                }
            }
            catch
            {
                Console.WriteLine($"La valeur entrée est invalide, entrer un nombre entre {minNumber} et {maxNumber}");
                userGuess = 0;
                return;
            }

            if (userGuess == randNumber)
            {
                Console.WriteLine($"Trouvé! :-) \nLe nombre est: {randNumber}");
                End();
                return;
            }

            Console.WriteLine(userGuess < randNumber ? "Plus petit, essayer un nombre plus grand" : "Plus grand, essayer un nombre plus petit");
            if (isInvinsible) return;
            maxTries--;
            Console.WriteLine(maxTries == 0 ? "Perdu :-(" : $"Il reste {maxTries} essais");
        }
        /// <summary>
        /// Prend l'input de fin de partie pour demander si on refait une partie ou si on retourne au menu principale
        /// </summary>
        private void End()
        {
            Console.WriteLine("Entrer 'Y' pour commencer une nouvelle partie ou 'N' pour retourner au menu principale");
            GetEndingInput();

            while (endingInput.ToLowerInvariant() != "y" && endingInput.ToLowerInvariant() != "n")
            {
                Console.WriteLine("La valeur entrée est invalide \n Entrer 'Y' pour commencer une nouvelle partie ou 'N' pour quitter");
                GetEndingInput();
            }
        }
        /// <summary>
        /// Vérifie l'input entrée. si input = "y" => continue si non input == "n" break le while loop et retourne au menu principale.
        /// </summary>
        private void GetEndingInput()
        {
            endingInput = Console.ReadLine();

            if (endingInput.ToLowerInvariant() == "y")
            {
                maxTries = MAX_TRIES;
                endingInput = "";
                Console.Clear();
                Process();
            }
            else if (endingInput.ToLowerInvariant() == "n")
            {
                isConsoleInit = false;
                if (isInvinsible) isInvinsible = false;
                difficultyInput = 0;
            }
        }
        /// <summary>
        /// Permet a l'utilisateur de tricher en entrant un code secret
        /// </summary>
        private void Cheat()
        {
            Console.WriteLine("***Enter Cheat Menu***\n");
            string cheat = Console.ReadLine();
            switch (cheat)
            {
                case "iddqd":
                case "IDDQD": isInvinsible = true; Console.WriteLine("*Nombre d'essais infini*\n"); break;
                case "idkfa":
                case "IDKFA": Console.WriteLine($"*CHEAT REPONSE* : {randNumber}\n"); break;
                default: Console.WriteLine("Cheat inconnu\n"); break;
            }
            Console.WriteLine($"***Exit Cheat Menu***\n\nEntrer un nombre entre {minNumber} et {maxNumber}");
        }
    }
}