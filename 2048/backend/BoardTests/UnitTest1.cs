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
        board.doMoveTest(0);
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
        board.doMoveTest(1);
        Assert.Equal(
            board.board,
            new int[,]{
                {0,0,0,8},
                {0,0,4,2},
                {0,0,4,2},
                {0,0,2,8}
            }
        );
        bool x = board.doMoveTest(1);
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
    public void LeftAndRight2(){
        Board board = new Board(
            new int[,]{
                {4,4,4,4},
                {4,4,4,2},
                {4,4,4,2},
                {4,4,4,2}
            });
        board.doMoveTest(0);
        int[,] test1 = 
        new int[,]{
                {8,8,0,0},
                {8,4,2,0},
                {8,4,2,0},
                {8,4,2,0}
            };
        Assert.Equal(
            board.board,
            test1
        );
        board = new Board(
            new int[,]{
                {128,32,4,2},
                {64,16,2,4},
                {4,32,8,2},
                {4,32,4,0}
            });
        Assert.True(!board.moves[0]);
        Assert.True(board.moves[1]);
        Assert.True(board.moves[2]);
        Assert.True(board.moves[3]);
        board = new Board(
            new int[,]{
                {512,16,4,4},
                {32,128,256,16},
                {8,64,8,4},
                {2,4,32,2}
            });
        Assert.True(board.moves[0]);
        Assert.True(board.moves[1]);
        Assert.True(!board.moves[2]);
        Assert.True(!board.moves[3]);
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

    [Fact]
    public void CanMove(){
        Board board = new Board(
            new int[,]{
                {2,4,8,2}, 
                {2,4,8,2}, 
                {2,4,8,2}, 
                {2,4,8,2}
            });
        board.updateMoves();
        Assert.Equal(
            board.moves,
            new bool[]{false,false,true,true}
        );
        board = new Board(
            new int[,]{
                {2,4,8,2}, 
                {2,4,8,2}, 
                {2,4,4,2}, 
                {2,4,8,2}
            });
        board.updateMoves();
        Assert.Equal(
            board.moves,
            new bool[]{true,true,true,true}
        );
        board = new Board(
            new int[,]{
                {16,2,16,4}, 
                {2, 4,8 ,2}, 
                {16,2,16,4}, 
                {2, 4,8 ,2}
            });
        board.updateMoves();
        Assert.True(!board.canMove());
    }
}