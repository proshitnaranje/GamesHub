using GameHub.DbContexts;
using GameHub.Entities;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Repository
{
    public class GamesRepository(GameHubContext context) : IGamesRepository
    {
        private readonly GameHubContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<Game?> GetGameAsync(int id)
        {
            return await _context.Games.Where(g => g.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<(IEnumerable<Game>, int)> GetGamesByPaginationAsync(int pageNumber, int pageSize)
        {
            // Calculate the number of items to skip
            int skipAmount = (pageNumber - 1) * pageSize;

            // Retrieve paginated data
            var paginatedGames = await _context.Games
                                               .Skip(skipAmount)
                                               .Take(pageSize)
                                               .ToListAsync();
            return (paginatedGames, _context.Games.Count());
        }
        public async Task<bool> GameExistsAsync(int id)
        {
            return await _context.Games.AnyAsync(g => g.ID == id);
        }

        public void AddGame(Game game)
        {
            _context.Games.Add(game);
        }

        public void UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void DeleteGame(Game game)
        {
            _context.Games?.Remove(game);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
