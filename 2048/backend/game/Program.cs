namespace Board;
using System;
using System.IO;
using AI;

public class Game {

    public static void Main(string[] args){
        Board board = new Board();
        while(board.canMove()){
            printBoard(board);
            Expectimax.makeMove(board);
        }
        Console.WriteLine("done");
    }

    private static void printBoard(Board board){
        Console.WriteLine("---------------------------------------");
        for(int row = 0 ; row < 4; row++){
            string rw = "| ";
            for(int i = 0; i < 4 ; i++){
                rw += board.board[row,i] + " | ";
            }
            Console.WriteLine(rw);
        }
    }


}