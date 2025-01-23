using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ticket_booking.Migrations
{
    /// <inheritdoc />
    public partial class tt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCapacity = table.Column<int>(type: "int", nullable: false),
                    RoomStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SeatStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seat_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateTable(
                name: "ShowTimes",
                columns: table => new
                {
                    ShowTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowTimeStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTimes", x => x.ShowTimeId);
                    table.ForeignKey(
                        name: "FK_ShowTimes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowTimes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Discription", "Title" },
                values: new object[,]
                {
                    { 1, "Description of Movie 1", "Movie 1" },
                    { 2, "Description of Movie 2", "Movie 2" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "RoomCapacity", "RoomStatus" },
                values: new object[,]
                {
                    { 1, 4, 0 },
                    { 2, 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "SeatId", "RoomId", "SeatNumber", "SeatStatus" },
                values: new object[,]
                {
                    { 1, 1, "A1", "Available" },
                    { 2, 1, "A2", "Available" },
                    { 3, 1, "A3", "Available" },
                    { 4, 1, "A4", "Available" },
                    { 5, 2, "B1", "Available" },
                    { 6, 2, "B2", "Available" },
                    { 7, 2, "B3", "Available" },
                    { 8, 2, "B4", "Available" }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "ShowTimeId", "MovieId", "RoomId", "ShowTimeStart" },
                values: new object[,]
                {
                    { 1, 1, 1, "10:30" },
                    { 2, 2, 1, "13:00" },
                    { 3, 2, 2, "16:30" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_RoomId",
                table: "Seat",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_MovieId",
                table: "ShowTimes",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_RoomId",
                table: "ShowTimes",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "ShowTimes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
