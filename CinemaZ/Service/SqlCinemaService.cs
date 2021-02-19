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
            _dbContext.Cinema.Add(cinema);

            _dbContext.SaveChanges();

            return new Cinema();
        }

        public Cinema DeleteCinema(Cinema cinema)
        {
            _dbContext.Cinema.Remove(cinema);

            _dbContext.SaveChanges();

            return new Cinema();
        }

        public Cinema EdditCinema(Cinema cinema)
        {
            Cinema cinemaToUpdate = _dbContext.Cinema.Where(c => c.Id == cinema.Id).FirstOrDefault();
            cinemaToUpdate.Name = cinema.Name;
            cinemaToUpdate.City = cinema.City;
            cinemaToUpdate.Adress = cinema.Adress;

            _dbContext.SaveChanges();

            return new Cinema();
        }

        public Cinema GetCinema(int id)
        {
            return _dbContext.Cinema.Where(c => c.Id == id).FirstOrDefault();
        }

        public List<Cinema> ListCinemas()
        {
            return _dbContext.Cinema.OrderBy(c => c.City).ToList();
        }
    }
}
