using System.Linq;
using CinemaZ.Data;
using CinemaZ.Models;

namespace CinemaZ.Service
{
    public class SqlMovieRoomService : ISqlMovieRoomService
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlMovieRoomService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Movie AddMovieToRoom(Movie movie, Room room)
        {
            Room roomDb = _dbContext.Room.FirstOrDefault(r => r.Id == room.Id);
            MovieRoom movieRoom = _dbContext.MovieRoom.FirstOrDefault(mr => mr.RoomId == room.Id);
            
            roomDb.MovieRoom.Add(new MovieRoom
            {
                MovieId = movie.Id,
                AirTime = movie.ReleaseDate
            });
            
            return new Movie();
        }
    }
}
