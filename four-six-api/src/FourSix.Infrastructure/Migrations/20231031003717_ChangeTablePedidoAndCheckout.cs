using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FourSix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTablePedidoAndCheckout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoCheckout",
                table: "PedidoCheckout");

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("1cf5d22d-05bf-45cb-ad1f-88a33a67bc72"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("26000029-db74-4ebe-b1c1-fc8f51399198"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("3c5b9af5-1ece-41b8-9e32-e0ba5ad69204"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("4fc64b86-b4a9-43af-9bee-559c6be8e880"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("5931d83f-5fbb-46b3-9810-52e629683f3d"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("86c25981-e16b-456b-9ca1-462bc9a6df81"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("9c317f77-3939-4365-a500-3bfc627716e0"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("abbdc726-4da0-4ac2-ba13-8c42dc47b4f3"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("c68a1fee-ccdc-498c-9d09-4275dfc13038"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("ff7d515d-101f-4a0a-9531-0498d971fef1"));

            migrationBuilder.AddColumn<int>(
                name: "Sequencia",
                table: "PedidoCheckout",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "Pedido",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoCheckout",
                table: "PedidoCheckout",
                columns: new[] { "PedidoId", "Sequencia" });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Ativo", "Categoria", "Descricao", "Nome", "Preco" },
                values: new object[,]
                {
                    { new Guid("16bc2ff9-29a2-4c87-bb12-058403a890dd"), true, 3, "Suco Natural de Laranja 500ml", "Suco Natural de Laranja", 10m },
                    { new Guid("325232a3-c774-4b84-9365-98e627d5931c"), true, 1, "Batata Frita especial", "Batata Frita", 6.50m },
                    { new Guid("3e3d5157-cc8d-4e43-bfc5-a38be81c32b4"), true, 2, "Bolo de chocolate com recheio de creme de morango", "Bolo Sensação", 3.25m },
                    { new Guid("5ad61401-de6f-4da5-bf59-b1cffb7869da"), true, 3, "H2O 500ml", "H2O", 8.25m },
                    { new Guid("7504fb29-0736-4056-a087-f06342fb2724"), true, 0, "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL", "Burguer FourSix", 10m },
                    { new Guid("8136fb3a-ef84-462d-87dc-d1d3908444aa"), true, 3, "Coca-cola 600ml", "Coca-cola", 8.25m },
                    { new Guid("bcfe82a9-8de7-47c1-96f3-228c88e9bd4e"), true, 0, "Pão, carne, queijo, alface, tomate e maionese ESPECIAL", "Burguer Six", 7.5m },
                    { new Guid("bf9bc451-e52d-4dcd-a196-22251d425fef"), true, 2, "Casquinha de sorvete de baunilha", "Sorvete de Baunilha", 1.25m },
                    { new Guid("c7492e38-4af0-4c54-8899-05993a3a68d6"), true, 1, "Cebola empanada especial", "Onion", 8.25m },
                    { new Guid("f60eb498-d6d6-4042-9775-9208fd1032d3"), true, 0, "Pão, carne, alface, tomate e maionese ESPECIAL", "Burger Four", 5.5m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoCheckout",
                table: "PedidoCheckout");

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("16bc2ff9-29a2-4c87-bb12-058403a890dd"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("325232a3-c774-4b84-9365-98e627d5931c"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("3e3d5157-cc8d-4e43-bfc5-a38be81c32b4"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("5ad61401-de6f-4da5-bf59-b1cffb7869da"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("7504fb29-0736-4056-a087-f06342fb2724"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("8136fb3a-ef84-462d-87dc-d1d3908444aa"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("bcfe82a9-8de7-47c1-96f3-228c88e9bd4e"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("bf9bc451-e52d-4dcd-a196-22251d425fef"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("c7492e38-4af0-4c54-8899-05993a3a68d6"));

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("f60eb498-d6d6-4042-9775-9208fd1032d3"));

            migrationBuilder.DropColumn(
                name: "Sequencia",
                table: "PedidoCheckout");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "Pedido",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoCheckout",
                table: "PedidoCheckout",
                columns: new[] { "PedidoId", "StatusId" });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Ativo", "Categoria", "Descricao", "Nome", "Preco" },
                values: new object[,]
                {
                    { new Guid("1cf5d22d-05bf-45cb-ad1f-88a33a67bc72"), true, 3, "Suco Natural de Laranja 500ml", "Suco Natural de Laranja", 10m },
                    { new Guid("26000029-db74-4ebe-b1c1-fc8f51399198"), true, 1, "Batata Frita especial", "Batata Frita", 6.50m },
                    { new Guid("3c5b9af5-1ece-41b8-9e32-e0ba5ad69204"), true, 0, "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL", "Burguer FourSix", 10m },
                    { new Guid("4fc64b86-b4a9-43af-9bee-559c6be8e880"), true, 0, "Pão, carne, queijo, alface, tomate e maionese ESPECIAL", "Burguer Six", 7.5m },
                    { new Guid("5931d83f-5fbb-46b3-9810-52e629683f3d"), true, 2, "Bolo de chocolate com recheio de creme de morango", "Bolo Sensação", 3.25m },
                    { new Guid("86c25981-e16b-456b-9ca1-462bc9a6df81"), true, 0, "Pão, carne, alface, tomate e maionese ESPECIAL", "Burger Four", 5.5m },
                    { new Guid("9c317f77-3939-4365-a500-3bfc627716e0"), true, 2, "Casquinha de sorvete de baunilha", "Sorvete de Baunilha", 1.25m },
                    { new Guid("abbdc726-4da0-4ac2-ba13-8c42dc47b4f3"), true, 1, "Cebola empanada especial", "Onion", 8.25m },
                    { new Guid("c68a1fee-ccdc-498c-9d09-4275dfc13038"), true, 3, "H2O 500ml", "H2O", 8.25m },
                    { new Guid("ff7d515d-101f-4a0a-9531-0498d971fef1"), true, 3, "Coca-cola 600ml", "Coca-cola", 8.25m }
                });
        }
    }
}
