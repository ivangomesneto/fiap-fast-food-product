using FourSix.Domain.Entities.PagamentoAggregate;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.UseCases.UseCases.Pagamentos.WebhookPagamento
{

    [SwaggerSchema(Required = new[] { "statusId" })]
    public class WebHookPagamentRequest
    {

        public EnumStatusPagamento statusId { get; set; }

        }
    }
