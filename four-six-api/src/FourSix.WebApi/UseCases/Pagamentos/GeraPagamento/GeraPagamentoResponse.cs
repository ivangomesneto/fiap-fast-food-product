using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Pagamentos.GeraPagamento
{
    public class GeraPagamentoResponse
    {
        public GeraPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
