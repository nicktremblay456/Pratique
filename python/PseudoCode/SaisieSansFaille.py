class SaisieSansFaille:
    def __init__(self):
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