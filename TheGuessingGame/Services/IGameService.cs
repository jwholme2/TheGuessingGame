using System.Collections.Generic;
using System.Threading.Tasks;
using TheGuessingGame.Models;

namespace TheGuessingGame.Services
{
    public interface IGameService
    {
        IList<Game> CachedGames { get; set; }

        Task<Guess> AddGuess(int gameId, Dictionary<string, string> guess);
        Task<IList<bool>> CheckGuess(Dictionary<string, string> attempts);
        Task<Game> Create();
        Guess RetrieveGuess(int gameId, int guessId);
    }
}