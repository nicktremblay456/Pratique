namespace CardGame
{
    public class Player
    {
        public enum ECardPower
        {
            WEAKER, STRONGER
        }

        private List<Card> m_Hand = new List<Card>();
        private ERole m_Role = ERole.NONE;
        private string m_Name;

        public List<Card> Hand { get => m_Hand; }
        public ERole Role { get => m_Role; set => m_Role = value; }
        public string Name { get => m_Name; }


        public Player(string a_Name)
        {
            m_Name = a_Name;
        }

        public void TakeCard(Card a_Card)
        {
            m_Hand.Add(a_Card);
        }

        public void PlayTurn()
        {

        }

        public void DrawHand()
        {
            Console.Write($"{m_Name} {RoleToString()}: ");
            foreach(Card card in m_Hand)
            {
                card.Draw();
            }
        }

        public List<Card> GetCards(ECardPower a_CardPower, int a_TotalCards)
        {
            List<Card> cards = new List<Card>();
            switch(a_CardPower)
            {
                case ECardPower.WEAKER: 
                    break;
                case ECardPower.STRONGER: 
                    break;
            }
            return cards;
        }

        private string RoleToString()
        {
            switch (m_Role)
            {
                case ERole.PRESIDENT: return "President";
                case ERole.VICE_PRESIDENT: return "Vice-President";
                case ERole.SECRETARY: return "Secretary";
                case ERole.ASS_HOLE: return "Asshole";
            }
            return string.Empty;
        }
    }
}