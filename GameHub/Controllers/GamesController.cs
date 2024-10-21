using GameHub.Models;
using GameHub.Repository;
using GameHub.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GameHub.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController(IGameService gameService) : ControllerBase
    {
        private readonly IGameService _gameService = gameService ??
            throw new ArgumentNullException(nameof(gameService));
        
        /// <summary>
        /// Retrieves games information
        /// </summary>
        /// <returns>Returns the games information if found; otherwise, returns NotFound (404).</returns>
        [HttpGet]
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GameInfoDto>>> GetGames()
        {
            var games = await _gameService.GetGamesAsync();
            return Ok(games);
        }

        /// <summary>
        /// Retrieves game information by game ID.
        /// </summary>
        /// <param name="id">The ID of the game to retrieve.</param>
        /// <returns>Returns the game information if found; otherwise, returns NotFound (404).</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GameInfoDto>> GetGame(int id)
        {
            var game = await _gameService.GetGameAsync(id);
            if (game == null)
                return NotFound();

            return Ok(game);
        }

        
        /// <summary>
        /// Retrieves games collection  by provided pagination values .
        /// </summary>
        /// <param name="pageNumber">The pageNumber of the game collection list to retrieve.</param>
        /// <param name="pageSize">The pageSize total number of records expected in collection response.</param>
        /// <returns>Returns the game information if found; otherwise, returns NotFound (404).</returns>
        [HttpGet("page")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GameInfoDto>>> GetGamesDetailsByPagination([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if(pageNumber < 1 || pageSize < 1)
                return BadRequest();
            
            var (games, paginationMetadata) = await _gameService.GetGamesDetailsAsync(pageNumber, pageSize);
            Response.Headers.Append("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));
            return Ok(games);
        }
        
        /// <summary>
        /// Create new game in application
        /// </summary>
        /// <param name="gameCreationDto">The gameCreationDto Insert new game details.</param>
        /// <returns>Returns Created on successful Insertation; otherwise, returns BadRequest.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddGame(GameCreationDto gameCreationDto)
        {
            if (gameCreationDto == null) { return BadRequest(); }
            var result = await _gameService.AddGameAsync(gameCreationDto);

            return result ? Created() : BadRequest();
        }

        /// <summary>
        /// Update existing game details in application
        /// </summary>
        /// <param name="id">The ID of the existing game.</param>
        /// <param name="gameUpdatedInfo">The gameUpdatedInfo Updated details.</param>
        /// <returns>Returns NoContent on successful update; otherwise, returns NotFound (404) or BadRequest if input modal is null.</returns>
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateGame(int id, GameCreationDto gameUpdatedInfo)
        {
            if (gameUpdatedInfo == null) { return BadRequest(); }
            var result = await _gameService.UpdateGameAsync(id, gameUpdatedInfo);
            return result ? NoContent() : NotFound();
        }

        /// <summary>
        /// Delete game data from application
        /// </summary>
        /// <param name="id">The ID of the game to delete.</param>
        /// <returns>Returns NoContent on successful deletion; otherwise, returns NotFound (404).</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await _gameService.DeleteGameAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
