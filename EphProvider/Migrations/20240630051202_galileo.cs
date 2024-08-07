﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EphProvider.Migrations
{
    /// <inheritdoc />
    public partial class galileo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galileo",
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
                    table.PrimaryKey("PK_Galileo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galileo");
        }
    }
}
