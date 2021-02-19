using CinemaZ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public class SqlMovieRoomService : ISqlMovieRoomService
    {
        private ApplicationDbContext _dbContext;

        public SqlMovieRoomService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
