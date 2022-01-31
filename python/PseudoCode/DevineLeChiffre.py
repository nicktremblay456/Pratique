import random

class DevineLeChiffre:
    def __init__(self):
        self.minNumber = 1
        self.maxNumber = 0

        self.randNumber = 0
        self.userGuess = 0
        self.difficultyInput = 0
        self.maxTries = 10

        self.endingInput = ""

        self.isInvinsible = False
        self.quit = False

    def process(self):
        self.__setDifficulty()
        while self.difficultyInput == 0:
            self.__setDifficulty()

        self.randNumber = random.randint(self.minNumber, self.maxNumber)
        
        print(f"Entrer un nombre entre {self.minNumber} et {self.maxNumber} vous avez droit a 10 essais")
        self.__getInput()

        while self.userGuess < 1 or self.userGuess > 100 or self.userGuess != self.randNumber:
            if self.maxTries == 0 or self.quit: break
            self.__getInput()

    def __getInput(self):
        try: 
            self.userGuess = int(input())
            if self.userGuess == -1:
                self.__cheat()
                self.userGuess = 0
                return
        except:
            print(f"La valeur entree est invalide, entrer un nombre entre {self.minNumber} et {self.maxNumber}")
            self.userGuess = 0
            return

        if self.userGuess == self.randNumber:
            print(f"Trouver! :-) \nLe nombre est: {self.randNumber}")
            self.__end()
            return
        
        if self.userGuess < self.randNumber: print("Plus petit, essayer un nombre plus grand")
        elif self.userGuess > self.randNumber: print("Plus grand, essayer un nombre plus petit")

        if self.isInvinsible: return
        self.maxTries-=1
        if self.maxTries == 0:  print("Perdu :-(")
        else: print(f"Il reste {self.maxTries} essais")

    def __setDifficulty(self):
        print("Entrer 1, 2 ou 3 pour choisir la difficulter.\n\n" +
              "1: Facile\n" +
              "2: Moyen\n" +
              "3: Difficile\n")
        try: self.difficultyInput = int(input())
        except:
            self.difficultyInput = 0

        if self.difficultyInput == 1: self.maxNumber = 100
        elif self.difficultyInput == 2: self.maxNumber = 150
        elif self.difficultyInput == 3: self.maxNumber = 200


    def __end(self):
        print("Entrer 'y' pour commencer une nouvelle partie ou 'n' pour retourner au menu principale")
        self.__getEndingInput()
        while self.endingInput.lower() != "y" and self.endingInput.lower() != "n":
            print("La valeur entree est invalide \nEntrer 'y' pour passer au client suivant ou 'n' pour quitter")
            self.__getEndingInput()

    def __getEndingInput(self):
        self.endingInput = input()
        if self.endingInput.lower() == "y":
            self.maxTries = 10
            self.process()
        elif self.endingInput.lower() == "n":
            if self.isInvinsible: self.isInvinsible = False
            self.quit = False

    def __cheat(self):
        print("***Enter Cheat Menu***\n")
        cheat = input()
        if cheat.lower() == "iddqd":
            self.isInvinsible = True
            print("*Nombre d'essais infini*\n")
        elif cheat.lower() == "idkfa":
            print(f"*CHEAT REPONSE* : {self.randNumber}\n")
        else: print("Cheat inconnu\n")
        print(f"***Exit Cheat Menu***\n\nEntrer un nombre entre {self.minNumber} et {self.maxNumber}")