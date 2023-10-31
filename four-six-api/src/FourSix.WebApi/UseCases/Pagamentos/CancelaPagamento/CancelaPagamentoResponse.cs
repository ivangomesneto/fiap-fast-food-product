using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Pagamentos.CancelaPagamento
{
    public class CancelaPagamentoResponse
    {
        public CancelaPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
