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

        while (isRunning)
        {
            while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
            {
                GetInput();
            }

            Console.WriteLine("Trouvé! :-) \nLe nombre est: " + randNumber);
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
        Console.WriteLine("Entrée y pour commencer une nouvelle partie ou n pour retourner au menu principale");
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