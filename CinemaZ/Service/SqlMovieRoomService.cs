using CinemaZ.Data;

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
