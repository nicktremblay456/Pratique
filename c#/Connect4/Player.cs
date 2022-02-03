namespace Connect4
{
    public class Player
    {
        private char m_Token;
        public char Token { get => m_Token; }

        public Player(char a_Token)
        {
            m_Token = a_Token;
        }

        public void AskPlayer(int a_Column)
        {
            Console.WriteLine("Entree votre choix de Colone: ");
            GetInput(a_Column);
            while (a_Column < 0 || a_Column > 6)
            {
                GetInput(a_Column);
            }
        }

        private void GetInput(int a_Column)
        {
            try { a_Column = int.Parse(Console.ReadLine()); }
            catch { a_Column = -1; }
        }
    }
}
