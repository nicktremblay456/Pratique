namespace TNT
{
    public class DevineLeChiffre3
    {
        private int randNumber, userGuess, maxTries;
        private string endingInput = "";
        private bool isRunning = true;

        private const int MaxTries = 10;

        public void Process()
        {
            Random random = new Random();
            maxTries = MaxTries;
            randNumber = random.Next(1, 101);

            Console.WriteLine($"*CHEAT REPONSE* : {randNumber}");
            Console.WriteLine("Entrer un nombre en 1 et 100, vous avez droit à 10 essais");
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
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
                userGuess = 0;
                return;
            }

            if (userGuess == randNumber)
            {
                Console.WriteLine($"Trouvé! :-) \nLe nombre est: {randNumber}");
                return;
            }

            Console.WriteLine((userGuess < randNumber && maxTries != 0) ? "Plus petit, esseyer un nombre plus grand" : "Plus grand, esseyer un nombre plus petit");

            maxTries--;
            Console.WriteLine(maxTries == 0 ? "Perdu :-(" : $"Il reste {maxTries} essai");
        }

        private void End()
        {
            Console.WriteLine("Entrée y pour commencer une nouvelle partie ou n pour retourner au menu principale");
            GetEndingInput();

            while (endingInput != "y" && endingInput != "Y" && endingInput != "n" && endingInput != "N")
            {
                Console.WriteLine("La valeur entrée est invalide \n Entrée y pour commencer une nouvelle partie ou n pour quitter");
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
                isRunning = false;
            }
        }
    }
}