using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Repositories.Abstract;

namespace PropertyManagement.Ui.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitRepository _unitRepository;

        public DashboardController(IBuildingRepository buildingRepository,
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
            var json = new[]
            {
                GetBuildingsByStateChart(),
                GetUnitSquareFootage()
            };

            return View(json);
        }

        private object GetBuildingsByStateChart()
        {
            var chartData = _buildingRepository.GetBuildings()
                .GroupBy(b => b.State)
                .Select(group => new
                {
                    label = group.Key,
                    value = group.Count()
                }).ToArray();

            var dataSource = new
            {
                chart = new
                {
                    caption = "Buildings by State",
                    subCaption = "this is the subcaption",
                    xAxisName = "State",
                    yAxisName = "Number of Buildings",
                    //numberSuffix = "K",
                    theme = "ocean"
                },

                data = chartData
            };

            var chartJson = new
            {
                type = "column2D",
                //width = "100%",
                //height = "100%",
                dataFormat = "json",
                dataSource = dataSource
            };

            return chartJson;
        }

        private object GetUnitSquareFootage()
        {
            var chartData = _unitRepository.GetUnits()
                .Select(u => new
                {
                    label = u.UnitName,
                    value = u.SquareFootage
                }).ToArray();

            var dataSource = new
            {
                chart = new
                {
                    caption = "Unit Square Footage",
                    subCaption = "this is the subcaption",
                    //xAxisName = "Unit Name",
                    yAxisName = "Square Footage",
                    //numberSuffix = "K",
                    theme = "ocean"
                },

                data = chartData
            };

            var chartJson = new
            {
                type = "bar2D",
                //width = "100%",
                //height = "100%",
                dataFormat = "json",
                dataSource = dataSource
            };

            return chartJson;
        }
    }
}
