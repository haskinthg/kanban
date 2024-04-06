using Kanban.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Db.Context;

public class BoardContext(DbContextOptions<BoardContext> options) : DbContext(options)
{
    public DbSet<BoardEntity> Boards { get; set; }
    public DbSet<ColumnEntity> Columns { get; set; }
    public DbSet<CardEntity> Cards { get; set; }

}