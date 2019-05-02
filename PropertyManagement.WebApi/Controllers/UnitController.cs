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
    public class UnitController : ControllerBase
    {
        private readonly IUnitRepository _unitRepository;

        public UnitController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        // GET api/unit
        [HttpGet]
        public ActionResult<IEnumerable<Unit>> Get()
        {
            return Ok(_unitRepository.GetUnits());
        }

        // GET api/unit/5
        [HttpGet("{id}")]
        public ActionResult<Unit> Get(int id)
        {
            var unit = _unitRepository.GetUnit(id);

            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // POST api/unit
        [HttpPost]
        public void Post(Models.UnitBindingModel model)
        {
            var unit = new Unit();

            unit.UnitName = model.UnitName;
            unit.BuildingId = model.BuildingId;
            unit.SquareFootage = model.SquareFootage;
            unit.NumberOfBedrooms = model.NumberOfBedrooms;
            unit.NumberOfBathrooms = model.NumberOfBathrooms;
            
            _unitRepository.AddUnit(unit);
        }

        // PUT api/unit/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Models.UnitBindingModel model)
        {
            if (id != model.UnitId)
            {
                return BadRequest();
            }

            var unit = _unitRepository.GetUnit(model.UnitId);

            unit.UnitName = model.UnitName;
            unit.BuildingId = model.BuildingId;
            unit.SquareFootage = model.SquareFootage;
            unit.NumberOfBedrooms = model.NumberOfBedrooms;
            unit.NumberOfBathrooms = model.NumberOfBathrooms;

            _unitRepository.UpdateUnit(unit);

            return NoContent();
        }

        // DELETE api/unit/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var unit = _unitRepository.GetUnit(id);

            if (unit == null)
            {
                return NotFound();
            }

            _unitRepository.HardDeleteUnit(id);
            return NoContent();
        }
    }
}
