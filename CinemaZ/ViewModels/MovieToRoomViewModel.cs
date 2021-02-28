using System;
using System.Collections.Generic;
using CinemaZ.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaZ.ViewModels
{
    public class MovieToRoomViewModel
    {
        public SelectList  Movies { get; set; }

        public SelectList Rooms { get; set; }
        
        public string MovieName { get; set; }
        
        public string RoomName { get; set; }
        
        public DateTime AirTime { get; set; }
    }
}