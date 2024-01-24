using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.ConfirmaPagamento
{
    [SwaggerSchema(Required = new[] { "pagamentoId" })]
    public class ConfirmaPagamentoResponse
    {
        /// <summary>
        /// Id do pagamento
        /// </summary>
        /// <example>c37b8f54-9a67-45c9-90b3-1f34641578d8</example>
        [SwaggerSchema(Nullable = false)]
        public Guid PagamentoId { get; set; }

        [SwaggerSchema(Nullable = false)]
        public Boolean pagamentoProcessado { get; set; }
    }
}
