using FourSix.Controllers.Adapters.Pagamentos.RealizaPagamento;
using FourSix.UseCases.UseCases.Pagamentos.WebhookPagamento;

namespace FourSix.Controllers.Adapters.Pagamentos.WebhookPagamento
{
    public interface IWebhookPagamentoAdapter
    {
        Task<WebhookPagamentoResponse> process(WebHookPagamentRequest request, Guid pagamentoId);
    }
}
