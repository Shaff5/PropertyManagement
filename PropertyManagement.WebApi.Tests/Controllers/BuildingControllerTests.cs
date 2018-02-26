namespace PropertyManagement.WebApi.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Results;
    //using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositories.Abstract;
    using WebApi.Controllers;
    using WebApi.Models;

    [TestClass]
    public class BuildingControllerTests
    {
        private List<Building> _buildings;

        /// <summary>
        /// Setup the building repository.
        /// </summary>
        /// <returns></returns>
        private IBuildingRepository SetupBuildingRepository()
        {
            _buildings = new List<Building>
            {
                new Building { BuildingId = 1, BuildingName = "Building 1" },
                new Building { BuildingId = 2, BuildingName = "Building 2" },
                new Building { BuildingId = 3, BuildingName = "Building 3" }
            };

            var mock = new Mock<IBuildingRepository>();
            mock.Setup(m => m.GetAllBuildings()).Returns(_buildings.AsQueryable());
            mock.Setup(m => m.GetBuildingById(It.IsAny<int>()))
                .Returns((int i) => _buildings.SingleOrDefault(b => b.BuildingId == i));
            mock.Setup(m => m.AddBuilding(It.IsAny<Building>()))
                .Callback((Building building) => _buildings.Add(building));
            mock.Setup(m => m.UpdateBuilding(It.IsAny<Building>()))
                .Callback((Building building) =>
                {
                    var b = _buildings.Find(x => x.BuildingId == building.BuildingId);
                    b.BuildingName = building.BuildingName;
                });
            mock.Setup(m => m.DeleteBuilding(It.IsAny<int>()))
                .Callback((int i) => _buildings.RemoveAll(b => b.BuildingId == i));

            return mock.Object;
        }

        /// <summary>
        /// Test the GetBuildings method.
        /// </summary>
        [TestMethod]
        public void GetBuildings_BuildingsExist_ReturnsAllBuildings()
        {
            var mockRepository = SetupBuildingRepository();

            var buildingController = new BuildingController(mockRepository);
            var buildings = buildingController.GetBuildings();

            Assert.AreEqual(3, buildings.Count());
        }

        /// <summary>
        /// Test the GetBuilding method.
        /// </summary>
        [TestMethod]
        public void GetBuilding_BuildingExists_ReturnOkWithBuilding()
        {
            var mockRepository = SetupBuildingRepository();

            var buildingController = new BuildingController(mockRepository);
            var building = buildingController.GetBuilding(2);
            
            Assert.IsInstanceOfType(building, typeof(OkNegotiatedContentResult<Building>));
        }

        /// <summary>
        /// Test the GetBuilding method for non-existent building.
        /// </summary>
        [TestMethod]
        public void GetBuilding_BuildingNotExists_ReturnsNotFound()
        {
            var mockRepository = SetupBuildingRepository();

            var buildingController = new BuildingController(mockRepository);
            var building = buildingController.GetBuilding(100);

            Assert.IsInstanceOfType(building, typeof(NotFoundResult));
        }

        /// <summary>
        /// Test the CreateBuilding method.
        /// </summary>
        [TestMethod]
        public void CreateBuilding_BuildingNotExists_ReturnsCreated()
        {
            const int id = 4;
            var mockRepository = SetupBuildingRepository();
            var initialCount = _buildings.Count;

            var buildingController = new BuildingController(mockRepository);
            var building = new Building { BuildingId = id };
            var result = buildingController.CreateBuilding(building);

            Assert.AreEqual(initialCount + 1, _buildings.Count);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<Building>));
        }

        /// <summary>
        /// Test the CreateBuilding method for already existing building.
        /// </summary>
        [TestMethod]
        public void CreateBuilding_BuildingExists_ReturnsConflict()
        {
            var mockRepository = SetupBuildingRepository();

            var buildingController = new BuildingController(mockRepository);
            var building = new Building { BuildingId = 1 };
            var result = buildingController.CreateBuilding(building);

            Assert.IsInstanceOfType(result, typeof(ConflictResult));
        }

        /// <summary>
        /// Test the UpdateBuilding method.
        /// </summary>
        [TestMethod]
        public void UpdateBuilding_BuildingExists_ReturnsOk()
        {
            const int id = 1;
            const string updatedName = "Updated Name";
            var mockRepository = SetupBuildingRepository();

            var buildingController = new BuildingController(mockRepository);
            var building = new Building { BuildingId = id, BuildingName = updatedName };
            var result = buildingController.UpdateBuilding(id, building);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            var updatedBuilding = _buildings.Find(b => b.BuildingId == id);
            Assert.AreEqual(updatedName, updatedBuilding.BuildingName);
        }

        /// <summary>
        /// Test the UpdateBuilding method for a non-existent building.
        /// </summary>
        [TestMethod]
        public void UpdateBuilding_BuildingNotExists_ReturnsNotFound()
        {
            const int id = 100;
            const string updatedName = "Updated Name";
            var mockRepository = SetupBuildingRepository();

            var buildingController = new BuildingController(mockRepository);
            var building = new Building { BuildingId = id, BuildingName = updatedName };
            var result = buildingController.UpdateBuilding(id, building);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        /// <summary>
        /// Test the UpdateBuilding method for a BuildingId mismatch.
        /// </summary>
        [TestMethod]
        public void UpdateBuilding_BuildingIdMismatch_ReturnsBadRequest()
        {
            const int id1 = 1;
            const int id2 = 2;
            const string updatedName = "Updated Name";
            var mockRepository = SetupBuildingRepository();

            var buildingController = new BuildingController(mockRepository);
            var building = new Building { BuildingId = id1, BuildingName = updatedName };
            var result = buildingController.UpdateBuilding(id2, building);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        /// <summary>
        /// Test the DeleteBuilding method.
        /// </summary>
        [TestMethod]
        public void DeleteBuilding_BuildingExists_ReturnsOk()
        {
            const int id = 2;
            var mockRepository = SetupBuildingRepository();
            var initialCount = _buildings.Count;

            var buildingController = new BuildingController(mockRepository);
            var result = buildingController.DeleteBuilding(id);

            Assert.AreEqual(initialCount -1, _buildings.Count);
            Assert.AreEqual(_buildings.FindIndex(b => b.BuildingId == id), -1);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        /// <summary>
        /// Test the DeleteBuilding method for non-existent building.
        /// </summary>
        [TestMethod]
        public void DeleteBuilding_BuildingNotExists_ReturnsOk()
        {
            const int id = 100;
            var mockRepository = SetupBuildingRepository();
            var initialCount = _buildings.Count;

            var buildingController = new BuildingController(mockRepository);
            var result = buildingController.DeleteBuilding(id);

            Assert.AreEqual(initialCount, _buildings.Count);
            Assert.AreEqual(_buildings.FindIndex(b => b.BuildingId == id), -1);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
