using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCEntity.Migrations
{
    public partial class ClientesRemovendoCPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Clientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
