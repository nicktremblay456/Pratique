public class DevineLeChiffre1
{
    private Random random = new Random();
    private int randNumber, userGuess;

    public void Process()
    {
        // 101 parce que le 2eme chiffre en parametre de la fonction Next est exclusif
        // ce qui fait qu'il aurais génerer un nombre entre 1 et 100.
        randNumber = random.Next(1, 101);
        Console.WriteLine("*CHEAT REPONSE* : " + randNumber);
        Console.WriteLine("Entrer un nombre en 1 et 100");
        GetInput();

        while (userGuess < 1 || userGuess > 100 || userGuess != randNumber)
        {
            GetInput();
        }

        Console.WriteLine("Trouvé! :-) \nLe nombre est: " + randNumber);
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