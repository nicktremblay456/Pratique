using System.Text.RegularExpressions;

/// <copyright file="Program.cs">
/// Copyright © 2022 © All Rights Reserved
/// </copyright>
/// <author>Nicolas Tremblay</author>
/// <date>2022/01/22 16:26 PM </date>
/// <summary>Class representing all pseudocode in a single program</summary>
public class PseudoCode
{
    // Data structure qui contient les sous programmes
    private struct ProgramsData
    {
        private CaisseAutomatique1 caisse1;
        private CaisseAutomatique2 caisse2;
        private ComptageDeMot comptage;
        private SaisieSansFaille saisie;
        private DevineLeChiffre1 devine1;
        private DevineLeChiffre2 devine2;
        private DevineLeChiffre3 devine3;

        // Props, propriétés public qui nous permet d'accèder aux values variables en haut sans pouvoir modifier leur valeur
        // On pourrais juste mettre les variable en haut public mais je veut pas qu'on puisse modifier leur value
        /*
         * L'operateur => (appeler lambda) revient au même que faire, google pour plus d'info sur les props et lambda...
         * get
         * {
         *      return caisse1;
         * }
         */
        public CaisseAutomatique1 Caisse1 { get => caisse1; }
        public CaisseAutomatique2 Caisse2 { get => caisse2; }
        public ComptageDeMot Comptage { get => comptage; }
        public SaisieSansFaille Saisie { get => saisie; }
        public DevineLeChiffre1 DevineLeChiffre1 { get => devine1; }
        public DevineLeChiffre2 DevineLeChiffre2 { get => devine2; }
        public DevineLeChiffre3 DevineLeChiffre3 { get => devine3; }

        public ProgramsData()// Constructor
        {
            // Initialise
            caisse1 = new CaisseAutomatique1();// operateur new pour créer une instance de la class
            caisse2 = new CaisseAutomatique2();
            comptage = new ComptageDeMot();
            saisie = new SaisieSansFaille();
            devine1 = new DevineLeChiffre1();
            devine2 = new DevineLeChiffre2();
            devine3 = new DevineLeChiffre3();
        }
    }

    private static ProgramsData data = new ProgramsData();

    private static int input = 0;
    private static bool isRunning = true;

    /// <summary>
    /// Fonction principale qui fait rouler tout
    /// </summary>
    private static void Main()
    {
        while(isRunning)
        {
            Program();
        }
    }

    private static void Program()
    {
        Console.WriteLine("Entrer 0, 1, 2, 3, 4, 5, 6 ou 7 pour choisir quoi faire. \n" +
                          "1: Caisse automatique VERSION 1 \n" +// \n pour skipper une ligne au lieu de faire plein de console.writeline()
                          "2: Caisse automatique VERSION 2 \n" +
                          "3: Comptage de mot *WORK IN PROGRESS* \n" +
                          "4: Saisie sans faille \n" +
                          "5: Devine le chiffre VERSION 1 \n" +
                          "6: Devine le chiffre VERSION 2 \n" +
                          "7: Devine le chiffre VERSION 3 \n" +
                          "0: Quitter");
        GetInput();
        // La fonction comptage de mot n'est 100% fonctionnel
        while (input < 0 || input > 7)
        {
            GetInput();
        }
        Console.Clear();// Comme on le lis.. Clear la console.
        switch (input)// plus clean que faire 8 if et else if
        {
            case 0: isRunning = false; break;// Coupe la boucle while dans la fonction Main() qui fait runner le programme
            case 1: data.Caisse1.Process(); break; // Appel la fonction process un passant par la props setter dans la struct en haut
            case 2: data.Caisse2.Process(); break;
            case 3: data.Comptage.Process(); break;
            case 4: data.Saisie.Process(); break;
            case 5: data.DevineLeChiffre1.Process(); break;
            case 6: data.DevineLeChiffre2.Process(); break;
            case 7: data.DevineLeChiffre3.Process(); break;
        }

        if (isRunning)// Pas afficher le message inutilement et d'appuyer sur une touche si l'utilisateur veut quitter
        {
            // Fin du sous programme
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();// Attend que l'utilisateur appuis sur une touche avant de continuer
            Console.Clear();
        }
    }

    private static void GetInput()
    {
        try// bloc try parce que on a une chance d'esseyer d'assigner un caractere a une variable de type int, resultat -> crash :-)
        {
            input = Int32.Parse(Console.ReadLine());
        }
        catch
        {
            // Au lieu de cracher fait ça
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 0 et 7");
            input = -1;// Puisque l'input pris étais invalide, on met une valeur par défault qui sera elle aussi refuser pour que le programme redemande d'entrer l'input
        }
    }
}

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
        // le ? c'est un operateur ternaire, google it ;p
        Transaction(client < price ? false : true, client < price ? price - client : client - price);
        //}

        Console.WriteLine("Transaction terminer");
    }

    /// <summary>
    /// Effectue les calcules et détermine si il y a de l'argent a retourner ou si il en manque
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
                client = 0.0f;
        }
    }
}

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
            while(price <= 0)
            {
                GetInput(true, "Prix invalide, entrez un prix plus grand que 0...");
            }

            GetInput(false, "Entrée le montant d'argent que vous voulez que le client " + (i + 1) + " doit donner");
            while(client <= 0)
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

// WORK IN PROGRESS
public class ComptageDeMot
{
    private string sentence = "";

    public void Process()
    {
        // Retirer quand fixer
        Console.WriteLine("*WORK IN PROGRESS* NE FONCTIONNE PAS DANS TOUS LES SITUATIONS");

        Console.WriteLine("Écrivez un phrase et le programme vas compter le nombre de 'le' dans la phrase");
        try { sentence = Console.ReadLine(); }
        catch { sentence = ""; }

        int count = Regex.Matches(sentence, "le").Count;
        Console.WriteLine("Total de LE: " + count);
    }
}

public class SaisieSansFaille
{
    private int input;

    public void Process()
    {
        Console.WriteLine("Entrer un nombre entier entre 1 et 150");
        GetInput();

        while (input < 1 || input > 150)
        {
            GetInput();
        }
    }

    private void GetInput()
    {
        try
        {
            input = Int32.Parse(Console.ReadLine());
        }
        catch
        {
            input = 0;
        }

        Console.WriteLine((input >= 1 && input <= 150) ? "ACCEPTER" : "REFUSER \n La valeur entrée est invalide, entrer un nombre entier entre 1 et 150");
    }
}

public class DevineLeChiffre1
{
    private Random random = new Random();
    private int randNumber, userGuess;

    public void Process()
    {
        // 101 parce que le 2eme chiffre en parametre de la fonction Next est exclusif
        // ce qui fait qu'il aurais génerer un nombre entre 1 et 100.
        // Même principe pour le 0
        randNumber = random.Next(1, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100");
        GetInput();

        while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
        {
            GetInput();
        }

        Console.WriteLine("Trouvé! Le nombre est: " + randNumber);
    }

    private void GetInput()
    {
        try { userGuess = Int32.Parse(Console.ReadLine()); }
        catch
        {
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
            userGuess = 0;
            return;
            // early return parce que je veut préciser a l'utilisateur qu'il a entrée un input autre qu'un nombre entier
            // et parce qu'on set userGuess a 0 donc l'ordi obligatoirement le message qui dit que le nombre est trop petit sera afficher
            // ce qui n'aurais pas sens.
        }

        Console.WriteLine(userGuess < randNumber ? "Plus petit, esseyer un nombre plus grand" : "Plus grand, esseyer un nombre plus petit");
    }
}

public class DevineLeChiffre2
{
    private Random random = new Random();
    private int randNumber, userGuess, maxTry = 10;

    public void Process()
    {
        randNumber = random.Next(1, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100, vous avez droit à 10 essais");
        GetInput();

        while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
        {
            GetInput();
        }

        Console.WriteLine("Trouvé! Le nombre est: " + randNumber);
    }

    private void GetInput()
    {
        try { userGuess = Int32.Parse(Console.ReadLine()); }
        catch
        {
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
            userGuess = 0;
            return;
        }

        if (userGuess == randNumber)
            return;// early return parce qu'on veut pas perdre une vie si on a trouvé la réponse
        
        Console.WriteLine(userGuess < randNumber ? "Plus petit, esseyer un nombre plus grand" : "Plus grand, esseyer un nombre plus petit");
        
        maxTry--;// Retire 1 vie
        Console.WriteLine(maxTry == 0 ? "Perdu :-(" : "Il reste " + maxTry + " essai");
    }
}

public class DevineLeChiffre3
{
    private Random random = new Random();
    private int randNumber, userGuess, maxTry = 10;
    private string endingInput = "";
    private bool isRunning = true;

    public void Process()
    {
        randNumber = random.Next(1, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100, vous avez droit à 10 essais");
        GetInput();

        while(isRunning)
        {
            while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
            {
                GetInput();
            }

            Console.WriteLine("Trouvé! :-) \n Le nombre est: " + randNumber);
            End();
        }
    }

    private void GetInput()
    {
        try
        {
            userGuess = Int32.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
            userGuess = 0;
            return;
        }
        
        if (userGuess == randNumber)
            return;

        Console.WriteLine(userGuess < randNumber ? "Plus petit, esseyer un nombre plus grand" : "Plus grand, esseyer un nombre plus petit");

        maxTry--;
        Console.WriteLine(maxTry == 0 ? "Perdu :-(" : "Il reste " + maxTry + " essai");
    }

    private void End()
    {
        Console.WriteLine("Entrée y pour commencer une nouvelle partie ou n pour quitter");
        GetEndingInput();

        while (endingInput != "y" && endingInput != "Y" && endingInput != "n" && endingInput != "N")
        {
            Console.WriteLine("La valeur entrée est invalide \n Entrée y pour commencer une nouvelle partie ou n pour quitter");
            GetEndingInput();
        }
    }

    private void GetEndingInput()
    {
        endingInput = Console.ReadLine();

        if (endingInput == "y" || endingInput == "Y")
        {
            maxTry = 10;
            endingInput = "";
            Console.Clear();
            Process();
        }
        else if (endingInput == "n" || endingInput == "N")
        {
            isRunning = false;
        }
    }
}