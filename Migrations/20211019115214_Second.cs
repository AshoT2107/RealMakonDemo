using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProtuctDb",
                table: "ProtuctDb");

            migrationBuilder.RenameTable(
                name: "ProtuctDb",
                newName: "Protucts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Protucts",
                table: "Protucts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Protucts",
                table: "Protucts");

            migrationBuilder.RenameTable(
                name: "Protucts",
                newName: "ProtuctDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProtuctDb",
                table: "ProtuctDb",
                column: "Id");
        }
    }
}
