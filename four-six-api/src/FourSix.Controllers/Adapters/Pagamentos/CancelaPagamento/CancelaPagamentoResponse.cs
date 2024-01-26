using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Pagamentos.CancelaPagamento
{
    public class CancelaPagamentoResponse
    {
        public CancelaPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
