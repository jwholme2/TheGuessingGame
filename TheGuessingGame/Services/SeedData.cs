using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheGuessingGame.Models;

namespace TheGuessingGame.Services
{
    public class SeedData
    {
        private const string BaseUrl = "https://www.willowtreeapps.com/api/v1.0/";

        public async Task<List<Employee>> GetSeedData() {
            var client = new HttpClient
            {
                BaseAddress = new System.Uri(BaseUrl)
            };
            var response = await client.GetAsync("profiles");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Employee>>(data);

        }
    }
}
