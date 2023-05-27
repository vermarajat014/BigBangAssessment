using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProj.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelId = table.Column<int>(name: "Hotel_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(name: "Hotel_Name", type: "nvarchar(max)", nullable: true),
                    HotelAddress = table.Column<string>(name: "Hotel_Address", type: "nvarchar(max)", nullable: true),
                    HotelContact = table.Column<string>(name: "Hotel_Contact", type: "nvarchar(max)", nullable: true),
                    HotelAmenities = table.Column<string>(name: "Hotel_Amenities", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(name: "Room_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Roomtype = table.Column<string>(name: "Room_type", type: "nvarchar(max)", nullable: true),
                    Availabilitystatus = table.Column<bool>(name: "Availability_status", type: "bit", nullable: false),
                    Roomprice = table.Column<int>(name: "Room_price", type: "int", nullable: false),
                    RoomNumber = table.Column<string>(name: "Room_Number", type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<int>(name: "Hotel_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotel_Hotel_Id",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Hotel_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Hotel_Id",
                table: "Rooms",
                column: "Hotel_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
