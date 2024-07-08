using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EphProvider.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PVT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatitudeLib = table.Column<float>(type: "real", nullable: false),
                    LongitudeLib = table.Column<float>(type: "real", nullable: false),
                    LatitudeRaw = table.Column<float>(type: "real", nullable: false),
                    LongitudeRaw = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVT", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PVT");
        }
    }
}
