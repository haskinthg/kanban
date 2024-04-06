using System;
namespace Kanban.Model.Dto;

public class ColumnDto {
    public required long Id {get; set;}
    public String? Title {get; set;}
    public List<CardDto>? Cards {get; set;}
} 