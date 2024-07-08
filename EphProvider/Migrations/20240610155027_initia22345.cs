using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EphProvider.Migrations
{
    /// <inheritdoc />
    public partial class initia22345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NavMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SvId = table.Column<int>(type: "int", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false),
                    Tow = table.Column<int>(type: "int", nullable: false),
                    NavigationMessage = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NavMessage_SvId_Week_Tow",
                table: "NavMessage",
                columns: new[] { "SvId", "Week", "Tow" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavMessage");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
