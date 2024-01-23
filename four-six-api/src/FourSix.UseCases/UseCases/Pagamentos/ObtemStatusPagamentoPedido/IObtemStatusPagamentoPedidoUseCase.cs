using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido
{
    public interface IObtemStatusPagamentoPedidoUseCase
    {
        Task<Pagamento> Execute(Guid pedidoId);
    }
}
