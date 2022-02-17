namespace CardGame
{
    public class Game
    {
        private List<Player> m_Players;
        private CardDeck m_CardDeck = new CardDeck();
        private bool m_IsRunning = true;
        private int m_Turn = 1;

        public List<Player> Players { get => m_Players; }
        public CardDeck CardDeck { get => m_CardDeck; }

        public Game(int a_PlayerCount, int a_CardPerPlayer)
        {
            // Init players
            m_Players = new List<Player>();
            for (int i = 0; i < a_PlayerCount; i++)
            {
                m_Players.Add(new Player($"Player {i + 1}"));
            }

            // Init players hands
            while (m_CardDeck.Deck.Count > 0)
            {
                foreach(Player player in m_Players)
                {
                    if (m_CardDeck.Deck.Count == 0)
                        break;
                    player.TakeCard(m_CardDeck.DrawCard());
                }
            }
            foreach (Player player in m_Players)
            {
                player.Hand.OrderBy(o => o.Value);
            }

            // Set player role
            for (int i = 0; i < (int)ERole.Count; i++)
            {
                m_Players[i].Role = (ERole)i;
            }
        }

        public void Run()
        {
            while (m_IsRunning)
            {
                m_Players[m_Turn].PlayTurn();

                if (m_Turn >= m_Players.Count)
                    m_Turn = 1;
                else
                    m_Turn++;
            }
        }

        public bool VictoryCondition()
        {
            foreach (Player player in m_Players)
            {
                return player.Hand.Count == 0;
            }

            return false;
        }

        private void PlayerTrade()
        {
            ///GetPlayerByRole(ERole.ASS_HOLE);
        }

         private Player? GetPlayerByRole(ERole a_Role)
        {
            foreach (Player player in m_Players)
            {
                if (player.Role == a_Role)
                    return player;
            }
            return null;
        }
    }
}