using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Pagamentos.NegaPagamento
{
    public class NegaPagamentoResponse
    {
        public NegaPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
