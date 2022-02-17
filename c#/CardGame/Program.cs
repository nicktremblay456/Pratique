using CardGame;

public class Program
{
    private static void Main(string[] args)
    {
        Game game = new Game(4, 13);
        foreach(Player player in game.Players)
        {
            player.DrawHand();
            Console.WriteLine();
        }
    }
}