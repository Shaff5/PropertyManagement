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
        private readonly IUnitRepository _unitRepository;
        
        public RecycleBinController(IBuildingRepository buildingRepository,
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

        public IActionResult Index()
        {
            var buildings = _buildingRepository.GetDeletedBuildings();
            var units = _unitRepository.GetDeletedUnits();

            var recycleBinItems = new List<RecycleBinViewModel>();
            
            recycleBinItems.AddRange(buildings.Select(b => new RecycleBinViewModel
            {
                Id = b.BuildingId,
                EntityName = typeof(Building).Name,
                Description = b.BuildingName,
                DeletedBy = b.LastUpdatedByName,
                DeletedOn = b.LastUpdatedOn
            }));
            recycleBinItems.AddRange(units.Select(u => new RecycleBinViewModel
            {
                Id = u.UnitId,
                EntityName = typeof(Unit).Name,
                Description = u.BuildingName,
                DeletedBy = u.LastUpdatedByName,
                DeletedOn = u.LastUpdatedOn
            }));

            return View(recycleBinItems); 
        }

        public IActionResult Delete(string entity, int id)
        {
            switch (entity.ToLower().Trim())
            {
                case "building":
                    _buildingRepository.HardDeleteBuilding(id);
                    break;
                case "unit":
                    _unitRepository.HardDeleteUnit(id);
                    break;
            }

            return RedirectToAction("Index", "RecycleBin");
        }

        public IActionResult Restore(string entity, int id)
        {
            switch (entity.ToLower().Trim())
            {
                case "building":
                    var building = _buildingRepository.GetBuilding(id);
                    building.IsDeleted = false;
                    _buildingRepository.UpdateBuilding(building);
                    break;
                case "unit":
                    var unit = _unitRepository.GetUnit(id);
                    unit.IsDeleted = false;
                    _unitRepository.UpdateUnit(unit);
                    break;
            }

            return RedirectToAction("Index", "RecycleBin");
        }
    }
}
