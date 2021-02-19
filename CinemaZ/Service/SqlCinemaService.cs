using CinemaZ.Data;
using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public class SqlCinemaService : ISqlCinemaService
    {
        private ApplicationDbContext _dbContext;

        public SqlCinemaService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cinema CreateCinema(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public Cinema DeleteCinema(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public Cinema EdditCinema(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public Cinema GetCinema(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cinema> ListCinemas()
        {
            throw new NotImplementedException();
        }
    }
}
