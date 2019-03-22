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

            return View(new BuildingViewModel
            {
                BuildingId = building.BuildingId,
                CreatedOn = building.CreatedOn,
                CreatedBy = building.CreatedBy,
                LastUpdatedOn = building.LastUpdatedOn,
                LastUpdatedBy = building.LastUpdatedBy,
                BuildingName = building.BuildingName,
                AddressLine1 = building.AddressLine1,
                AddressLine2 = building.AddressLine2,
                AddressLine3 = building.AddressLine3,
                City = building.City,
                State = building.State,
                ZipCode = building.ZipCode,
                PurchaseDate = building.PurchaseDate,
                PurchasePrice = building.PurchasePrice,
                SellDate = building.SellDate,
                SellPrice = building.SellPrice,
                NumberOfUnits = building.NumberOfUnits
            });
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
