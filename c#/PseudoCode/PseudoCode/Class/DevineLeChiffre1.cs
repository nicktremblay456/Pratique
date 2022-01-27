namespace TNT
{
    public class DevineLeChiffre1
    {
        private Random random = new Random();
        private int randNumber, userGuess;
        private bool isConsoleInit = false;


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

            // 101 parce que le 2eme chiffre en parametre de la fonction Next est exclusif
            // ce qui fait qu'il aurais génerer un nombre entre 1 et 99.
            randNumber = random.Next(1, 101);
            Console.WriteLine($"*CHEAT REPONSE* : {randNumber}");
            Console.WriteLine("Entrer un nombre entre 1 et 100");
            GetInput();

            while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
            {
                GetInput();
            }

            isConsoleInit = false;
        }

        private void GetInput()
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
        }
    }
}