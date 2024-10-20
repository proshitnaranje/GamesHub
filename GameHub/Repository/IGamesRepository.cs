using GameHub.Entities;

namespace GameHub.Repository
{
    public interface IGamesRepository
    {
        Task<Game?> GetGameAsync(int id);

        Task<IEnumerable<Game>> GetGamesAsync();
        
        Task<bool> GameExistsAsync(int id);
        void AddGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(Game game);
        Task<bool> SaveChangesAsync();
    }
}
