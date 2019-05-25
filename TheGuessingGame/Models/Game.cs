using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGuessingGame.Models
{
    public class Game
    {
        /// <summary>
        /// The id of the <see cref="Game"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Seed data for the <see cref="Game"/>.
        /// </summary>
        public List<Employee> Data {get;set;}

        /// <summary>
        /// A collection of <see cref="Guess"/>. 
        /// </summary>
        public List<Guess> Guesses { get; set; } = new List<Guess>();
    }
}
