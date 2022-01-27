namespace TNT
{
    public class Devine
    {
        private Random random = new Random();
        private int randNumber, userGuess;
        private bool isConsoleInit = false, isRunning = true;
        private int maxTries;
        private string endingInput = "";
        
        private ConsoleColor color = ConsoleColor.DarkMagenta;
        
        private const int MAX_TRIES = 10;


        public void Process_Version_1()
        {
            if (!isConsoleInit)
                SetConsole();

            // 101 parce que le 2eme chiffre en parametre de la fonction Next est exclusif
            // ce qui fait qu'il aurais génerer un nombre entre 1 et 99.
            randNumber = random.Next(1, 101);
            Console.WriteLine($"*CHEAT REPONSE* : {randNumber}");
            Console.WriteLine("Entrer un nombre entre 1 et 100");
            GetInput(isFirstVersion: true);

            while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
            {
                GetInput(isFirstVersion: true);
            }

            isConsoleInit = false;
        }

        public void Process_Version_2()
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
                if (maxTries == 0)
                    break;
                GetInput(isFirstVersion: false);
            }

            isConsoleInit = false;
        }

        public void Process_Version_3()
        {
            if (!isConsoleInit)
                SetConsole();

            maxTries = MAX_TRIES;
            randNumber = random.Next(1, 101);

            Console.WriteLine($"*CHEAT REPONSE* : {randNumber}");
            Console.WriteLine("Entrer un nombre entre 1 et 100, vous avez droit à 10 essais");
            GetInput(isFirstVersion: false);

            while (isRunning)
            {
                while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
                {
                    if (maxTries == 0) break;
                    GetInput(isFirstVersion: false);
                }

                End();
            }
        }

        private void SetConsole()
        {
            Program.SetBackgroundColor(color);
            if (!isRunning)
                isRunning = true;
            isConsoleInit = true;
        }

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
                Console.WriteLine(maxTries == 0 ? "Perdu :-(" : $"Il reste {maxTries} essai");
            }
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
                Process_Version_3();
            }
            else if (endingInput == "n" || endingInput == "N")
            {
                isConsoleInit = false;
                isRunning = false;
            }
        }
    }
}