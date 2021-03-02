using System.Collections.Generic;
using CinemaZ.Controllers;
using CinemaZ.Models;
using CinemaZ.Models.Types;
using CinemaZ.Service;
using CinemaZ.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Controllers
{
    [TestClass]
    public class CinemaControllerTest : DbContextSqlLite
    {
        private readonly SqlCinemaService _sqlCinemaService;
        private readonly SqlRoomService _sqlRoomService;
        private readonly CinemaController _cinemaController;

        public CinemaControllerTest()
        {
            _sqlCinemaService = new SqlCinemaService(_dbContext);
            _sqlRoomService = new SqlRoomService(_dbContext);
            _cinemaController = new CinemaController(_sqlCinemaService, _sqlRoomService);
        }

        [TestMethod]
        public void CreateCinema_ShouldHaveModelCinemaCreateViewModel()
        {
            ViewResult result = _cinemaController.CreateCinema() as ViewResult;

            CinemaCreateViewModel model = result.Model as CinemaCreateViewModel;

            var str = result.ViewName;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateCinema_ShouldReturnView()
        {
            ViewResult result = _cinemaController.CreateCinema() as ViewResult;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CinemaDetail_ShouldGetData()
        {
            //Arrange
            Cinema cinema1 = new();

            cinema1.Adress = "wew";
            cinema1.City = CityType.California;
            cinema1.Name = "name";
            cinema1.Rooms = new List<Room>();
            cinema1.TimeClose = "weq";

            //Act
            _sqlCinemaService.CreateCinema(cinema1);

            //Assert
            ViewResult result = _cinemaController.CinemaDetail(cinema1.Id) as ViewResult;
            CinemaDetailsModel model = result.Model as CinemaDetailsModel;

            Assert.AreEqual(cinema1.Name,model.Name);
            Assert.AreEqual(cinema1.TimeClose, model.TimeClose);
        }

        [TestMethod]
        public void CinemaDetail_ShouldHaveModelCinemaDetailModel()
        {
            //Arrange
            Cinema cinema1 = new();

            cinema1.Adress = "wew";
            cinema1.City = CityType.California;
            cinema1.Name = "name";
            cinema1.Rooms = new List<Room>();
            cinema1.TimeClose = "weq";

            //Act
            _sqlCinemaService.CreateCinema(cinema1);

            //Assert
            ViewResult result = _cinemaController.CinemaDetail(cinema1.Id) as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(CinemaDetailsModel));
        }

        [TestMethod]
        public void CinemaDetail_ShouldReturnView()
        {
            //Arrange
            Cinema cinema1 = new();

            cinema1.Adress = "wew";
            cinema1.City = CityType.California;
            cinema1.Name = "name";
            cinema1.Rooms = new List<Room>();
            cinema1.TimeClose = "weq";

            //Act
            _sqlCinemaService.CreateCinema(cinema1);

            //Assert
            ViewResult result = _cinemaController.CinemaDetail(cinema1.Id) as ViewResult;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ListArticles_ShouldGetData()
        {
            //Arrange
            Cinema cinema1 = new();

            cinema1.Adress = "wew";
            cinema1.City = CityType.California;
            cinema1.Name = "name";
            cinema1.Rooms = new List<Room>();
            cinema1.TimeClose = "weq";

            Cinema cinema2 = new();

            cinema2.Adress = "wewqwe";
            cinema2.City = CityType.California;
            cinema2.Name = "nameqwe";
            cinema2.Rooms = new List<Room>();
            cinema2.TimeClose = "weeqwq";

            //Act
            _dbContext.Cinema.Add(cinema1);
            _dbContext.Cinema.Add(cinema2);

            _dbContext.SaveChanges();

            //Assert
            ViewResult result = _cinemaController.ListCinema() as ViewResult;

            var m = result.Model as CinemaListViewModel;

            Assert.AreEqual(2, m.Cinemas.Count);
        }

        [TestMethod]
        public void ListArticles_ShouldReturnView()
        {
            ViewResult result = _cinemaController.ListCinema() as ViewResult;
            
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ListArticles_ShouldHaveModelCinemaListViewModel()
        {
            ViewResult result = _cinemaController.ListCinema() as ViewResult;
            
            Assert.IsInstanceOfType(result.Model, typeof(CinemaListViewModel));
        }
    }
}