import CaisseAutomatique, SaisieSansFaille, DevineLeChiffre

class Program:
    def __init__(self):
        self.caisse = CaisseAutomatique.CaisseAutomatique()
        self.saisie = SaisieSansFaille.SaisieSansFaille()
        self.devine = DevineLeChiffre.DevineLeChiffre()
        self.isRunning = True
        self.userChoice = -1

    def run(self):
        while self.isRunning:
            self.__process()

    def __process(self):
        print("Entrer 0, 1, 2, ou 3 pour choisir quoi faire.\n\n" +
              "1: Caisse automatique\n" +
              #"{(int)Option.COMPTAGE_DE_MOT}: Comptage de mot\n" +
              "2: Saisie sans faille\n" +
              "3: Devine le chiffre\n" +
              "0: Quitter")
        self.__getInput()
        while self.userChoice == -1:
            self.__getInput()
            
        if self.userChoice == 0: self.isRunning = False
        elif self.userChoice == 1: self.caisse.process()
        elif self.userChoice == 2: self.saisie.process()
        elif self.userChoice == 3: self.devine.process()

        if self.isRunning:
            input("\nAppuyez sur une touche pour revenir au menu principale...")

    def __getInput(self):
        try:
            self.userChoice = int(input())
            if self.userChoice > 3 or self.userChoice < 0:
                self.userChoice = -1
        except:
            self.userChoice = -1

        if self.userChoice == -1:
            print("La valeur entree est invalide, entrer un nombre en 0 et 3")