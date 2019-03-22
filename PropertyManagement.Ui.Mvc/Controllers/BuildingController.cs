using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Domain;
using PropertyManagement.Repositories.Abstract;

namespace PropertyManagement.Ui.Mvc.Controllers
{
    public class BuildingController : Controller
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingController(IBuildingRepository buildingRepository)
        {
            if (buildingRepository == null)
            {
                throw new ArgumentNullException("buildingRepository");
            }

            _buildingRepository = buildingRepository;
        }

        public IActionResult Index()
        {
            var buildings = _buildingRepository.GetBuildings();

            return View(buildings);
        }

        public IActionResult Edit(int id)
        {
            var building = new Building();

            if (id > 0)
            {
                building = _buildingRepository.GetBuilding(id);
            }

            return View(building);
        }

        public IActionResult Save(Building building)
        {
            if (building.BuildingId > 0)
            {
                _buildingRepository.UpdateBuilding(building);
            }
            else
            {
                _buildingRepository.AddBuilding(building);
            }


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _buildingRepository.DeleteBuilding(id);

            return RedirectToAction("Index");
        }
    }
}
