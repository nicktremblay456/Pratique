namespace TNT
{
    public class ComptageDeMot
    {
        private string txt = "";
        private bool isConsoleInit = false;

        private ConsoleColor color = ConsoleColor.DarkGray;

        /// <summary>
        /// Comptage de mot
        /// </summary>
        public void Process()
        {
            if (!isConsoleInit)
                SetConsole();

            string searchTerm = "le";

            Console.WriteLine("Écrivez une phrase et le programme vas compter le nombre de mot 'le' dans la phrase");
            txt = Console.ReadLine();

            // Convertie la phrase entrée par l'utilisateur en tableau de mots
            string[] source = txt.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<string> matchQuery = from word in source// from word in source = foreach(String word in source) 
                             where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()// if (word.tolowercase == searchterm.tolowercase)
                             select word;// Prend le word == a "le" et l'ajoute au tableau matchQuery
            
            int wordCount = matchQuery.Count();
            
            Console.WriteLine($"Total de LE: {wordCount}");

            isConsoleInit = false;
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