using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Products.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.CreateTable(
                    name: "ProtuctDb",
                    columns: table => new
                        {
                            Id = table.Column<int>(type: "integer", nullable: false)
                                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                            Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                            Details = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                            Price = table.Column<int>(type: "integer", nullable: false)
                        },
                    constraints: table =>
                        {
                            table.PrimaryKey("PK_ProtuctDb", x => x.Id);
                        });
            }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProtuctDb");
        }
    }
}
