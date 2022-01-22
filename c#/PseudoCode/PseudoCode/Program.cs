using System.Text.RegularExpressions;

// <copyright file="Program.cs">
// Copyright © 2022 © All Rights Reserved
// </copyright>
// <author>Nicolas Tremblay</author>
// <date>2022/01/22 15:23:58 PM </date>
// <summary>Class representing all pseudocode in a single program</summary>
public class PseudoCode
{
    private struct ProgramsData
    {
        private CaisseAutomatique1 caisse1;
        private CaisseAutomatique2 caisse2;
        private ComptageDeMot comptage;
        private SaisieSansFaille saisie;
        private DevineLeChiffre1 devine1;
        private DevineLeChiffre2 devine2;
        private DevineLeChiffre3 devine3;
        
        // Props
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
            caisse1 = new CaisseAutomatique1();
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
    private static string inputStr = "";
    private static bool isRunning = true;

    /// <summary>
    /// Fonction principale qui fait rouler tout
    /// </summary>
    private static void Main()
    {
        while(isRunning)
        {
            Programme();
        }
    }

    private static void Programme()
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
        Verification();
        // La fonction comptage de mot n'est 100% fonctionnel
        while (!Int32.TryParse(inputStr, out input) || input < 0 || input > 7)
        {
            Verification();
        }
        Console.Clear();
        switch (input)// plus clean que faire 10 if et else if
        {
            case 0:
                // Coupe la boucle while dans la fonction Main() qui fait runner le programme
                isRunning = false;
                break;
            case 1:
                data.Caisse1.Traitement();
                break;
            case 2:
                data.Caisse2.Traitement();
                break;
            case 3:
                data.Comptage.Traitement();
                break;
            case 4:
                data.Saisie.Traitement();
                break;
            case 5:
                data.DevineLeChiffre1.Traitement();
                break;
            case 6:
                data.DevineLeChiffre2.Traitement();
                break;
            case 7:
                data.DevineLeChiffre3.Traitement();
                break;
        }
    }

    private static void Verification()
    {
        inputStr = Console.ReadLine();

        try// bloc try parce que on a une chance d'esseyer d'assigner un caractere a une variable de type int, resultat = crash :-)
        {
            input = Int32.Parse(inputStr);
        }
        catch
        {
            // Au lieu de cracher fait ça
            if (!Int32.TryParse(inputStr, out input))//si il y pas de int dans le string qui contient l'input entrée par le user
            {
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 0 et 7");
            }
            input = 0;
        }
    }
}

public class CaisseAutomatique1
{
    public float prix, client;

    public void Traitement()
    {
        Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");

        // Demande a l'utilisateur d'entrée un prix et vérifie si la valeur entrée est plus grand que 0
        // ou si c'est vraiment un nombre et non un caractere
        Entrer(true, "Entrée le prix du produit");
        while (prix <= 0)
        {
            Entrer(true, "Prix invalide, entrez un prix plus grand que 0...");
        }

        // Demande a l'utilisateur d'entrée un montant et vérifie si la valeur entrée est plus grand que 0 
        // ou si c'est vraiment un nombre et non un caractere
        Entrer(false, "Entrée le montant d'argent que vous voulez donner");
        while (client <= 0)
        {
            Entrer(false, "Le montant du client est invalide, entrez un montant plus grand que 0...");
        }

        // Utiliser le while loop si on veut que l'utilisateur entre le montant restant a payer lui même.
        //while (client != prix)
        //{
        Transaction(client < prix ? false : true, client < prix ? prix - client : client - prix);
        //}

        Console.WriteLine("Transaction terminer");

        // Fin du sous programme
        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ReadKey();// Attend que l'utilisateur appuis sur une touche avant de continuer
        Console.Clear();
    }

    /// <summary>
    /// Effectue les calcules et détermine si il y a de l'argent a retourner ou si il en manque
    /// </summary>
    /// <param name="retourner">Mettre a vrai si on dois retourner de l'argent au client, faux si le client dois donner plus</param>
    /// <param name="montant">Le montant restant ou de surplus a payer ou redonner</param>
    private void Transaction(bool retourner, float montant)
    {
        client = retourner ? client + montant : client - montant;
        Console.WriteLine(retourner ? "Montant de surplus qui vous reviens: " + montant + "$" : "Montant qui vous manque a payer: " + montant + "$" + "\nVous donnez alors: " + montant + "$");
    }

    /// <summary>
    /// Prend l'input de l'utilisateur
    /// </summary>
    /// <param name="priceCheck">Mettre a true quand on veut assigner une value a la variable prix si non mettre faux pour le montant du client</param>
    /// <param name="message">Le message a afficher selon la situation</param>
    private void Entrer(bool priceCheck, string message)
    {
        Console.WriteLine(message);
        try
        {
            // Placer dans le bloque try car l'assignation du prix ou montant du client entrée
            // par l'utilisateure peut etre autre chose qu'un float/int ce qui peut faire cracher le programme
            if (priceCheck)
                // la fonction parse cherche un float ou int a dans le string que retourn ReadLine (input entrée par l'utilisateur)
                prix = float.Parse(Console.ReadLine());
            else
                client = float.Parse(Console.ReadLine());
        }
        catch
        {
            // Si le try échoue, on rattrape l'erreur
            if (priceCheck)
                prix = 0.0f;
            else
                client = 0.0f;
        }
    }
}

public class CaisseAutomatique2
{
    public float client, prix;
    public int totalClients = 5;

    public void Traitement()
    {
        Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");

        for (int i = 0; i < totalClients; i++)
        {
            Entrer(true, "Entrée le prix du produit pour le client " + (i + 1));
            while(prix <= 0)
            {
                Entrer(true, "Prix invalide, entrez un prix plus grand que 0...");
            }

            Entrer(false, "Entrée le montant d'argent que vous voulez que le client " + (i + 1) + " doit donner");
            while(client <= 0)
            {
                Entrer(false, "Le montant du client est invalide, entrez un montant plus grand que 0...");
            }

            // Utiliser le while loop si on veut que l'utilisateur entre le montant restant a payer lui même.
            //while (client != prix)
            //{
            Transaction(client < prix ? false : true, client < prix ? prix - client : client - prix);
            //}
            
            Console.WriteLine("Transaction terminer. Clients Restant: " + (totalClients - (i + 1)) + "\n");
        }

        // Fin du sous programme
        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ReadKey();// Attend que l'utilisateur appuis sur une touche avant de continuer
        Console.Clear();
    }

    /// <summary>
    /// Effectue les calcules et détermine si il y a de l'argent a retourner ou si il en manque
    /// </summary>
    /// <param name="retourner">Mettre a vrai si on dois retourner de l'argent au client, faux si le client dois donner plus</param>
    /// <param name="montant">Le montant restant ou de surplus a payer ou redonner</param>
    private void Transaction(bool retourner, float montant)
    {
        client = retourner ? client - montant : client + montant;
        Console.WriteLine(retourner ? "Montant de surplus qui vous reviens: " + montant + "$" : "Montant qui vous manque a payer: " + montant + "$" + "\nVous donnez alors: " + montant + "$");
    }

    /// <summary>
    /// Prend l'input de l'utilisateur
    /// </summary>
    /// <param name="priceCheck">Mettre a true quand on veut assigner une value a la variable prix si non mettre faux pour le montant du client</param>
    /// <param name="message">Le message a afficher selon la situation</param>
    private void Entrer(bool priceCheck, string message)
    {
        Console.WriteLine(message);
        try
        {
            // Placer dans le bloque try car l'assignation du prix ou montant du client entrée
            // par l'utilisateure peut etre autre chose qu'un float/int ce qui peut faire cracher le programme
            if (priceCheck)
                // la fonction parse cherche un float ou int a dans le string que retourn ReadLine (input entrée par l'utilisateur)
                prix = float.Parse(Console.ReadLine());
            else
                client = float.Parse(Console.ReadLine());
        }
        catch
        {
            // Si le try échoue, on rattrape l'erreur
            if (priceCheck)
                prix = 0.0f;
            else
                client = 0.5f;
        }
    }
}

// WORK IN PROGRESS
public class ComptageDeMot
{
    private string phrase = "";

    public void Traitement()
    {
        // Retirer quand fixer
        Console.WriteLine("*WORK IN PROGRESS* NE FONCTIONNE PAS DANS TOUS LES SITUATIONS");

        Console.WriteLine("Écrivez un phrase et le programme vas compter le nombre de 'le' dans la phrase");
        try { phrase = Console.ReadLine(); }
        catch { phrase = ""; }

        int count = Regex.Matches(phrase, "le").Count;
        Console.WriteLine("Total de LE: " + count);

        // Fin du sous programme
        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ReadKey();// Attend que l'utilisateur appuis sur une touche avant de continuer
        Console.Clear();
    }
}

public class SaisieSansFaille
{
    private int input;

    public void Traitement()
    {
        VerifierInput("Entrer un nombre entier entre 1 et 150");

        while (input < 1 || input > 150)
        {
            VerifierInput("REFUSER \n La valeur entrée est invalide, entrer un nombre entier entre 1 et 150");
        }
    }

    private void VerifierInput(string message)
    {
        Console.WriteLine(message);
        try
        {
            input = Int32.Parse(Console.ReadLine());
        }
        catch
        {
            input = 0;
        }

        if (input >= 1 && input <= 150)
        {
            Console.WriteLine("ACCEPTER");

            // Fin du sous programme
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();// Attend que l'utilisateur appuis sur une touche avant de continuer
            Console.Clear();
        }
    }
}

public class DevineLeChiffre1
{
    private Random Random = new Random();
    private int randNumber;
    private int userGuess;
    private string inputStr = "";

    public void Traitement()
    {
        // 101 parce que le 2eme chiffre en parametre de la fonction Next est exclusif
        // ce qui fait qu'il aurais génerer un nombre entre 1 et 100.
        // Même principe pour le 0
        randNumber = Random.Next(1, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100");
        Verification();

        while (!Int32.TryParse(inputStr, out userGuess) || userGuess < 1 || userGuess > 100 || userGuess != randNumber)
        {
            Verification();
        }

        Console.WriteLine("Trouvé! Le nombre est: " + randNumber);

        // Fin du sous programme
        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ReadKey();// Attend que l'utilisateur appuis sur une touche avant de continuer
        Console.Clear();
    }

    private void Verification()
    {
        inputStr = Console.ReadLine();
        try
        {
            userGuess = Int32.Parse(inputStr);
        }
        catch
        {
            if (!Int32.TryParse(inputStr, out userGuess))
            {
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
            }
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
    private Random Random = new Random();
    private int randNumber;
    private int userGuess;
    private string inputStr = "";
    private int essai = 10;

    public void Traitement()
    {
        randNumber = Random.Next(1, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100, vous avez droit à 10 essais");
        Verification();

        while (!Int32.TryParse(inputStr, out userGuess) || userGuess < 1 || userGuess > 100 || userGuess != randNumber)
        {
            Verification();
        }

        Console.WriteLine("Trouvé! Le nombre est: " + randNumber);

        // Fin du sous programme
        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ReadKey();// Attend que l'utilisateur appuis sur une touche avant de continuer
        Console.Clear();
    }

    private void Verification()
    {
        inputStr = Console.ReadLine();
        try
        {
            userGuess = Int32.Parse(inputStr);
        }
        catch
        {
            if (!Int32.TryParse(inputStr, out userGuess))
            {
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
            }
            userGuess = 0;
            return;
        }

        if (userGuess == randNumber)
            return;// early return parce qu'on veut pas perdre une vie si on a trouvé la réponse
        
        Console.WriteLine(userGuess < randNumber ? "Plus petit, esseyer un nombre plus grand" : "Plus grand, esseyer un nombre plus petit");
        
        essai--;// Retire 1 vie
        Console.WriteLine(essai == 0 ? "Perdu :-(" : "Il reste " + essai + " essai");
    }
}

public class DevineLeChiffre3
{
    private Random random = new Random();
    private int randNumber, userGuess, essai = 10;
    private string inputStr = "", inputFin = "";
    private bool isRunning = true;

    public void Traitement()
    {
        randNumber = random.Next(1, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100, vous avez droit à 10 essais");
        Verification();

        while(isRunning)
        {
            while (!Int32.TryParse(inputStr, out userGuess) || userGuess < 1 || userGuess > 100 || userGuess != randNumber)
            {
                Verification();
            }

            Console.WriteLine("Trouvé! :-) \n Le nombre est: " + randNumber);
            Fin();
        }

        // Fin du sous programme
        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ReadKey();// Attend que l'utilisateur appuis sur une touche avant de continuer
        Console.Clear();
    }

    private void Verification()
    {
        inputStr = Console.ReadLine();

        try
        {
            userGuess = Int32.Parse(inputStr);
        }
        catch
        {
            if (!Int32.TryParse(inputStr, out userGuess))
            {
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
            }
            userGuess = 0;
            return;
        }
        
        if (userGuess == randNumber)
            return;

        Console.WriteLine(userGuess < randNumber ? "Plus petit, esseyer un nombre plus grand" : "Plus grand, esseyer un nombre plus petit");

        essai--;
        Console.WriteLine(essai == 0 ? "Perdu :-(" : "Il reste " + essai + " essai");
    }

    private void Fin()
    {
        Console.WriteLine("Entrée y pour commencer une nouvelle partie ou n pour quitter");
        InputFin();

        while (inputFin != "y" && inputFin != "Y" && inputFin != "n" && inputFin != "N")
        {
            Console.WriteLine("La valeur entrée est invalide \n Entrée y pour commencer une nouvelle partie ou n pour quitter");
            InputFin();
        }
    }

    private void InputFin()
    {
        inputFin = Console.ReadLine();

        if (inputFin == "y" || inputFin == "Y")
        {
            essai = 10;
            inputFin = "";
            Console.Clear();
            Traitement();
        }
        else if (inputFin == "n" || inputFin == "N")
        {
            isRunning = false;
        }
    }
}