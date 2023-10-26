using FourSix.Domain.Entities.PedidoAggregate;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pedidos.AlteraStatusPedido
{
    [SwaggerSchema(Required = new[] { "IdPedido", "StatusId", "DataStatus"})]
    public class AlteraStatusPedidoRequest
    {
        /// <summary>
        /// Id do Pedido
        /// </summary>
        /// <example>9b084d56-9d07-4060-87f2-9e053af42189</example>
        [SwaggerSchema(Nullable = false)]
        public Guid PedidoId { get; set; }

        /// <summary>
        /// Id do Status
        /// </summary>
        /// <example>2</example>
        [SwaggerSchema(Nullable = true)]
        public EnumStatusPedido StatusId { get; set; }

        /// <summary>
        /// Data do Status
        /// </summary>
        /// <example>2023-10-30T18:00</example>
        [SwaggerSchema(Nullable = false)]
        public DateTime DataStatus { get; set; }
    }
}
