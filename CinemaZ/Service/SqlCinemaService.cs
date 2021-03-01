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
        private readonly ApplicationDbContext _dbContext;

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
            Cinema cinemaToUpdate = _dbContext.Cinema.FirstOrDefault(c => c.Id == cinema.Id);
            cinemaToUpdate.Name = cinema.Name;
            cinemaToUpdate.City = cinema.City;
            cinemaToUpdate.Adress = cinema.Adress;
            cinemaToUpdate.TimeClose = cinema.TimeClose;
            cinemaToUpdate.Rooms = cinema.Rooms;

            _dbContext.SaveChanges();

            return new Cinema();
        }

        public Cinema GetCinema(int id)
        {
            return _dbContext.Cinema.FirstOrDefault(c => c.Id == id);
        }

        public List<Cinema> ListCinemas()
        {
            return _dbContext.Cinema.OrderBy(c => c.City).ToList();
        }

        public List<Room> ListRooms(Cinema cinema)
        {
            int id = cinema.Id;

            return _dbContext.Room.Where(r => r.CinemaId == id).ToList();
        }
    }
}
