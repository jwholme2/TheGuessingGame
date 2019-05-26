using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheGuessingGame.Models;

namespace TheGuessingGame.Services
{
    /// <summary>
    /// Service to retrieve data from public API.
    /// </summary>
    public class SeedData : ISeedService<Employee>
    {
        private const string BaseUrl = "https://www.willowtreeapps.com/api/v1.0/";

        static readonly Random rnd = new Random();

        public IList<Employee> Cache { get; set; }

        public async Task<IList<Employee>> RetrieveData(int limit = 5)
        {
            if (Cache == null || Cache.Count == 0)
            {
                await RefreshCache();
            }

            var employees = Cache.OrderBy(x => rnd.Next()).Take(limit);

            return new List<Employee>(employees);
        }

        public async Task RefreshCache()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            var response = await client.GetAsync("profiles");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            Cache = JsonConvert.DeserializeObject<List<Employee>>(data);
        }
    }
}
