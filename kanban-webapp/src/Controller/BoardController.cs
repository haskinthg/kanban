using Kanban.Model.Dto;
using Kanban.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controller;

[Route("boards")]
[ApiController]
public class BoardController : ControllerBase
{
    private readonly IBoardService _boardService;
    public BoardController(IBoardService boardService)
    {
        this._boardService = boardService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShortBoardDto>>> GetBoards()
    {
        var boards = await _boardService.GetAll();
        return Ok(boards);
    }

    [HttpPost]
    public  async Task<ActionResult<ShortBoardDto>> PostBoard(ShortBoardDto shortBoard)
    {
        return await _boardService.Create(shortBoard);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BoardDto>> GetBoardById(long id)
    {
        return await _boardService.Get(id);
    }

    [HttpPost("full")]
    public async Task<ActionResult<BoardDto>> PostBoard(BoardDto board)
    {
        return await _boardService.Update(board);
    }

}