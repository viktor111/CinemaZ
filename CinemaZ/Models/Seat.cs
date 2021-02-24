using CinemaZ.Models;
using CinemaZ.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public RowType RowId { get; set; }

        public ColumnType ColumnId { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }

        public bool Taken { get; set; } = false;
    }
}
