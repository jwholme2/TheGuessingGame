using System.Collections.Generic;
using System.Threading.Tasks;
using TheGuessingGame.Models;

namespace TheGuessingGame.Services
{
    public interface ISeedService<T>
    {
        /// <summary>
        /// In-memory collection.
        /// </summary>
        IList<T> Cache { get; set; }

 
        /// <summary>
        /// Retrieves data from the cache
        /// </summary>
        /// <param name="limit">Number of records to return.</param>
        /// <returns></returns>
        Task<IList<T>> RetrieveData(int limit = 5);

        /// <summary>
        /// Refreshes the cache.
        /// </summary>
        /// <returns></returns>
        Task RefreshCache();
    }
}