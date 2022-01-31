from CaisseAutomatique import CaisseAutomatique
from SaisieSansFaille import SaisieSansFaille
from DevineLeChiffre import DevineLeChiffre

class Program:
    def __init__(self):
        self.caisse = CaisseAutomatique()
        self.saisie = SaisieSansFaille()
        self.devine = DevineLeChiffre()
        self.isRunning = True
        self.userChoice = -1

    def run(self):
        while self.isRunning:
            self.__process()

    def __process(self):
        print("Entrer 0, 1, 2, 3 ou 4 pour choisir quoi faire.\n\n" +
              "1: Caisse automatique\n" +
              "2: Comptage de mot *En developpement*\n" +
              "3: Saisie sans faille\n" +
              "4: Devine le chiffre\n" +
              "0: Quitter")
        self.__getInput()
        while self.userChoice == -1:
            self.__getInput()
           
        if self.userChoice == 0: self.isRunning = False
        elif self.userChoice == 1: self.caisse.process()
        elif self.userChoice == 2: print("*WORK IN PROGRESS*")
        elif self.userChoice == 3: self.saisie.process()
        elif self.userChoice == 4: self.devine.process()

        if self.isRunning:
            input("\nAppuyez sur une touche pour revenir au menu principale...")

    def __getInput(self):
        try:
            self.userChoice = int(input())
            if self.userChoice > 4 or self.userChoice < 0:
                self.userChoice = -1
        except: self.userChoice = -1

        if self.userChoice == -1:
            print("La valeur entree est invalide, entrer un nombre en 0 et 3")

program = Program()
program.run()