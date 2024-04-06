namespace Kanban.Model.Dto;

// [BindProperties]
public class BoardDto
{
    public required long Id { get; set; }
    public required String Name { get; set; }
    public String? Description { get; set; }
    public List<ColumnDto>? Columns { get; set; }
}