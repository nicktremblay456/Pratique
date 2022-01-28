class CaisseAutomatique:
    def __init__(self):
        self.client = 0
        self.price = 0
        self.currentClient = 1
        self.isRunning = True
        self.endingInput = ""

    def process(self):
        print("Pour les montants decimaux, utiliser la ',' a la place du '.' \n")

        while self.isRunning:
            #Entrer le prix du produit
            self.__getInput(True, f"Entrer le prix du produit pour le client {self.currentClient}: ")
            while self.price <= 0:
                self.__getInput(True, "Prix invalide, entrez un prix plus grand que 0... : ")
            #Entrer le montant d'argent donné par le client
            self.__getInput(False, f"Entrer le montant d'argent que vous voulez que le client {self.currentClient} donne: ")
            while self.client <= 0:
                self.__getInput(False, "Le montant du client est invalide, entrez un montant plus grand que 0... : ")

            self.__transaction(False if self.client < self.price else True, (self.price - self.client) if self.client < self.price else (self.client - self.price))

            self.__end()

    def __getInput(self, priceCheck, message):
        try:
            if priceCheck:
                self.price = float(input(message))
            else:
                self.client = float(input(message))
        except:
            if priceCheck:
                self.price = 0
            else:
                self.client = 0

    def __transaction(self, returnBack, amount):
        global client
        if returnBack:
            self.client - amount
            print("Montant de surplus qui vous reviens: $", amount)
        else:
            self.client + amount
            print("Montant qui vous manque a payer: $", amount)
            print("\nVous donnez alors: $", amount)

    def __end(self):
        print("Transaction terminee.\nEntrer 'y' pour passer au client suivant ou 'n' pour arreter et retourner au menu principale")
        self.__getEndingInput()
        while self.endingInput != "y" and self.endingInput != "Y" and self.endingInput != "n" and self.endingInput != "N":
            print("La valeur entree est invalide \nEntrer 'y' pour passer au client suivant ou 'n' pour quitter")
            self.__getEndingInput()

    def __getEndingInput(self):
        self.endingInput = input()

        if self.endingInput == "y" or self.endingInput == "Y":
            print("Client suivant...")
            self.currentClient+=1
        elif self.endingInput == "n" or self.endingInput == "N":
            self.isRunning = False

class SaisieSansFaille:
    def __Init__(self):
        self.input = 0

    def process(self):
        print("Entrer un nombre entier entre 1 et 150")
        self.__getInput()
        while self.input < 1 or self.input > 150:
            self.__getInput()

    def __getInput(self):
        try:
            self.input = int(input())
        except:
            self.input = 0

        if self.input >= 1 and self.input <= 150:
            print("ACCEPTER")
        else:
            print("REFUSER \nLa valeur entree est invalide, entrer un nombre entier entre 1 et 150")

# The function that run the program
def main():
    #caisse = CaisseAutomatique()
    #caisse.process()
    saisie = SaisieSansFaille()
    saisie.process()

main()