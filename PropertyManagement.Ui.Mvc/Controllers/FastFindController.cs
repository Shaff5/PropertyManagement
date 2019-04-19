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

        public IActionResult Index(string searchTerm)
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

            var viewModel = new FastFindViewModel();
            viewModel.Buildings = buildings;
            viewModel.Units = units;
            viewModel.Rents = rents;

            return View(viewModel);
        }
    }
}
