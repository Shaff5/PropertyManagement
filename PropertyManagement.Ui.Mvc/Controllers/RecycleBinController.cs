using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Domain;
using PropertyManagement.Repositories.Abstract;
using PropertyManagement.Ui.Mvc.Models.Building;

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

            return View(buildings);
        }

        public IActionResult Delete(int id)
        {
            _buildingRepository.HardDeleteBuilding(id);

            return RedirectToAction("Index");
        }
    }
}
