using FourSix.Controllers.Adapters.Pagamentos.RealizaPagamento;
using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Pagamentos.RealizaPagamento;
using FourSix.UseCases.UseCases.Pagamentos.WebhookPagamento;

namespace FourSix.Controllers.Adapters.Pagamentos.WebhookPagamento
{
    public class WebhookPagamentoAdapter : IWebhookPagamentoAdapter
    {
        private readonly Notification _notification;

        private readonly IWebhookPagamentoUseCase _useCase;

        public WebhookPagamentoAdapter(Notification notification,
            IWebhookPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        public async Task<WebhookPagamentoResponse> process(WebHookPagamentRequest request, Guid pagamentoId)
        {
            var model = new PagamentoModel(await _useCase.Execute(pagamentoId, request.statusId));

            return new WebhookPagamentoResponse(model);
        }
    }
}
