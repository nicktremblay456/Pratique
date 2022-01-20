using System;

public class PseudoCode
{
    public static void Main()
    {
        // version 1
        //CaisseAutomatique1 caisseAutomatique = new CaisseAutomatique1();
        //caisseAutomatique.Traitement();

        // version 2
        //CaisseAutomatique2 caisseAutomatique = new CaisseAutomatique2();
        //caisseAutomatique.Traitement();

        //---------------------------------------------------

        //ComptageDeMot comptageDeMot = new ComptageDeMot();
        //comptageDeMot.Traitement();

        //---------------------------------------------------

        //SaisieSansFaille saisieSansFaille = new SaisieSansFaille();
        //saisieSansFaille.Traitement();

        //---------------------------------------------------

        // Version 1
        //DevineLeChiffre1 devineLeChiffre = new DevineLeChiffre1();
        //devineLeChiffre.Traitement();

        // Version 2
        //DevineLeChiffre2 devineLeChiffre = new DevineLeChiffre2();
        //devineLeChiffre.Traitement();

        // Version 3
        DevineLeChiffre3 devineLeChiffre = new DevineLeChiffre3();
        devineLeChiffre.Traitement();
    }
}


public class CaisseAutomatique1
{
    public float prix = 50;
    public float client = 55;

    public void Traitement()
    {
        while (client != prix)
        {
            if (client < prix)
            {
                float montantRestant = prix - client;
                Payer(montantRestant);
            }
            else if (client > prix)
            {
                float montantSurplus = client - prix;
                Redonner(montantSurplus);
            }
        }

        Console.WriteLine("Transaction terminer");
    }

    public void Payer(float montant)
    {
        client += montant;
        Console.WriteLine("Client: " + client);
    }

    public void Redonner(float montant)
    {
        client -= montant;
        Console.WriteLine("Client: " + client);
    }
}

public class CaisseAutomatique2
{
    public Random Random = new Random();
    public float client = 55;
    public float prix = 50;
    public int totalClients = 5;

    public void Traitement()
    {
        for (int i = 0; i < totalClients; i++)
        {
            while (client != prix)
            {
                if (client < prix)
                {
                    float montantRestant = prix - client;
                    Payer(montantRestant);
                }
                else if (client > prix)
                {
                    float montantSurplus = client - prix;
                    Redonner(montantSurplus);
                }
            }

            FinDeTransaction();
            Console.WriteLine("Transaction terminer. Clients Restant: " + (i + 1));
        }
    }

    public void Payer(float montant)
    {
        client += montant;
        Console.WriteLine("Client: " + client);
    }

    public void Redonner(float montant)
    {
        client -= montant;
        Console.WriteLine("Client: " + client);
    }

    public void FinDeTransaction()
    {
        client = Random.Next(0, 101);
        prix = 50;
    }
}

// TO REVIEW
public class ComptageDeMot
{
    private int total = 0;
    private string phrase = "le le le le";

    public void Traitement()
    {
        for (int i = 0; i < phrase.Length; i++)
        {
            if ((phrase[i + 1] > phrase.Length) || (phrase[i + 2] > phrase.Length) || (phrase[i + 3] > phrase.Length))
            {
                if (phrase[i] == ' ' && phrase[i + 1] == 'l' &&
                    phrase[i + 2] == 'e' && phrase[i + 3] == ' ')
                {
                    total++;
                }
            }
        }

        Console.WriteLine("Total de LE: " + total);
    }
}

public class SaisieSansFaille
{
    private int input;
    private string inputStr = "";

    public void Traitement()
    {
        Console.WriteLine("Entrer un nombre entier entre 1 et 150");
        inputStr = Console.ReadLine();

        while (input < 1 || input > 150 || !Int32.TryParse(inputStr, out input))
        {
            Console.WriteLine("La valeur entrée est invalide, entrer un nombre entier entre 1 et 150");
            inputStr = Console.ReadLine();
            try
            {
                input = Int32.Parse(inputStr);
            }
            catch
            {
                input = 0;
            }
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
        randNumber = Random.Next(0, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100");
        inputStr = Console.ReadLine();
        Verification();

        while (!Int32.TryParse(inputStr, out userGuess) || userGuess < 1 || userGuess > 100 || userGuess != randNumber)
        {
            if (!Int32.TryParse(inputStr, out userGuess))
            {
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
            }
            inputStr = Console.ReadLine();

            try
            {
                userGuess = Int32.Parse(inputStr);
            }
            catch
            {
                userGuess = 0;
            }

            Verification();
        }

        Console.WriteLine("Trouvé!");
        Console.WriteLine("Le nombre est: " + randNumber);
    }

    private void Verification()
    {
        if (userGuess < randNumber)
        {
            Console.WriteLine("Plus petit, esseyer un nombre plus grand");
        }
        else if (userGuess > randNumber)
        {
            Console.WriteLine("Plus grand, esseyer un nombre plus petit");
        }
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
        randNumber = Random.Next(0, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100, vous avez droit à 10 essais");
        inputStr = Console.ReadLine();
        Verification();

        while (!Int32.TryParse(inputStr, out userGuess) || userGuess < 1 || userGuess > 100 || userGuess != randNumber)
        {
            if (!Int32.TryParse(inputStr, out userGuess))
            {
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
            }
            inputStr = Console.ReadLine();

            try
            {
                userGuess = Int32.Parse(inputStr);
            }
            catch
            {
                userGuess = 0;
            }

            Verification();
        }

        Console.WriteLine("Trouvé! :-)");
        Console.WriteLine("Le nombre est: " + randNumber);
    }

    private void Verification()
    {
        if (userGuess < randNumber)
        {
            Console.WriteLine("Plus petit, esseyer un nombre plus grand");
        }
        else if (userGuess > randNumber)
        {
            Console.WriteLine("Plus grand, esseyer un nombre plus petit");
        }

        
        
        essai--;
        if (essai == 0)
        {
            Console.WriteLine("Perdu :-(");
        }
        else
        {
            Console.WriteLine("Il reste " + essai + " essai");
        }
    }
}

public class DevineLeChiffre3
{
    private Random Random = new Random();
    private int randNumber;
    private int userGuess;
    private string inputStr = "";
    private int essai = 10;
    private bool isRunning = true;

    public void Traitement()
    {
        randNumber = Random.Next(0, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100, vous avez droit à 10 essais");
        inputStr = Console.ReadLine();
        Verification();

        while(isRunning)
        {
            while (!Int32.TryParse(inputStr, out userGuess) || userGuess < 1 || userGuess > 100 || userGuess != randNumber)
            {
                if (!Int32.TryParse(inputStr, out userGuess))
                {
                    Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 100");
                }
                inputStr = Console.ReadLine();

                try
                {
                    userGuess = Int32.Parse(inputStr);
                }
                catch
                {
                    userGuess = 0;
                }

                Verification();
            }

            Console.WriteLine("Trouvé! :-)");
            Console.WriteLine("Le nombre est: " + randNumber + "\n");
            Fin();
        }

    }

    private void Verification()
    {
        if (userGuess < randNumber)
        {
            Console.WriteLine("Plus petit, esseyer un nombre plus grand");
        }
        else if (userGuess > randNumber)
        {
            Console.WriteLine("Plus grand, esseyer un nombre plus petit");
        }



        essai--;
        if (essai == 0)
        {
            Console.WriteLine("Perdu :-(");
        }
        else
        {
            Console.WriteLine("Il reste " + essai + " essai");
        }
    }

    private void Fin()
    {
        Console.WriteLine("Entrée y pour commencer une nouvelle partie ou n pour quitter");
        string c = Console.ReadLine();
        Console.WriteLine("c: " + c);

        InputFin(c);

        while (c != "y" || c != "Y" || c != "n" || c != "N")
        {
            Console.WriteLine("La valeur entrée est invalide");
            Console.WriteLine("Entrée y pour commencer une nouvelle partie ou n pour quitter");
            c = Console.ReadLine();
            InputFin(c);
        }
    }

    private void InputFin(string input)
    {
        if (input == "y" || input == "Y")
        {
            essai = 10;
            Traitement();
        }
        else if (input == "n" || input == "N")
        {
            isRunning = false;
        }
    }
}