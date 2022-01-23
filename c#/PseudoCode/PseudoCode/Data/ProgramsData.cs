public struct ProgramsData
{
    private CaisseAutomatique1 caisse1;
    private CaisseAutomatique2 caisse2;
    private ComptageDeMot comptage;
    private SaisieSansFaille saisie;
    private DevineLeChiffre1 devine1;
    private DevineLeChiffre2 devine2;
    private DevineLeChiffre3 devine3;

    // Props, propriétés public qui nous permet d'accèder aux values variables en haut sans pouvoir modifier leur valeur
    // On pourrais juste mettre les variable en haut public mais je veut pas qu'on puisse modifier leur value
    /*
     * L'operateur => (appeler lambda) revient au même que faire...
     * get
     * {
     *      return caisse1;
     * }
     * google pour plus d'info sur les props et lambda...
     */
    public CaisseAutomatique1 Caisse1 { get => caisse1; }
    public CaisseAutomatique2 Caisse2 { get => caisse2; }
    public ComptageDeMot Comptage { get => comptage; }
    public SaisieSansFaille Saisie { get => saisie; }
    public DevineLeChiffre1 DevineLeChiffre1 { get => devine1; }
    public DevineLeChiffre2 DevineLeChiffre2 { get => devine2; }
    public DevineLeChiffre3 DevineLeChiffre3 { get => devine3; }

    public ProgramsData()// Constructor
    {
        // Initialise
        caisse1 = new CaisseAutomatique1();// operateur new pour créer une instance de la class et ça appel la fonction constructeur
        caisse2 = new CaisseAutomatique2();
        comptage = new ComptageDeMot();
        saisie = new SaisieSansFaille();
        devine1 = new DevineLeChiffre1();
        devine2 = new DevineLeChiffre2();
        devine3 = new DevineLeChiffre3();
    }
}