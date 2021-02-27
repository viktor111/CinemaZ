using CinemaZ.Data;
using CinemaZ.Models;
using CinemaZ.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaZ.Service
{
    public class SqlSeatService : ISqlSeatService
    {
        private readonly ApplicationDbContext _dbContext;

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

        public List<Seat> GenerateSeats(Room room)
        {
            List<Seat> newSeats = new();

            string[] rows = Enum.GetNames(typeof(RowType));
            string[] cols = Enum.GetNames(typeof(ColumnType));

            for (int i = 0; i < rows.Length; i++)
            {
                string row = rows[i];
                Seat seat = new();

                seat.Room = room;
                seat.RowId = (RowType)Enum.Parse(typeof(RowType), row);
                
                for (int j = 0; j < cols.Length; j++)
                {
                    string col = cols[j];

                    seat.ColumnId = (ColumnType)Enum.Parse(typeof(ColumnType), col);

                    newSeats.Add(seat);

                    _dbContext.Seat.Add(seat);

                    seat = new();

                    seat.RowId = (RowType)Enum.Parse(typeof(RowType), row);
                    seat.Room = room;
                }
            }

            return newSeats;
        }

        public Seat GetSeat(int id)
        {
            return _dbContext.Seat.FirstOrDefault(s => s.Id == id);
        }

        public List<Seat> ListSeats()
        {
            return _dbContext.Seat.OrderBy(s => s.RowId).ToList();
        }
    }
}
