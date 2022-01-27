namespace TNT
{
    public class CaisseAutomatique2 : Caisse
    {
        private int currentClient = 1;
        private string endingInput = "";
        private bool isRunning = true;

        public override void Process()
        {
            if (!isConsoleInit)
                SetConsole();

            Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");

            while(isRunning)
            {
                GetInput(true, $"Entrer le prix du produit pour le client {currentClient}");
                while (price <= 0)
                {
                    GetInput(true, "Prix invalide, entrez un prix plus grand que 0...");
                }

                GetInput(false, $"Entrer le montant d'argent que vous voulez que le client {currentClient} donne");
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
                isConsoleInit = false;
                isRunning = false;
            }
        }
    }
}