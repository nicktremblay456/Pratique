namespace TNT
{
    public class DevineLeChiffre1 : Devine
    {
        public override void Process()
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
    }
}