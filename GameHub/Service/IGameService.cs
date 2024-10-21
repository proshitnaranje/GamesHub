using GameHub.Entities;
using GameHub.Models;

namespace GameHub.Service
{
    public interface IGameService
    {
        Task<GameInfoDto?> GetGameAsync(int id);
        Task<IEnumerable<GameInfoDto>> GetGamesAsync();

        Task<(IEnumerable<GameInfoDto>, PaginationMetadata)> GetGamesDetailsAsync(int pageNumber, int pageSize);
        Task<bool> AddGameAsync(GameCreationDto game);
        Task<bool> UpdateGameAsync(int id, GameCreationDto game);
        Task<bool> DeleteGameAsync(int id); 
    }
}
