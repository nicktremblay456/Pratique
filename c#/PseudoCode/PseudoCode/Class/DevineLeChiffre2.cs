namespace TNT
{
    public class DevineLeChiffre2 : Devine
    {
        private int maxTries;
        private const int MAX_TRIES = 10;

        public override void Process()
        {
            if (!isConsoleInit)
                SetConsole();

            maxTries = MAX_TRIES;
            randNumber = random.Next(1, 101);
            Console.WriteLine($"*CHEAT REPONSE* : {randNumber}");
            Console.WriteLine("Entrer un nombre entre 1 et 100, vous avez droit à 10 essais");
            GetInput();

            while (userGuess < 1 || userGuess > 100 || userGuess != randNumber && maxTries != 0)
            {
                GetInput();
            }

            isConsoleInit = false;
        }

        protected override void GetInput()
        {
            try { userGuess = Int32.Parse(Console.ReadLine()); }
            catch
            {
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre entre 1 et 100");
                userGuess = 0;
                return;
            }

            if (userGuess == randNumber)
            {
                Console.WriteLine($"Trouvé! :-) \nLe nombre est: {randNumber}");
                return;// early return parce qu'on veut pas perdre une vie si on a trouvé la réponse
            }

            Console.WriteLine(userGuess < randNumber ? "Plus petit, essayer un nombre plus grand" : "Plus grand, essayer un nombre plus petit");

            maxTries--;// Retire 1 vie
            Console.WriteLine(maxTries == 0 ? "Perdu :-(" : $"Il reste {maxTries} essai");
        }
    }
}