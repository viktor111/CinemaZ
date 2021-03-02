using System.Collections.Generic;
using CinemaZ.Controllers;
using CinemaZ.Models;
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