using System.Reflection.Metadata;
namespace AI;
using Board;
using System;
public class Expectimax{

    public static void makeMove(Board board){
        int best = -1; 
        int score = -100000000;
        int i = 0;
        foreach(bool b in board.moves){
            if(b){
                Board nboard = new Board(board.board);
                nboard.doMoveTest(i);
                int nScore = expectmax(nboard, 4, true);
                Console.WriteLine(nScore);
                if(nScore > score){
                    best = i; 
                    score = nScore;
                }
            }
            i++;
        }
        board.doMove(best);
    }

    private static List<(Board, bool)> getBoards(Board board){
        List<(Board, bool)> newBoards = new List<(Board, bool)>();
        for(int x = 0; x < 4; x++){
            for(int y = 0; y < 4; y++){
                if(board.isEmpty(x, y)){
                    Board nBoard = new Board(board.board);
                    Board nBoard2 = new Board(board.board);
                    nBoard.board[x,y] = 2;
                    nBoard2.board[x,y] = 4;
                    nBoard.updateMoves();
                    nBoard2.updateMoves();
                    newBoards.Add((nBoard, true));
                    newBoards.Add((nBoard2, false));
                }
            }
        }
        return newBoards;
    }

    private static int expectmax(Board board, int depth, bool addRandom){
        if (depth == 0) return heur(board);
        if (board.canMove() == false) return -1000;
        int score = 0;
        if(!addRandom){
            int bestscore = -10000;
            for(int i =0 ; i < 4;i++){
                bool b = board.moves[i];
                if(b){
                    Board nBoard = new Board(board.board);
                    nBoard.doMoveTest(i);
                    score = expectmax(nBoard, depth-1, true);
                    bestscore = Math.Max(bestscore, score);
                }
            }
            return bestscore;
        } else {
            int i = 0;
            foreach((Board, bool) nBoard in getBoards(board)){
                i += 1;
                double score2 = expectmax(nBoard.Item1, depth -1,false);
                score2 *= nBoard.Item2 ? 0.9 : 0.1;
                score += (int) Math.Floor(score2);
            }

            return score / i;
        }
    }
    
    private static int heur(Board board){
        int score = 0;
        int[,] weights = new int[,]{
            {135,121,102,99},
            {97,88,76,73},
            {66,56,37,16},
            {12,9,7,3}
        };
        for(int i = 0; i < 4; i++){
            for(int l = 0; l < 4; l++){
                int tile = board.board[i,l];
                score += tile * weights[i,l];
            }
        }
        return score;
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
