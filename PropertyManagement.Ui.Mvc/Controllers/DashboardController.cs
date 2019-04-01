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

        public DashboardController(IBuildingRepository buildingRepository)
        {
            if (buildingRepository == null)
            {
                throw new ArgumentNullException("buildingRepository");
            }

            _buildingRepository = buildingRepository;
        }

        public IActionResult Index()
        {
            return View(GetBuildingsByStateChart());
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
                width = "100%",
                height = "100%",
                dataFormat = "json",
                dataSource = dataSource
            };

            return chartJson;
        }

        //private object GetUnitSquareFootage()
        //{

        //}
    }
}
