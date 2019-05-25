using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheGuessingGame.Models;

namespace TheGuessingGame.Services
{
    public class GameService
    {
        private SeedData _seedData;

        public GameService(SeedData seedData) {
            _seedData = seedData;
        }
        public List<Game> CachedGames { get; set; } = new List<Game>();

        /// <summary>
        /// Creates game with preloaded data.
        /// </summary>
        /// <returns></returns>
        public async Task<Game> Create() {
            var id = CachedGames.Count;
            var newGame = new Game() { Id = id};
            newGame.Data = await _seedData.RetrieveData();
            CachedGames.Add(newGame);

            return newGame;

        }

        public async Task<Guess> AddGuess(int gameId, Dictionary<string,string> guess)
        {

            var game = CachedGames.Find(x => Equals(x.Id, gameId));

            if (game == null) {
                return null;
            }

            var newGuess = new Guess()
            {
                Id = game.Guesses.Count,
            };

            foreach (var key in guess) {
                newGuess.Attempts.Add(key.Key, key.Value);
            }

            var results = await CheckGuess(newGuess.Attempts);

            newGuess.Grades.AddRange(results);

            return newGuess;

        }

        public async Task<List<bool>> CheckGuess(Dictionary<string,string> attempts)
        {
            var employees = _seedData.CachedEmployees;

            if (employees == null || employees.Count == 0)
            {
                await _seedData.GetSeedData();
            }

            var gradedGuess = new List<bool>();

            foreach (var guess in attempts)
            {
                var employee = _seedData.CachedEmployees.Find(x => x.Id == guess.Key);
                gradedGuess.Add(employee?.FirstName == guess.Value);
            }

            return gradedGuess;

        }

        public Guess RetrieveGuess(int gameId, int guessId)
        {
            var game = CachedGames.Find(x => Equals(x.Id, gameId));

            if (game == null)
            {
                return null;
            }

            var guess = game.Guesses.Find(x => x.Id == guessId);

            if (guess == null) {
                return null;
            }

            return guess;

        }
    }
}
