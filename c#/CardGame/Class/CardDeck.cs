namespace CardGame
{
    public class CardDeck
    {
        private List<Card> m_Deck = new List<Card>();

        private const int MAX_JOKER = 2;

        public List<Card> Deck { get => m_Deck; }

        public CardDeck()
        {
            for (int i = 0; i < (int)ECardSuit.Count; i++)
            {
                for (int j = 0; j < (int)ECardValue.Count - 1; j++)
                {
                    m_Deck.Add(new Card((ECardSuit)i, (ECardValue)j));
                }
            }
            // Add 2 jokers
            for (int i = 0; i < MAX_JOKER; i++)
            {
                m_Deck.Add(new Card(ECardSuit.NONE, ECardValue.JOKER));
            }
        }

        public Card DrawCard()
        {
            Random rand = new Random();
            Card card = m_Deck[rand.Next(0, m_Deck.Count)];
            m_Deck.Remove(card);
            return card;
        }
    }
}