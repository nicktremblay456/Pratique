namespace TNT
{
    /// <copyright file="CaisseAutomatique1.cs">
    /// Copyright © 2022 © All Rights Reserved
    /// </copyright>
    /// <author>Nicolas Tremblay</author>
    /// <date>2022/01/22 16:26 PM </date>
    /// <summary>Class representing Caisse Automatique version 1</summary>
    public class CaisseAutomatique1
    {
        private float price, client;

        public void Process()
        {
            Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");

            // Demande a l'utilisateur d'entrée un prix et vérifie si la valeur entrée est plus grand que 0
            // ou si c'est vraiment un nombre et non un caractere
            GetInput(true, "Entrée le prix du produit");
            while (price <= 0)
            {
                GetInput(true, "Prix invalide, entrez un prix plus grand que 0...");
            }

            // Demande a l'utilisateur d'entrée un montant et vérifie si la valeur entrée est plus grand que 0 
            // ou si c'est vraiment un nombre et non un caractere
            GetInput(false, "Entrée le montant d'argent que vous voulez donner");
            while (client <= 0)
            {
                GetInput(false, "Le montant du client est invalide, entrez un montant plus grand que 0...");
            }

            // Utiliser le while loop si on veut que l'utilisateur entre le montant restant a payer lui même.
            //while (client != prix)
            //{
            Transaction(client < price ? false : true, client < price ? price - client : client - price);
            //}

            Console.WriteLine("Transaction terminer");
        }

        /// <summary>
        /// Effectue les calcules et détermine si il y a de l'argent a retourner ou si il en manque à payer
        /// </summary>
        /// <param name="returnMoney">Mettre a vrai si on dois retourner de l'argent au client, faux si le client dois donner plus</param>
        /// <param name="amount">Le montant restant ou de surplus a payer ou redonner</param>
        private void Transaction(bool returnMoney, float amount)
        {
            client = returnMoney ? client + amount : client - amount;
            Console.WriteLine(returnMoney ? "Montant de surplus qui vous reviens: " + amount + "$" : "Montant qui vous manque a payer: " + amount + "$" + "\nVous donnez alors: " + amount + "$");
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
                    price = float.Parse(Console.ReadLine());
                else
                    client = float.Parse(Console.ReadLine());
            }
            catch
            {
                if (priceCheck)
                    price = 0.0f;
                else
                    client = 0.0f;
            }
        }
    }
}