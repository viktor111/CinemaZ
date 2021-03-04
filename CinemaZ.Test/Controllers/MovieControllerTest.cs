using CinemaZ.Controllers;
using CinemaZ.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Controllers
{
    [TestClass]
    public class MovieControllerTest : DbContextSqlLite
    {
        private readonly ISqlMovieService _sqlMovieService;
        private readonly ISqlPremiereService _sqlPremiereService;
        private readonly ISqlRoomService _sqlRoomService;
        private readonly ISqlMovieRoomService _sqlMovieRoomService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private MovieController _movieController;

        public MovieControllerTest()
        {
            _sqlMovieService = new SqlMovieService(_dbContext);
            _sqlPremiereService = new SqlPremiereService(_dbContext);
            _sqlRoomService = new SqlRoomService(_dbContext);
            _sqlMovieRoomService = new SqlMovieRoomService(_dbContext);

            _movieController = new MovieController
            (
                _sqlMovieService,
                _sqlPremiereService,
                _sqlRoomService,
                _sqlMovieRoomService,
                _webHostEnvironment
            );
        }

        [TestMethod]
        public void CreateMovie_ShouldReturnView()
        {
            ViewResult result = _movieController.Index() as ViewResult;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
