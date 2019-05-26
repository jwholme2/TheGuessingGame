using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGuessingGame.Models
{
    /// <summary>
    /// Represents a guess.
    /// </summary>
    public class Guess
    {
        /// <summary>
        /// The Id of the guess.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Collection of guesses.
        /// </summary>
        public Dictionary<string, string> Attempts { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Collection of answers.
        /// </summary>
        public IList<bool> Grades { get; set; } = new List<bool>();
    }
}
