using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Pagamentos.NegaPagamento
{
    public class NegaPagamentoResponse
    {
        public NegaPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
