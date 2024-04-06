using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Model.Entity;

public class BoardEntity : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public required long Id { get; set; }
    public required String Name { get; set; }
    public String? Description { get; set; }
    public required List<ColumnEntity> Columns { get; set; }
}