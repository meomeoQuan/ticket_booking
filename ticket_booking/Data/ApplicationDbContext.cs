using Microsoft.EntityFrameworkCore;
using ticket_booking.Models;

namespace ticket_booking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "User 1" },
                new User { UserId = 2, Name = "User 2" }
            );
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
                new ShowTime { ShowTimeId = 1, ShowTimeStart = "10:30", MovieId = 1, RoomId = 1 },
                new ShowTime { ShowTimeId = 2, ShowTimeStart = "13:00", MovieId = 2, RoomId = 1 },
                new ShowTime { ShowTimeId = 3, ShowTimeStart = "16:30", MovieId = 2, RoomId = 2 }
            );

            // Seed data for Seats with a 2x2 matrix for each room
            modelBuilder.Entity<Seat>().HasData(
                // Room 1, day 1
                new Seat { SeatId = 1, SeatNumber = "A1", SeatStatus = "Available", RoomId = 1 },
                new Seat { SeatId = 2, SeatNumber = "A2", SeatStatus = "Available", RoomId = 1 },
                new Seat { SeatId = 3, SeatNumber = "A3", SeatStatus = "Available", RoomId = 1 },
                new Seat { SeatId = 4, SeatNumber = "A4", SeatStatus = "Available", RoomId = 1 },

                // Room 2, day 1
                new Seat { SeatId = 5, SeatNumber = "B1", SeatStatus = "Available", RoomId = 2 },
                new Seat { SeatId = 6, SeatNumber = "B2", SeatStatus = "Available", RoomId = 2 },
                new Seat { SeatId = 7, SeatNumber = "B3", SeatStatus = "Available", RoomId = 2 },
                new Seat { SeatId = 8, SeatNumber = "B4", SeatStatus = "Available", RoomId = 2 }
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