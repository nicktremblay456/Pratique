mainTab = {'7': ' ' , '8': ' ' , '9': ' ' ,
        '4': ' ' , '5': ' ' , '6': ' ' ,
        '1': ' ' , '2': ' ' , '3': ' ' }

gameInProgress = True;
isPlayerOneTurn = True;
joueur_X = " X |";
joueur_O = " O |";
choice = "";

def drawBoard(board):
    print(board['7'] + '|' + board['8'] + '|' + board['9'])
    print('-+-+-')
    print(board['4'] + '|' + board['5'] + '|' + board['6'])
    print('-+-+-')
    print(board['1'] + '|' + board['2'] + '|' + board['3'])

def getInput():
    choice = input()
    while choice != "A1" and choice != "A2" and choice != "A3" and choice != "B1" and choice != "B2" and choice != "B3" and choice != "C1" and choice != "C2" and choice != "C3":
        choice = input("Reponse incorrecte. Ex: A1")

def gameLoop():
    pass


drawBoard(mainTab)
