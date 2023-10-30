using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FourSix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixPedidoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("7686debb-92c2-4d89-a669-8988da8e8c72"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("947e3d62-26fa-4ba6-8395-39c259fc43ec"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("a0d0225e-0f3c-42ff-935d-beb44bb2cac4"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("a45a3af2-17db-459f-867a-b0c2e1261dc0"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("c2a49da0-6bc2-4cdc-be77-97d0284b8c92"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("c55a9ca7-411d-4245-8b91-1efbc30f7a9b"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("d23c72b6-0bbe-4e0d-a46e-b8d72da5e9ef"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("ea5df339-afd7-41b6-a4ab-44979c1d919d"));

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "PedidoItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Ativo", "Categoria", "Descricao", "Nome", "Preco" },
                values: new object[,]
                {
                    { new Guid("18a977bd-54e2-4391-86e2-038ad6c72157"), true, 0, "Pão, carne, queijo, alface, tomate e maionese ESPECIAL", "Burguer Six", 7.5m },
                    { new Guid("21da57d4-4cfd-4831-a892-4c3eb79a18d1"), true, 1, "Batata Frita especial", "Batata Frita", 6.50m },
                    { new Guid("30425653-ca46-4b60-ab3b-2726cc52deff"), true, 2, "Bolo de chocolate com recheio de creme de morango", "Bolo Sensação", 3.25m },
                    { new Guid("34e39816-b398-48ec-b20a-a9994f61d9d5"), true, 2, "Casquinha de sorvete de baunilha", "Sorvete de Baunilha", 1.25m },
                    { new Guid("3d1b783b-d184-4827-8bd4-f2a06dc697c0"), true, 3, "Suco Natural de Laranja 500ml", "Suco Natural de Laranja", 10m },
                    { new Guid("4250a8cb-78de-4260-b749-f9cb75e2b543"), true, 0, "Pão, carne, alface, tomate e maionese ESPECIAL", "Burger Four", 5.5m },
                    { new Guid("49cf5138-8b2e-4e2f-9dbf-fe8a694ad327"), true, 3, "H2O 500ml", "H2O", 8.25m },
                    { new Guid("c14888c9-ed90-43dc-a695-41612beb258c"), true, 0, "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL", "Burguer FourSix", 10m },
                    { new Guid("efaa0b05-5a6e-4a3e-9b00-f5f61613616d"), true, 3, "Coca-cola 600ml", "Coca-cola", 8.25m },
                    { new Guid("fbeb1955-cafd-4737-a958-c7582aa95990"), true, 1, "Cebola empanada especial", "Onion", 8.25m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("18a977bd-54e2-4391-86e2-038ad6c72157"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("21da57d4-4cfd-4831-a892-4c3eb79a18d1"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("30425653-ca46-4b60-ab3b-2726cc52deff"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("34e39816-b398-48ec-b20a-a9994f61d9d5"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("3d1b783b-d184-4827-8bd4-f2a06dc697c0"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("4250a8cb-78de-4260-b749-f9cb75e2b543"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("49cf5138-8b2e-4e2f-9dbf-fe8a694ad327"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("c14888c9-ed90-43dc-a695-41612beb258c"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("efaa0b05-5a6e-4a3e-9b00-f5f61613616d"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("fbeb1955-cafd-4737-a958-c7582aa95990"));

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "PedidoItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Ativo", "Categoria", "Descricao", "Nome", "Preco" },
                values: new object[,]
                {
                    { new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"), true, 3, "H2O 500ml", "H2O", 8.25m },
                    { new Guid("7686debb-92c2-4d89-a669-8988da8e8c72"), true, 2, "Casquinha de sorvete de baunilha", "Sorvete de Baunilha", 1.25m },
                    { new Guid("947e3d62-26fa-4ba6-8395-39c259fc43ec"), true, 0, "Pão, carne, alface, tomate e maionese ESPECIAL", "Burger Four", 5.5m },
                    { new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"), true, 3, "Suco Natural de Laranja 500ml", "Suco Natural de Laranja", 10m },
                    { new Guid("a0d0225e-0f3c-42ff-935d-beb44bb2cac4"), true, 3, "Coca-cola 600ml", "Coca-cola", 8.25m },
                    { new Guid("a45a3af2-17db-459f-867a-b0c2e1261dc0"), true, 0, "Pão, carne, queijo, alface, tomate e maionese ESPECIAL", "Burguer Six", 7.5m },
                    { new Guid("c2a49da0-6bc2-4cdc-be77-97d0284b8c92"), true, 1, "Cebola empanada especial", "Onion", 8.25m },
                    { new Guid("c55a9ca7-411d-4245-8b91-1efbc30f7a9b"), true, 1, "Batata Frita especial", "Batata Frita", 6.50m },
                    { new Guid("d23c72b6-0bbe-4e0d-a46e-b8d72da5e9ef"), true, 0, "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL", "Burguer FourSix", 10m },
                    { new Guid("ea5df339-afd7-41b6-a4ab-44979c1d919d"), true, 2, "Bolo de chocolate com recheio de creme de morango", "Bolo Sensação", 3.25m }
                });
        }
    }
}
