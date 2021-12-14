using AutoMapper;
using PostgresEF.Dtos;
using PostgresEF.Models.Entities;

namespace PostgresEF.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
       
    }
}
