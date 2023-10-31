using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Pagamentos.RealizaPagamento
{
    public class RealizaPagamentoResponse
    {
        public RealizaPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
