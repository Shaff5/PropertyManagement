﻿using System;
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
                CreatedOn = id > 0 ? building.CreatedOn : (DateTime?)null,
                CreatedBy = building.CreatedByName,
                LastUpdatedOn = id > 0 ? building.LastUpdatedOn : (DateTime?)null,
                LastUpdatedBy = building.LastUpdatedByName,
                BuildingName = building.BuildingName,
                AddressLine1 = building.AddressLine1,
                AddressLine2 = building.AddressLine2,
                AddressLine3 = building.AddressLine3,
                City = building.City,
                State = building.State,
                ZipCode = building.ZipCode,
                PurchaseDate = id > 0 ? building.PurchaseDate : (DateTime?)null,
                PurchasePrice = building.PurchasePrice,
                SellDate = id > 0 ? building.SellDate : null,
                SellPrice = building.SellPrice,
                NumberOfUnits = building.NumberOfUnits
            });
        }

        public IActionResult Save(BuildingBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", new BuildingViewModel
                {
                    BuildingId = model.BuildingId,
                    CreatedOn = model.CreatedOn,
                    CreatedBy = model.CreatedBy,
                    LastUpdatedOn = model.LastUpdatedOn,
                    LastUpdatedBy = model.LastUpdatedBy,
                    BuildingName = model.BuildingName,
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    AddressLine3 = model.AddressLine3,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PurchaseDate = model.PurchaseDate,
                    PurchasePrice = model.PurchasePrice,
                    SellDate = model.SellDate,
                    SellPrice = model.SellPrice,
                    NumberOfUnits = model.NumberOfUnits
                });
            }

            var building = new Building();

            if (model.BuildingId > 0)
            {
                building = _buildingRepository.GetBuilding(model.BuildingId);
            }
      
            building.BuildingName = model.BuildingName;
            building.AddressLine1 = model.AddressLine1;
            building.AddressLine2 = model.AddressLine2;
            building.AddressLine3 = model.AddressLine3;
            building.City = model.City;
            building.State = model.State;
            building.ZipCode = model.ZipCode;
            building.PurchaseDate = model.PurchaseDate;
            building.PurchasePrice = model.PurchasePrice;
            building.NumberOfUnits = model.NumberOfUnits;

            if (model.BuildingId > 0)
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
            _buildingRepository.SoftDeleteBuilding(id);

            return RedirectToAction("Index");
        }
    }
}
