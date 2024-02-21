using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTec02EISG.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfesorId",
                table: "Carreras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfesorId",
                table: "Carreras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
