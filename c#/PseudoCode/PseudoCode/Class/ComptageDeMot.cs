namespace TNT
{
    public class ComptageDeMot
    {
        private string txt = "";
        private bool isConsoleInit = false;

        private void SetConsole()
        {
            if (Console.BackgroundColor != ConsoleColor.DarkGray)
                Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            isConsoleInit = true;
        }

        public void Process()
        {
            if (!isConsoleInit)
                SetConsole();

            string searchTerm = "le";

            Console.WriteLine("Écrivez une phrase et le programme vas compter le nombre de mot 'le' dans la phrase");
            try { txt = Console.ReadLine(); }
            catch { txt = ""; }

            // Convertie le string en tableau de mot.
            string[] source = txt.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Crée un requête. Utilise ToLowerInvariant pour matcher "le" et "Le"
            IEnumerable<string> matchQuery = from word in source
                             where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
                             select word;
            
            int wordCount = matchQuery.Count();
            
            Console.WriteLine($"Total de LE: {wordCount}");

            isConsoleInit = false;
        }
    }
}