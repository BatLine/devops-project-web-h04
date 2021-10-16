using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project3H04.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KunstwerkController : ControllerBase
    {
        // GET: api/<KunstwerkController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<KunstwerkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<KunstwerkController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<KunstwerkController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KunstwerkController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
