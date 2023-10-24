using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pedidos.NovoPedido
{
    [SwaggerSchema(Required = new[] { "numeroPedido", "clienteId", "dataPedido" })]
    public class NovoPedidoRequest
    {
        /// <summary>
        /// Número do Pedido
        /// </summary>
        /// <example>12354</example>
        [SwaggerSchema(Nullable = false)]
        public string NumeroPedido { get; set; }
        /// <summary>
        /// Data do Pedido
        /// </summary>
        /// <example>2023-10-24T18:00</example>
        [SwaggerSchema(Nullable = false)]
        public DateTime DataPedido { get; set; }
        /// <summary>
        /// Id do Cliente
        /// </summary>
        /// <example>9b084d56-9d07-4060-87f2-9e053af42189</example>
        [SwaggerSchema(Nullable = true)]
        public Guid? ClienteId { get; set; }
    }
}
