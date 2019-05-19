using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly SeedData _seedDataService;
        static readonly Random rnd = new Random();


        public GameController(SeedData seedDataService) {

            _seedDataService = seedDataService;
        }

        // GET api/values
        [HttpGet("setup")]
        public async Task<IEnumerable<Employee>> GetAsync()
        {
            var employees = await _seedDataService.GetSeedData();

            var limit = employees.OrderBy(x => rnd.Next()).Take(5);


            return limit;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
