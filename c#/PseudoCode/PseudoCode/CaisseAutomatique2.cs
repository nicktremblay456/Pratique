public class CaisseAutomatique2
{
    private float client, price;
    private int totalClients = 5;

    public void Process()
    {
        Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");

        for (int i = 0; i < totalClients; i++)
        {
            GetInput(true, "Entrée le prix du produit pour le client " + (i + 1));
            while (price <= 0)
            {
                GetInput(true, "Prix invalide, entrez un prix plus grand que 0...");
            }

            GetInput(false, "Entrée le montant d'argent que vous voulez que le client " + (i + 1) + " doit donner");
            while (client <= 0)
            {
                GetInput(false, "Le montant du client est invalide, entrez un montant plus grand que 0...");
            }

            // Utiliser le while loop si on veut que l'utilisateur entre le montant restant a payer lui même.
            //while (client != prix)
            //{
            Transaction(client < price ? false : true, client < price ? price - client : client - price);
            //}

            Console.WriteLine("Transaction terminer. Clients Restant: " + (totalClients - (i + 1)) + "\n");
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
        Console.WriteLine(returnBack ? "Montant de surplus qui vous reviens: " + amount + "$" : "Montant qui vous manque a payer: " + amount + "$" + "\nVous donnez alors: " + amount + "$");
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
            // Placer dans le bloque try car l'assignation du prix ou montant du client entrée
            // par l'utilisateure peut etre autre chose qu'un float/int ce qui peut faire cracher le programme
            if (priceCheck)
                // la fonction parse cherche un float ou int a dans le string que retourn ReadLine (input entrée par l'utilisateur)
                price = float.Parse(Console.ReadLine());
            else
                client = float.Parse(Console.ReadLine());
        }
        catch
        {
            // Si le try échoue, on rattrape l'erreur
            if (priceCheck)
                price = 0.0f;
            else
                client = 0.5f;
        }
    }
}