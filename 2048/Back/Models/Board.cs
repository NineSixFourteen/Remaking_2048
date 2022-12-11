namespace Back.Board;
    
public class Board {

    private int[,] board {get;set;} 
    private int score;
    private int noMoves;
    private bool[] moves;

    public Board(){
        board = new int[4,4];
        moves = new bool[]{true,true,true,true}; /* Left, Right, Down, Up*/
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

    public void updateMoves(){
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
    

    public bool canMove(bool left){
        for(int i = 0; i < 4;i++){
            if(canMoveRow(i, left)){
                return true;
            }
        }
        return false;
    }

    public bool canMoveRow(int row, bool left){
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


    /* Rotate the board to check top and bottom are movable*/
    /* Also used to unrotate the board*/

    public void rotate(){
        int[,] newBoard = new int[4,4];
        for(int col = 0 ; col < 4; col++){
            for(int row = 0; row < 4;row++){
                newBoard[row,col] = this.board[col,row];
            }
        }
        this.board = newBoard;
    }
    

    

}
