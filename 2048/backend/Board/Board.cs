namespace Board;
    
public class Board {

    public  int[,] board {get;set;} 
    private int score;
    private int noMoves;
    private bool[] moves;

    public Board(int[,] ints)
    {
        board = ints;
        moves = new bool[]{true,true,true,true}; /* Left, Right, Up, Down*/
    }

    public Board(Board b){
        this.board = b.board;
        this.moves = b.moves;
        this.noMoves = b.noMoves;
        this.score = b.score;
    }

    public int getBiggestTile(){
        int big = 0; 
        for(int i = 0; i < 4; i++){
            for(int l = 0; l < 4;l++){
                if(this.board[i,l] > big){
                    big = this.board[i,l];
                }
            }
        }
        return big;
    }

    public bool isEmpty(int x, int y){
        return this.board[x,y] == 0;
    }

    private void updateMoves(){
        this.moves = findMoves();
    }

    public bool[] findMoves(){
        bool[] moves = new bool[]{false,false,false,false};
        moves[0] = canMove(true);
        moves[1] = canMove(false);
        rotate();
        moves[2] = canMove(true);
        moves[3] = canMove(false);
        rotate();
        return moves;
    }
    

    private bool canMove(bool left){
        for(int i = 0; i < 4;i++){
            if(canMoveRow(i, left)){
                return true;
            }
        }
        return false;
    }

    private bool canMoveRow(int row, bool left){
        int[] nums;
        int check;
        if(left){
            nums = new int[]{1,2,3};
            check = -1;
        } else {
            nums = new int[]{0,1,2};
            check = 1;
        }
        bool skip = true;  
        foreach(int num in nums){
            if(board[row,num] != 0){
                skip = false;
            } 
        }        
        if(skip){
            return false;
        }
        foreach(int num in nums ){
            if( board[row,num] != 0 && board[row, num + check] == 0){
                return true;
            }
            if( board[row,num] != 0 && board[row,num + check ] == board[row,num]){
                return true;
            }
        }
        return false;
    }


    public bool doMove(int num){
        if(num < 4 && moves[num]){
            makeMove(num);
            updateMoves();
            return true;
        } 
        return false;
    }

    private void makeMove(int num){
        if(num > 1){ // Rotate for down and up 
            rotate();
        }
        switch(num){
            case 0:
            case 3:
                move(true);
                break;
            case 1:
            case 2:
                move(false);
                break;
        }
        if(num > 1){ // Rotate for down and up to put in correct positions
            rotate();
        }
    }

    private void move(bool left){
        for(int i = 0; i < 4;i++){
            moveRow(i, left);
        }
    }

    private void moveRow(int row, bool left){
        int[] tiles;
        int direction; 
        if(left){
            tiles = new int[]{1,2,3};
            direction = -1;
        } else {
            tiles = new int[]{2,1,0};
            direction = 1;
        }
        foreach(int tile in tiles){
            budgeTile(row,tile, direction);
        }
        foreach(int tile in tiles){
            lookMerge(row,tile, direction);
        }
        foreach(int tile in tiles){
            budgeTile(row,tile, direction);
        }
    }

    private void lookMerge(int row, int tile, int dir){
        if(board[row, tile] == 0){
            return;
        }
        if(board[row,tile] == board[row,tile + dir]){
            board[row,tile] = 0;
            board[row,tile + dir] *= 2;
        }
    }

    private void budgeTile(int row,int tile, int dir){
        if(board[row, tile] == 0){
            return;
        }
        while(true){
            if(dir == -1){
                if(tile < 1){
                    break;
                }
            } else {
                if(tile > 2){
                    break;
                }
            }
            if(board[row, tile + dir] == 0){
                board[row, tile + dir] = board[row, tile];
                board[row, tile] = 0 ;
                tile += dir;
            } else {
                break;
            }
        }

    }


    /* Rotate the board to check top and bottom are movable*/
    /* Also used to unrotate the board*/

    private void rotate(){
        int[,] newBoard = new int[4,4];
        for(int col = 0 ; col < 4; col++){
            for(int row = 0; row < 4;row++){
                newBoard[row,col] = this.board[col,row];
            }
        }
        this.board = newBoard;
    }


    

    

}
