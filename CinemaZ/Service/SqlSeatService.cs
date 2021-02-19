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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Seat> ListSeats()
        {
            throw new NotImplementedException();
        }
    }
}
