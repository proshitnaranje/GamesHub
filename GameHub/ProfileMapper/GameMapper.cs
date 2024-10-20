using AutoMapper;

namespace GameHub.ProfileMapper
{
    public class GameMapper : Profile
    {
        public GameMapper() {
            CreateMap<Entities.Game, Models.GameInfoDto>();
            CreateMap<Models.GameCreationDto, Entities.Game>();
        }
    }
}
