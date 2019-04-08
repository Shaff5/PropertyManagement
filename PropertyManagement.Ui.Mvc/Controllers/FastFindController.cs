using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Repositories.Abstract;
using PropertyManagement.Ui.Mvc.Models.FastFind;

namespace PropertyManagement.Ui.Mvc.Controllers
{
    public class FastFindController : Controller
    {
        IBuildingRepository _buildingRepository;
        IUnitRepository _unitRepository;

        public FastFindController(IBuildingRepository buildingRepository,
            IUnitRepository unitRepository)
        {
            if (buildingRepository == null)
            {
                throw new ArgumentNullException("buildingRepository");
            }
            if (unitRepository == null)
            {
                throw new ArgumentNullException("unitRepository");
            }

            _buildingRepository = buildingRepository;
            _unitRepository = unitRepository;
        }

        public IActionResult Index(string searchTerm)
        {
            var buildingFilters = new List<Tuple<string, object>>();
            buildingFilters.Add(new Tuple<string, object>("BuildingName LIKE {0}", $"%{searchTerm}%"));
            var buildings = _buildingRepository.GetBuildings(buildingFilters);

            var unitFilters = new List<Tuple<string, object>>();
            unitFilters.Add(new Tuple<string, object>("UnitName LIKE {0}", $"%{searchTerm}%"));
            var units = _unitRepository.GetUnits(unitFilters);

            var viewModel = new FastFindViewModel();
            viewModel.Buildings = buildings;
            viewModel.Units = units;

            return View(viewModel);
        }
    }
}
