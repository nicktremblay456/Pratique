using Connect4;

namespace TNT.Main
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Connect4!\n" +
                            "In short, it´s a vertical board with 42 windows distributed in 6 rows and\n" +
                            "7 columns.\n" +
                            "Both players have a set of 21 thin token (X & O)\n" +
                            "The aim for both players is to make a straight line of four own pieces.\n" +
                            "The line can be vertical, horizontal or diagonal.\n" +
                            "Have Fun!\n");

            Board board = new Board();
            board.ShowBoard(); // Used to show the board on start

            Game game = new Game();
            game.Run();
        }
    }
}