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
            var building = _buildingRepository.GetBuilding(id);

            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        // POST api/building
        [HttpPost]
        public void Post(Models.BuildingBindingModel model)
        {
            var building = new Building();

            building.BuildingName = model.BuildingName;
            building.AddressLine1 = model.AddressLine1;
            building.AddressLine2 = model.AddressLine2;
            building.AddressLine3 = model.AddressLine3;
            building.City = model.City;
            building.State = model.State;
            building.ZipCode = model.ZipCode;
            building.PurchaseDate = model.PurchaseDate;
            building.PurchasePrice = model.PurchasePrice;
            building.NumberOfUnits = model.NumberOfUnits;

            _buildingRepository.AddBuilding(building);
        }

        // PUT api/building/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Models.BuildingBindingModel model)
        {
            if (id != model.BuildingId)
            {
                return BadRequest();
            }

            var building = _buildingRepository.GetBuilding(model.BuildingId);

            building.BuildingName = model.BuildingName;
            building.AddressLine1 = model.AddressLine1;
            building.AddressLine2 = model.AddressLine2;
            building.AddressLine3 = model.AddressLine3;
            building.City = model.City;
            building.State = model.State;
            building.ZipCode = model.ZipCode;
            building.PurchaseDate = model.PurchaseDate;
            building.PurchasePrice = model.PurchasePrice;
            building.NumberOfUnits = model.NumberOfUnits;

            _buildingRepository.UpdateBuilding(building);

            return NoContent();
        }

        // DELETE api/building/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var building = _buildingRepository.GetBuilding(id);

            if (building == null)
            {
                return NotFound();
            }

            _buildingRepository.HardDeleteBuilding(id);
            return NoContent();
        }
    }
}
