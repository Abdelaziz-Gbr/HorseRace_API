using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorseRace_API.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class addedlookuptables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUpTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LookUpTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpValues_LookUpTypes_LookUpTypeId",
                        column: x => x.LookUpTypeId,
                        principalTable: "LookUpTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUpValues_LookUpTypeId",
                table: "LookUpValues",
                column: "LookUpTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUpValues");

            migrationBuilder.DropTable(
                name: "LookUpTypes");
        }
    }
}
