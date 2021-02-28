using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaZ.Models;

namespace CinemaZ.Service
{
    public interface ISqlMovieRoomService
    {
        MovieRoom AddMovieToRoom(MovieRoom movieRoom);
    }
}
