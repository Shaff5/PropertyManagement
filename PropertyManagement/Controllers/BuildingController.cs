using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyManagement.Controllers
{
    [Route("api/[controller]")]
    public class BuildingController : Controller
    {
        // GET: api/building
        [HttpGet("[action]")]
        public IEnumerable<Building> Get()
        {
            var building1 = new Building();
            building1.BuildingId = 5;
            building1.BuildingName = "ABC";
            building1.Address = "1 Main Street";
            building1.City = "Lee";

            return new Building[] { building1 };
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        public class Building
        {
            public int BuildingId { get; set; }
            public string BuildingName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
        }
    }
}
