using Kanban.Model.Dto;

namespace Kanban.Service;

public interface IBoardService {
    public Task<ShortBoardDto> Create(ShortBoardDto dto);
    public Task<BoardDto> Update(BoardDto dto);
    public Task<BoardDto> Get(long id);
    public Task<IEnumerable<ShortBoardDto>> GetAll();
    // public ShortBoardDto remove(ShortBoardDto dto);
}