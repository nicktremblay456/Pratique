namespace TNT
{
    public struct ProgramData
    {
        public CaisseAutomatique1 Caisse1 { get; private set; }
        public CaisseAutomatique2 Caisse2 { get; private set; }
        public ComptageDeMot Comptage { get; private set; }
        public SaisieSansFaille Saisie { get; private set; }
        public DevineLeChiffre1 DevineLeChiffre1 { get; private set; }
        public DevineLeChiffre2 DevineLeChiffre2 { get; private set; }
        public DevineLeChiffre3 DevineLeChiffre3 { get; private set; }

        public ProgramData()
        {
            // Init object.
            Caisse1 = new CaisseAutomatique1();
            Caisse2 = new CaisseAutomatique2();
            Comptage = new ComptageDeMot();
            Saisie = new SaisieSansFaille();
            DevineLeChiffre1 = new DevineLeChiffre1();
            DevineLeChiffre2 = new DevineLeChiffre2();
            DevineLeChiffre3 = new DevineLeChiffre3();
        }
    }
}