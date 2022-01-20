public class PseudoCode
{
    private static int input = 0;
    private static string inputStr = "";

    public static void Main()
    {
        Console.WriteLine("Entrer 1, 2, 3, 4, 5, 6 ou 7 pour choisir quoi faire.");
        Console.WriteLine("1: Caisse automatique VERSION 1 \n" +
                          "2: Caisse automatique VERSION 2 \n" +
                          "3: Comptage de mot \n" +
                          "4: Saisie sans faille \n" +
                          "5: Devine le chiffre VERSION 1 \n" +
                          "6: Devine le chiffre VERSION 2 \n" +
                          "7: Devine le chiffre VERSION 3");
        inputStr = Console.ReadLine();
        Verification();
        // Verification -> input == 3 parce que la fonction comptage de mot n'est pas encore fonctionnel
        while (!Int32.TryParse(inputStr, out input) || input < 1 || input > 7 || input == 3)
        {
            if (!Int32.TryParse(inputStr, out input))
            {
                Console.WriteLine("La valeur entrée est invalide, entrer un nombre en 1 et 7");
            }
            inputStr = Console.ReadLine();
            Verification();
        }
        Console.Clear();
        switch (input)
        {
            case 1:
                CaisseAutomatique1 caisseAutomatique = new CaisseAutomatique1();
                caisseAutomatique.Traitement();
                break;
            case 2:
                CaisseAutomatique2 caisseAutomatique2 = new CaisseAutomatique2();
                caisseAutomatique2.Traitement();
                break;
            case 3:
                ComptageDeMot comptageDeMot = new ComptageDeMot();
                comptageDeMot.Traitement();
                break;
            case 4:
                SaisieSansFaille saisieSansFaille = new SaisieSansFaille();
                saisieSansFaille.Traitement();
                break;
            case 5:
                DevineLeChiffre1 devineLeChiffre = new DevineLeChiffre1();
                devineLeChiffre.Traitement();
                break;
            case 6:
                DevineLeChiffre2 devineLeChiffre2 = new DevineLeChiffre2();
                devineLeChiffre2.Traitement();
                break;
            case 7:
                DevineLeChiffre3 devineLeChiffre3 = new DevineLeChiffre3();
                devineLeChiffre3.Traitement();
                break;
        }
    }

    private static void Verification()
    {
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


public class CaisseAutomatique1
{
    public float prix, client;

    public void Traitement()
    {
        Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");
        Console.WriteLine("Entrée le prix du produit");
        prix = float.Parse(Console.ReadLine());
        Console.WriteLine("Entrée le montant d'argent que vous voulez donner");
        client = float.Parse(Console.ReadLine());

        // Utiliser le while loop si on veut que l'utilisateur entre le montant restant a payer lui même.
        //while (client != prix)
        //{
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
        //}

        Console.WriteLine("Transaction terminer");
    }

    public void Payer(float montant)
    {
        client += montant;
        Console.WriteLine("Montant qui vous manque a payer: " + montant + "$");
        Console.WriteLine("Vous donnez alors: " + montant + "$");
    }

    public void Redonner(float montant)
    {
        client -= montant;
        Console.WriteLine("Montant de surplus qui vous reviens: " + montant + "$");
    }
}

public class CaisseAutomatique2
{
    public float client, prix;
    public int totalClients = 5;

    public void Traitement()
    {
        Console.WriteLine("Pour les montants decimaux, utiliser la ',' a la place du '.' \n");
        float montantRestant;
        float montantSurplus;


        for (int i = 0; i < totalClients; i++)
        {
            Console.WriteLine("Entrée le prix du produit pour le client " + (i + 1));
            prix = float.Parse(Console.ReadLine());
            Console.WriteLine("Entrée le montant d'argent que vous voulez que le client " + (i + 1) + " doit donner");
            client = float.Parse(Console.ReadLine());

            // Utiliser le while loop si on veut que l'utilisateur entre le montant restant a payer lui même.
            //while (client != prix)
            //{
                if (client < prix)
                {
                    montantRestant = prix - client;
                    Payer(montantRestant);
                }
                else if (client > prix)
                {
                    montantSurplus = client - prix;
                    Redonner(montantSurplus);
                }
            //}
            
            Console.WriteLine("Transaction terminer. Clients Restant: " + (totalClients - (i + 1)) + "\n");
        }
    }

    public void Payer(float montant)
    {
        client += montant;
        Console.WriteLine("Montant qui vous manque a payer: " + montant + "$");
        Console.WriteLine("Vous donnez alors: " + montant + "$");
    }

    public void Redonner(float montant)
    {
        client -= montant;
        Console.WriteLine("Montant de surplus qui vous reviens: " + montant + "$");
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
            if (!((i + 1) > phrase.Length) && !((i + 2) > phrase.Length) && !((i + 3) > phrase.Length))
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

            Verification();
        }

        Console.WriteLine("Trouvé! Le nombre est: " + randNumber);
    }

    private void Verification()
    {
        try
        {
            userGuess = Int32.Parse(inputStr);
        }
        catch
        {
            userGuess = 0;
        }

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

            Verification();
        }

        Console.WriteLine("Trouvé! :-)");
        Console.WriteLine("Le nombre est: " + randNumber);
    }

    private void Verification()
    {
        try
        {
            userGuess = Int32.Parse(inputStr);
        }
        catch
        {
            userGuess = 0;
        }

        if (userGuess == randNumber)
            return;
        else if (userGuess < randNumber)
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

                Verification();
            }

            Console.WriteLine("Trouvé! :-) \n Le nombre est: " + randNumber);
            Fin();
        }
    }

    private void Verification()
    {
        try
        {
            userGuess = Int32.Parse(inputStr);
        }
        catch
        {
            userGuess = 0;
        }
        
        if (userGuess == randNumber)
            return;
        else if (userGuess < randNumber)
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
            Fin();
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

        while (c != "y" && c != "Y" && c != "n" && c != "N")
        {
            Console.WriteLine("La valeur entrée est invalide \n Entrée y pour commencer une nouvelle partie ou n pour quitter");
            c = Console.ReadLine();
        }

        InputFin(c);
    }

    private void InputFin(string input)
    {
        if (input == "y" || input == "Y")
        {
            essai = 10;
            Console.Clear();
            Traitement();
        }
        else if (input == "n" || input == "N")
        {
            isRunning = false;
        }
    }
}