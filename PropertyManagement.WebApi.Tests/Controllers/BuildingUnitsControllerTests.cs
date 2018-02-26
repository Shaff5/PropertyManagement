namespace PropertyManagement.WebApi.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositories.Abstract;
    using WebApi.Controllers;

    [TestClass]
    public class BuildingUnitsControllerTests
    {
        private List<Unit> _units;

        /// <summary>
        /// Setup the unit repository.
        /// </summary>
        /// <returns></returns>
        private IUnitRepository SetupUnitRepository()
        {
            _units = new List<Unit>
            {
                new Unit { UnitId = 1, UnitName = "Unit 1", BuildingId = 1 },
                new Unit { UnitId = 2, UnitName = "Unit 2", BuildingId = 2 },
                new Unit { UnitId = 3, UnitName = "Unit 3", BuildingId = 1 }
            };

            var mock = new Mock<IUnitRepository>();
            mock.Setup(m => m.GetUnitsByBuildingId(It.IsAny<int>()))
                .Returns((int i) => _units.FindAll(u => u.BuildingId == i).AsQueryable());

            return mock.Object;
        }

        /// <summary>
        /// Test the GetBuildingUnits method.
        /// </summary>
        [TestMethod]
        public void GetBuildingUnits_UnitsExist_ReturnsUnits()
        {
            var mockRepository = SetupUnitRepository();

            var buildingUnitsController = new BuildingUnitsController(mockRepository);
            var units = buildingUnitsController.GetBuildingUnits(1);

            Assert.AreEqual(2, units.Count());
        }

        /// <summary>
        /// Test the GetBuildingUnits for non-existent units.
        /// </summary>
        [TestMethod]
        public void GetBuildingUnits_UnitsNotExist_ReturnsEmptyEnumerable()
        {
            var mockRepository = SetupUnitRepository();

            var buildingUnitsController = new BuildingUnitsController(mockRepository);
            var units = buildingUnitsController.GetBuildingUnits(100);

            Assert.AreEqual(0, units.Count());
        }
    }
}
