namespace Bench;
using Board;
using AI;
using System.Threading.Tasks;

public class Bench {

    public static void Main(string[] args){
       runBench("");
    }

    public static void runBench(String whatToRun){
        var strs = runNew(10);
        foreach(var str in strs){
            using(StreamWriter writetext = new StreamWriter("NewBench.txt")){
                writetext.WriteLine(str);
            }
        }
        
    }

    public static List<String> runNew(int num){
        List<String> Mes = new List<string>(); 
        for(int i =0; i < num;i++){
            Board board = new Board();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while(board.canMove()){
                Expectimax.makeMove(board);
            }
            watch.Stop();
            Mes.Add(
                "Moves : " + board.numberOfMoves + "\n " + 
                "Time : " + watch.ElapsedMilliseconds + " MilliSeconds\n" + 
                "Score : " + board.score   
            );    
        }
        return Mes;
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