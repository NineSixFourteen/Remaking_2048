namespace Board;
using System;
using System.IO;
using AI;

public class Game {

    public static void Main(string[] args){
        Board board = new Board();
        Board board2 = new Board(board.board);
        var watch = System.Diagnostics.Stopwatch.StartNew();
        while(board.canMove()){
            Expectimax.makeMove(board);
            printBoard(board);
        }
        watch.Stop();
        var watch2 = System.Diagnostics.Stopwatch.StartNew();
        while(board2.canMove()){
            ExpectimaxOld.makeMove(board2);
            printBoard(board2);
        }
        Console.WriteLine("New\n Moves : " + board.numberOfMoves + "\n " + "in " + watch.ElapsedMilliseconds + " MilliSeconds" );
        Console.WriteLine("Old\nMoves : " + board2.numberOfMoves + "\n " + "in " + watch2.ElapsedMilliseconds + " MilliSeconds" );
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