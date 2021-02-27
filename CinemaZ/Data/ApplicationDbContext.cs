using CinemaZ.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// ReSharper disable HeapView.BoxingAllocation

namespace CinemaZ.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relations -------------------------------------------------
            // One to one premiere and movie
            modelBuilder.Entity<Movie>().HasKey(e => e.PremiereId);

            modelBuilder.Entity<Premiere>()
                .HasOne(e => e.Movie)
                .WithOne(e => e.Premiere);

            // One to many cinema and rooms
            modelBuilder.Entity<Cinema>()
                .HasMany(e => e.Rooms)
                .WithOne(e => e.Cinema)
                .HasForeignKey(e => e.CinemaId);

            // One to many room and seats
            modelBuilder.Entity<Room>()
                .HasMany(e => e.Seats)
                .WithOne(e => e.Room)
                .HasForeignKey(e => e.RoomId);

            // Many to many Movie room
            modelBuilder.Entity<MovieRoom>().HasKey(e => new {e.MovieId, e.RoomId });

            modelBuilder.Entity<MovieRoom>()
                .HasOne(e => e.Movie)
                .WithMany(e => e.MovieRoom)
                .HasForeignKey(e => e.MovieId);

            modelBuilder.Entity<MovieRoom>()
                .HasOne(e => e.Room)
                .WithMany(e => e.MovieRoom)
                .HasForeignKey(e => e.RoomId);
        }

        public DbSet<Cinema> Cinema {get; set; }
        public DbSet<Movie> Movie {get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<MovieRoom> MovieRoom { get; set; }
        public DbSet<Premiere> Premiere { get; set; }
    }
}
