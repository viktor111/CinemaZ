using CinemaZ.Models.Types;

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
