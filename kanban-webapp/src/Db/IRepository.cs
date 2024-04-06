using Kanban.Model.Entity;

namespace Kanban.Db;

public interface IRepository<T> : IDisposable
    where T : IBaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> Get(long id);
    void Create(T item);
    Task Update(T item);
    void Delete(long id);
    Task Save();
}