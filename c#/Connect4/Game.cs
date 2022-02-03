namespace Connect4
{
    public class Game
    {
        private Board m_Board;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;

        public Game()
        {
            m_Board = new Board();
            m_PlayerOne = new Player('X');
            m_PlayerTwo = new Player('O');
        }

        public void Run()
        {
			int round = 0;
			int row = -1;
			int column = -1;

			while (round != 42)
			{
				while(row < 0 || row > 5)
                {
					if (round % 2 == 0)
						m_PlayerOne.AskPlayer(column);
					else
						m_PlayerTwo.AskPlayer(column);

					row = m_Board.FindRow(column);
				}

				m_Board.AssignCase(row, column, (round % 2 == 0) ? m_PlayerOne.Token : m_PlayerTwo.Token);// Once it gets out of Do...While 
																													// it put a token on the selected column 'X'||'O'

				Console.Clear();

				m_Board.ShowBoard();

				if (m_Board.VerifyVictory(row, column, (round % 2 == 0) ? 'X' : 'O'))
				{
					Console.WriteLine($"The winner is: {((round % 2 == 0) ? 'X' : 'O')}");
					Console.ReadKey();
					return;
				}

				round++;
			}
			Console.WriteLine("GAME TIE!");
			Console.ReadKey();
		}
    }
}
