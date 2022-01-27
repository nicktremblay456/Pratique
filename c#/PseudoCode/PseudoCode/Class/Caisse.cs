namespace TNT
{
    public class Caisse
    {
        protected float client, price;
        protected bool isConsoleInit = false;

        public virtual void Process()
        {

        }

        protected void SetConsole()
        {
            if (Console.BackgroundColor != ConsoleColor.DarkGreen)
                Program.SetBackgroundColor(ConsoleColor.DarkGreen);
            Console.Clear();
            isConsoleInit = true;
        }

        /// <summary>
        /// Effectue les calcules et détermine si il y a de l'argent a retourner ou si il en manque
        /// </summary>
        /// <param name="returnBack">Mettre a vrai si on dois retourner de l'argent au client, faux si le client dois donner plus</param>
        /// <param name="amount">Le montant restant ou de surplus a payer ou redonner</param>
        protected void Transaction(bool returnBack, float amount)
        {
            client = returnBack ? client - amount : client + amount;
            Console.WriteLine(returnBack ? $"Montant de surplus qui vous reviens: {amount} $" : $"Montant qui vous manque a payer: {amount} $\nVous donnez alors: {amount} $");
        }

        /// <summary>
        /// Prend l'input de l'utilisateur
        /// </summary>
        /// <param name="priceCheck">Mettre a true quand on veut assigner une value a la variable prix si non mettre faux pour le montant du client</param>
        /// <param name="message">Le message a afficher selon la situation</param>
        protected void GetInput(bool priceCheck, string message)
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
                    client = 0.0f;
            }
        }
    }
}