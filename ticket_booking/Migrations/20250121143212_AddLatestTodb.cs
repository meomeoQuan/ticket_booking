using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ticket_booking.Migrations
{
    /// <inheritdoc />
    public partial class AddLatestTodb : Migration
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
                    Row = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Column = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatStatus = table.Column<int>(type: "int", nullable: false),
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
                columns: new[] { "SeatId", "Column", "RoomId", "Row", "SeatStatus" },
                values: new object[,]
                {
                    { 1, "1", 1, "A", 0 },
                    { 2, "2", 1, "A", 0 },
                    { 3, "1", 1, "B", 0 },
                    { 4, "2", 1, "B", 0 },
                    { 5, "1", 2, "A", 0 },
                    { 6, "2", 2, "A", 0 },
                    { 7, "1", 2, "B", 0 },
                    { 8, "2", 2, "B", 0 }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "ShowTimeId", "MovieId", "RoomId", "ShowTimeStart" },
                values: new object[,]
                {
                    { 1, 1, 1, "17:30" },
                    { 2, 2, 2, "23:00" }
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
