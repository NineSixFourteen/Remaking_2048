namespace BoardTests;
using Board;

public class UnitTest1{
    [Fact]
    public void LeftAndRight(){
        Board board = new Board(
            new int[,]{
                {2,2,2,2}, 
                {2,0,2,2}, 
                {2,2,2,0}, 
                {2,4,4,0}
            });
        board.doMove(0);
        int[,] test1 = 
        new int[,]{
                {4,4,0,0},
                {4,2,0,0},
                {4,2,0,0},
                {2,8,0,0}
            };
        Assert.Equal(
            board.board,
            test1
        );
        board.doMove(1);
        Assert.Equal(
            board.board,
            new int[,]{
                {0,0,0,8},
                {0,0,4,2},
                {0,0,4,2},
                {0,0,2,8}
            }
        );
        bool x = board.doMove(1);
        Assert.Equal(
            board.board,
            new int[,]{
                {0,0,0,8},
                {0,0,4,2},
                {0,0,4,2},
                {0,0,2,8}
            }
        );
        Assert.Equal(x, false);
    }

    [Fact]
    public void UpandDown(){
        Board board = new Board(
            new int[,]{
                {2,2,2,2}, 
                {2,2,2,2}, 
                {0,0,0,0}, 
                {2,4,4,2}
            });
        board.doMove(2);
        Assert.Equal(
            board.board,
            new int[,]{
                {0,0,0,0},
                {0,0,0,0},
                {2,4,4,2},
                {4,4,4,4}
            }
        );
        board.doMove(3);
        Assert.Equal(
            board.board,
            new int[,]{
                {2,8,8,2},
                {4,0,0,4},
                {0,0,0,0},
                {0,0,0,0}
            }
        );
    }
}