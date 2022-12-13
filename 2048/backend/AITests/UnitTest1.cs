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
        Assert.True(true);

    }
}