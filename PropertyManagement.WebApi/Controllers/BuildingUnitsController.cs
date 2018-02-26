namespace PropertyManagement.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Repositories.Abstract;

    public class BuildingUnitsController : ApiController
    {
        private readonly IUnitRepository _unitRepository;

        public BuildingUnitsController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        //GET api/building/5/units
        /// <summary>
        /// Gets the building units.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Unit> GetBuildingUnits(int buildingId)
        {
            return _unitRepository.GetUnitsByBuildingId(buildingId);
        }
    }
}
