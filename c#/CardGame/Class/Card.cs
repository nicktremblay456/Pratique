namespace CardGame
{
    public class Card
    {
        private ECardSuit m_Suit;
        private ECardValue m_Value;
        private char m_SuitSymbol;

        public ECardSuit Suit { get => m_Suit; }
        public ECardValue Value { get => m_Value; }

        public Card(ECardSuit a_Suit, ECardValue a_Value)
        {
            m_Suit = a_Suit;
            m_Value = a_Value;
            SetSuitSymbol();
        }

        private void SetSuitSymbol()
        {
            switch (m_Suit)
            {
                case ECardSuit.DIAMONDS: m_SuitSymbol = '♦'; break;
                case ECardSuit.SPADES: m_SuitSymbol = '♠'; break;
                case ECardSuit.CLUBS: m_SuitSymbol = '♣'; break;
                case ECardSuit.HEARTS: m_SuitSymbol = '♥'; break;
            }
        }
        
        public void Draw()
        {
            // ♥ ♦ ♣ ♠
            switch (m_Value)
            {
                case ECardValue.TWO: Console.Write($"2{m_SuitSymbol} "); break;
                case ECardValue.THREE: Console.Write($"3{m_SuitSymbol} "); break;
                case ECardValue.FOUR: Console.Write($"4{m_SuitSymbol} "); break;
                case ECardValue.FIVE: Console.Write($"5{m_SuitSymbol} "); break;
                case ECardValue.SIX: Console.Write($"6{m_SuitSymbol} "); break;
                case ECardValue.SEVEN: Console.Write($"7{m_SuitSymbol} "); break;
                case ECardValue.EIGHT: Console.Write($"8{m_SuitSymbol} "); break;
                case ECardValue.NINE: Console.Write($"9{m_SuitSymbol} "); break;
                case ECardValue.TEN: Console.Write($"10{m_SuitSymbol} "); break;
                case ECardValue.JACK: Console.Write($"J{m_SuitSymbol} "); break;
                case ECardValue.QUEEN: Console.Write($"Q{m_SuitSymbol} "); break;
                case ECardValue.KING: Console.Write($"K{m_SuitSymbol} "); ; break;
                case ECardValue.ACE: Console.Write($"A{m_SuitSymbol} "); break;
                case ECardValue.JOKER: Console.Write($"JOKER "); break;
            }
        }
    }
}