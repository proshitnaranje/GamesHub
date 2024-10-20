﻿using AutoMapper;
using GameHub.Entities;
using GameHub.Models;
using GameHub.Repository;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Service
{
    public class GameService(IGamesRepository gamesRepository, IMapper mapper) : IGameService
    {
        private readonly IGamesRepository _gamesRepository = gamesRepository ?? throw new ArgumentNullException(nameof(gamesRepository));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<GameInfoDto?> GetGameAsync(int id)
        {
            var game = await _gamesRepository.GetGameAsync(id);

            return _mapper.Map<GameInfoDto>(game);
        }
        public async Task<IEnumerable<GameInfoDto>> GetGamesAsync()
        {
            var games = await _gamesRepository.GetGamesAsync();
            return _mapper.Map<IEnumerable<GameInfoDto>>(games);
        }
        public async Task<(IEnumerable<GameInfoDto>, PaginationMetadata)> GetGamesDetailsAsync(int pageNumber, int pageSize)
        {
            // collection to start from
            var collection = await _gamesRepository.GetGamesByPaginationAsync(pageNumber, pageSize);
            var paginationMetadata = new PaginationMetadata(collection.Item2, pageSize, pageNumber);
            var finalcollection = _mapper.Map<IEnumerable<GameInfoDto>>(collection.Item1);
            return (finalcollection, paginationMetadata);
        }
       
        public async Task<bool> AddGameAsync(GameCreationDto game)
        {
            var newGame = _mapper.Map<Game>(game);
            _gamesRepository.AddGame(newGame);
            return await _gamesRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateGameAsync(int id, GameCreationDto gameUpdate)
        {
            var game = await _gamesRepository.GetGameAsync(id);
            if(game != null)
            {
                game.Title = gameUpdate.Title;
                game.Genre = gameUpdate.Genre;
                game.Description = gameUpdate.Description;
                game.Price = gameUpdate.Price;
                game.ReleaseDate = gameUpdate.ReleaseDate;
                game.StockQuantity = gameUpdate.StockQuantity;
                return await _gamesRepository.SaveChangesAsync();
            }
            return false;
        }
       
        public async Task<bool> DeleteGameAsync(int id)
        {
            var game = await _gamesRepository.GetGameAsync(id);
            if (game != null)
            {
                _gamesRepository.DeleteGame(game);
                return await _gamesRepository.SaveChangesAsync();
            }
            return false;
        }
    }
}
