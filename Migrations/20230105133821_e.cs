using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect2.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpirationID",
                table: "Beauty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Expiration",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationProductName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expiration", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beauty_ExpirationID",
                table: "Beauty",
                column: "ExpirationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beauty_Expiration_ExpirationID",
                table: "Beauty",
                column: "ExpirationID",
                principalTable: "Expiration",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beauty_Expiration_ExpirationID",
                table: "Beauty");

            migrationBuilder.DropTable(
                name: "Expiration");

            migrationBuilder.DropIndex(
                name: "IX_Beauty_ExpirationID",
                table: "Beauty");

            migrationBuilder.DropColumn(
                name: "ExpirationID",
                table: "Beauty");
        }
    }
}
