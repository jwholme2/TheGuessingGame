using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheGuessingGame.Models;
using TheGuessingGame.Services;

namespace TheGuessingGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService) {

            _gameService = gameService;
        }

        // POST game 
        // starts new game
        [HttpPost]
        [ProducesResponseType(typeof(Game), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post()
        {
            var game = await _gameService.Create();

            return CreatedAtAction(nameof(Get), new { game.Id }, game);
        }

        // GET game/id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var game = _gameService.CachedGames.SingleOrDefault(x => x.Id == id);

            if (game == null) {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost("{id}/guess")]
        [ProducesResponseType(typeof(Guess), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromRoute] int id, [FromBody] Dictionary<string,string> guess)
        {
            var result = await _gameService.AddGuess(id, guess);

            if (result == null) {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { result.Id }, result);

        }

        [HttpGet("{id}/guess/{guessId}")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute] int gameId, [FromRoute] int guessId)
        {
            var result = _gameService.RetrieveGuess(gameId, guessId);

            if (result == null) {
                return NotFound();
            }

            return Ok(result);

        }

    }
}
