using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.GeraQRCode
{
    [SwaggerSchema(Required = new[] { "pedidoId", "valorPedido" })]
    public class GeraQRCodeRequest
    {
        /// <summary>
        /// Id do pedido
        /// </summary>
        /// <example>c37b8f54-9a67-45c9-90b3-1f34641578d8</example>
        [SwaggerSchema(Nullable = false)]
        public Guid PedidoId { get; set; }

        /// <summary>
        /// Valor do pedido
        /// </summary>
        /// <example>23.59</example>
        [SwaggerSchema(Nullable = false)]
        public decimal ValorPedido { get; set; }
    }
}
