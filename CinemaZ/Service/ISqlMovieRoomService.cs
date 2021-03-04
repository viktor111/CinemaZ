using CinemaZ.Models;

namespace CinemaZ.Service
{
    public interface ISqlMovieRoomService
    {
        MovieRoom AddMovieToRoom(MovieRoom movieRoom);
    }
}
