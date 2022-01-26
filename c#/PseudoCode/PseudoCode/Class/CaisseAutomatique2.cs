namespace TNT
{
    public class CaisseAutomatique2
    {
        private float client, price;
        private int currentClient = 1;
        private string endingInput = "";
        private bool isRunning = true;

        public void Process()
        {
            Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");

            while(isRunning)
            {
                GetInput(true, $"Entrée le prix du produit pour le client {currentClient}");
                while (price <= 0)
                {
                    GetInput(true, "Prix invalide, entrez un prix plus grand que 0...");
                }

                GetInput(false, $"Entrée le montant d'argent que vous voulez que le client {currentClient} doit donner");
                while (client <= 0)
                {
                    GetInput(false, "Le montant du client est invalide, entrez un montant plus grand que 0...");
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
        private void GetInput(bool priceCheck, string message)
        {
            Console.WriteLine(message);
            try
            {
                if (priceCheck)
                    price = float.Parse(Console.ReadLine());
                else
                    client = float.Parse(Console.ReadLine());
            }
            catch
            {
                if (priceCheck)
                    price = 0.0f;
                else
                    client = 0.5f;
            }
        }

        private void End()
        {
            Console.WriteLine("Transaction terminée.\nEntrée 'y' pour passer au client suivant ou 'n' pour arrêter et retourner au menu principale");
            GetEndingInput();

            while (endingInput != "y" && endingInput != "Y" && endingInput != "n" && endingInput != "N")
            {
                Console.WriteLine("La valeur entrée est invalide \n Entrée 'y' pour passer au client suivant ou 'n' pour quitter");
                GetEndingInput();
            }
        }

        private void GetEndingInput()
        {
            endingInput = Console.ReadLine();

            if (endingInput == "y" || endingInput == "Y")
            {
                Console.WriteLine("Client suivant...");
                currentClient++;
            }
            else if (endingInput == "n" || endingInput == "N")
            {
                isRunning = false;
            }
        }
    }
}