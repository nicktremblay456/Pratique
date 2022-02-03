namespace Connect4
{
    public class Board
    {
        private List<List<char>> m_Board;

        public Board()
        {
            m_Board = new List<List<char>>();
            for (int i = 0; i < 6; i++)
            {
                m_Board.Add(new List<char>(7));
            }
        }

        public void ShowBoard()
        {
            Console.Write("   1   2   3   4   5   6   7");
            Console.Write("\n _____________________________\n");
            for (int i = m_Board.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < m_Board[i].Count; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(" |");
                    }
                    Console.Write($" {m_Board[i][j]}  |");
                }
                Console.Write("\n |___|___|___|___|___|___|___|\n");
            }
        }

		public void AssignCase(int a_Row, int a_Column, char a_Token) 
		{ 
			m_Board[a_Row][a_Column] = a_Token; 
		}

		public int FindRow(int a_Column)
		{
		    for (int i = 0; i < m_Board.Count; i++)
		    {
		        if (m_Board[i][a_Column] == ' ')
		        {
		            return i;
		        }
		    }

		    return -1;
		}

        public bool VerifyVictory(int a_Row, int a_Column, char a_Token)
        {
			int token = 1;

			// VÉRIFY VERTICAL VICTORY
			// i is a_Row (initial value);
			// i >= 0 (Maximal value); 
			// i-- (Because we verify from to top to the bottom of the board) 

			for (int i = a_Row - 1; i >= 0; i--)
			{
				if (m_Board[i][a_Column] == a_Token)
				{
					token++;
				}
				else
				{
					break;
				}

				if (token == 4)
				{
					return true;
				}
			}

			//VÉRIFY HORIZONTAL VICTORY

			token = 1; // Reset token to 1 for a different win condition: Horizontal.

			// Left -> Right
			for (int i = a_Column + 1; i <= 6; i++)
			{
				if (m_Board[a_Row][i] == a_Token)
				{
					token++;
				}
				else
				{
					break;
				}

				if (token == 4)
				{
					return true;
				}
			}

			// Right -> Left
			for (int i = a_Column - 1; i >= 0; i--)
			{
				if (m_Board[a_Row][i] == a_Token)
				{
					token++;
				}
				else
				{
					break;
				}

				if (token == 4)
				{
					return true;
				}
			}

			// VERIFY DIAGONAL VICTORY

			token = 1;  // Reset token to 1 for a different win condition: Diagonal ==> TopLeft -> BottomRight && BottomRight -> TopLeft.

			// Top Left -> Bottom Right
			for (int i = a_Row + 1, j = a_Column - 1; i <= 5 && j >= 0; i++, j--)
			{
				if (m_Board[i][j] == a_Token)
				{
					token++;
				}
				else
				{
					break;
				}

				if (token == 4)
				{
					return true;
				}
			}

			//Bottom Right -> Top Left
			for (int i = a_Row - 1, j = a_Column + 1; i >= 0 && j <= 6; i--, j++)
			{
				if (m_Board[i][j] == a_Token)
				{
					token++;
				}
				else
				{
					break;
				}

				if (token == 4)
				{
					return true;
				}
			}

			token = 1;  // Reset token to 1 for a different win condition: Diagonal ==> TopRight -> BottomLeft && BottomLeft -> TopRight.

			// Top Right -> Bottom Left
			for (int i = a_Row - 1, j = a_Column - 1; i >= 0 && j >= 0; i--, j--)
			{
				if (m_Board[i][j] == a_Token)
				{
					token++;
				}
				else
				{
					break;
				}

				if (token == 4)
				{
					return true;
				}
			}

			// Bottom Right -> Top Left
			for (int i = a_Row + 1, j = a_Column + 1; i <= 5 && j <= 6; i++, j++)
			{
				if (m_Board[i][j] == a_Token)
				{
					token++;
				}
				else
				{
					break;
				}

				if (token == 4)
				{
					return true;
				}
			}

			return false;
		}
    }
}