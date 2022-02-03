public class TicTacToe
{
    #region Variables
    string[][] board = new string[3][];

    bool isRunning = true;
    bool isPlayerOneTurn = true;
    string joueur_X = " X |";
    string joueur_O = " O |";
    string choice = "";
    #endregion

    public TicTacToe()
    {
        board[0] = new string[3] { "   |", "   |", "   |" };
        board[1] = new string[3] { "   |", "   |", "   |" };
        board[2] = new string[3] { "   |", "   |", "   |" };
    }

    public void GameLoop()
    {
        while (isRunning)
        {
            DrawBoard();

            Choixjoueur();
            Console.Clear();

            switch (choice)
            {
                case "A1":
                    PlaceToken(0, 0);
                    break;
                case "A2":
                    PlaceToken(1, 0);
                    break;
                case "A3":
                    PlaceToken(2, 0);
                    break;
                case "B1":
                    PlaceToken(0, 1);
                    break;
                case "B2":
                    PlaceToken(1, 1);
                    break;
                case "B3":
                    PlaceToken(2, 1);
                    break;
                case "C1":
                    PlaceToken(0, 2);
                    break;
                case "C2":
                    PlaceToken(1, 2);
                    break;
                case "C3":
                    PlaceToken(2, 2);
                    break;
                default:
                    break;
            }
            if (VictoryCondition())
            {
                isRunning = false;
            }
            if (choice != "")// If player placed a piece in an empty slot
                isPlayerOneTurn = !isPlayerOneTurn;// next turn
        }
    }

    private void Choixjoueur()
    {
        choice = Console.ReadLine();
        while (choice != "A1" && choice != "A2" && choice != "A3" && choice != "B1" && choice != "B2"
            && choice != "B3" && choice != "C1" && choice != "C2" && choice != "C3")
        {
            Console.WriteLine("Réponse incorrecte. Ex: A1");
            choice = Console.ReadLine();
        }
    }

    private void DrawBoard()
    {
        Console.WriteLine("  A   B   C ");
        Console.Write("1");
        foreach (string n in board[0])
        {
            Console.Write(n);
        }
        Console.WriteLine(" ");
        Console.Write("2");
        foreach (string n in board[1])
        {
            Console.Write(n);
        }
        Console.WriteLine(" ");
        Console.Write("3");
        foreach (string n in board[2])
        {
            Console.Write(n);
        }
        Console.WriteLine(" ");
    }

    private void PlaceToken(int row, int column)
    {
        if (IsEmpty(row, column))
            board[row][column] = isPlayerOneTurn ? joueur_X : joueur_O;
        else
            choice = "";//if there is already a piece, then choix="" so the input will be refuse and will ask to enter another choice.
    }

    private bool IsEmpty(int row, int column)
    {
        bool empty = board[row][column] != joueur_X && board[row][column] != joueur_O;
        if (!empty)
        {
            Console.WriteLine($"Il y a déjà une pièce au coordonnée [{row + 1}][{column + 1}]");
        }
        return empty;
    }

    private bool VictoryCondition()
    {
        if ((board[0][0] == joueur_X && board[1][0] == joueur_X && board[2][0] == joueur_X) ||
            (board[0][1] == joueur_X && board[1][1] == joueur_X && board[2][1] == joueur_X) ||
            (board[0][2] == joueur_X && board[1][2] == joueur_X && board[2][2] == joueur_X) ||
            (board[0][0] == joueur_X && board[0][1] == joueur_X && board[0][2] == joueur_X) ||
            (board[1][0] == joueur_X && board[1][1] == joueur_X && board[1][2] == joueur_X) ||
            (board[2][0] == joueur_X && board[2][1] == joueur_X && board[2][2] == joueur_X) ||
            (board[0][0] == joueur_X && board[1][1] == joueur_X && board[2][2] == joueur_X) ||
            (board[0][2] == joueur_X && board[1][1] == joueur_X && board[2][0] == joueur_X))
        {
            Console.WriteLine("Joueur X gagne!");
            return true;
        }
        else if ((board[0][0] == joueur_O && board[1][0] == joueur_O && board[2][0] == joueur_O) ||
                (board[0][1] == joueur_O && board[1][1] == joueur_O && board[2][1] == joueur_O) ||
                (board[0][2] == joueur_O && board[1][2] == joueur_O && board[2][2] == joueur_O) ||
                (board[0][0] == joueur_O && board[0][1] == joueur_O && board[0][2] == joueur_O) ||
                (board[1][0] == joueur_O && board[1][1] == joueur_O && board[1][2] == joueur_O) ||
                (board[2][0] == joueur_O && board[2][1] == joueur_O && board[2][2] == joueur_O) ||
                (board[0][0] == joueur_O && board[1][1] == joueur_O && board[2][2] == joueur_O) ||
                (board[0][2] == joueur_O && board[1][1] == joueur_O && board[2][0] == joueur_O))
        {
            Console.WriteLine("Joueur O gagne!");
            return true;
        }

        return false;
    }
}

public class Game
{
    private static void Main(string[] args)
    {
        TicTacToe game = new TicTacToe();
        game.GameLoop();
    }
}