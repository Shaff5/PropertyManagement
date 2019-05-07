using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Repositories.Abstract;

namespace PropertyManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FastFindController : ControllerBase
    {
        IBuildingRepository _buildingRepository;
        IUnitRepository _unitRepository;
        IRentRepository _rentRepository;

        public FastFindController(IBuildingRepository buildingRepository,
            IUnitRepository unitRepository, IRentRepository rentRepository)
        {
            if (buildingRepository == null)
            {
                throw new ArgumentNullException("buildingRepository");
            }
            if (unitRepository == null)
            {
                throw new ArgumentNullException("unitRepository");
            }
            if (rentRepository == null)
            {
                throw new ArgumentNullException("rentRepository");
            }

            _buildingRepository = buildingRepository;
            _unitRepository = unitRepository;
            _rentRepository = rentRepository;
        }

        // GET api/fastfind/abcd
        [HttpGet("{searchTerm}")]
        public ActionResult<Models.FastFindBindingModel> Get(string searchTerm)
        {
            var buildingFilters = new List<Tuple<string, object>>();
            buildingFilters.Add(new Tuple<string, object>("BuildingName LIKE {0}", $"%{searchTerm}%"));
            var buildings = _buildingRepository.GetBuildings(buildingFilters);

            var unitFilters = new List<Tuple<string, object>>();
            unitFilters.Add(new Tuple<string, object>("UnitName LIKE {0}", $"%{searchTerm}%"));
            var units = _unitRepository.GetUnits(unitFilters);

            var rentFilters = new List<Tuple<string, object>>();
            rentFilters.Add(new Tuple<string, object>("UnitName LIKE {0}", $"%{searchTerm}%"));
            var rents = _rentRepository.GetRents(rentFilters);

            var model = new Models.FastFindBindingModel();
            model.Buildings = buildings;
            model.Units = units;
            model.Rents = rents;

            return Ok(model);
        }
    }
}
