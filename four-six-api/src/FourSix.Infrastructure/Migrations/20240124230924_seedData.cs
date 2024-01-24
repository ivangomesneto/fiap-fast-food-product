using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourSix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: new Guid("78e3b8d0-be9a-4407-9304-c61788797808"),
                column: "DataPedido",
                value: new DateTime(2024, 1, 24, 15, 9, 24, 251, DateTimeKind.Local).AddTicks(2926));

            migrationBuilder.UpdateData(
                table: "PedidoCheckout",
                keyColumns: new[] { "PedidoId", "Sequencia" },
                keyValues: new object[] { new Guid("78e3b8d0-be9a-4407-9304-c61788797808"), 0 },
                column: "DataStatus",
                value: new DateTime(2024, 1, 24, 15, 9, 24, 251, DateTimeKind.Local).AddTicks(2926));

            migrationBuilder.InsertData(
                table: "StatusPagamento",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { (short)4, "Negado" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatusPagamento",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: new Guid("78e3b8d0-be9a-4407-9304-c61788797808"),
                column: "DataPedido",
                value: new DateTime(2023, 10, 30, 19, 26, 39, 762, DateTimeKind.Local).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "PedidoCheckout",
                keyColumns: new[] { "PedidoId", "Sequencia" },
                keyValues: new object[] { new Guid("78e3b8d0-be9a-4407-9304-c61788797808"), 0 },
                column: "DataStatus",
                value: new DateTime(2023, 10, 30, 19, 26, 39, 762, DateTimeKind.Local).AddTicks(4023));
        }
    }
}
