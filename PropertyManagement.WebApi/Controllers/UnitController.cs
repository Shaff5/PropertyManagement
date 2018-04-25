namespace PropertyManagement.WebApi.Controllers
{
    using System.Web.Http;
    using Repositories.Abstract;

    public class UnitController : ApiController
    {
        private readonly IUnitRepository _unitRepository;

        public UnitController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        // GET api/unit
        /// <summary>
        /// Gets the units.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetUnits()
        {
            var units = _unitRepository.GetAllUnits();
            return Ok(units);
        }

        // GET api/unit/5
        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetUnit(int id)
        {
            var unit = _unitRepository.GetUnitById(id);
            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // POST api/unit
        /// <summary>
        /// Creates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateUnit(Models.Unit unit)
        {
            if (_unitRepository.GetUnitById(unit.UnitId) != null)
            {
                return Conflict();
            }

            _unitRepository.AddUnit(unit);
            return CreatedAtRoute("DefaultApi", new { id = unit.UnitId }, unit);
        }

        // PUT api/unit/5
        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateUnit(int id, Models.Unit unit)
        {
            if (id != unit.UnitId)
            {
                return BadRequest();
            }

            var u = _unitRepository.GetUnitById(id);
            if (u == null)
            {
                return NotFound();
            }

            _unitRepository.UpdateUnit(unit);
            return Ok();
        }

        // DELETE api/unit/5
        /// <summary>
        /// Deletes the unit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteUnit(int id)
        {
            _unitRepository.DeleteUnit(id);
            return Ok();
        }
    }
}
