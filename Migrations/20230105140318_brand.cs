using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect2.Migrations
{
    public partial class brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Beauty");

            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Beauty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beauty_BrandID",
                table: "Beauty",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beauty_Brand_BrandID",
                table: "Beauty",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beauty_Brand_BrandID",
                table: "Beauty");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Beauty_BrandID",
                table: "Beauty");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Beauty");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Beauty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
