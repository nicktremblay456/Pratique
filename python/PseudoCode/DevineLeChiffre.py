import random

class DevineLeChiffre:
    def __init__(self):
        self.randNumber = 0
        self.userGuess = 0
        self.maxTries = 10
        self.endingInput = ""
        self.isInvinsible = False

    def process(self):
        self.randNumber = random.randint(1, 100)
        
        print("Entrer un nombre entre 1 et 100, vous avez droit a 10 essais")
        self.__getInput()

        while self.userGuess < 1 or self.userGuess > 100 or self.userGuess != self.randNumber:
            if self.maxTries == 0: break
            self.__getInput()

        self.__end()

    def __getInput(self):
        try: 
            self.userGuess = int(input())
            if self.userGuess == -1:
                self.__cheat()
                self.userGuess = 0
                return
        except:
            print("La valeur entree est invalide, entrer un nombre entre 1 et 100")
            self.userGuess = 0
            return

        if self.userGuess == self.randNumber:
            print(f"Trouver! :-) \nLe nombre est: {self.randNumber}")
            return
        
        if self.userGuess < self.randNumber: print("Plus petit, essayer un nombre plus grand")
        elif self.userGuess > self.randNumber: print("Plus grand, essayer un nombre plus petit")

        if self.isInvinsible: return
        self.maxTries-=1
        if self.maxTries == 0:  print("Perdu :-(")
        else: print(f"Il reste {self.maxTries} essais")

    def __end(self):
        print("Entrer 'y' pour commencer une nouvelle partie ou 'n' pour retourner au menu principale")
        self.__getEndingInput()
        while self.endingInput != "y" and self.endingInput != "Y" and self.endingInput != "n" and self.endingInput != "N":
            print("La valeur entree est invalide \nEntrer 'y' pour passer au client suivant ou 'n' pour quitter")
            self.__getEndingInput()

    def __getEndingInput(self):
        self.endingInput = input()
        if self.endingInput == "y" or self.endingInput == "Y":
            self.maxTries = 10
            self.endingInput = ""
            self.process()
        elif self.endingInput == "n" or self.endingInput == "N":
            if self.isInvinsible: self.isInvinsible = False

    def __cheat(self):
        print("***Enter Cheat Menu***\n")
        cheat = input()
        if cheat == "IDDQD":
            self.isInvinsible = True
            print("*Nombre d'essais infini*\n")
        elif cheat == "IDKFA":
            print(f"*CHEAT REPONSE* : {self.randNumber}")
        else: print("Cheat inconnu\n")
        print("***Exit Cheat Menu***\n\nEntrer un nombre entre 1 et 100")