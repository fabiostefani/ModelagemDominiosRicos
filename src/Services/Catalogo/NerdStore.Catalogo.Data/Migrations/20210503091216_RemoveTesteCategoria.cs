using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Data.Migrations
{
    public partial class RemoveTesteCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teste",
                table: "Categorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Teste",
                table: "Categorias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
