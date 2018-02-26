namespace PropertyManagement.WebApi.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Results;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositories.Abstract;
    using WebApi.Controllers;

    [TestClass]
    public class UnitControllerTests
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
                new Unit { UnitId = 1, UnitName = "Unit 1" },
                new Unit { UnitId = 2, UnitName = "Unit 2" },
                new Unit { UnitId = 3, UnitName = "Unit 3" }
            };

            var mock = new Mock<IUnitRepository>();
            mock.Setup(m => m.GetAllUnits()).Returns(_units.AsQueryable());
            mock.Setup(m => m.GetUnitById(It.IsAny<int>()))
                .Returns((int i) => _units.SingleOrDefault(u => u.UnitId == i));
            mock.Setup(m => m.AddUnit(It.IsAny<Unit>()))
                .Callback((Unit unit) => _units.Add(unit));
            mock.Setup(m => m.UpdateUnit(It.IsAny<Unit>()))
                .Callback((Unit unit) =>
                {
                    var u = _units.Find(x => x.UnitId == unit.UnitId);
                    u.UnitName = unit.UnitName;
                });
            mock.Setup(m => m.DeleteUnit(It.IsAny<int>()))
                .Callback((int i) => _units.RemoveAll(u => u.UnitId == i));

            return mock.Object;
        }

        /// <summary>
        /// Test the GetUnits method.
        /// </summary>
        [TestMethod]
        public void GetUnits_UnitsExist_ReturnsAllUnits()
        {
            var mockRepository = SetupUnitRepository();

            var unitController = new UnitController(mockRepository);
            var units = unitController.GetUnits();

            Assert.AreEqual(3, units.Count());
        }

        /// <summary>
        /// Test the GetUnit method.
        /// </summary>
        [TestMethod]
        public void GetUnit_UnitExists_ReturnOkWithUnit()
        {
            var mockRepository = SetupUnitRepository();

            var unitController = new UnitController(mockRepository);
            var unit = unitController.GetUnit(2);

            Assert.IsInstanceOfType(unit, typeof(OkNegotiatedContentResult<Unit>));
        }

        /// <summary>
        /// Test the GetUnit method for non-existent unit.
        /// </summary>
        [TestMethod]
        public void GetUnit_UnitNotExists_ReturnsNotFound()
        {
            var mockRepository = SetupUnitRepository();

            var unitController = new UnitController(mockRepository);
            var unit = unitController.GetUnit(100);

            Assert.IsInstanceOfType(unit, typeof(NotFoundResult));
        }

        /// <summary>
        /// Test the CreateUnit method.
        /// </summary>
        [TestMethod]
        public void CreateUnit_UnitNotExists_ReturnsCreated()
        {
            const int id = 4;
            var mockRepository = SetupUnitRepository();
            var initialCount = _units.Count;

            var unitController = new UnitController(mockRepository);
            var unit = new Unit { UnitId = id };
            var result = unitController.CreateUnit(unit);

            Assert.AreEqual(initialCount + 1, _units.Count);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<Unit>));
        }

        /// <summary>
        /// Test the CreateUnit method for already existing unit.
        /// </summary>
        [TestMethod]
        public void CreateUnit_UnitExists_ReturnsConflict()
        {
            var mockRepository = SetupUnitRepository();

            var unitController = new UnitController(mockRepository);
            var unit = new Unit { UnitId = 1 };
            var result = unitController.CreateUnit(unit);

            Assert.IsInstanceOfType(result, typeof(ConflictResult));
        }

        /// <summary>
        /// Test the UpdateUnit method.
        /// </summary>
        [TestMethod]
        public void UpdateUnit_UnitExists_ReturnsOk()
        {
            const int id = 1;
            const string updatedName = "Updated Name";
            var mockRepository = SetupUnitRepository();

            var unitController = new UnitController(mockRepository);
            var unit = new Unit { UnitId = id, UnitName = updatedName };
            var result = unitController.UpdateUnit(id, unit);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            var updatedUnit = _units.Find(u => u.UnitId == id);
            Assert.AreEqual(updatedName, updatedUnit.UnitName);
        }

        /// <summary>
        /// Test the UpdateUnit method for a non-existent unit.
        /// </summary>
        [TestMethod]
        public void UpdateUnit_UnitNotExists_ReturnsNotFound()
        {
            const int id = 100;
            const string updatedName = "Updated Name";
            var mockRepository = SetupUnitRepository();

            var unitController = new UnitController(mockRepository);
            var unit = new Unit { UnitId = id, UnitName = updatedName };
            var result = unitController.UpdateUnit(id, unit);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        /// <summary>
        /// Test the UpdateUnit method for a UnitId mismatch.
        /// </summary>
        [TestMethod]
        public void UpdateUnit_UnitIdMismatch_ReturnsBadRequest()
        {
            const int id1 = 1;
            const int id2 = 2;
            const string updatedName = "Updated Name";
            var mockRepository = SetupUnitRepository();

            var unitController = new UnitController(mockRepository);
            var unit = new Unit { UnitId = id1, UnitName = updatedName };
            var result = unitController.UpdateUnit(id2, unit);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        /// <summary>
        /// Test the DeleteUnit method.
        /// </summary>
        [TestMethod]
        public void DeleteUnit_UnitExists_ReturnsOk()
        {
            const int id = 2;
            var mockRepository = SetupUnitRepository();
            var initialCount = _units.Count;

            var unitController = new UnitController(mockRepository);
            var result = unitController.DeleteUnit(id);

            Assert.AreEqual(initialCount - 1, _units.Count);
            Assert.AreEqual(_units.FindIndex(u => u.UnitId == id), -1);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        /// <summary>
        /// Test the DeleteUnit method for non-existent unit.
        /// </summary>
        [TestMethod]
        public void DeleteUnit_UnitNotExists_ReturnsOk()
        {
            const int id = 100;
            var mockRepository = SetupUnitRepository();
            var initialCount = _units.Count;

            var unitController = new UnitController(mockRepository);
            var result = unitController.DeleteUnit(id);

            Assert.AreEqual(initialCount, _units.Count);
            Assert.AreEqual(_units.FindIndex(u => u.UnitId == id), -1);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
