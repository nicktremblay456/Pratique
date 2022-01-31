class CaisseAutomatique:
    def __init__(self):
        self.client = 0
        self.price = 0
        self.currentClient = 1
        self.isRunning = True
        self.endingInput = ""

    def process(self):
        print("Pour les montants decimaux, utiliser le '.' a la place de la ','\n")

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
        while self.endingInput.lower() != "y" and self.endingInput.lower() != "n":
            print("La valeur entree est invalide \nEntrer 'y' pour passer au client suivant ou 'n' pour quitter")
            self.__getEndingInput()

    def __getEndingInput(self):
        self.endingInput = input()

        if self.endingInput.lower() == "y":
            print("Client suivant...")
            self.currentClient+=1
        elif self.endingInput.lower() == "n":
            self.isRunning = False