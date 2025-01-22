using Microsoft.EntityFrameworkCore;
using ticket_booking.Models;

namespace ticket_booking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Movies (necessary for ShowTimes to work properly)
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "Movie 1", Discription = "Description of Movie 1" },
                new Movie { MovieId = 2, Title = "Movie 2", Discription = "Description of Movie 2" }
            );

            // Seed data for Rooms
            modelBuilder.Entity<Room>().HasData(
                new Room { RoomId = 1, RoomCapacity = 4, RoomStatus = 0 },
                new Room { RoomId = 2, RoomCapacity = 4, RoomStatus = 0 }
            );

            // Seed data for ShowTimes
            modelBuilder.Entity<ShowTime>().HasData(
                new ShowTime { ShowTimeId = 1, ShowTimeStart = "17:30", MovieId = 1, RoomId = 1 },
                new ShowTime { ShowTimeId = 2, ShowTimeStart = "23:00", MovieId = 2, RoomId = 2 }
            );

            // Seed data for Seats with a 2x2 matrix for each room
            modelBuilder.Entity<Seat>().HasData(
                // Room 1, ShowTime 1
                new Seat { SeatId = 1, Row = "A", Column = "1", SeatStatus = 0, RoomId = 1,  },
                new Seat { SeatId = 2, Row = "A", Column = "2", SeatStatus = 0, RoomId = 1, },
                new Seat { SeatId = 3, Row = "B", Column = "1", SeatStatus = 0, RoomId = 1, },
                new Seat { SeatId = 4, Row = "B", Column = "2", SeatStatus = 0, RoomId = 1, },

                // Room 2, ShowTime 2
                new Seat { SeatId = 5, Row = "A", Column = "1", SeatStatus = 0, RoomId = 2,  },
                new Seat { SeatId = 6, Row = "A", Column = "2", SeatStatus = 0, RoomId = 2,  },
                new Seat { SeatId = 7, Row = "B", Column = "1", SeatStatus = 0, RoomId = 2,  },
                new Seat { SeatId = 8, Row = "B", Column = "2", SeatStatus = 0, RoomId = 2, }
            );

            // Configure foreign keys for Seat-ShowTime and Seat-Room relationships
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Room)
                .WithMany()  // Assuming one Room can have many Seats
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

        }

    }
}