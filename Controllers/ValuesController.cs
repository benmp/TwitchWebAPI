using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TwitchWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IRedisClient _redisClient;
        public ValuesController(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { _redisClient.RedisServer.Configuration };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
