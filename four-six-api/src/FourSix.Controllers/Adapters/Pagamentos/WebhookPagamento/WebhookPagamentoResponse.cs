using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Pagamentos.WebhookPagamento
{
    public class WebhookPagamentoResponse
    {
        public WebhookPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
