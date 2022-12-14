namespace Board;
using System;
using System.IO;
using AI;

public class Game {

    public static void Main(string[] args){
        Board board = new Board();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        while(board.canMove()){
            Expectimax.makeMove(board);
            printBoard(board);
        }
        watch.Stop();
        Console.WriteLine("New\n Moves : " + board.numberOfMoves + "\n " + "in " + watch.ElapsedMilliseconds + " MilliSeconds" );    
    }

    private static void printBoard(Board board){
        for(int row = 0 ; row < 4; row++){
            string rw = "| ";
            for(int i = 0; i < 4 ; i++){
                rw += board.board[row,i] + " | ";
            }
            Console.WriteLine(rw);
        }
    }


}