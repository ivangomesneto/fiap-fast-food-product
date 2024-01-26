using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Pagamentos.RealizaPagamento
{
    public class RealizaPagamentoResponse
    {
        public RealizaPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
