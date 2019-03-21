using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Domain;
using PropertyManagement.Repositories.Abstract;

namespace PropertyManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingController(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }


        // GET api/building
        [HttpGet]
        public ActionResult<IEnumerable<Building>> Get()
        {
            return Ok(_buildingRepository.GetBuildings());
        }

        // GET api/building/5
        [HttpGet("{id}")]
        public ActionResult<Building> Get(int id)
        {
            return Ok(_buildingRepository.GetBuilding(id));
        }

        // POST api/building
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/building/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/building/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
