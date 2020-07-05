using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIo.NerdStore.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Imagem = table.Column<string>(type: "varchar(250)", nullable: false),
                    QuantidadeEstoque = table.Column<int>(nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: true),
                    Largura = table.Column<int>(type: "int", nullable: true),
                    Profundidade = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Codigo", "Nome" },
                values: new object[] { new Guid("f28c3329-75ab-4b73-b5e4-585bbc927259"), 102, "Adesivos" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Codigo", "Nome" },
                values: new object[] { new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"), 100, "Camisetas" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Codigo", "Nome" },
                values: new object[] { new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"), 101, "Canecas" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "CategoriaId", "DataCadastro", "Descricao", "Imagem", "Nome", "QuantidadeEstoque", "Valor", "Altura", "Largura", "Profundidade" },
                values: new object[,]
                {
                    { new Guid("c21bbe90-1553-4096-86cb-37eddb612449"), true, new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"), new DateTime(2020, 7, 4, 16, 1, 56, 542, DateTimeKind.Local).AddTicks(8100), "Camiseta 100% algodão", "camiseta2.jpg", "Camiseta Code life preta", 0, 90m, 5, 5, 5 },
                    { new Guid("64d3bd9c-f59e-4d30-9ce4-37b3f1f8be79"), true, new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"), new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5650), "Camiseta 100% algodão", "camiseta4.jpg", "Camiseta Debug", 0, 110m, 5, 5, 5 },
                    { new Guid("6f01cdaf-efcd-43ad-af23-13075155c2dd"), true, new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"), new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5670), "Camiseta 100% algodão", "camiseta3.jpg", "Camiseta Code life branca", 0, 80m, 5, 5, 5 },
                    { new Guid("f4cd1c0b-06aa-487a-bd2b-bfbfdcbd903a"), true, new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"), new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5700), "Camiseta 100% algodão", "camiseta1.jpg", "Camiseta Software", 0, 80m, 5, 5, 5 },
                    { new Guid("cdff447b-749a-46f0-be02-71853fbadd64"), true, new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"), new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5410), "Caneca de porcelana", "caneca4.jpg", "Caneca no coffe no code", 0, 10m, 12, 8, 5 },
                    { new Guid("dc1d7b5e-f54e-481b-a20a-332e7f7f3c70"), true, new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"), new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5680), "Caneca de porcelana", "caneca1.jpg", "Caneca Star bucks", 0, 20m, 12, 8, 5 },
                    { new Guid("d58bff42-99ae-4a0b-9790-c4f5f8ce24fe"), true, new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"), new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5690), "Caneca de porcelana", "caneca2.jpg", "Caneca Prgramador", 0, 20m, 12, 8, 5 },
                    { new Guid("a781fc58-1b2e-42a5-b4fa-84f0df30a9eb"), true, new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"), new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5720), "Caneca de porcelana", "caneca3.jpg", "Caneca Turn code", 0, 20m, 12, 8, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
