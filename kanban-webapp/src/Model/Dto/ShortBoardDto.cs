using System;
using Microsoft.AspNetCore.Mvc;
namespace Kanban.Model.Dto;

// [BindProperties]
public class ShortBoardDto {
    public long? Id {get; set;}
    public String? Name {get; set;}
    public String? Description {get; set;}
} 