using Kanban.Db.Context;
using Kanban.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Db;

public class BoardRepository : IBoardRepository
{
    private readonly BoardContext _db;

    public BoardRepository(BoardContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public async Task<IEnumerable<BoardEntity>> GetAll()
    {
        return await _db.Boards.ToListAsync();
    }

    public async Task<BoardEntity?> Get(long id)
    {
        return await _db.Boards
                .Include(b => b.Columns)
                .ThenInclude(c => c.Cards)
                .FirstOrDefaultAsync(b => b.Id == id);
    }

    public void Create(BoardEntity item)
    {
        _db.Boards.Add(item);
    }

    public async Task Update(BoardEntity item)
    {
        // Обновляем состояние доски
        BoardEntity? boardEntity = await Get(item.Id);
        if(boardEntity != null) {
            boardEntity.Columns.ForEach(column => {
                _db.Cards.RemoveRange(column.Cards);
            });
            _db.Columns.RemoveRange(boardEntity.Columns);
            await Save();
            _db.Entry(boardEntity).State = EntityState.Deleted;
        }
        _db.Entry(item).State = EntityState.Modified;
        foreach (var column in item.Columns)
        {
            _db.Columns.Add(column);
            foreach (var card in column.Cards)
            {
                    _db.Cards.Add(card);
            }
        }
    }

    public void Delete(long id)
    {
        var item = _db.Boards.Find(id);
        if (item != null)
            _db.Boards.Remove(item);
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _db.DisposeAsync();
        }
    }
}