namespace razor.Data;
using Board;

public class BoardService
{
    public Task<Board> GetBoard(){
        return Task.FromResult(new Board());

    }
}
