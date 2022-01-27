namespace TNT
{
    public class CaisseAutomatique1 : Caisse
    {
        public override void Process()
        {
            if (!isConsoleInit)
                SetConsole();

            Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");
            // Entrée prix du produit
            GetInput(true, "Entrer le prix du produit");
            while (price <= 0)
            {
                GetInput(true, "Prix invalide, entrez un prix plus grand que 0...");
            }
            // Entrée le montant d'argent donné par le client
            GetInput(false, "Entrer le montant d'argent que vous voulez que le client donne");
            while (client <= 0)
            {
                GetInput(false, "Le montant du client est invalide, entrez un montant plus grand que 0...");
            }

            // Utiliser le while loop si on veut que l'utilisateur entre le montant restant a payer lui même.
            //while (client != prix)
            //{
            Transaction(client < price ? false : true, client < price ? price - client : client - price);
            //}

            Console.WriteLine("Transaction terminée");

            isConsoleInit = false;
        }
    }
}