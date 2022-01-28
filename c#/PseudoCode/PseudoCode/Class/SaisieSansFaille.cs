namespace TNT
{
    public class SaisieSansFaille
    {
        private int input;
        private bool isConsoleInit = false;

        private ConsoleColor color = ConsoleColor.DarkRed;

        /// <summary>
        /// Saisie sans Faille
        /// </summary>
        public void Process()
        {
            if (!isConsoleInit)
                SetConsole();

            Console.WriteLine("Entrer un nombre entier entre 1 et 150");
            GetInput();

            while (input < 1 || input > 150)
            {
                GetInput();
            }

            isConsoleInit = false;
        }
        /// <summary>
        /// Prend l'input de l'utilisateur et effectue les vérification.
        /// </summary>
        private void GetInput()
        {
            try { input = int.Parse(Console.ReadLine()); }
            catch { input = 0; }

            Console.WriteLine((input >= 1 && input <= 150) ? "ACCEPTER" : "REFUSER \nLa valeur entrée est invalide, entrer un nombre entier entre 1 et 150");
        }
        /// <summary>
        /// Change la couleur du background de la console
        /// </summary>
        private void SetConsole()
        {
            Program.SetBackgroundColor(color);
            isConsoleInit = true;
        }
    }
}