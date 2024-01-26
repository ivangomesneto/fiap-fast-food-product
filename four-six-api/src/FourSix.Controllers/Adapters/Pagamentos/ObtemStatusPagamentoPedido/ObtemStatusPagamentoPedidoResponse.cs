using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Controllers.Adapters.Pagamentos.ObtemStatusPagamentoPedido
{
    public class ObtemStatusPagamentoPedidoResponse
    {
        public ObtemStatusPagamentoPedidoResponse(StatusPagamento statusPagamento) => StatusPagamento = statusPagamento;
        public StatusPagamento StatusPagamento { get; }
    }
}
