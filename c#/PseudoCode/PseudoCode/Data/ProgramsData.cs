/// <copyright file="Program.cs">
/// Copyright © 2022 © All Rights Reserved
/// </copyright>
/// <author>Nicolas Tremblay</author>
/// <date>2022/01/22 16:26 PM </date>
/// <summary>Struct containing all option in the program</summary>
public struct ProgramsData
{

    // Props, propriétés public qui nous permet d'accèder aux valeur des variables sans pouvoir la modifier.
    // On pourrais juste mettre les variable en haut public mais je veut pas qu'on puisse modifier leur value
    // google pour plus d'info sur les property get set
    public CaisseAutomatique1 Caisse1 { get; private set; }
    public CaisseAutomatique2 Caisse2 { get; private set; }
    public ComptageDeMot Comptage { get; private set; }
    public SaisieSansFaille Saisie { get; private set; }
    public DevineLeChiffre1 DevineLeChiffre1 { get; private set; }
    public DevineLeChiffre2 DevineLeChiffre2 { get; private set; }
    public DevineLeChiffre3 DevineLeChiffre3 { get; private set; }

    public ProgramsData()// Constructor
    {
        // Initialise
        Caisse1 = new CaisseAutomatique1();// operateur new pour créer une instance de la class et ça appel la fonction constructeur
        Caisse2 = new CaisseAutomatique2();
        Comptage = new ComptageDeMot();
        Saisie = new SaisieSansFaille();
        DevineLeChiffre1 = new DevineLeChiffre1();
        DevineLeChiffre2 = new DevineLeChiffre2();
        DevineLeChiffre3 = new DevineLeChiffre3();
    }
}