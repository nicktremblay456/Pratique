namespace TNT
{
    public struct ProgramData
    {
        public Caisse Caisse { get; private set; }
        public ComptageDeMot Comptage { get; private set; }
        public SaisieSansFaille Saisie { get; private set; }
        public Devine Devine { get; private set; }

        public ProgramData()
        {
            // Init object.
            Caisse = new Caisse();
            Comptage = new ComptageDeMot();
            Saisie = new SaisieSansFaille();
            Devine = new Devine();
        }
    }
}