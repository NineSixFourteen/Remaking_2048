namespace AITests;
using AI;
using Board;

public class UnitTest1{
    [Fact]
    public void Test1(){
        Board board = new Board(
            new int[,]{
                {64,2 ,32,8},
                {16,32,16,4},
                {4 ,8 ,4 ,2},
                {2 ,2 ,4 ,2}
            }
        );
        Expectimax.makeMove(board);
        board = new Board(
            new int[,]{
                {2048,512 ,4,4},
                {16,128,256,16},
                {4 ,2 ,32 ,8},
                {2 ,16 ,4 ,2}
            }
        );
        Assert.True(board.moves[0]);
        Assert.True(board.moves[1]);
        Assert.False(board.moves[2]);
        Assert.False(board.moves[3]);
        Expectimax.makeMove(board);
    }
}