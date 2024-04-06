using AutoMapper;
using Kanban.Db;
using Kanban.Model.Dto;
using Kanban.Model.Entity;

namespace Kanban.Service;

public class BoardService : IBoardService
{
    private readonly IMapper _mapper;
    private readonly IBoardRepository _boardRepository;

    public BoardService(IMapper mapper, IBoardRepository boardRepository)
    {
        this._mapper = mapper;
        this._boardRepository = boardRepository;
    }

    public async Task<ShortBoardDto> Create(ShortBoardDto dto)
    {
        BoardEntity boardEntity = _mapper.Map<BoardEntity>(dto);
        _boardRepository.Create(boardEntity);
        await _boardRepository.Save();
        return _mapper.Map<ShortBoardDto>(boardEntity);
    }

    public async Task<BoardDto> Update(BoardDto dto)
    {
        BoardEntity boardEntity = _mapper.Map<BoardEntity>(dto);
        await _boardRepository.Update(boardEntity);
        await _boardRepository.Save();
        return _mapper.Map<BoardDto>(boardEntity);
    }

    public async Task<BoardDto> Get(long id)
    {
        BoardEntity? boardEntity = await _boardRepository.Get(id);
        return _mapper.Map<BoardDto>(boardEntity);
    }
    public async Task<IEnumerable<ShortBoardDto>> GetAll()
    {
        IEnumerable<BoardEntity> boards = await _boardRepository.GetAll();
        return boards.Select(_mapper.Map<ShortBoardDto>);
    }
}