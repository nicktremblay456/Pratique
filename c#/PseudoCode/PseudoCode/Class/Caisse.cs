namespace TNT
{
    public class Caisse
    {
        #region Variables/Const
        private float client, price;
        private bool isConsoleInit = false, isRunning = true;
        private int currentClient = 1;
        private string endingInput = "";

        private ConsoleColor color = ConsoleColor.DarkGreen;
        #endregion
        
        /// <summary>
        /// Fonction traitement
        /// </summary>
        public void Process()
        {
            if (!isConsoleInit)
                SetConsole();

            Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");

            while (isRunning)
            {
                GetInput(ref price, $"Entrer le prix du produit pour le client {currentClient}");
                while (price <= 0)
                {
                    GetInput(ref price, "Prix invalide, entrez un prix plus grand que 0...");
                }

                GetInput(ref client, $"Entrer le montant d'argent que vous voulez que le client {currentClient} donne");
                while (client <= 0)
                {
                    GetInput(ref client, "Le montant du client est invalide, entrez un montant plus grand que 0...");
                }

                // Utiliser le while loop si on veut que l'utilisateur entre le montant restant a payer lui même.
                //while (client != prix)
                //{
                Transaction(client < price ? false : true, client < price ? price - client : client - price);
                //}

                End();
            }
        }
        /// <summary>
        /// Change la couleur du background de la console.
        /// </summary>
        private void SetConsole()
        {
            PseudoCode.SetBackgroundColor(color);
            isConsoleInit = true;
        }
        /// <summary>
        /// Effectue les calcules et détermine si il y a de l'argent a retourner ou si il en manque
        /// </summary>
        /// <param name="returnBack">Mettre a vrai si on dois retourner de l'argent au client, faux si le client dois donner plus</param>
        /// <param name="amount">Le montant restant ou de surplus a payer ou redonner</param>
        private void Transaction(bool returnBack, float amount)
        {
            client = returnBack ? client - amount : client + amount;
            Console.WriteLine(returnBack ? $"Montant de surplus qui vous reviens: {amount} $" : $"Montant qui vous manque a payer: {amount} $\nVous donnez alors: {amount} $");
        }
        /// <summary>
        /// Prend l'input de l'utilisateur
        /// </summary>
        /// <param name="priceCheck">Mettre a true quand on veut assigner une value a la variable prix si non mettre faux pour le montant du client</param>
        /// <param name="message">Le message a afficher selon la situation</param>
        private void GetInput(ref float value, string message)
        {
            Console.WriteLine(message);
            try
            {
                value = float.Parse(Console.ReadLine());
            }
            catch
            {
                value = 0f;
            }
        }
        /// <summary>
        /// Prend l'input de fin de partie pour demander si on refait une partie ou si on retourne au menu principale
        /// </summary>
        private void End()
        {
            Console.WriteLine("Transaction terminée.\nEntrer 'y' pour passer au client suivant ou 'n' pour arrêter et retourner au menu principale");
            GetEndingInput();

            while (endingInput != "y" && endingInput != "Y" && endingInput != "n" && endingInput != "N")
            {
                Console.WriteLine("La valeur entrée est invalide \nEntrer 'y' pour passer au client suivant ou 'n' pour quitter");
                GetEndingInput();
            }
        }
        /// <summary>
        /// Vérifie l'input entrée. si input = "y" => continue si non input == "n" break le while loop et retourne au menu principale.
        /// </summary>
        private void GetEndingInput()
        {
            endingInput = Console.ReadLine();

            if (endingInput == "y" || endingInput == "Y")
            {
                Console.Clear();
                Console.WriteLine("Client suivant...");
                currentClient++;
            }
            else if (endingInput == "n" || endingInput == "N")
            {
                isConsoleInit = false;
                isRunning = false;
            }
        }
    }
}