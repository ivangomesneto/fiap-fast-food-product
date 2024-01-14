using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Pagamentos.ConsultaPagamento
{
    public class ConsultaPagamentoResponse
    {
        public ConsultaPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
