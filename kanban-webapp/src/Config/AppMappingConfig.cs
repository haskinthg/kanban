using AutoMapper;
using Kanban.Model.Dto;
using Kanban.Model.Entity;

namespace Kanban.Config;

public class AppMappingProfile : Profile
{
		public AppMappingProfile()
		{			
			CreateMap<BoardDto, BoardEntity>();
            CreateMap<BoardEntity, BoardDto>();
            CreateMap<ShortBoardDto, BoardEntity>();
            CreateMap<BoardEntity, ShortBoardDto>();
            CreateMap<ColumnDto, ColumnEntity>();
            CreateMap<ColumnEntity, ColumnDto>();
            CreateMap<CardDto, CardEntity>();
            CreateMap<CardEntity, CardDto>();
		}
}