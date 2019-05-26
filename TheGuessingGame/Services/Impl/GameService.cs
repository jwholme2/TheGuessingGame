using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheGuessingGame.Models;

namespace TheGuessingGame.Services
{
    public class GameService : IGameService
    {
        private readonly ISeedService<Employee> _seedData;

        public GameService(ISeedService<Employee> seedData)
        {
            _seedData = seedData;
        }
        public IList<Game> CachedGames { get; set; } = new List<Game>();

        /// <summary>
        /// Creates game with preloaded data.
        /// </summary>
        /// <returns></returns>
        public async Task<Game> Create()
        {
            var id = CachedGames.Count;
            var newGame = new Game() { Id = id };
            newGame.Data = await _seedData.RetrieveData();
            CachedGames.Add(newGame);

            return newGame;

        }

        public async Task<Guess> AddGuess(int gameId, Dictionary<string, string> guess)
        {

            var game = CachedGames.SingleOrDefault(x => Equals(x.Id, gameId));

            if (game == null)
            {
                return null;
            }

            var isValidGuess = guess.Keys.Intersect(game.Data.Select(x => x.Id)).Count() == guess.Keys.Count();

            if (!isValidGuess) {
                return null;
            }

            var newGuess = new Guess()
            {
                Id = game.Guesses.Count,
            };

            foreach (var key in guess)
            {
                newGuess.Attempts.Add(key.Key, key.Value);
            }

            var results = await CheckGuess(newGuess.Attempts);

            newGuess.Grades = new List<bool>(results);

            game.Guesses.Add(newGuess);

            return newGuess;

        }

        public async Task<IList<bool>> CheckGuess(Dictionary<string, string> attempts)
        {
            var employees = _seedData.Cache;

            if (employees == null || employees.Count == 0)
            {
                await _seedData.RefreshCache();
            }

            var gradedGuess = new List<bool>();

            foreach (var guess in attempts)
            {
                var employee = _seedData.Cache.SingleOrDefault(x => x.Id == guess.Key);
                gradedGuess.Add(employee?.FirstName == guess.Value);
            }

            return gradedGuess;

        }

        public Guess RetrieveGuess(int gameId, int guessId)
        {
            var game = CachedGames.SingleOrDefault(x => Equals(x.Id, gameId));

            if (game == null)
            {
                return null;
            }

            var guess = game.Guesses.SingleOrDefault(x => x.Id == guessId);

            if (guess == null)
            {
                return null;
            }

            return guess;

        }
    }
}
