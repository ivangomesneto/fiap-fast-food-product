using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Controllers.Adapters.Pagamentos.ObtemStatusPagamentoPedido
{
    public class ObtemStatusPagamentoPedidoResponse
    {
        public ObtemStatusPagamentoPedidoResponse(EnumStatusPagamento enumStatusPagamento) => StatusPagamento = enumStatusPagamento;
        public EnumStatusPagamento StatusPagamento { get; }
    }
}
