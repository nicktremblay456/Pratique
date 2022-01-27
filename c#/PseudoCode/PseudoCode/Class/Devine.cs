namespace TNT
{
    public class Devine
    {
        protected Random random = new Random();
        protected int randNumber, userGuess;
        protected bool isConsoleInit = false;

        public virtual void Process()
        {

        }

        protected void SetConsole()
        {
            if (Console.BackgroundColor != ConsoleColor.DarkCyan)
                Program.SetBackgroundColor(ConsoleColor.DarkCyan);
            Console.Clear();
            isConsoleInit = true;
        }

        protected virtual void GetInput()
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