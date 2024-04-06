using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Model.Entity;

public class CardEntity : IBaseEntity {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public required long Id {get; set;}
    public String? Title {get; set;}
    public String? Description {get; set;}
} 