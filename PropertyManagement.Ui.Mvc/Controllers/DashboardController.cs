using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PropertyManagement.Ui.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var chartJson = new
            {
                chart = new
                {
                    caption = "Countries With Most Oil Reserves [2017-18]",
                    subCaption = "In MMbbl = One Million barrels",
                    xAxisName = "Country",
                    yAxisName = "Reserves (MMbbl)",
                    numberSuffix = "K",
                    theme = "fusion"
                },
                data = new[]
                {
                    new {label = "Venezuela", value = "290"},
                    new {label = "Saudi", value = "260"},
                    new {label = "Canada", value = "180"},
                    new {label = "Iran", value = "140"},
                    new {label = "Russia", value = "115"},
                    new {label = "UAE", value = "100"},
                    new {label = "USA", value = "30"},
                    new {label = "China", value = "30"}
                }
            };

            //return Json(chartJson);
            return View(chartJson);
        }
    }
}
