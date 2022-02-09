namespace TNT
{
    public struct ProgramData
    {
        public readonly Caisse Caisse;
        public readonly ComptageDeMot Comptage;
        public readonly SaisieSansFaille Saisie;
        public readonly Devine Devine;

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