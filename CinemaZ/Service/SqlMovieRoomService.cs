using System.Linq;
using CinemaZ.Data;
using CinemaZ.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaZ.Service
{
    public class SqlMovieRoomService : ISqlMovieRoomService
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlMovieRoomService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MovieRoom AddMovieToRoom(MovieRoom movieRoom)
        {
            Room roomDb = _dbContext.Room.Where(r => r.Id == movieRoom.RoomId).Include(r => r.MovieRoom).FirstOrDefault();
            if (roomDb is not null)
            {
                MovieRoom movieRoomDb = roomDb.MovieRoom.FirstOrDefault(mr => mr.RoomId == movieRoom.RoomId);
            
                roomDb.MovieRoom.Add(new MovieRoom
                {
                    MovieId = movieRoom.MovieId
                });

                if (movieRoomDb is not null) movieRoomDb.AirTime = movieRoom.AirTime;
            }

            _dbContext.SaveChanges();
            
            return new MovieRoom();
        }
    }
}
