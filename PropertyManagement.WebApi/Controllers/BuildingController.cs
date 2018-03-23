namespace PropertyManagement.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Repositories.Abstract;

    public class BuildingController : ApiController
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingController(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        // GET api/building
        /// <summary>
        /// Gets the buildings.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Models.Building> GetBuildings()
        {
            var buildings = _buildingRepository.GetAllBuildings();
            return buildings.ToArray();
        }

        // GET api/building/5
        /// <summary>
        /// Gets the building.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetBuilding(int id)
        {
            var building = _buildingRepository.GetBuildingById(id);
            if (building == null)
            {
                return NotFound();
            }
            
            return Ok(building);
        }

        // POST api/building
        /// <summary>
        /// Creates the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateBuilding(Models.Building building)
        {
            if (_buildingRepository.GetBuildingById(building.BuildingId) != null)
            {
                return Conflict();
            }

            _buildingRepository.AddBuilding(building);
            return CreatedAtRoute("DefaultApi", new { id = building.BuildingId }, building);
        }

        // PUT api/building/5
        /// <summary>
        /// Updates the building.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateBuilding(int id, Models.Building building)
        {
            if (id != building.BuildingId)
            {
                return BadRequest();
            }

            var b = _buildingRepository.GetBuildingById(id);
            if (b == null)
            {
                return NotFound();
            }
            
            _buildingRepository.UpdateBuilding(building);
            return Ok();
        }

        // DELETE api/building/5
        /// <summary>
        /// Deletes the building.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteBuilding(int id)
        {
            _buildingRepository.DeleteBuilding(id);

            return Ok();
        }
    }
}
