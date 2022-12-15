namespace Bench;
using Board;
using AI;
using System.Threading.Tasks;
using System.Diagnostics;

public class Bench {

    public static void Main(string[] args){
       runPython(10);
    }

    public static void runBench(){
        writeToFile("NewBench.txt", runNew(10));
        writeToFile("OldBench.txt", runOld(10));
        runPython(10);
    }

    private static void runPython(int num){
        System.Diagnostics.Process.Start("CMD.exe","/C python python_ver/game.py PyBench " + num).WaitForExit();
    }

    private static List<String> runOld(int num){
        List<String> Mes = new List<string>(); 
        for(int i =0; i < num;i++){
            Board board = new Board();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while(board.canMove()){
                ExpectimaxOld.makeMove(board);
            }
            watch.Stop();
            Mes.Add(
                "Moves : " + board.numberOfMoves + "\n " + 
                "Time : " + watch.ElapsedMilliseconds + " MilliSeconds\n" + 
                "Score : " + board.score  + "\n" 
            );    
        }
        return Mes;
    }

    public static void writeToFile(string name, List<string> strs){
        string s = "";
        foreach(var str in strs){
            s += str;
        }
        using(StreamWriter writetext = new StreamWriter(name)){
            writetext.WriteLine(s);
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
                "Score : " + board.score  + "\n" 
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