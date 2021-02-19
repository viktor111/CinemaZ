using CinemaZ.Data;
using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public class SqlSeatService : ISqlSeatService
    {
        private ApplicationDbContext _dbContext;

        public SqlSeatService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Seat CreateSeat(Seat seat)
        {
            _dbContext.Seat.Add(seat);

            _dbContext.SaveChanges();

            return new Seat();
        }

        public Seat DeleteSeat(Seat seat)
        {
            throw new NotImplementedException();
        }

        public Seat EdditSeat(Seat seat)
        {
            throw new NotImplementedException();
        }

        public Seat GetSeat(int id)
        {
            return _dbContext.Seat.Where(s => s.Id == id).FirstOrDefault();
        }

        public List<Seat> ListSeats()
        {
            return _dbContext.Seat.OrderBy(s => s.Row).ToList();
        }
    }
}
