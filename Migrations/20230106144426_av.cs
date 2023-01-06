using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect2.Migrations
{
    public partial class av : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tester",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tester", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Testing",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TesterID = table.Column<int>(type: "int", nullable: true),
                    BeautyID = table.Column<int>(type: "int", nullable: true),
                    TestingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testing", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Testing_Beauty_BeautyID",
                        column: x => x.BeautyID,
                        principalTable: "Beauty",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Testing_Tester_TesterID",
                        column: x => x.TesterID,
                        principalTable: "Tester",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Testing_BeautyID",
                table: "Testing",
                column: "BeautyID");

            migrationBuilder.CreateIndex(
                name: "IX_Testing_TesterID",
                table: "Testing",
                column: "TesterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testing");

            migrationBuilder.DropTable(
                name: "Tester");
        }
    }
}
