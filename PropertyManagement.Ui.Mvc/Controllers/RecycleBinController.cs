using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Domain;
using PropertyManagement.Repositories.Abstract;
using PropertyManagement.Ui.Mvc.Models.RecycleBin;

namespace PropertyManagement.Ui.Mvc.Controllers
{
    public class RecycleBinController : Controller
    {
        private readonly IBuildingRepository _buildingRepository;
        
        public RecycleBinController(IBuildingRepository buildingRepository)
        {
            if (buildingRepository == null)
            {
                throw new ArgumentNullException("buildingRepository");
            }
            
            _buildingRepository = buildingRepository;
        }

        public IActionResult Index()
        {
            var buildings = _buildingRepository.GetDeletedBuildings();

            var viewModel = buildings.Select(b => new RecycleBinViewModel
            {
                Id = b.BuildingId,
                EntityName = typeof(Building).Name,
                Description = b.BuildingName,
                DeletedBy = "not implemented",
                DeletedOn = b.LastUpdatedOn
            });

            return View(viewModel); 
        }

        public IActionResult Delete(int id)
        {
            _buildingRepository.HardDeleteBuilding(id);

            return RedirectToAction("Index", "Building");
        }

        public IActionResult Restore(int id)
        {
            var building = _buildingRepository.GetBuilding(id);
            building.IsDeleted = false;
            _buildingRepository.UpdateBuilding(building);

            return RedirectToAction("Index", "Building");
        }
    }
}
