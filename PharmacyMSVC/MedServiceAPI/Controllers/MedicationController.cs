using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;

        public MedicationController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }
        // GET: api/<MedsAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MedsAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MedsAPIController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Medication medsapi)
        {
           await publishEndpoint.Publish<Medication>(medsapi);

            return Ok();
        }

        // PUT api/<MedsAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedsAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
