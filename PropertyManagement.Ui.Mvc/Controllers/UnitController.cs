using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Domain;
using PropertyManagement.Repositories.Abstract;
using PropertyManagement.Ui.Mvc.Models.Unit;

namespace PropertyManagement.Ui.Mvc.Controllers
{
    public class UnitController : Controller
    {
        private IUnitRepository _unitRepository;

        public UnitController(IUnitRepository unitRepository)
        {
            if (unitRepository == null)
            {
                throw new ArgumentNullException("unitRepository");
            }

            _unitRepository = unitRepository;
        }

        public IActionResult Index()
        {
            var units = _unitRepository.GetUnits();

            return View(units);
        }

        public IActionResult Edit(int id)
        {
            var unit = new Unit();

            if (id > 0)
            {
                unit = _unitRepository.GetUnit(id);
                if (unit == null)
                {
                    return NotFound();
                }
            }

            return View(new UnitViewModel
            {
                UnitId = unit.UnitId,
                CreatedOn = id > 0 ? unit.CreatedOn : (DateTime?)null,
                CreatedBy = id > 0 ? unit.CreatedByName : string.Empty,
                LastUpdatedOn = id > 0 ? unit.LastUpdatedOn : (DateTime?)null,
                LastUpdatedBy = unit.LastUpdatedByName,
                UnitName = unit.UnitName,
                BuildingName = unit.BuildingName,
                SquareFootage = unit.SquareFootage,
                NumberOfBedrooms = unit.NumberOfBedrooms,
                NumberOfBathrooms = unit.NumberOfBathrooms
            });
        }

        public IActionResult Save(UnitBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                DateTime? createdOn = (DateTime?)null;
                var createdBy = string.Empty;
                DateTime? lastUpdatedOn = (DateTime?)null;
                var lastUpdatedBy = string.Empty;
                var buildingName = string.Empty;

                if (model.UnitId > 0)
                {
                    var u = _unitRepository.GetUnit(model.UnitId);
                    createdOn = u.CreatedOn;
                    createdBy = u.CreatedByName;
                    lastUpdatedOn = u.LastUpdatedOn;
                    lastUpdatedBy = u.LastUpdatedByName;
                    buildingName = u.BuildingName;
                }

                return View("Edit", new UnitViewModel
                {
                    UnitId = model.UnitId,
                    CreatedOn = createdOn,
                    CreatedBy = createdBy,
                    LastUpdatedOn = lastUpdatedOn,
                    LastUpdatedBy = lastUpdatedBy,
                    UnitName = model.UnitName,
                    BuildingName = buildingName,
                    SquareFootage = model.SquareFootage,
                    NumberOfBedrooms = model.NumberOfBedrooms,
                    NumberOfBathrooms = model.NumberOfBathrooms
                });
            }

            var unit = new Unit();

            if (model.UnitId > 0)
            {
                unit = _unitRepository.GetUnit(model.UnitId);
            }

            unit.UnitName = model.UnitName;
            unit.SquareFootage = model.SquareFootage;
            unit.NumberOfBedrooms = model.NumberOfBedrooms;
            unit.NumberOfBathrooms = model.NumberOfBathrooms;
            
            if (model.UnitId > 0)
            {
                _unitRepository.UpdateUnit(unit);
            }
            else
            {
                _unitRepository.AddUnit(unit);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _unitRepository.SoftDeleteUnit(id);

            return RedirectToAction("Index");
        }

        public IActionResult Search()
        {
            return View("Search", new UnitSearchViewModel());
        }

        public IActionResult SearchResults(UnitSearchViewModel model)
        {
            var filters = new List<Tuple<string, object>>();

            foreach (var property in model.GetType().GetProperties())
            {
                var value = property.GetValue(model);
                if (value == null)
                {
                    continue;
                }

                if (property.PropertyType == typeof(decimal?))
                {
                    if (property.Name.EndsWith("Low"))
                    {
                        filters.Add(new Tuple<string, object>($"{property.Name.Substring(0, property.Name.Length - 3)} > {{0}}", $"{(decimal)value}"));
                    }
                    else
                    {
                        filters.Add(new Tuple<string, object>($"{property.Name.Substring(0, property.Name.Length - 4)} < {{0}}", $"{(decimal)value}"));
                    }
                }

                if (property.PropertyType == typeof(DateTime?))
                {
                    if (property.Name.EndsWith("Start"))
                    {
                        filters.Add(new Tuple<string, object>($"{property.Name.Substring(0, property.Name.Length - 5)} > {{0}}", $"{(DateTime)value}"));
                    }
                    else
                    {
                        filters.Add(new Tuple<string, object>($"{property.Name.Substring(0, property.Name.Length - 3)} < {{0}}", $"{(DateTime)value}"));
                    }
                }

                if (property.PropertyType == typeof(string) && !string.IsNullOrEmpty(value.ToString().Trim()))
                {
                    filters.Add(new Tuple<string, object>($"{property.Name} LIKE {{0}}", $"%{value.ToString()}%"));
                }
            }

            var units = _unitRepository.GetUnits(filters);

            return View("Index", units);
        }
    }
}
