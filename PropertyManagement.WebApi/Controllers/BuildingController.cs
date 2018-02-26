namespace PropertyManagement.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Description;
    //using Data;
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
        //[ResponseType(typeof(Building[]))]
        public IEnumerable<Building> GetBuildings()
        {
            var buildings = _buildingRepository.GetAllBuildings();
            var buildingList = new List<Building>();
            foreach (var building in buildings)
            {
                var b = new Building();
                b.BuildingId = building.BuildingId;
                b.BuildingName = building.BuildingName;
                b.AddressLine1 = building.AddressLine1;
                b.AddressLine2 = building.AddressLine2;
                b.AddressLine3 = building.AddressLine3;
                b.City = building.City;
                b.State = building.State;
                b.ZipCode = building.ZipCode;
                b.PurchaseDate = building.PurchaseDate;
                //another trivial change 555
                buildingList.Add(b);
            }
            return buildingList.ToArray();
        }

        // GET api/building/5
        /// <summary>
        /// Gets the building.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        //[ResponseType(typeof(Building))]
        public IHttpActionResult GetBuilding(int id)
        {
            var building = _buildingRepository.GetBuildingById(id);
            if (building == null)
            {
                return NotFound();
            }

            var b = new Building();
            b.BuildingId = building.BuildingId;
            b.BuildingName = building.BuildingName;
            b.AddressLine1 = building.AddressLine1;
            b.AddressLine2 = building.AddressLine2;
            b.AddressLine3 = building.AddressLine3;
            b.City = building.City;
            b.State = building.State;
            b.ZipCode = building.ZipCode;
            b.PurchaseDate = building.PurchaseDate;

            return Ok(b);
        }

        // POST api/building
        /// <summary>
        /// Creates the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateBuilding(Building building)
        {
            if (_buildingRepository.GetBuildingById(building.BuildingId) != null)
            {
                return Conflict();
            }

            var b = new Models.Building();
            b.BuildingId = building.BuildingId;
            b.BuildingName = building.BuildingName;
            b.AddressLine1 = building.AddressLine1;
            b.AddressLine2 = building.AddressLine2;
            b.AddressLine3 = building.AddressLine3;
            b.City = building.City;
            b.State = building.State;
            b.ZipCode = building.ZipCode;
            b.PurchaseDate = building.PurchaseDate;

            _buildingRepository.AddBuilding(b);
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
        public IHttpActionResult UpdateBuilding(int id, Building building)
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

            b.BuildingName = building.BuildingName;
            b.AddressLine1 = building.AddressLine1;
            b.AddressLine2 = building.AddressLine2;
            b.AddressLine3 = building.AddressLine3;
            b.City = building.City;
            b.State = building.State;
            b.ZipCode = building.ZipCode;
            b.PurchaseDate = building.PurchaseDate;

            _buildingRepository.UpdateBuilding(b);
            return Ok();
        }

        // DELETE api/building/5
        /// <summary>
        /// Deletes the building.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        //[HttpDelete]
        //public IHttpActionResult DeleteBuilding(int id)
        //{
        //    _buildingRepository.DeleteBuilding(id);
        //    return Ok();
        //}

        public class Building
        {
            public int BuildingId { get; set; }
            public string BuildingName { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public DateTime PurchaseDate { get; set; }
        }
    }
}
