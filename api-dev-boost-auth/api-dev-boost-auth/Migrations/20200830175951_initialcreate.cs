using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_dev_boost_auth.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApontamentoHoras",
                columns: table => new
                {
                    ApontamentoHorasId = table.Column<Guid>(nullable: false),
                    IdentificadorFuncionario = table.Column<string>(nullable: false),
                    Mes = table.Column<int>(nullable: false),
                    HorasTrabalhadas = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApontamentoHoras", x => x.ApontamentoHorasId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApontamentoHoras",
                columns: new[] { "ApontamentoHorasId", "HorasTrabalhadas", "IdentificadorFuncionario", "Mes" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 50.0, "Funcionario 1", 4 },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 168.0, "Funcionario 1", 5 }
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96a1834b-5907-4a02-915c-c7c030f5834f", "51622cda-b7e5-4a80-b358-a6c4250f106b", "Manager", "MANAGER" },
                    { "4ce20842-6b7a-4aad-b477-7d793c9dcdc4", "964aec30-e986-46b9-8e54-3e57bd3ebdb5", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApontamentoHoras");

            migrationBuilder.DropTable(
                name: "IdentityRole");
        }
    }
}
