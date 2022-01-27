namespace TNT
{
    public class DevineLeChiffre3
    {
        private int randNumber, userGuess, maxTries;
        private string endingInput = "";
        private bool isRunning = true, isConsoleInit = false;

        private const int MaxTries = 10;

        private void SetConsole()
        {
            if (Console.BackgroundColor != ConsoleColor.DarkCyan)
                Program.SetBackgroundColor(ConsoleColor.DarkCyan);
            Console.Clear();
            isConsoleInit = true;
        }

        public void Process()
        {
            if (!isConsoleInit)
                SetConsole();

            Random random = new Random();
            maxTries = MaxTries;
            randNumber = random.Next(1, 101);

            Console.WriteLine($"*CHEAT REPONSE* : {randNumber}");
            Console.WriteLine("Entrer un nombre entre 1 et 100, vous avez droit à 10 essais");
            GetInput();

            while (isRunning)
            {
                while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
                {
                    if (maxTries == 0) break;
                    GetInput();
                }

                End();
            }
        }

        private void GetInput()
        {
            try
            {
                userGuess = int.Parse(Console.ReadLine());
            }
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

            Console.WriteLine((userGuess < randNumber && maxTries != 0) ? "Plus petit, essayer un nombre plus grand" : "Plus grand, essayer un nombre plus petit");

            maxTries--;
            Console.WriteLine(maxTries == 0 ? "Perdu :-(" : $"Il reste {maxTries} essai");
        }

        private void End()
        {
            Console.WriteLine("Entrer y pour commencer une nouvelle partie ou n pour retourner au menu principale");
            GetEndingInput();

            while (endingInput != "y" && endingInput != "Y" && endingInput != "n" && endingInput != "N")
            {
                Console.WriteLine("La valeur entrée est invalide \n Entrer y pour commencer une nouvelle partie ou n pour quitter");
                GetEndingInput();
            }
        }

        private void GetEndingInput()
        {
            endingInput = Console.ReadLine();

            if (endingInput == "y" || endingInput == "Y")
            {
                maxTries = 10;
                endingInput = "";
                Console.Clear();
                Process();
            }
            else if (endingInput == "n" || endingInput == "N")
            {
                isConsoleInit = false;
                isRunning = false;
            }
        }
    }
}