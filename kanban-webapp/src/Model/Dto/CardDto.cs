using System;
namespace Kanban.Model.Dto;

public class CardDto {
    public required long Id {get; set;}
    public String? Title {get; set;}
    public String? Description {get; set;}
} 