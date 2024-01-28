using FourSix.Domain.Entities.PagamentoAggregate;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento
{
    [SwaggerSchema(Required = new[] { "statusId" })]
    public class AlteraStatusPagamentRequest
    {
        /// <summary>
        /// Novo status do pagamento
        /// </summary>
        /// <example>Pago</example>
        public EnumStatusPagamento StatusId { get; set; }

        /// <summary>
        /// Valor pago
        /// </summary>
        /// <example>47.15</example>
        public decimal? ValorPago { get; set; }
    }
}
