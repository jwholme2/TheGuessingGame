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
        static readonly Random rnd = new Random();
        public List<Employee> CachedEmployees {get;set; }

        public async Task<List<Employee>> RetrieveData() {

            if (CachedEmployees == null || CachedEmployees.Count == 0) {

                await GetSeedData();  
            }

            var employees = CachedEmployees.OrderBy(x => rnd.Next()).Take(5);

            return new List<Employee>(employees);
        }

        public async Task GetSeedData() {
            var client = new HttpClient
            {
                BaseAddress = new System.Uri(BaseUrl)
            };
            var response = await client.GetAsync("profiles");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            CachedEmployees = JsonConvert.DeserializeObject<List<Employee>>(data);
        }


    }
}
