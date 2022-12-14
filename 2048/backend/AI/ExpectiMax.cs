using System.Reflection.Metadata;
namespace AI;
using Board;
using System;
public class Expectimax{

    public static void makeMove(Board board){
        int best = -1; 
        int bestscore = -100000000;
        int[] scores = new int[4]{bestscore -1,bestscore -1,bestscore -1,bestscore -1};
        Parallel.For(0, 4, i => { 
            if(board.moves[i]){
                Board nBoard = new Board(board.board);
                nBoard.doMoveTest(i);
                scores[i] = expectmax(nBoard, 4, true);
            }
        });
        for(int i = 0; i < 4; i++){
            if(scores[i] > bestscore){
                bestscore = scores[i];
                best = i;
            }
        }
        board.doMove(best);
    }

        public static int getMove(Board board){
        int best = -1; 
        int bestscore = -100000000;
        int[] scores = new int[4]{bestscore -1,bestscore -1,bestscore -1,bestscore -1};
        Parallel.For(0, 4, i => { 
            if(board.moves[i]){
                Board nBoard = new Board(board.board);
                nBoard.doMoveTest(i);
                scores[i] = expectmax(nBoard, 4 , true);
            }
        });
        for(int i = 0; i < 4; i++){
            if(scores[i] > bestscore){
                bestscore = scores[i];
                best = i;
            }
        }
        return best;
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
            int[] scores = new int[4];
            Parallel.For(0, 4, i => { 
                if(board.moves[i]){
                    Board nBoard = new Board(board.board);
                    nBoard.doMoveTest(i);
                    scores[i] = expectmax(nBoard, depth-1, true);
                }
            });
            foreach(int val in scores){
                bestscore = Math.Max(bestscore, val);
            }
            return bestscore;
        } else {
            int i = 0;
            Parallel.ForEach(getBoards(board), 
                nboard => {
                    i += 1;
                    double score2;
                    score2 = expectmax(nboard.Item1, depth -1,false);
                    score2 *= nboard.Item2 ? 0.9 : 0.1;
                    score += (int) Math.Floor(score2);
                }
            );
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
