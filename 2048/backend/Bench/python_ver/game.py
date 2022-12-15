from Board_class import Boards
from PlayerAI import AI
import time
import sys

def main():
    board = Boards();
    ai =  AI();
    start = time.time();
    name = sys.argv[1];
    amount = sys.argv[2];
    message = ""
    for i in range(int(amount)):
        board = Boards();
        while(len(board.possibleMoves) != 0):
            ai.takeBoard(board)
            x = ai.nextMove();
            if   x == "LEFT":
                board.doMove("left");
            elif x == "DOWN":
                board.doMove("down");
            elif x == "RIGHT":
                board.doMove("right");
            else:
                board.doMove("up");
        end = time.time()
        message +=  "Moves : " + str(board.noMoves) + "\n" + \
                    "Time  : " + str(end - start) + " seconds \n" + \
                    "Score : " + str(board.score) + "\n";
    f = open(name + ".txt", "w")
    f.write(message)
    f.close()



main()